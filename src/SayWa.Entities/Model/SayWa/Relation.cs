using System;

namespace SayWa.Entities
{
	/// <summary>
	/// 类relation。
	/// </summary>

	public partial class Relation : BaseModel
    {
		public Relation()
		{}
		#region Model
		private long _id;
		private string _name;
		private int _ismaster=0;
		private DateTime _createtime= DateTime.Now;

		/// <summary>
		/// 亲属关系名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 是否具备管理权限 0-否 1-是
		/// </summary>
		public int IsMaster
		{
			set{ _ismaster=value;}
			get{return _ismaster;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

