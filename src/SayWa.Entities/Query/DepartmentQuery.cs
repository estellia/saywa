using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Entities.Query
{
    public class DepartmentQuery : QueryBase
    {
        private int? _isDelete = 0;

        public int? IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }

        /// <summary>
        /// 父部门ID
        /// </summary>
        public long? ParentId { get; set; }
    }
}
