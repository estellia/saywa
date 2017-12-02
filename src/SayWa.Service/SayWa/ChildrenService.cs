using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class ChildrenService : BaseService<Children>
    {
        private string _tbName = "tb_children";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public ChildrenService(ConnectionFactory connFactory) : base(connFactory, "tb_children", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Children model, string sql = "")
        {
            sql = @"INSERT INTO [tb_children] ([name] ,[nickName] ,[gender] ,[birthday] ,[weight] ,[familyId] ,
                                               [createUser] )
                                        VALUES (@name,@nickName,@gender,@birthday,@weight,@familyId,@createUser)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Children model, string sql = "")
        {
            sql = @"update [tb_family] set 
                    [familyName] =@familyName 
                    where Id = @Id";
            return base.Update(model, sql);
        }


    }
}
