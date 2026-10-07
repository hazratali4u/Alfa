using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>Promotion_Collections Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>23 Aug 07 </date>
	/// <description>Responsible to provide access to collection class for Promotion_Collection </description>
	/// </summary>
	public class PromotionCollections_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public PromotionCollections_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public methods
		public void Add_PCol(Promotion_Collection  p_PCol)
		{
			List.Add (p_PCol);
			
		}
		public Promotion_Collection Get_PCol(int p_Index)
		{
			return (Promotion_Collection) List[p_Index];
		}
		#endregion

	}
}
