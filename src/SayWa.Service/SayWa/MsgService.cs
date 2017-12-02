using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class MsgService : BaseService<Msg>
    {
        private string _tbName = "tb_loginUser";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public MsgService(ConnectionFactory connFactory) : base(connFactory, "tb_loginUser",1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Msg model, string sql = "")
        {
            sql = @"INSERT INTO [tb_msg] ( [familyId] ,[createUser] ,[content] ,[parentId] )
                                  VALUES (@familyId,@createUser,@content,@isDelete,@parentId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Msg model, string sql = "")
        {
            sql = @"update [tb_msg] set 
                            [familyId] = @familyId,
                            [content] = @content,
                            [isDelete] = @isDelete,
                            [parentId] = @parentId 
                        where [id] = @id";
            return base.Update(model, sql);
        }

    }
}
