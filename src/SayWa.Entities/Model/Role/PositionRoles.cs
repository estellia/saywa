
namespace SayWa.Entities
{
	/// <summary>
	/// 类tb_positionroles。
	/// </summary>
	public partial class PositionRoles : BaseModel
    {
		public PositionRoles()
		{}
		#region Model
		private long _positionid;
		private long _roleid;

		/// <summary>
		/// 
		/// </summary>
		public long PositionId
		{
			set{ _positionid=value;}
			get{return _positionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long RoleId
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		#endregion Model

	}
}

