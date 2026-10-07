using System;


namespace SAMSCommon.Classes
{	/// <author>
	/// Naveed Mahmood
	/// </author>
	/// <summary>
	/// Summary description for clsCheckedListItems.
	/// This class is designed to work with CheckedListBoxes
	/// It is same as clsListItems but with an extra member m_checkState
	/// to hold the checked state of the Item.
	/// </summary>
	public class clsCheckedListItems
	{
		private string m_itemString;
		private string m_itemKey;
		private int imageIndex=-1;
		private bool m_checkState;

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

		public bool CheckState
		{
			get
			{
				return m_checkState;
			}
			set
			{
				m_checkState = value;
			}
		}

		public override string ToString()
		{
			return m_itemString;
		}

		public clsCheckedListItems()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public clsCheckedListItems(string pItemString, string pItemKey, bool pCheckState)
		{
			m_itemString = pItemString;
			m_itemKey = pItemKey;
			m_checkState = pCheckState;
		}
	}
}
