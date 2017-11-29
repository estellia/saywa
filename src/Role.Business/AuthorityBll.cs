using Role.Entities;
using Role.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Role.Entities.Common;
using Role.Entities.Query;
using Microsoft.Extensions.Options;

namespace Role.Business
{
    public class AuthorityBll: BaseBllExtend<Authority>
    {
        private AuthorityService _service;        

        public AuthorityBll(AuthorityService service,
            IDatabase cache, IOptions<SysConfig> config) :base(service,"authority",cache,config)
        {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public  List<Authority> Query(AuthorityQuery query)
        {
            return _service.Query(query);
        }              
    }
}
