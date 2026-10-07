using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SaleOrderDetailCol_Controller.
	/// </summary>
	public class SaleOrderDetailCol_Controller : System .Collections .CollectionBase
	{
		public SaleOrderDetailCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Public Methods
		public void Add(SaleOrderDetail_Collection   p_BCol)
		{
			List.Add (p_BCol);			
		}
		public SaleOrderDetail_Collection Get(int p_Index)
		{
			return (SaleOrderDetail_Collection ) List[p_Index];
		}
		#endregion
	}
}
