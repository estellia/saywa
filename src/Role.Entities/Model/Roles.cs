
namespace Role.Entities
{
	/// <summary>
	/// 类tb_role。
	/// </summary>
	public partial class RolesTb : BaseModel
    {
		public RolesTb()
		{}
		#region Model
		private string _rolename;

		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}

        /// <summary>
        /// 是否删除 0-否 1-是
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 是否管理员角色
        /// </summary>
        public int IsAdmin { get; set; }
        #endregion Model
    }
}

