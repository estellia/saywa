using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Service
{
    public class RelationService : BaseService<Relation>
    {
        private string _tbName = "tb_relation";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public RelationService(ConnectionFactory connFactory) : base(connFactory, "tb_relation", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Relation model, string sql = "")
        {
            sql = @"INSERT INTO [tb_relation] ([name] ,[isMaster]  )
                                       VALUES (@name,@isMaster)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Relation model, string sql = "")
        {
            sql = @"update [tb_relation] set 
                    [name] = @name,
                    [isMaster] = @isMaster
                   where Id = @Id";
            return base.Update(model, sql);
        }

    }
}