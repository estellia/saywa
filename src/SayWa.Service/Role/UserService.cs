using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class UserService : BaseService<User>
    {
        private string _tbName = "tb_User";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public UserService(ConnectionFactory connFactory) :base(connFactory, "tb_User")
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(User model, string sql = "")
        {
            sql = @"INSERT INTO tb_User (UserName,DeparmentId,LoginId) VALUES (?UserName,?DeparmentId,?LoginId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(User model, string sql = "")
        {
            sql = @"update tb_User set UserName = ?UserName DeparmentId=?DeparmentId,LoginId=?LoginId where Id = ?Id";
            return base.Update(model, sql);
        }
    }
}
