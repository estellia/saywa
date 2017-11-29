using System;
namespace SayWa.Entities
{
	/// <summary>
	/// 类family。
	/// </summary>

	public partial class Family : BaseModel
    {
		public Family()
		{}
		#region Model
		private long _id;
		private string _familyname;
		private DateTime _createtime= DateTime.Now;
		private long _createuserid;

		/// <summary>
		/// 家庭名称
		/// </summary>
		public string FamilyName
		{
			set{ _familyname=value;}
			get{return _familyname;}
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
		/// 创建人ID
		/// </summary>
		public long CreateUserId
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		#endregion Model


	}
}

