using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name> PromotionFor_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>22 Aug 07</date>
	/// <description>Responsible to hold the collection of PromotionFor_Collection values </description>
	/// </summary>
	public class PromotionFor_Collection
	{
		#region Constructor
		public PromotionFor_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Private class variables
		private long mPromotion_For_ID;
		private long mPromotion_ID;
		private int mScheme_ID;
		private int mDist_ID;
		private	int mAssigned_Dist_ID;

		#endregion

		#region Public Properties
		/// <summary>
		/// 
		/// </summary>
		public long Promotion_For_ID
		{
			get
			{
				return mPromotion_For_ID;
			}
			set
			{
				mPromotion_For_ID = value;
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
		public int Assigned_Dist_ID
		{
			get
			{
				return mAssigned_Dist_ID;
			}
			set
			{
				mAssigned_Dist_ID = value;
			}
		}

		#endregion
	}
}
