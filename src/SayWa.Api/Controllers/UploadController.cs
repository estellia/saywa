using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using SayWa.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SayWa.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        [Route("upload/img")]
        public JsonResult UploadFile()
        {
            var files = base.Context.Request.Form.Files;
            var urls = new List<string>();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    var res = CheckFile(file);
                    if (!res.IsSuccess())
                    {
                        return Json(res);
                    }
                }
                foreach(var file in files)
                {
                    var res = SaveFile(file);
                    if (!res.IsSuccess())
                    {
                        return Json(res);
                    }
                    urls.Add(res.returnValue);
                }
            }
            return Json(Result<object>.SuccessBack(urls));
        }

        /// <summary>
        /// 检查图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private Result<bool> CheckFile(IFormFile file)
        {
            var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            //判断后缀是否是图片或者视频
            var fileExtension = Path.GetExtension(filename);
            const string fileFiltImg = ".gif|.jpg|.php|.jsp|.jpeg|.png|......";
            const string fileFiltVedio = ".mpg|.mpeg|.avi|.rm|.rmvb|.mov|.wmv|.asf|.dat";
            if (fileExtension == null)
            {
                return Result<bool>.FailBack(string.Format("{0}没有扩展名", filename));
            }
            if (fileFiltImg.IndexOf(fileExtension.ToLower(), StringComparison.Ordinal) <= -1)
            {
                if (fileFiltImg.IndexOf(fileFiltVedio.ToLower(), StringComparison.Ordinal) <= -1)
                {
                    return Result<bool>.FailBack(string.Format("上传的文件{0}不是图片或视频", filename));
                }
                return Result<bool>.FailBack(string.Format("上传的文件{0}不是图片或视频", filename));
            }
            return Result<bool>.SuccessBack(true);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private Result<string> SaveFile(IFormFile file)
        {
            long size = 0;
            var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            //判断后缀是否是图片
            var fileExtension = Path.GetExtension(filename);
            const string fileFilt = ".gif|.jpg|.bmp|.jsp|.jpeg|.png|......";
          
            filename = Guid.NewGuid().ToString() + fileExtension;
            var path = AppContext.BaseDirectory;
            var index = path.IndexOf("\\bin");
            if (index != -1)
            {
                path = path.Substring(0, index);
            }
            path += "/wwwroot";

            var backUrl = string.Format("/uploads/img/{0}/", DateTime.Now.ToString("yyMMdd"));

            path += backUrl;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            backUrl += filename;
            filename = path + filename;
            size += file.Length;
            using (FileStream fs = System.IO.File.Create(filename))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return Result<string>.SuccessBack(backUrl);
        }
    }
}
