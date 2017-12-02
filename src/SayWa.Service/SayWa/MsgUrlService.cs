using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class MsgUrlService : BaseService<MsgUrl>
    {
        private string _tbName = "tb_MsgUrl";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public MsgUrlService(ConnectionFactory connFactory) : base(connFactory, "tb_MsgUrl", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(MsgUrl model, string sql = "")
        {
            sql = @"INSERT INTO [tb_msgUrl] ( [msgId] ,[type] ,[url] )
                                     VALUES (@msgId,@type,@url)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(MsgUrl model, string sql = "")
        {
            return 0;
        }

    }
}