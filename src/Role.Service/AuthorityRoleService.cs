using Role.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Role.Service
{
    public class AuthorityRoleService : BaseService<AuthorityRole>
    {
        private string _tbName = "tb_AuthorityRole";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public AuthorityRoleService(ConnectionFactory connFactory) : base(connFactory, "tb_AuthorityRole")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(AuthorityRole model, string sql = "")
        {
            sql = @"INSERT INTO tb_authorityrole (RoleId ,AuthorityId ) VALUES (?RoleId,?AuthorityId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(AuthorityRole model, string sql = "")
        {
            sql = @"update tb_authorityrole set 
                    RoleId = ?RoleId,
                    AuthorityId = ?AuthorityId where Id = ?Id";
            return base.Update(model, sql);
        }

        /// <summary>
        /// 查询角色拥有的权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<AuthorityRole> GetList(long roleId)
        {
            var sql = string.Format("select * from tb_authorityrole where roleId={0}",roleId);
            using(var conn = base.ConnectFactory.GetMySqlConn())
            {
                var lst = conn.Query<AuthorityRole>(sql);
                conn.Dispose();
                if (lst == null) return new List<AuthorityRole>();
                return lst.ToList();
            }
        }
    }
}
