using SayWa.Business;
using SayWa.Entities;
using SayWa.Entities.Query;
using SayWa.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Business
{
    public class DepartmentBll : BaseBllExtend<Department>
    {
        private DepartmentService _service;

        public DepartmentBll(DepartmentService service, IDatabase cache):base(service,"department",cache)
        {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Department> Query(DepartmentQuery query)
        {
            return _service.Query(query);
        }
    }
}
