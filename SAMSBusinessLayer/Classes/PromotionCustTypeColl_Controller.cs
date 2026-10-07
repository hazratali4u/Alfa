using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>PromotionCustomerTypeCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>24 Aug 07 </date>
	/// <description>Class Responsible to call Promotion Customer Type collection for values</description>
	/// </summary>
	public class PromotionCustTypeColl_Controller : System .Collections .CollectionBase
	{
		#region Contructor
		public PromotionCustTypeColl_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(PromotionCustomerType_Collection p_PCustTypeCol)
		{
			List.Add (p_PCustTypeCol);			
		}

		public void Insert(int p_i , PromotionCustomerType_Collection p_PCustTypeCol)
		{
			List.Insert (p_i ,p_PCustTypeCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public PromotionCustomerType_Collection Get(int p_Index)
		{
			return (PromotionCustomerType_Collection) List[p_Index];
		}
		#endregion
	}
}
