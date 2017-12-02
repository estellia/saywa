using Dapper;
using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class LoginUserService : BaseService<LoginUser>
    {
        private string _tbName = "tb_loginUser";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public LoginUserService(ConnectionFactory connFactory) : base(connFactory, "tb_loginUser",1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(LoginUser model, string sql = "")
        {
            sql = @"INSERT INTO [tb_loginUser] ([wxCode] ,[userCode] ,[userName] ,[nickName] ,[pwd] , [gender] )
                         VALUES (@wxCode,@userCode,@userName,@nickName,@pwd,@gender)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(LoginUser model, string sql = "")
        {
            sql = @"update [tb_loginUser] set 
                    [userCode] = @userCode,
                    [userName] = @userName,
                    [nickName] = @nickName,
                    [pwd] = @pwd,
                    [gender] = @gender 
                    where Id = @Id";
            return base.Update(model, sql);
        }

    }
}
