using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SayWa.Entities.Query;
using System.Text;
using SayWa.Entities.Query;

namespace SayWa.Service
{
    public class BaseService<T>
    {
        private ConnectionFactory _connFactory;
        private string _tbName = "";

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="connFactory"></param>
        public BaseService(ConnectionFactory connFactory,string tabName)
        {
            _connFactory = connFactory;
            _tbName = tabName;
        }

        public ConnectionFactory ConnectFactory
        {
            get { return _connFactory; }
        }

        /// <summary>
        /// GetModel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public virtual T GetModel(long id)
        {
            var sql = string.Format("select * from {0} where id={1}", _tbName, id);
            using(var conn = _connFactory.GetMySqlConn())
            {
                var m = conn.QueryFirstOrDefault<T>(sql);
                conn.Dispose();
                return m;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public virtual int Delete(long id)
        {
            var sql = string.Format("delete from {0} where id={1}", _tbName, id);
            using (var conn = _connFactory.GetMySqlConn())
            {
                var cnt = conn.Execute(sql);
                conn.Dispose();
                return cnt;               
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual long Add(T model,string sql)
        {
            if (string.IsNullOrEmpty(sql)) return 0;
            sql += @"; select last_insert_id();";
            using (var conn = _connFactory.GetMySqlConn())
            {
                var id = conn.ExecuteScalar(sql,model);
                conn.Dispose();
                if (id == null) return 0;
                return long.Parse(id.ToString());
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">修改</param>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public virtual int Update(T model, string sql)
        {
            if (string.IsNullOrEmpty(sql)) return 0;
            using (var conn = _connFactory.GetMySqlConn())
            {
                var cnt = conn.Execute(sql, model);
                conn.Dispose();
                return cnt;
            }
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual int DeleteLogic(long id)
        {
            var sql = string.Format("update {0} set isDelete=1 where id={1}", _tbName, id);
            using (var conn = _connFactory.GetMySqlConn())
            {
                var cnt = conn.Execute(sql);
                conn.Dispose();
                return cnt;
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual List<T> Query(QueryBase search)
        {
            var sql = new StringBuilder("select {0} from "+_tbName+" where 1=1 ");
            InitQueryParam(sql, search);
            if (search.IsNeedTotal)
            {
                QueryCnt(sql, search);
                if (search.totalCnt <= 0) return new List<T>();
            }
            return QueryList(sql, search);
        }

        /// <summary>
        /// 查询记录数量
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        public virtual int QueryCnt(StringBuilder sb, QueryBase search)
        {
            var sql = string.Format(sb.ToString(), "count(*)");
            using (var conn = ConnectFactory.GetMySqlConn())
            {
                var cnt = conn.QueryFirst<int>(sql, search);
                conn.Dispose();
                search.totalCnt = cnt;
                return cnt;
            }
        }

        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="search"></param>
        internal virtual void InitQueryParam(StringBuilder sb, QueryBase search)
        {
            return;
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        protected List<T> QueryList(StringBuilder sb, QueryBase search)
        {
            if (!search.page.HasValue || search.page.Value <= 0) search.page = 1;
            if (!search.pageSize.HasValue || search.pageSize.Value <= 0) search.page = 20;
            if (string.IsNullOrEmpty(search.Orderby)) search.Orderby = " id desc";
            sb.AppendFormat(" order by {0}  LIMIT {1},{2} ", search.Orderby, (search.page.Value - 1) * search.pageSize.Value, search.pageSize.Value);
            var sql = string.Format(sb.ToString(), "*");
            using (var conn = ConnectFactory.GetMySqlConn())
            {
                var lst = conn.Query<T>(sql.ToString(), search);
                conn.Dispose();
                if (lst == null) return new List<T>();
                return lst.ToList();
            }
        }

    }
}
