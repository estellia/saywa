using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class FamilyUserService : BaseService<FamilyUser>
    {
        private string _tbName = "tb_familyUser";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public FamilyUserService(ConnectionFactory connFactory) : base(connFactory, "tb_familyUser", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(FamilyUser model, string sql = "")
        {
            sql = @"INSERT INTO [tb_familyUser] ([familyId] ,[userId] ,[relationId] ,[relationName] ,[relationNickName] ,
                                                 [ischecked] ,[status] ) 
                                        VALUES (@familyId,@userId,@relationId,@relationName,@relationNickName,
                                                @ischecked,s@tatus)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(FamilyUser model, string sql = "")
        {
            sql = @"update  [tb_familyUser] set 
                            [familyId] = @familyId,
                            [userId] = @userId,
                            [relationId] = @relationId,
                            [relationName] = @relationName,
                            [relationNickName] = @relationNickName,
                            [ischecked] = @ischecked,
                            [status] = @status
                      where [id] = @id";
            return base.Update(model, sql);
        }


    }
}