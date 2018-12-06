using System;
using System.Collections.Generic;
using System.Web;
using EVALUATION.WEB.Models;
using System.Threading.Tasks;

namespace EVALUATION.WEB
{
    public class TCacheInternal<T> : ITCache<T>
    {
        internal static readonly object Locker = new object();

        public Task<T> Get(string cacheName,
            int cacheTimeOutSeconds,
            Func<Task<T>> func)
        {
            var obj = HttpContext.Current.Cache.Get(cacheName);
            if (obj != null)
            {
                return (Task<T>)obj;
            }

            lock (Locker)
            {
                obj = HttpContext.Current.Cache.Get(cacheName);
                if (obj == null)
                {
                    obj = func();
                    HttpContext.Current.Cache.Insert(cacheName, obj, null,
                        DateTime.Now.Add(new TimeSpan(0, 0, cacheTimeOutSeconds)),
                        TimeSpan.Zero);
                }
                return (Task<T>)obj;
            }
        }
    }
}