using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Role.Entities.Common
{
    public class SysConfig
    {
        private long _adminId = 1;

        /// <summary>
        /// 管理员帐号
        /// </summary>
        public long AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }
    }
}
