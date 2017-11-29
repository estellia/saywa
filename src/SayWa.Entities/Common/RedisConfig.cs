using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Entities.Common
{
    public class RedisConfig
    {
        public static string GetKey(string cls,string type="list",string id = "")
        {
            return string.Format("roles_{0}_{1}_{2}",cls,type,id);
        }
    }
}
