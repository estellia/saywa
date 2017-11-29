using System;
using System.Text;
namespace SayWa.Entities
{

    public partial class Department : BaseModel
    {
        public Department()
        { }
        #region Model
        private string _departmentname;
        private long? _parentid = 0;

        /// <summary>
        /// 
        /// </summary>
        public string DepartmentName
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }

        /// <summary>
        /// 是否删除 0-否 1-是
        /// </summary>
        public int IsDelete { get; set; }
        #endregion Model

    }
}

