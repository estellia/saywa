using System;
namespace SayWa.Entities
{
	/// <summary>
	/// 类user。
	/// </summary>
	public partial class LoginUser : BaseModel
    {
		public LoginUser()
		{}
		#region Model
		private long _id;
		private string _wxcode;
		private string _usercode;
		private string _username;
		private string _nickname;
		private string _pwd;
		private DateTime _createtime= DateTime.Now;
		private int _gender=0;

		/// <summary>
		/// 微信号
		/// </summary>
		public string WxCode
		{
			set{ _wxcode=value;}
			get{return _wxcode;}
		}
		/// <summary>
		/// 用户登录号
		/// </summary>
		public string UserCode
		{
			set{ _usercode=value;}
			get{return _usercode;}
		}
		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 0-未填写 1-男 2-女
		/// </summary>
		public int Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		#endregion Model

	}
}

