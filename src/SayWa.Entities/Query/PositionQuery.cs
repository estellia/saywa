using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SayWa.Entities.Query
{
    public class PositionQuery:QueryBase
    {
        private int? _isDelete = 0;

        public int? IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
    }
}
