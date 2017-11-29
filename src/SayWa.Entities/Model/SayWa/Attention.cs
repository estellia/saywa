using System;
namespace SayWa.Entities
{
	/// <summary>
	/// 类attention。
	/// </summary>

	public partial class Attention : BaseModel
    {
		public Attention()
		{}
		#region Model
		private long _id;
		private long _familyid;
		private long _userid;
		private DateTime _createtime= DateTime.Now;
		private DateTime _updatetime= DateTime.Now;
		private int _isdelete=0;

		/// <summary>
		/// 家庭ID
		/// </summary>
		public long FamilyId
		{
			set{ _familyid=value;}
			get{return _familyid;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public long UserId
		{
			set{ _userid=value;}
			get{return _userid;}
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
		/// 更新时间
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 0-未删除 1-已删除
		/// </summary>
		public int IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

