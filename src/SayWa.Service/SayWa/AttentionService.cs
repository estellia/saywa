using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class AttentionService : BaseService<Attention>
    {
        private string _tbName = "tb_attention";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public AttentionService(ConnectionFactory connFactory) : base(connFactory, "tb_attention", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Attention model, string sql = "")
        {
            sql = @"INSERT INTO [tb_attention] ([familyId] ,[userId] ,[isDelete] )
                                        VALUES (@familyId,@userId,isDelete)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Attention model, string sql = "")
        {
            sql = @"update [tb_attention] set 
                            [familyId] = @familyId,
                            [userId] = @userId,
                            [updateTime] = getdate(),
                            [isDelete] = @isDelete  
                            where Id = @Id";
            return base.Update(model, sql);
        }


    }
}