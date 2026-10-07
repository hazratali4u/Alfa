using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>Basket_Detail_Collection </name>
	/// <author>Syed Ali Raza </author>
	/// <date>22 Aug 07 </date>
	/// <description>Responsible to hold the collection of promotion offers after calculation </description>
	/// </summary>
	public class PromoOffers_Collection
	{
		public PromoOffers_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		#region Private class variables

		private long mBasket_ID;
		private long mBasketDetail_ID;
		private int mQuantity;
		private decimal mOffer_Value;
		private float mDiscount;
		private bool mIs_And;
        private bool mIs_Claimable;
		private int mSKU_ID;
		private int mFree_SKU_ID;
		private int mUOM_ID;
		private int mSKU_GroupID;
        private int mDistributor_ID;
		private int mPromoOffer_ID;
		private int mPromotion_ID;
		private int mScheme_ID;

	
		#endregion

		#region Public Properties
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

		public int Group_ID
		{
			get
			{
				return mSKU_GroupID ;
			}
			set
			{
				mSKU_GroupID = value;
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
        public bool Is_Claimable
        {
            get
            {
                return mIs_Claimable;
            }
            set
            {
                mIs_Claimable = value;
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
		public int Free_SKU_ID
		{
			get
			{
				return mFree_SKU_ID ;
			}
			set
			{
				mFree_SKU_ID = value;
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
		public int PromoOffer_ID
		{
			get
			{
				return mPromoOffer_ID;
			}
			set
			{
				mPromoOffer_ID = value;
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
		
		#endregion
	}
}
