using System;
namespace Role.Entities
{
	public partial class DepartmentPosition : BaseModel
    {
		public DepartmentPosition()
		{}
		#region Model

		private long _departmentid;
		private long _positionid;

		/// <summary>
		/// 
		/// </summary>
		public long DepartmentId
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long PositionId
		{
			set{ _positionid=value;}
			get{return _positionid;}
		}
		#endregion Model
	}
}

