using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name> Scheme_Collection </name>
	/// <author>Syed Ali Raza</author>
	/// <date>22 Aug 07</date>
	/// <description>Responsible to hold thecollection of Scheme values </description>
	/// </summary>
	public class Scheme_Collection
	{
		#region Constructor
		public Scheme_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region private class variables
		private int mScheme_ID;
		private int mDist_ID;
		private string mScheme_Code;
		private string mScheme_Desc;
		private DateTime mScheme_date;
		#endregion

		#region Class Objects
		private PromotionCollections_Controller objPromotionCol_Cntrl; 
		#endregion

		#region Public Properties
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
		public string Scheme_Code
		{
			get
			{
				return mScheme_Code;
			}
			set
			{
				mScheme_Code = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string Scheme_Desc
		{
			get
			{
				return mScheme_Desc;
			}
			set
			{
				mScheme_Desc = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTime Scheme_date
		{
			get
			{
				return mScheme_date;
			}
			set
			{
				mScheme_date = value;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		public PromotionCollections_Controller ObjPromotionCol_Cntrl
		{
			get
			{
				return objPromotionCol_Cntrl;
			}
			set
			{
				objPromotionCol_Cntrl = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		

		#endregion
	}
}
