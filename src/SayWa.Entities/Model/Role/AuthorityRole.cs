using System;
using System.Text;
namespace SayWa.Entities
{
	/// <summary>
	/// 类tb_authorityrole。
	/// </summary>
	public partial class AuthorityRole : BaseModel
    {
		public AuthorityRole()
		{}
		#region Model
		private long _roleid=0;
		private long _authorityid=0;

		/// <summary>
		/// 
		/// </summary>
		public long RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long AuthorityId
		{
			set{ _authorityid=value;}
			get{return _authorityid;}
		}
		#endregion Model

	}
}

