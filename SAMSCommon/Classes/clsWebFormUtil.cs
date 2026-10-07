using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAMSCommon.Classes
{
	/**
	 * Created By: Riyaz Ramzan Ali
	 * Created On: 16/01/2006
	 * Created For: Implementing role based login.
	 */
	/// <summary>
	/// Summary description for clsWebFormUtil.
	/// </summary>
	public class clsWebFormUtil
	{
		#region Instance Members

		#region Constructors

		private clsWebFormUtil()
		{
		}

		#endregion

		#endregion

		#region Static Methods
		
		public static void SetEntryButtonsEnabilityByCapiton( Button pBtnEntry, string pStrEntryCaption, string pStrSaveCaption, params WebControl[] pObjDependentControls )
		{
			if( pBtnEntry.Text == pStrSaveCaption )
			{
				// Set the entry button caption to the default.
				pBtnEntry.Text = pStrEntryCaption;
				// Enable all save related controls.
				clsWebFormUtil.SetWebControlsEnability( false, pObjDependentControls );
			}
			else
			{
				// Set the entry button caption to the save.
				pBtnEntry.Text = pStrSaveCaption;
				// Enable all save related controls.
				clsWebFormUtil.SetWebControlsEnability( true, pObjDependentControls );
			}
		}
		
		
		public static void SetWebControlsEnability( bool pBEnable, params WebControl[] pObjControls )
		{
			foreach( WebControl objControl in pObjControls )
			{
				// Assign given enablity to the controls.
				objControl.Enabled = pBEnable;
			}
		}
		
		
		public static void SetTextBoxText( String pStrTextValue, params TextBox[] pObjTextControls )
		{
			foreach( TextBox objTextControl in pObjTextControls )
			{
				// Assign given the text value to the controls.
				objTextControl.Text = pStrTextValue;
			}
		}
		
		
		public static void SetControlsTextAndEnability( String pStrTextValue, bool pBEnable, params Control[] pObjTextControls )
		{
			foreach( TextBox objTextControl in pObjTextControls )
			{
				// Assign given value to the controls appropriate properties.
				objTextControl.Text = pStrTextValue;
				objTextControl.Enabled = pBEnable;
			}
		}
		
		
		public static void SetListControlsSelectedIndex( int pNIndex, params ListControl[] pObjListControls )
		{
			foreach( ListControl objListControl in pObjListControls )
			{
				// Assign given the inded value to the controls.
				objListControl.SelectedIndex = pNIndex;
			}
		}		
		
		
		#region Check Box List
		
		public static void FillListBox( CheckBoxList pLstControl, ArrayList pObjList )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjList, false );
		}
		
		
		public static void FillListBox( CheckBoxList pLstControl, ArrayList pObjList, bool pBClearListItems )
		{
			clsWebFormUtil.FillListBox( pLstControl,  pObjList, pBClearListItems, true );
		}
		
		
		public static void FillListBox( CheckBoxList pLstControl, ArrayList pObjList, bool pBClearListItems, bool pBSortList )
		{
			/**			 
			 * Inserted For: Allowing the clearing of the list.
			 */
			if( pLstControl != null )
			{
				if( pObjList != null )
				{
					// Clear list items if asked.
					if( pBClearListItems )
					{
						pLstControl.Items.Clear();
					}
					// Add the list elements to the ListBox.
					for( int nI=0; nI < pObjList.Count; nI++ )
					{
						// Add each element as clsListItem.
						pLstControl.Items.Add( ( clsListItems )pObjList[ nI ] );
					}
					
					if( pBSortList )
					{
						/**
							 * Inserted and Commented For: Implementing role based login. No such property available for the web ListBox controls.
						 */
						//pLstControl.Sorted = true;
						/**
						 * End of Insert and Comment.
						 */
					}
					/**
					 * End of Insert.
					 */
				}
					/**
						 * Inserted For: Allowing the clearing of the list.
					 */
				else
				{
					pLstControl.Items.Clear();
				}
				/**
				 * End of Update.
				 */
			}
		}
		
		public static void FillListBox( CheckBoxList pLstControl, DataTable pObjTable, int pColKey, int pColValue )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, false );
		}
		
	
		public static void FillListBox( CheckBoxList pLstControl, DataTable pObjTable, int pColKey, int pColValue,  bool pBClearListItems )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, pBClearListItems, true );
		}
		
	
		public static void FillListBox( CheckBoxList pLstControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems, bool pBSortList )
		{
			/**			 
			 * Inserted For: Allowing the clearing of the list.
			 */
			if( pLstControl != null )
			{
				if( pObjTable != null )
				{
					// Clear list items if asked.
					if( pBClearListItems )
					{
						pLstControl.Items.Clear();
					}
					// Add the list elements to the ListBox.
					for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
					{
						// Add each element as clsListItem.
						pLstControl.Items.Add( new clsListItems ( pObjTable.Rows[nI][pColValue].ToString(), pObjTable.Rows[nI][pColKey].ToString() ) );
					}
					
					if( pBSortList )
					{
						/**
							 * Inserted and Commented For: Implementing role based login. No such property available for the web ListBox controls.
						 */
						//pLstControl.Sorted = true;
						/**
						 * End of Insert and Comment.
						 */
					}
					/**
					 * End of Insert.
					 */
				}
					/**
						 * Inserted For: Allowing the clearing of the list.
					 */
				else
				{
					pLstControl.Items.Clear();
				}
				/**
				 * End of Update.
				 */
			}
		}
		
		
		public static void FillListBox( CheckBoxList pLstControl, DataTable pObjTable, string pColKey, string pColValue )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, false );
		}
		
	
		public static void FillListBox( CheckBoxList pLstControl, DataTable pObjTable, string pColKey, string pColValue,  bool pBClearListItems )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, pBClearListItems, true );
		}
		
	
		public static void FillListBox( CheckBoxList pLstControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems, bool pBSortList )
		{
			/**			 
			 * Inserted For: Allowing the clearing of the list.
			 */
			if( pLstControl != null )
			{
				if( pObjTable != null )
				{
					// Clear list items if asked.
					if( pBClearListItems )
					{
						pLstControl.Items.Clear();
					}
					// Add the list elements to the ListBox.
					for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
					{
						// Add each element as clsListItem.
						pLstControl.Items.Add( new clsListItems ( pObjTable.Rows[nI][pColValue].ToString(), pObjTable.Rows[nI][pColKey].ToString() ) );
					}
					
					if( pBSortList )
					{
						/**
							 * Inserted and Commented For: Implementing role based login. No such property available for the web ListBox controls.
						 */
						//pLstControl.Sorted = true;
						/**
						 * End of Insert and Comment.
						 */
					}
					/**
					 * End of Insert.
					 */
				}
					/**
						 * Inserted For: Allowing the clearing of the list.
					 */
				else
				{
					pLstControl.Items.Clear();
				}
				/**
				 * End of Update.
				 */
			}
		}
		
		
		#endregion

		#region List Box
		
		public static void FillListBox( ListBox pLstControl, ArrayList pObjList )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjList, false );
		}
		
		
		public static void FillListBox( ListBox pLstControl, ArrayList pObjList, bool pBClearListItems )
		{
			clsWebFormUtil.FillListBox( pLstControl,  pObjList, pBClearListItems, true );
		}
		
		
		public static void FillListBox( ListBox pLstControl, ArrayList pObjList, bool pBClearListItems, bool pBSortList )
		{
			/**			 
			 * Inserted For: Allowing the clearing of the list.
			 */
			if( pLstControl != null )
			{
				if( pObjList != null )
				{
					// Clear list items if asked.
					if( pBClearListItems )
					{
						pLstControl.Items.Clear();
					}
					// Add the list elements to the ListBox.
					for( int nI=0; nI < pObjList.Count; nI++ )
					{
						// Add each element as clsListItem.
						pLstControl.Items.Add( ( clsListItems )pObjList[ nI ] );
					}
					
					if( pBSortList )
					{
						/**
						 	 * Inserted and Commented For: Implementing role based login. No such property available for the web ListBox controls.
						 */
						//pLstControl.Sorted = true;
						/**
						 * End of Insert and Comment.
						 */
					}
					/**
					 * End of Insert.
					 */
				}
					/**
						 * Inserted For: Allowing the clearing of the list.
					 */
				else
				{
					pLstControl.Items.Clear();
				}
				/**
				 * End of Update.
				 */
			}
		}
		
		public static void FillListBox( ListBox pLstControl, DataTable pObjTable, int pColKey, int pColValue )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, false );
		}
		
	
		public static void FillListBox( ListBox pLstControl, DataTable pObjTable, int pColKey, int pColValue,  bool pBClearListItems )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, pBClearListItems, true );
		}
		
	
		public static void FillListBox( ListBox pLstControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems, bool pBSortList )
		{
			/**			 
			 * Inserted For: Allowing the clearing of the list.
			 */
			if( pLstControl != null )
			{
				if( pObjTable != null )
				{
					// Clear list items if asked.
					if( pBClearListItems )
					{
						pLstControl.Items.Clear();
					}
					// Add the list elements to the ListBox.
					for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
					{
						// Add each element as clsListItem.
						pLstControl.Items.Add( new clsListItems ( pObjTable.Rows[nI][pColValue].ToString(), pObjTable.Rows[nI][pColKey].ToString() ) );
					}
					
					if( pBSortList )
					{
						/**
							 * Inserted and Commented For: Implementing role based login. No such property available for the web ListBox controls.
						 */
						//pLstControl.Sorted = true;
						/**
						 * End of Insert and Comment.
						 */
					}
					/**
					 * End of Insert.
					 */
				}
					/**
						 * Inserted For: Allowing the clearing of the list.
					 */
				else
				{
					pLstControl.Items.Clear();
				}
				/**
				 * End of Update.
				 */
			}
		}
		
		
		public static void FillListBox( ListBox pLstControl, DataTable pObjTable, string pColKey, string pColValue )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, false );
		}
		
	
		public static void FillListBox( ListBox pLstControl, DataTable pObjTable, string pColKey, string pColValue,  bool pBClearListItems )
		{
			clsWebFormUtil.FillListBox( pLstControl, pObjTable, pColKey , pColValue, pBClearListItems, true );
		}
		
	
		public static void FillListBox( ListBox pLstControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems, bool pBSortList )
		{
			/**			 
			 * Inserted For: Allowing the clearing of the list.
			 */
			if( pLstControl != null )
			{
				if( pObjTable != null )
				{
					// Clear list items if asked.
					if( pBClearListItems )
					{
						pLstControl.Items.Clear();
					}
					// Add the list elements to the ListBox.
					for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
					{
						// Add each element as clsListItem.
						pLstControl.Items.Add( new clsListItems ( pObjTable.Rows[nI][pColValue].ToString(), pObjTable.Rows[nI][pColKey].ToString() ) );
					}
					
					if( pBSortList )
					{
						/**
							 * Inserted and Commented For: Implementing role based login. No such property available for the web ListBox controls.
						 */
						//pLstControl.Sorted = true;
						/**
						 * End of Insert and Comment.
						 */
					}
					/**
					 * End of Insert.
					 */
				}
					/**
						 * Inserted For: Allowing the clearing of the list.
					 */
				else
				{
					pLstControl.Items.Clear();
				}
				/**
				 * End of Update.
				 */
			}
		}
		
		
		#endregion
		
		#region Drop Down

		public static int GetDropDownListItemIndexByKey( DropDownList pCboControl, object pObjItemKey )
		{
			int nResult = -1;
			clsListItems objListItem = null;

			for( int nX = 0; nX < pCboControl.Items.Count; nX++ )
			{
				objListItem = clsListItems.ToListItem( pCboControl.Items[ nX ] );
				if( objListItem.ItemKey.Equals( pObjItemKey.ToString() ) )
				{
					nResult = nX;
					break;
				}
			}
			
			return( nResult );
		}

		
		public static void SelectDropDownListItemByKey( DropDownList pCboControl, object pObjKey )
		{
			pCboControl.SelectedIndex = clsWebFormUtil.GetDropDownListItemIndexByKey( pCboControl, pObjKey );
		}
		
		
		public static void FillDropDownList( DropDownList pCboControl, ArrayList pObjList )
		{
			clsWebFormUtil.FillDropDownList( pCboControl, pObjList, false );
		}
		
		
		public static void FillDropDownList( DropDownList pCboControl, ArrayList pObjList, bool pBClearListItems )
		{
			if( pObjList != null )
			{
				// Clear list items if asked.
				if( pBClearListItems )
				{
					pCboControl.Items.Clear();
				}
				// Add the list elements to the ComboBox.
				for( int nI=0; nI < pObjList.Count; nI++ )
				{
					// Add each element as clsListItem.
					pCboControl.Items.Add( ( clsListItems )pObjList[ nI ] );
				}
			} 
			else
			{
				pCboControl.Items.Clear();	
			}
		}

		public static void FillDropDownList( DropDownList pCboControl, DataTable pObjTable, string pColKey, string pColValue )
		{
			clsWebFormUtil.FillDropDownList( pCboControl, pObjTable, pColKey, pColValue, false );
		}
		
	
		public static void FillDropDownList( DropDownList pCboControl, DataTable pObjTable, string pColKey, string pColValue, bool pBClearListItems )
		{
			if( pObjTable != null )
			{
				// Clear list items if asked.
				if( pBClearListItems )
				{
					pCboControl.Items.Clear();
				}
				// Add the list elements to the ComboBox.
				for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
				{
					// Add each element as clsListItem.
					pCboControl.Items.Add( new clsListItems ( pObjTable.Rows[nI][pColValue].ToString(), pObjTable.Rows[nI][pColKey].ToString() ) );					
				}
			} 
			else
			{
				pCboControl.Items.Clear();	
			}
		}


		public static void FillDropDownList( DropDownList pCboControl, DataTable pObjTable, int pColKey, int pColValue )
		{
			clsWebFormUtil.FillDropDownList( pCboControl, pObjTable, pColKey, pColValue, false );
		}
		
	
		public static void FillDropDownList( DropDownList pCboControl, DataTable pObjTable, int pColKey, int pColValue, bool pBClearListItems )
		{
			if( pObjTable != null )
			{
				// Clear list items if asked.
				if( pBClearListItems )
				{
					pCboControl.Items.Clear();
				}
				// Add the list elements to the ComboBox.
				for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
				{
					// Add each element as clsListItem.
					pCboControl.Items.Add( new clsListItems ( pObjTable.Rows[nI][pColValue].ToString(), pObjTable.Rows[nI][pColKey].ToString() ) );					
				}
			} 
			else
			{
				pCboControl.Items.Clear();	
			}
		}



		public static String GetListItemKey( DropDownList pCboSource )
		{
			return( clsWebFormUtil.GetListItemKey( pCboSource, pCboSource.SelectedIndex ) );
		}
		
		
		public static String GetListItemKey( DropDownList pCboSource, int pNIndex )
		{
			return( clsWebFormUtil.GetListItemKey( pCboSource, pNIndex, null ) );
		}
		
		
		public static String GetListItemKey( DropDownList pCboSource, String pStrDefaultErrorValue )
		{
			return( clsWebFormUtil.GetListItemKey( pCboSource, pCboSource.SelectedIndex, pStrDefaultErrorValue ) );
		}
		
		
		public static String GetListItemKey( DropDownList pCboSource, int pNIndex, String pStrDefaultErrorValue )
		{
			String strResult = pStrDefaultErrorValue;
			clsListItems objListItem = null;

			if( pNIndex > -1 )
			{
				objListItem = clsListItems.ToListItem( pCboSource.Items[ pNIndex ] );
				// On error return the default value.
				strResult = ( objListItem==null )? pStrDefaultErrorValue : objListItem.ItemKey;
			}

			return( strResult );
		}

		#endregion

		#region Commented Code

		//		/**
		//		 * Created For: Implementing role based login.
		//		 */
		//		public static void SetDateTimePickerValue( params DateTimePicker[] pDtpControls )
		//		{
		//			clsWebFormUtil.SetDateTimePickerValue( DateTime.Now, pDtpControls );
		//		}
		//		/**
		//			 * Created For: Implementing role based login.
		//		 */
		//		public static void SetDateTimePickerValue( DateTime pDtmValue, params DateTimePicker[] pDtpControls )
		//		{
		//			foreach( DateTimePicker dtpControl in pDtpControls )
		//			{
		//				dtpControl.Value = pDtmValue;
		//			}
		//		}

		#endregion
		
		
		#endregion

	}
}
