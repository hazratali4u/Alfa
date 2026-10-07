using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name> Promotion_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>22 Aug 07</date>
	/// <description>Responsible to hold the Promotion_Collection values </description>
	/// </summary>
	public class Promotion_Collection
	{
		#region Constructor
		public Promotion_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion 

		#region Private class variables
		
		private long mPromotion_ID;
		private int mScheme_ID;
		private int mDist_ID;
		private string mPromotion_Code;
		private string mPromotion_Desc;
		private DateTime mPromotion_Date;
		private bool mClaimable;
		private DateTime mStart_Date;
		private DateTime mEnd_Date;
		private bool mIs_Active;
		private int mPromotion_Type;
		private int mPromotion_Selection;
		private bool mIs_Scheme;
		private bool mPromotion_For;

		#endregion

		#region Class Objects
		private BasketCollection_Controller objBasketCol_Cntrl;
		private PromotionForCollection_Controller objPromotionForCol_Cntrl;
		private PromotionForCustColl_Controller objPromotionForCustCol_Cntrl;
		private PromotionCustTypeColl_Controller objPromotionForCustTypeCol_Cntrl;
        private PromotionCustVolclassColl_Controller ObjPromotionCustVolClassCol_Cntrl;
		#endregion

		#region Public Properties

		/// <summary>
		/// 
		/// </summary>
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
		public bool Promotion_For
		{
			get
			{
				return mPromotion_For;
			}
			set
			{
				mPromotion_For = value;
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
		public string Promotion_Code
		{
			get
			{
				return mPromotion_Code;
			}
			set
			{
				mPromotion_Code = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Promotion_Desc
		{
			get
			{
				return mPromotion_Desc;
			}
			set
			{
				mPromotion_Desc = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Promotion_Date
		{
			get
			{
				return mPromotion_Date;
			}
			set
			{
				mPromotion_Date = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Claimable
		{
			get
			{
				return mClaimable;
			}
			set
			{
				mClaimable = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Start_Date
		{
			get
			{
				return mStart_Date;
			}
			set
			{
				mStart_Date = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime End_Date
		{
			get
			{
				return mEnd_Date;
			}
			set
			{
				mEnd_Date = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Is_Active
		{
			get
			{
				return mIs_Active;
			}
			set
			{
				mIs_Active = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Promotion_Type
		{
			get
			{
				return mPromotion_Type;
			}
			set
			{
				mPromotion_Type = value;				
			}			
		}

		/// <summary>
		/// 
		/// </summary>
		public int Promotion_Selection
		{
			get
			{
				return mPromotion_Selection;
			}
			set
			{
				mPromotion_Selection = value;
			}
		}		
		/// <summary>
		/// 
		/// </summary>
		public BasketCollection_Controller ObjBasketCol_Cntrl
		{
			get
			{
				return objBasketCol_Cntrl;
			}
			set
			{
				objBasketCol_Cntrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public PromotionForCollection_Controller ObjPromotionForCol_Cntrl
		{
			get
			{
				return objPromotionForCol_Cntrl;
			}
			set
			{
				objPromotionForCol_Cntrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public PromotionForCustColl_Controller ObjPromotionForCustCol_Cntrl 
		{
			get
			{
				return objPromotionForCustCol_Cntrl;
			}
			set
			{
				objPromotionForCustCol_Cntrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public PromotionCustTypeColl_Controller ObjPromotionCustTypeCol_Cntrl
		{
			get
			{
				return objPromotionForCustTypeCol_Cntrl;
                        
			}
			set
			{
				objPromotionForCustTypeCol_Cntrl = value;
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// 

        public PromotionCustVolclassColl_Controller ObjPromotionVolClassCol_Cntrl
        {
            get
            {
                return ObjPromotionCustVolClassCol_Cntrl;
            }
            set
            {
                ObjPromotionCustVolClassCol_Cntrl = value;
            }
        }
		#endregion
		
		
	}
}
