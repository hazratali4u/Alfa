using System;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Collection Class for Basket Detail
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// BasketDetail_ID
    /// </item>
    /// <term>
    /// Basket_ID
    /// </term>
    /// <item>
    /// Promotion_ID
    /// </item>
    /// <item>
    /// Scheme_ID etc
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class Basket_Detail_Collection
	{
		#region Constructor

        /// <summary>
        /// Constructor for Basket_Detail_Collection
        /// </summary>
		public Basket_Detail_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion 
		
		#region Private class variables
		
		private long mBasketDetail_ID;
		private long mBasket_ID;
		private long mPromotion_ID;
		private int mScheme_ID;
		private int mDist_ID;
		private decimal mMin_Val;
		private decimal mMax_Val;
		private int mMultiple_Of;
		private int mSKUCompany_ID;
        private int mSKU_ID;
		private int mSKUBrand_ID;
		private int mSKUDiv_ID;
		private int mSKUCatg_ID;
		private int mSKUProductLine_ID;
		private int mSKUGroup_ID;
		private int mUOM_ID;
		//private long mSKU_Mapping_ID;
		#endregion

        #region Class Objects
        private PromotionOfferColl_Controller objPromotionOfferCol_Cntrl;
        #endregion

		#region Public Properties

		/// <summary>
        /// SKUCompany_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int SKUCompany_ID
		{
			get
			{
				return mSKUCompany_ID;
			}
			set
			{
				mSKUCompany_ID = value;
			}		
		
		}

        /// <summary>
        /// BasketDetail_ID
        /// <remarks>long</remarks>
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
        /// Basket_ID
        /// <remarks>long</remarks>
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
        /// Promotion_ID
        /// <remarks>long</remarks>
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
        /// Scheme_ID
        /// <remarks>int</remarks>
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
        /// Dist_ID
        /// <remarks>int</remarks>
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
        /// Min_Val
        /// <remarks>decimal</remarks>
		/// </summary>
		public decimal Min_Val
		{
			get
			{
				return mMin_Val;
			}
			set
			{
				mMin_Val = value;
			}
		}

		/// <summary>
        /// Max_Val
        /// <remarks>decimal</remarks>
		/// </summary>
		public decimal Max_Val
		{
			get
			{
				return mMax_Val;
			}
			set
			{
				mMax_Val = value;
			}
		}

		/// <summary>
        /// Multiple_Of
        /// <remarks>int</remarks>
		/// </summary>
		public int Multiple_Of
		{
			get
			{
				return mMultiple_Of;
			}
			set
			{
				mMultiple_Of = value;
			}
		}

		/// <summary>
        /// SKU_ID
        /// <remarks>int</remarks>
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
        /// SKUBrand_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int SKUBrand_ID
		{
			get
			{
				return mSKUBrand_ID;
			}
			set
			{
				mSKUBrand_ID = value;
			}
		}

		/// <summary>
        /// SKUDiv_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int SKUDiv_ID
		{
			get
			{
				return mSKUDiv_ID;
			}
			set
			{
				mSKUDiv_ID = value;
			}
		}

		/// <summary>
        /// SKUCatg_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int SKUCatg_ID
		{
			get
			{
				return mSKUCatg_ID;
			}
			set
			{
				mSKUCatg_ID = value;
			}
		}

		/// <summary>
        /// SKUProductLine_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int SKUProductLine_ID
		{
			get
			{
				return mSKUProductLine_ID;
			}
			set
			{
				mSKUProductLine_ID = value;
			}
		}

		/// <summary>
        /// SKUGroup_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int SKUGroup_ID
		{
			get
			{
				return mSKUGroup_ID;
			}
			set
			{
				mSKUGroup_ID = value;
			}
		}

		/// <summary>
        /// UOM_ID
        /// <remarks>int</remarks>
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
        /// ObjPromotionOfferCol_Cntrl
        /// <remarks>
        /// PromotionOfferColl_Controller
        /// </remarks>
        /// </summary>
        public PromotionOfferColl_Controller ObjPromotionOfferCol_Cntrl
        {
            get
            {
                return objPromotionOfferCol_Cntrl;
            }
            set
            {
                objPromotionOfferCol_Cntrl = value;
            }
        }
		#endregion
	}
}
