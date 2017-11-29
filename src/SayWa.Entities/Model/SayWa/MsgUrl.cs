using System;

namespace SayWa.Entities
{
	/// <summary>
	/// 类msgUrl。
	/// </summary>

	public partial class MsgUrl : BaseModel
    {
		public MsgUrl()
		{}
		#region Model
		private long _id;
		private long _msgid;
		private int _type=0;
		private string _url;
		private DateTime _createtime= DateTime.Now;

		/// <summary>
		/// 信息ID
		/// </summary>
		public long MsgId
		{
			set{ _msgid=value;}
			get{return _msgid;}
		}
		/// <summary>
		/// 0-图片 1-视频
		/// </summary>
		public int Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 连接地址
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

