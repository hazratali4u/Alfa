using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name> SaleOrderDetail_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>03 Oct 07</date>
	/// <description>Responsible to hold the collection of SaleOrder promotion of frmOrderEntry </description>
	/// </summary>
	public class SaleOrderPromotion_Collection
	{
		public SaleOrderPromotion_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region private class variables
		private int mDistributor_ID;
		private int mPromotion_ID;
		private int mPromotionOffer_ID;
		private int mBasket_ID;
		private int mBasketDetail_ID;
		private int mScheme_ID;
		private int mSKU_ID;
		private int mQuantity;
		private decimal mUnit_Price;
		private decimal mRetail_Price;		
		private float mGST_Rate;
		private decimal mGST_Amount;
		private decimal mClaim_Amount;
		private long mSale_Order_Detail_ID;
		private int mSALE_ORDER_PROMOTION_ID;
		private decimal mDisc_Rate;
		private decimal mDisc_Amount;
		private bool mIs_Scheme;
		private decimal mSale_Order_Master_Id;
		#endregion

		#region public Properties

		public decimal Sale_Order_Master_Id
		{
			get
			{
				return mSale_Order_Master_Id;
			}
			set
			{
				mSale_Order_Master_Id = value;
			}
		}

		public bool Is_Scheme
		{
			get
			{
				return mIs_Scheme;
			}
			set
			{
				mIs_Scheme = value;
			}
		}

		public decimal Disc_Amount
		{
			get
			{
				return mDisc_Amount;
			}
			set
			{
				mDisc_Amount = value;
			}
		}

		public decimal Disc_Rate
		{
			get
			{
				return mDisc_Rate; 
			}
			set
			{
				mDisc_Rate = value;
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

		public int SALE_ORDER_PROMOTION_ID
		{
			get
			{
				return mSALE_ORDER_PROMOTION_ID;
			}
			set
			{
				mSALE_ORDER_PROMOTION_ID= value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public int Promotion_ID
		{
			get
			{
				return mPromotion_ID;
			}
			set
			{
				mPromotion_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int PromotionOffer_ID
		{
			get
			{
				return mPromotionOffer_ID;
			}
			set
			{
				mPromotionOffer_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Basket_ID
		{
			get
			{
				return mBasket_ID;
			}
			set
			{
				mBasket_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int BasketDetail_ID
		{
			get
			{
				return mBasketDetail_ID;
			}
			set
			{
				mBasketDetail_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Scheme_ID
		{
			get
			{
				return mScheme_ID;
			}
			set
			{
				mScheme_ID = value;
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
		public int Quantity
		{
			get
			{
				return mQuantity;
			}
			set
			{
				mQuantity = value;
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
		public decimal GST_Amount
		{
			get
			{
				return mGST_Amount;
			}
			set
			{
				mGST_Amount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal Claim_Amount
		{
			get
			{
				return mClaim_Amount;
			}
			set
			{
				mClaim_Amount = value;
			}
		}

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

		#endregion
	}
}
