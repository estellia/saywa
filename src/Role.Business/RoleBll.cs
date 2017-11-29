using Role.Entities;
using Role.Entities.Query;
using Role.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Business
{
    public class RoleBll : BaseBllExtend<RolesTb>
    {
        private RoleService _service;

        public RoleBll(RoleService service, IDatabase cache):base(service,"role",cache)
        {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<RolesTb> Query(RolesQuery query)
        {
            return _service.Query(query);
        }

    }
}
