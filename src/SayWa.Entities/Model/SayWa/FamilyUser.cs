using System;
namespace SayWa.Entities
{

	public partial class FamilyUser : BaseModel
    {
		public FamilyUser()
		{}
		#region Model
		private long _id;
		private long _familyid;
		private long _userid;
		private int _relationid=0;
		private string _relationname;
		private string _relationnickname;
		private DateTime _creattime= DateTime.Now;
		private int _ischecked=1;
		private int _status=0;

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
		/// 0-其它 1-M 2-F,见枚举
		/// </summary>
		public int RelationId
		{
			set{ _relationid=value;}
			get{return _relationid;}
		}
		/// <summary>
		/// 与宝宝的关系名称
		/// </summary>
		public string RelationName
		{
			set{ _relationname=value;}
			get{return _relationname;}
		}
		/// <summary>
		/// 称呼
		/// </summary>
		public string RelationNickName
		{
			set{ _relationnickname=value;}
			get{return _relationnickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatTime
		{
			set{ _creattime=value;}
			get{return _creattime;}
		}
		/// <summary>
		/// 0-未通过 1-已通过 （对于有发贴权限的亲属，创建时，需要检查）
		/// </summary>
		public int IsChecked
		{
			set{ _ischecked=value;}
			get{return _ischecked;}
		}
		/// <summary>
		/// 0-正常 1-删除 2-隐藏这个家庭的发贴信息
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

