using System;

namespace SAMSBusinessLayer.Classes
{	
	/// <summary>
	/// <name> PromotionOffer_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>22 Aug 07</date>
	/// <description>Responsible to hold the collection of Promotion_Collection values </description>
	/// </summary>
	public class PromotionOffer_Collection
	{
		#region Constructor
		public PromotionOffer_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region private class variables
		
		private long mPromotion_Offer_ID;
		private long mBasket_ID;
		private long mPromotion_ID;
		private int mScheme_ID;
		private int mDist_ID;
		private long mBasketDetail_ID;
		private int mQuantity;
		private decimal mOffer_Value;
		private float mDiscount;
		private bool mIs_And;
		private int mSKU_ID;
		private int mUOM_ID;
		
		#endregion

		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public long Promotion_Offer_ID
		{
			get
			{
				return mPromotion_Offer_ID;
			}
			set
			{
				mPromotion_Offer_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long Basket_ID
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
		public long Promotion_ID
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
		public int Dist_ID
		{
			get
			{
				return mDist_ID;
			}
			set
			{
				mDist_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long BasketDetail_ID
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
		public decimal Offer_Value
		{
			get
			{
				return mOffer_Value;
			}
			set
			{
				mOffer_Value = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public float Discount
		{
			get
			{
				return mDiscount;
			}
			set
			{
				mDiscount = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Is_And
		{
			get
			{
				return mIs_And;
			}
			set
			{
				mIs_And = value;
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
		public int UOM_ID
		{
			get
			{
				return mUOM_ID;
			}
			set
			{
				mUOM_ID = value;
			}
		}

		#endregion
	}
}
