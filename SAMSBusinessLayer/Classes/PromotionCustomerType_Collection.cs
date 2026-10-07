using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name> PromotionCustomerType_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>23 Aug 07</date>
	/// <description>Responsible to hold the collection of PromotionCustomerType_Collection values </description>
	/// </summary>
	public class PromotionCustomerType_Collection
	{
		#region Public Class variables
		public PromotionCustomerType_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Class variables
		public long Promotion_Cust_Type_ID;
		public long Promotion_ID;
		public int	Scheme_ID;
		public int Dist_ID;
		public int Customer_Type_ID;
        #endregion
	}
}
