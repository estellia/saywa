using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace web.test.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// 静态
        /// </summary>
        public static List<Student> students = new List<Student>();
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddStudent(Student student)
        {
            if (student == null)
            {
                return Json(new ReturnCode(-1, "error"));
            }
            students.Add(student);
            return Json(new ReturnCode(1, "success"));
        }
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllStudent()
        {
            return Json(students);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteStudent(string name)
        {
            var student = students.FirstOrDefault(p => p.Name == name);
            if (student != null)
            {
                students.Remove(student);
            }
            return Json(new ReturnCode(1, "success"));
        }
    }

    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 拥有的课程
        /// </summary>
        public List<Course> Courses
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 课程
    /// </summary>
    public class Course
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// 处理结果返回值
    /// </summary>
    public class ReturnCode
    {
        public ReturnCode(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
