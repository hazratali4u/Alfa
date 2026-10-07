using System;

namespace SAMSCommon.Classes
{
	/// <summary>	
	/// Summary description for clsDetailListItems.
	/// </summary>
	public class clsDetailListItems
	{
		private bool m_itemType;
		private string m_itemString;
		private string m_itemParentKey;
		private string m_itemKey;
		private int imageIndex=-1;

		public int ImageIndex
		{
			get
			{
				return imageIndex;

			}
			set
			{
				imageIndex=value;


			}
		}
		public bool ItemType
		{
			get
			{
				return m_itemType;
			}
			set
			{
				m_itemType=value;
			}
		}

		public string ItemString
		{
			get
			{
				return m_itemString;
			}
			set
			{
				m_itemString=value;
			}
		}

		public string ItemParentKey
		{
			get
			{
				return m_itemParentKey;
			}
			set
			{
				m_itemParentKey=value;
			}
		}

		public string ItemKey
		{
			get
			{
				return m_itemKey;
			}
			set
			{
				m_itemKey=value;
			}
		}

		
		public override string ToString()
		{
			return m_itemString;
		}


		public clsDetailListItems()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public clsDetailListItems(bool itmType, string itmString , string itmParentKey, string itmKey)
		{
			m_itemType = itmType;
			m_itemString = itmString;
			m_itemParentKey = itmParentKey;	
			m_itemKey = itmKey;	
		}
	}
}
