using SayWa.Entities;
using SayWa.Entities.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class RoleService : BaseService<RolesTb>
    {
        private string _tbName = "tb_Role";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public RoleService(ConnectionFactory connFactory) :base(connFactory, "tb_Role")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(RolesTb model, string sql = "")
        {
            sql = @"INSERT INTO tb_Role (RoleName) VALUES (?RoleName)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(RolesTb model, string sql = "")
        {
            sql = @"update tb_Role set RoleName = ?RoleName where Id = ?Id";
            return base.Update(model, sql);
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="search"></param>
        internal override void InitQueryParam(StringBuilder sb, QueryBase query)
        {
            var search = query as RolesQuery;
            if (search.IsDelete.HasValue)
            {
                sb.Append(" and isDelete=?IsDelete");
            }
            return;
        }
    }
}
