using Role.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Role.Entities.Query;
using System.Text;

namespace Role.Service
{
    public class DepartmentService : BaseService<Department>
    {
        private string _tbName = "tb_Department";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public DepartmentService(ConnectionFactory connFactory) :base(connFactory, "tb_Department")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Department model, string sql = "")
        {
            sql = @"INSERT INTO tb_Department (DepartmentName,ParentId) VALUES (?DepartmentName,?ParentId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Department model, string sql = "")
        {
            sql = @"update tb_Department set DepartmentName = ?DepartmentName ,ParentId=?ParentId where Id = ?Id";
            return base.Update(model, sql);
        }

        internal override void InitQueryParam(StringBuilder sb, QueryBase query)
        {            
            var search = query as DepartmentQuery;
            if (search.IsDelete.HasValue) sb.Append(" and isDelete=?IsDelete");
            if (search.ParentId.HasValue) sb.Append(" and ParentId=?ParentId");
            return;
        }
    }
}
