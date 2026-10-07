using System;
using System.Web.UI.WebControls;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// Summary description for clsListItems.
	/// </summary>
	public class clsListItems
	{
		private string m_itemString;
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
		
	
		public override string ToString()
		{
			return m_itemString;
		}

		
		public clsListItems()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		
		public clsListItems(string itmString , string itmKey)
		{
			m_itemString = itmString;
			m_itemKey = itmKey;	
		}
		
	
		#region Operators
		// Defines implicit SqlParameter[] conversion operator:
		public static implicit operator ListItem( clsListItems pObjListItem )
		{
			return( new ListItem( pObjListItem.m_itemString, pObjListItem.m_itemKey ) );
		}

		#endregion

		#region Static Methods
		
		public static clsListItems ToListItem( ListItem pObjListItem )
		{
			return( new clsListItems( pObjListItem.Text, pObjListItem.Value ) );
		}

		
		#endregion

	}
}
