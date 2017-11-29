
namespace Role.Entities
{
	public partial class User : BaseModel
    {
		public User()
		{}
		#region Model

		private string _username;
		private long? _departmentid;
		private string _loginid;

		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? DepartMentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginId
		{
			set{ _loginid=value;}
			get{return _loginid;}
		}
		#endregion Model
	}
}

