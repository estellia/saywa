using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Entities.Query
{
    public class RolesQuery:QueryBase
    {
        private int? _isDelete = 0;

        public int? IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
    }
}
