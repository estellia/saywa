using System;
namespace SayWa.Entities
{
	/// <summary>
	/// 类msg。
	/// </summary>
	public partial class Msg : BaseModel
    {
		public Msg()
		{}
		#region Model
		private long _id;
		private long _familyid;
		private long _createuser;
		private string _content;
		private DateTime _createtime= DateTime.Now;
		private int _isdelete;
		private long _parentid=0;
	
		/// <summary>
		/// 家庭ID
		/// </summary>
		public long FamilyId
		{
			set{ _familyid=value;}
			get{return _familyid;}
		}
		/// <summary>
		/// 创建者ID
		/// </summary>
		public long CreateUser
		{
			set{ _createuser=value;}
			get{return _createuser;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
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
		/// 0-未删除 1-已删除
		/// </summary>
		public int IsDelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 回复的消息ID，原生消息值为0
		/// </summary>
		public long ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model


	}
}

