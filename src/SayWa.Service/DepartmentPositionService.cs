using Dapper;
using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class DepartmentPositionService : BaseService<DepartmentPosition>
    {
        private string _tbName = "tb_DepartmentPosition";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public DepartmentPositionService(ConnectionFactory connFactory) :base(connFactory, "tb_DepartmentPosition")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(DepartmentPosition model, string sql = "")
        {
            sql = @"INSERT INTO tb_departmentposition ( 
                        DepartmentId ,
                        PositionId ) VALUES (?DepartmentId,?PositionId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(DepartmentPosition model, string sql = "")
        {
            sql = @"update tb_departmentposition set 
                            DepartmentId = @DepartmentId,
                            PositionId = @PositionId whereId = ?Id";
            return base.Update(model, sql);
        }

        /// <summary>
        /// 查询部门职位列表
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public List<DepartmentPosition> GetList(long departmentId)
        {
            var sql = string.Format("select * from tb_departmentposition where departmentId={0}", departmentId);
            using (var conn = base.ConnectFactory.GetMySqlConn())
            {
                var lst = conn.Query<DepartmentPosition>(sql);
                conn.Dispose();
                if (lst == null) return new List<DepartmentPosition>();
                return lst.ToList();
            }
        }
    }
}
