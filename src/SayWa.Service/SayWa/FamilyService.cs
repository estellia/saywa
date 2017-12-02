using SayWa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SayWa.Entities.Query;

namespace SayWa.Service
{
    public class FamilyService : BaseService<Family>
    {
        private string _tbName = "tb_family";
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public FamilyService(ConnectionFactory connFactory) : base(connFactory, "tb_family", 1)
        {
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override long Add(Family model, string sql = "")
        {
            sql = @"INSERT INTO [tb_family] ( [familyName] ,[createUserId] ) VALUES (@familyName,@createUserId)";
            return base.Add(model, sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public override int Update(Family model, string sql = "")
        {
            sql = @"update [tb_family] set 
                    [familyName] =@familyName where 
                    Id = @Id";
            return base.Update(model, sql);
        }


    }
}
