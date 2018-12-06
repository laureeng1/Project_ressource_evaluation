using System;
using System.Threading.Tasks;

namespace EVALUATION.WEB
{
    public interface ITCache<T>
    {
        Task<T> Get(string cacheKeyName, int cacheTimeOutSeconds, Func<Task<T>> func);
    }  
}