using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Summary description for SKUPrices_Collection.
	/// </summary>
	public class SKUPrices_Collection
	{
		public SKUPrices_Collection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region private
		private long m_SKU_ID;
		private long m_SKU_Mapping_ID;
		private string m_SKUCode;
		private long m_Dist_ID;
		private decimal m_Dist_Price;
		private decimal m_Trade_Price;
		private decimal m_Retail_Price;
		private decimal m_Tax_Price;
		
		private decimal m_SKU_Unit_Price;
		private decimal m_Dozen_Price;
		private decimal m_Case_Price;
		#endregion 

		#region public properties
		/// <summary>
		/// 
		/// </summary>
		public long SKU_SKU_ID
		{
			get
			{
				return m_SKU_ID;
			}
			set
			{
				m_SKU_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKU_SKU_Mapping_ID
		{
			get
			{
				return m_SKU_Mapping_ID;
			}
			set
			{
				m_SKU_Mapping_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SKU_SKUCode
		{
			get
			{
				return m_SKUCode;
			}
			set
			{
				m_SKUCode = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public long SKUDist_ID
		{
			get
			{
				return m_Dist_ID;
			}
			set
			{
				m_Dist_ID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKUDist_Price
		{
			get
			{
				return m_Dist_Price;
			}
			set
			{
				m_Dist_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKUTrade_Price
		{
			get
			{
				return m_Trade_Price;
			}
			set
			{
				m_Trade_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKURetail_Price
		{
			get
			{
				return m_Retail_Price;
			}
			set
			{
				m_Retail_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKUTax_Price
		{
			get
			{
				return m_Tax_Price;
			}
			set
			{
				m_Tax_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKUDozen_Price
		{
			get
			{
				return m_Dozen_Price;
			}
			set
			{
				m_Dozen_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKUUnit_Price
		{
			get
			{
				return m_SKU_Unit_Price;
			}
			set
			{
				m_SKU_Unit_Price = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public decimal SKUCase_Price
		{
			get
			{
				return m_Case_Price;
			}
			set
			{
				m_Case_Price = value;
			}
		}
		
		#endregion
	}
}
