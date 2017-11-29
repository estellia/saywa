using System;

namespace SayWa.Entities
{
	/// <summary>
	/// 类msgLike。
	/// </summary>

	public partial class MsgLike : BaseModel
    {
		public MsgLike()
		{}
		#region Model
		private long _id;
		private long _msgid;
		private long _createuserid;
		private DateTime _createtime= DateTime.Now;
		private int _isdelete=0;

		/// <summary>
		/// 
		/// </summary>
		public long MsgId
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long CreateUserId
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
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

