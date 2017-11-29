using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role.Entities
{
    public class Result<T>
    {
        /// <summary>
        ///  实体数据
        /// </summary>
        public T returnValue { get; set; }

        /// <summary>
        /// 结果码
        /// </summary>
        public int resultCode { get; set; }

        /// <summary>
        /// message
        /// </summary>
        public string resultMessage;

        /// <summary>
        /// 具体错误
        /// </summary>
        /// <value>具体错误</value>
        public List<ErrorMsg> errors { get; set; }
              

        /// <summary>
        /// 是否成功
        /// </summary>
        /// <returns></returns>
        public  bool IsSuccess()
        {
            return resultCode == 0;
        }

        /// <summary>
        /// 添加错误详细信息
        /// </summary>
        /// <param name="field"></param>
        /// <param name="msg"></param>
        public void AddErrorMsg(string field,string msg)
        {
            if (errors == null) errors = new List<ErrorMsg>();
            errors.Add(new ErrorMsg() { Field = field, Message = msg });
        }

        /// <summary>
        /// 是否包含错误详细信息
        /// </summary>
        /// <returns></returns>
        public bool ContainErrors()
        {
            if (errors == null || errors.Count <= 0) return false;
            return true;
        }

        /// <summary>
        /// 返回一个成功的消息
        /// </summary>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> SuccessBack(T value, string msg = "")
        {
            return new Result<T>()
            {
               resultCode=0,
               returnValue=value,
               resultMessage=msg
            };
        }

        /// <summary>
        /// 返回一个失败的消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="errors"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Result<T> FailBack(string msg, List<ErrorMsg> errors = null, T value = default(T),int errorCode=1)
        {
            return new Result<T>()
            {
                resultCode = errorCode,
                returnValue = value,
                resultMessage=msg,
                errors=errors
            };
        }
    }
}
