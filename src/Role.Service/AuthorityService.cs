using Role.Entities;
using Dapper;
using Role.Entities.Query;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Role.Service
{
    public class AuthorityService: BaseService<Authority>
    {
        //private string _tbName = "tb_Authority";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public AuthorityService(ConnectionFactory connFactory) :base(connFactory, "tb_Authority")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Authority model,string sql="")
        {
            sql = @"INSERT INTO tb_authority (AuthorityName) VALUES (?AuthorityName)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Authority model, string sql="")
        {
            sql = @"update tb_authority set AuthorityName = ?AuthorityName where Id = ?Id";
            return base.Update(model, sql);
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="search"></param>
        internal override void InitQueryParam(StringBuilder sb, QueryBase query)
        {
            var search = query as AuthorityQuery;
            if (search.IsDelete.HasValue)
            {
                sb.Append(" and isDelete=?IsDelete");
            }
            return;
        }       
    }
}
