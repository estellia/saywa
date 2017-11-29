
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Role.Entities
{

    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorModel 
    {    
        /// <summary>
        /// 400-错误请求 401-没有认证 403-访问被拒绝 404资源没找到  405不允许此方法
        /// </summary>
        /// <value>400-错误请求 401-没有认证 403-访问被拒绝 404资源没找到  405不允许此方法</value>
        public int? Code { get; set; }
        /// <summary>
        /// Gets or Sets Msg
        /// </summary>

        public string Msg { get; set; }
        /// <summary>
        /// 具体错误
        /// </summary>
        /// <value>具体错误</value>
        public List<ErrorMsg> Errors { get; set; }
               

    }
}
