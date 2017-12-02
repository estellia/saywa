using Dapper;
using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class PositionRoleService : BaseService<PositionRoles>
    {
        private string _tbName = "tb_PositionRoles";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public PositionRoleService(ConnectionFactory connFactory) :base(connFactory, "tb_PositionRoles")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(PositionRoles model, string sql = "")
        {
            sql = @"INSERT INTO tb_positionroles ( 
                             PositionId , RoleId )
                        VALUES (?PositionId,?RoleId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(PositionRoles model, string sql = "")
        {
            sql = @"update tb_positionroles set 
                        PositionId = ?PositionId,
                        RoleId = ?RoleId where Id = ?Id";
            return base.Update(model, sql);
        }

        /// <summary>
        /// 查询职位权限列表
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public List<PositionRoles> GetList(long positionId)
        {
            var sql = string.Format("select * from tb_positionroles where positionId={0}", positionId);
            using (var conn = base.ConnectFactory.GetMySqlConn())
            {
                var lst = conn.Query<PositionRoles>(sql);
                conn.Dispose();
                if (lst == null) return new List<PositionRoles>();
                return lst.ToList();
            }
        }
    }
}
