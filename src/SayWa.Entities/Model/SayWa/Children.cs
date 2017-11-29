using System;

namespace SayWa.Entities
{
	/// <summary>
	/// 类children。
	/// </summary>

	public partial class Children : BaseModel
    {
		public Children()
		{}
		#region Model
		private long _id;
		private string _name;
		private string _nickname;
		private int _gender=0;
		private DateTime? _birthday;
		private decimal _weight=0M;
		private long _familyid;
		private DateTime _createtime= DateTime.Now;
		private long _createuser;
	
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
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
		/// 0-未填写 1-男 2-女
		/// </summary>
		public int Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 体重
		/// </summary>
		public decimal Weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 家庭ID
		/// </summary>
		public long FamilyId
		{
			set{ _familyid=value;}
			get{return _familyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
        #endregion Model

    }
}

