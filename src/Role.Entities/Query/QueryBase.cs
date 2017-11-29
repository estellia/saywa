using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Entities.Query
{

    /// <summary>
    /// 查询条件基类
    /// </summary>
    public class QueryBase
    {
        private int? _page = 1;
        /// <summary>
        /// 页码
        /// </summary>
        public int? page
        {
            get { return _page; }
            set
            {
                if (!value.HasValue || value.Value <= 0) value = 1;
                _page = value;
            }
        }

        private int? _pageSize = 20;
        /// <summary>
        /// 页面条数
        /// </summary>
        public int? pageSize
        {
            get { return _pageSize; }
            set
            {
                if (!value.HasValue || value.Value <= 0) value = 20;
                _pageSize = value;
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public string Orderby { get; set; }

        /// <summary>
        /// 总数量，用于返回
        /// </summary>
        public int totalCnt { get; set; }

        /// <summary>
        /// 是否需要查询总条数
        /// </summary>
        private bool _isNeedTotal = true;
        public bool IsNeedTotal
        {
            get { return _isNeedTotal; }
            set { _isNeedTotal = value; }
        }        
    }

}
