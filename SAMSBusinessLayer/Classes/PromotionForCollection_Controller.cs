using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>PromotionForCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>24 Aug 07 </date>
	/// <description>Class Responsible to call PromotionFor_Collection for values</description>
	/// </summary>
	public class PromotionForCollection_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public PromotionForCollection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(PromotionFor_Collection  p_PForCol)
		{
			List.Add (p_PForCol);			
		}

		public void Insert(int p_i,PromotionFor_Collection p_PForCol)
		{
			List.Insert (p_i ,p_PForCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public PromotionFor_Collection Get(int p_Index)
		{
			return (PromotionFor_Collection) List[p_Index];
		}
		#endregion


	}
}
