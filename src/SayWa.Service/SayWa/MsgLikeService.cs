using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class MsgLikeService : BaseService<MsgLike>
    {
        private string _tbName = "tb_MsgLike";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public MsgLikeService(ConnectionFactory connFactory) : base(connFactory, "tb_MsgLike", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(MsgLike model, string sql = "")
        {
            sql = @"INSERT INTO [tb_msgLike] ([msgId] ,[createUserId] ,[isDelete] ) 
                                      VALUES (@msgId,@createUserId,@isDelete)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(MsgLike model, string sql = "")
        {
            sql = @"update [tb_msgLike] set 
                           [isDelete] =@isDelete where @id= id";
            return base.Update(model, sql);
        }

    }
}