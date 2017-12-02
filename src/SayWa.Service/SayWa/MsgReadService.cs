using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class MsgReadService : BaseService<MsgRead>
    {
        private string _tbName = "tb_MsgRead";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public MsgReadService(ConnectionFactory connFactory) : base(connFactory, "tb_MsgRead", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(MsgRead model, string sql = "")
        {
            sql = @"INSERT INTO [tb_msgRead] ([msgId] ,[msgCreateUser] ,[isRead] ) 
                          VALUES(@msgId, @msgCreateUser,@isRead)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(MsgRead model, string sql = "")
        {
            sql = @"update [tb_msgRead] set 
                            [msgId] = @msgId,
                            [msgCreateUser] = @msgCreateUser,
                            [isRead] = @isRead where @id= id";
            return base.Update(model, sql);
        }

    }
}