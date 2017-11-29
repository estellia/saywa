using Role.Entities.Common;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Business
{
    public static class RedisHelper
    {
        /// <summary>
        /// 扩展 获取redis 的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static T Get<T>(this IDatabase cache, string cacheKey)
        {
            try
            {
                var str = cache.StringGet(cacheKey);
                if (!string.IsNullOrWhiteSpace(str))
                {
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
                    return result;
                }
                return default(T);
            }
            catch (Exception)
            {
                return default(T);
            }

        }

        /// <summary>
        /// 写缓存
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="expiry"></param>
        public static void SetObj<T>(this IDatabase cache, string cacheKey, T obj, TimeSpan? expiry=null)
        {
            if (!expiry.HasValue) expiry = new TimeSpan(1, 0, 0, 0);
            try
            {
                var result = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                cache.StringSet(cacheKey, result, expiry.Value);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
