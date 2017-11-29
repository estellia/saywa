using Role.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Service
{
    public class PositionService : BaseService<Position>
    {
        private string _tbName = "tb_Position";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public PositionService(ConnectionFactory connFactory) :base(connFactory, "tb_Position")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Position model, string sql = "")
        {
            sql = @"INSERT INTO tb_Position (PositionName) VALUES (?PositionName)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Position model, string sql = "")
        {
            sql = @"update tb_Position set PositionName = ?PositionName where Id = ?Id";
            return base.Update(model, sql);
        }
    }
}
