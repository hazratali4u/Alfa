using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>PromotionForCustomerCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>24 Aug 07 </date>
	/// <description>Class Responsible to call PromotionForCustomer_Collection for values</description>
	/// </summary>
	public class PromotionForCustColl_Controller : System .Collections .CollectionBase
	{
		#region Contructor
		public PromotionForCustColl_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(PromotionForCustomer_Collection p_PForCustCol)
		{
			List.Add (p_PForCustCol);			
		}

		public void Insert(int p_i , PromotionForCustomer_Collection p_PForCustCol)
		{
			List.Insert (p_i ,p_PForCustCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public PromotionForCustomer_Collection Get(int p_Index)
		{
			return (PromotionForCustomer_Collection) List[p_Index];
		}
		#endregion
	}
}
