using System;

namespace SayWa.Entities
{
	/// <summary>
	/// 类msgRead。
	/// </summary>
	public partial class MsgRead : BaseModel
    {
		public MsgRead()
		{}
		#region Model
		private long _id;
		private long _msgid;
		private long _msgcreateuser;
		private int _isread=0;

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
		public long MsgCreateUser
		{
			set{ _msgcreateuser=value;}
			get{return _msgcreateuser;}
		}
		/// <summary>
		/// 0-未读 1-已读
		/// </summary>
		public int IsRead
		{
			set{ _isread=value;}
			get{return _isread;}
		}
		#endregion Model        
	}
}

