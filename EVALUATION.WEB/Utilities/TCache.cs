using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EVALUATION.WEB
{
    public class TCache<T>
    {
        public Task<T> Get(string cacheKeyName, int cacheTimeOutSeconds, 
            Func<Task<T>> func)
        {
            return new TCacheInternal<T>().Get(
                cacheKeyName,cacheTimeOutSeconds,func);
        }

        //public T Get(string cacheKeyName, int cacheTimeOutSeconds,
        //    Func<T> func)
        //{
        //    return new TCacheInternal<T>().Get(
        //        cacheKeyName, cacheTimeOutSeconds, func);
        //}
    }
}