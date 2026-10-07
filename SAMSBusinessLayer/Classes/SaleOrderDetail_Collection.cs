using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name> SaleOrderDetail_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>11 Sep 2007</date>
	/// <description>Responsible to hold the collection of SaleOrderDetail of frmOrderEntry </description>
	/// </summary>
	public class SaleOrderDetail_Collection
	{
		#region Constructor
		public SaleOrderDetail_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region private class variables
		private long mSale_Order_Detail_ID;
		private int mDistributor_ID;
		private int mSKU_ID;
		private int mQuantity_Unit;
		private decimal mUnit_Price;
		private decimal mRetail_Price;
		private decimal mTax_Price;
		private float mGST_Rate;
		private decimal mAmount;
		private decimal mNet_Amount;
		private decimal mStandard_Discount;
		private decimal mExtra_Discount;
		private string mGST_On;
		private decimal mGST_Amount;
		private string mBatch_No;
        private bool mIs_Deleted;
		private DateTime mTime_Stamp;
		private long mSale_Order_Id;
		#endregion

		#region Class Objects
		private SaleOrderPromoCol_Controller  objSOrderPromoCol_Cntrlr;
		#endregion

		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public long Sale_Order_Detail_ID
		{
			get
			{
				return mSale_Order_Detail_ID;
			}
			set
			{
				mSale_Order_Detail_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Distributor_ID
		{
			get
			{
				return mDistributor_ID;
			}
			set
			{
				mDistributor_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int SKU_ID
		{
			get
			{
				return mSKU_ID;
			}
			set
			{
				mSKU_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Quantity_Unit
		{
			get
			{
				return mQuantity_Unit;
			}
			set
			{
				mQuantity_Unit = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Unit_Price
		{
			get
			{
				return mUnit_Price;
			}
			set
			{
				mUnit_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Retail_Price
		{
			get
			{
				return mRetail_Price;
			}
			set
			{
				mRetail_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Tax_Price
		{
			get
			{
				return mTax_Price;
			}
			set
			{
				mTax_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public float GST_Rate
		{
			get
			{
				return mGST_Rate;
			}
			set
			{
				mGST_Rate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Amount
		{
			get
			{
				return mAmount;
			}
			set
			{
				mAmount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Net_Amount
		{
			get
			{
				return mNet_Amount;
			}
			set
			{
				mNet_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Standard_Discount
		{
			get
			{
				return mStandard_Discount;
			}
			set
			{
				mStandard_Discount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Extra_Discount
		{
			get
			{
				return mExtra_Discount;
			}
			set
			{
				mExtra_Discount = value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public decimal GST_Amount
		{
			get
			{
				return mGST_Amount ;
			}
			set
			{
				mGST_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string GST_On
		{
			get
			{
				return mGST_On;
			}
			set
			{
				mGST_On = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Batch_No
		{
			get
			{
				return mBatch_No;
			}
			set
			{
				mBatch_No = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Is_Deleted
		{
			get
			{
				return mIs_Deleted;
			}
			set
			{
				mIs_Deleted = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Time_Stamp
		{
			get
			{
				return mTime_Stamp;
			}
			set
			{
				mTime_Stamp = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Sale_Order_Id
		{
			get
			{
				return mSale_Order_Id;
			}
			set
			{
				mSale_Order_Id = value;
			}
		}

		public SaleOrderPromoCol_Controller ObjSOrderPromoCol_Cntrlr
		{
			get
			{
				return objSOrderPromoCol_Cntrlr;
			}
			set
			{
				objSOrderPromoCol_Cntrlr = value;
			}
		}
		#endregion
	}
}
