using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Mood_Food.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private HttpSessionState session;

        public SessionManager()
        {
            session = HttpContext.Current.Session;
        }

        public void Abbandon()
        {
            session.Abandon();
        }

        public T Get<T>(string key)
        {
            return (T)session[key];
        }

        public void Set<T>(string key, T value)
        {
            session[key] = value;
        }

        public T TryGet<T>(string key)
        {
            try
            {
                return (T)session[key];
            }
            catch (NullReferenceException)
            {

                return default(T);
            }
        }
    }
}