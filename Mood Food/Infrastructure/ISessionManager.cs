﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mood_Food.Infrastructure
{
   public interface ISessionManager
    {
        T Get<T>(string key);
        T TryGet<T>(string key);
        void Set<T>(string key, T value);
        void Abbandon();
    }
}
