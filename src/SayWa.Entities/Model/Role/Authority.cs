using System;
using System.Text;
namespace SayWa.Entities
{
	/// <summary>
	/// 类tb_authority。
	/// </summary>
	public partial class Authority:BaseModel
	{
		#region Model
		private string _authorityname;

		/// <summary>
		/// 
		/// </summary>
		public string AuthorityName
		{
			set{ _authorityname=value;}
			get{return _authorityname;}
		}

        /// <summary>
        /// 是否删除 0-否 1-是
        /// </summary>
        public int IsDelete { get; set; }
        #endregion Model

    }
}

