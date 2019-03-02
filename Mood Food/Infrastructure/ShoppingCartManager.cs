using Mood_Food.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Infrastructure
{
    public class ShoppingCartManager
    {
        ISessionManager session;
        MoodFoodContext db;

        ShoppingCartManager(ISessionManager session, MoodFoodContext db)
        {
            this.session = session;
            this.db = db;
        }



    }
}