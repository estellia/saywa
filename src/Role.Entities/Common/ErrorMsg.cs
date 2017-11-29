
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
    /// 错误消息详细信息
    /// </summary>
    public partial class ErrorMsg
    {
        public ErrorMsg()
        {

        }

        public ErrorMsg(string fieldName, string error)
        {
            Field = fieldName;
            Message = error;
        }
        /// <summary>
        /// 错误字段
        /// </summary>
        /// <value>错误字段</value>
        public string Field { get; set; }
        /// <summary>
        /// 错误原因
        /// </summary>
        /// <value>错误原因</value>
        public string Message { get; set; }
    }
}
