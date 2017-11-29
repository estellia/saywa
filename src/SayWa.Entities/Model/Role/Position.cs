
namespace SayWa.Entities
{
	public partial class Position : BaseModel
    {
		public Position()
		{}
		#region Model
		private string _positionname;

		/// <summary>
		/// 
		/// </summary>
		public string PositionName
		{
			set{ _positionname = value;}
			get{return _positionname; }
		}

        /// <summary>
        /// 是否删除 0-否 1-是
        /// </summary>
        public int IsDelete { get; set; }
        #endregion Model

    }
}

