using SayWa.Entities;
using SayWa.Entities.Query;
using SayWa.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Business
{
    public class PositionBll : BaseBllExtend<Position>
    {
        private PositionService _service;

        public PositionBll(PositionService service, IDatabase cache):base(service,"position",cache)
        {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Position> Query(PositionQuery query)
        {
            return _service.Query(query);
        }
    }
}
