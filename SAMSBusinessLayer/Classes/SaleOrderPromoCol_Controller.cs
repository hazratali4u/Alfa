using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SaleOrderPromoCol_Controller.
	/// </summary>
	public class SaleOrderPromoCol_Controller : System .Collections .CollectionBase
	{
		public SaleOrderPromoCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Public Methods
		public void Add(SaleOrderPromotion_Collection   p_BCol)
		{
			List.Add (p_BCol);			
		}
		public SaleOrderPromotion_Collection Get(int p_Index)
		{
			return (SaleOrderPromotion_Collection) List[p_Index];
		}

		public SaleOrderPromotion_Collection GetPromoOffer(long SALE_ORDER_DETAIL_ID)
		{
			int i=0;
			foreach(Object obj in List)
			{
				if(((SaleOrderPromotion_Collection) obj).Sale_Order_Detail_ID==SALE_ORDER_DETAIL_ID)
				{
					break;
				}
				i++;
			}
			return (SaleOrderPromotion_Collection) List[i];
		}

		#endregion
	}
}
