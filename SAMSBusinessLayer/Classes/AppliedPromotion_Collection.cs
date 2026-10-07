using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Collection Class for Promotion
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
	public class AppliedPromotion_Collection
	{
		#region Constructor

        /// <summary>
        /// Constructor for AppliedPromotion_Collection
        /// </summary>
		public AppliedPromotion_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region private class variables
		private long mBasketDetail_ID;
		private long mBasket_ID;
		private long mPromotion_ID;
		private int mScheme_ID;
		private int mDist_ID;
		private int mPromotion_Offer_ID;
		private int mSKU_ID;
		private int mBasket_Selection;

		private int mGroup_Id;
		private decimal mSku_Amount;
		private int mSKU_Quantity;
		#endregion

		#region Properties
		
        /// <summary>
        /// BasketDetail_ID
        /// <remarks>
        /// long
        /// </remarks>
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
        /// <remarks>
        /// long
        /// </remarks>
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
        /// <remarks>
        /// long
        /// </remarks>
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
        /// Promotion_Offer_ID
        /// <remarks>int</remarks>
		/// </summary>
		public int Promotion_Offer_ID
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
        /// SKU_ID
        /// <remarks>
        /// int
        /// </remarks>
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
        /// Basket_Selection
        /// <remarks>
        /// int
        /// </remarks>
		/// </summary>
		public int Basket_Selection
		{
			get
			{
				return mBasket_Selection;
			}
			set
			{
				mBasket_Selection = value;
			}
		}

		/// <summary>
        /// Group_Id
        /// <remarks>
        /// int
        /// </remarks>
		/// </summary>
		public int Group_Id
		{
			get
			{
				return mGroup_Id;
			}
			set
			{
				mGroup_Id = value;
			}
		}

		/// <summary>
        /// Sku_Amount
        /// <remarks>
        /// decimal
        /// </remarks>
		/// </summary>
		public decimal Sku_Amount
		{
			get
			{
				return mSku_Amount;
			}
			set
			{
				mSku_Amount = value;
			}
		}

		/// <summary>
        /// SKU_Quantity
        /// <remarks>
        /// int
        /// </remarks>
		/// </summary>
		public int SKU_Quantity
		{
			get
			{
				return mSKU_Quantity;
			}
			set
			{
				mSKU_Quantity = value;
			}
		}

		#endregion
	}
}
