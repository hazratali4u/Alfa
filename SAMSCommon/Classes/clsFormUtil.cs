using System;
using System.Collections;
using System.Windows.Forms;
using System.Data ;

namespace SAMSCommon.Classes
{
	/**
	 * Created By: Riyaz Ramzan Ali
	 * Created On: 30/09/2005
	 * Created For: Defining the form functionality.
	 */
	/// <summary>
	/// clsFormUtil contains form utility methods.
	/// </summary>
	public class clsFormUtil
	{
		#region Constructor

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 30/09/2005
		 * Created For: Defining the form functionality.
		 */
		private clsFormUtil()
		{
		}

		#endregion

		#region Static Methods
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 30/09/2005
		 * Created For: Defining the form functionality.
		 */
		public static void SetEntryButtonsEnabilityByCapiton( Button pBtnEntry, String pStrEntryCaption, String pStrSaveCaption, params Control[] pObjDependentControls )
		{
			if( pBtnEntry.Text == pStrSaveCaption )
			{
				// Set the entry button caption to the default.
				pBtnEntry.Text = pStrEntryCaption;
				// Enable all save related controls.
				clsFormUtil.SetControlsEnablity( false, pObjDependentControls );
			}
			else
			{
				// Set the entry button caption to the save.
				pBtnEntry.Text = pStrSaveCaption;
				// Enable all save related controls.
				clsFormUtil.SetControlsEnablity( true, pObjDependentControls );
			}
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 30/09/2005
		 * Created For: Defining the form functionality.
		 */
		public static void SetControlsEnablity( bool pBEnable, params Control[] pObjControls )
		{
			foreach( Control objControl in pObjControls )
			{
				// Assign given enablity to the controls.
				objControl.Enabled = pBEnable;
			}
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 30/09/2005
		 * Created For: Defining the form functionality.
		 */
		public static void SetControlsText( String pStrTextValue, params Control[] pObjTextControls )
		{
			foreach( TextBoxBase objTextControl in pObjTextControls )
			{
				// Assign given the text value to the controls.
				objTextControl.Text = pStrTextValue;
			}
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 30/09/2005
		 * Created For: Defining the form functionality.
		 */
		public static void SetControlsTextAndEnability( String pStrTextValue, bool pBEnable, params Control[] pObjTextControls )
		{
			foreach( TextBoxBase objTextControl in pObjTextControls )
			{
				// Assign given value to the controls appropriate properties.
				objTextControl.Text = pStrTextValue;
				objTextControl.Enabled = pBEnable;
			}
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 05/10/2005
		 * Created For: Defining the BL and form functionality.
		 */
		public static void SetListControlsSelectedIndex( int pNIndex, params ListControl[] pObjListControls )
		{
			foreach( ListControl objListControl in pObjListControls )
			{
				// Assign given the inded value to the controls.
				objListControl.SelectedIndex = pNIndex;
			}
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 03/10/2005
		 * Created For: Defining the form functionality.
		 */
		public static void FillListBox( ListBox pLstControl, ArrayList pObjList )
		{
			clsFormUtil.FillListBox( pLstControl, pObjList, false );
		}
		/**
		 * Updated By: Riyaz Ramzan Ali
		 * Updated On: 13/10/2005
		 * Updated For: Implementing the list sort functionality.
		 */
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 03/10/2005
		 * Created For: Defining the form functionality.
		 */
		public static void FillListBox( ListBox pLstControl, ArrayList pObjList, bool pBClearListItems )
		{
			clsFormUtil.FillListBox( pLstControl,  pObjList, pBClearListItems, true );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 13/10/2005
		 * Created For: Implementing the list sort functionality.
		 */
		public static void FillListBox( ListBox pLstControl, ArrayList pObjList, bool pBClearListItems, bool pBSortList )
		{
			/**
			 * Inserted By: Riyaz Ramzan Ali
			 * Inserted On: 15/10/2005
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
					/**
					 * Inserted By: Riyaz Ramzan Ali
					 * Inserted On: 13/10/2005
					 * Inserted For: Implementing the list sort functionality.
					 */
					if( pBSortList )
					{
						pLstControl.Sorted = true;
					}
					/**
					 * End of Insert.
					 */
				}
				/**
				 * Inserted By: Riyaz Ramzan Ali
				 * Inserted On: 15/10/2005
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

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 05/10/2005
		 * Created For: Defining the BL and form functionality.
		 */
		public static int GetComboBoxItemIndexByKey( ComboBox pCboControl, object pObjItemKey )
		{
			int nResult = -1;
			clsListItems objListItem = null;

			for( int nX = 0; nX < pCboControl.Items.Count; nX++ )
			{
				objListItem = ( clsListItems )pCboControl.Items[ nX ];
				if( objListItem.ItemKey.Equals( pObjItemKey.ToString() ) )
				{
					nResult = nX;
					break;
				}
			}
			
			return( nResult );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 05/10/2005
		 * Created For: Defining the BL and form functionality.
		 */
		public static void SelectComboBoxItemByKey( ComboBox pCboControl, object pObjKey )
		{
			pCboControl.SelectedIndex = clsFormUtil.GetComboBoxItemIndexByKey( pCboControl, pObjKey );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 05/10/2005
		 * Created For: Defining the form functionality.
		 */
		public static void FillComboBox( ComboBox pCboControl, ArrayList pObjList )
		{
			clsFormUtil.FillComboBox( pCboControl, pObjList, false );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 05/10/2005
		 * Created For: Defining the form functionality.
		 */		
		public static void FillComboBox( ComboBox pCboControl, ArrayList pObjList, bool pBClearListItems )
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
		
		/**
			 * Created By: Riyaz Ramzan Ali
			 * Created On: 05/10/2005
			 * Created For: Defining the form functionality.
			 */
		public static void FillComboBox( ComboBox pCboControl, DataTable pObjTable, string KeyFieldName, string TextFieldName )
		{
			clsFormUtil.FillComboBox( pCboControl, pObjTable, KeyFieldName, TextFieldName, false );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 05/10/2005
		 * Created For: Defining the form functionality.
		 */		
		public static void FillComboBox( ComboBox pCboControl, DataTable pObjTable, string KeyFieldName, string TextFieldName, bool pBClearListItems )
		{
			if( pObjTable != null )
			{
				// Clear list items if asked.
				if( pBClearListItems )
				{
					pCboControl.Items.Clear();
				}
				// Add the list elements to the ComboBox.
				foreach( DataRow row in pObjTable.Rows  ) 
				{
					pCboControl.Items.Add( new clsListItems ( row[TextFieldName].ToString() , row[KeyFieldName].ToString() ) );
				}
//
//				for( int nI=0; nI < pObjTable.Rows.Count; nI++ )
//				{
//					// Add each element as clsListItem.
//				
//				}
			} 
			else
			{
				pCboControl.Items.Clear();	
			}
		}
		

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 07/10/2005
		 * Created For: Defining the form functionality.
		 */
		public static void SetDateTimePickerValue( params DateTimePicker[] pDtpControls )
		{
			clsFormUtil.SetDateTimePickerValue( DateTime.Now, pDtpControls );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 07/10/2005
		 * Created For: Defining the form functionality.
		 */
		public static void SetDateTimePickerValue( DateTime pDtmValue, params DateTimePicker[] pDtpControls )
		{
			foreach( DateTimePicker dtpControl in pDtpControls )
			{
				dtpControl.Value = pDtmValue;
			}
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 08/11/2005
		 * Created For: Bug fixing.
		 */
		public static String GetListItemKey( ComboBox pCboSource )
		{
			return( clsFormUtil.GetListItemKey( pCboSource, pCboSource.SelectedIndex ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 08/11/2005
		 * Created For: Bug fixing.
		 */
		public static String GetListItemKey( ComboBox pCboSource, int pNIndex )
		{
			return( clsFormUtil.GetListItemKey( pCboSource, pNIndex, null ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 08/11/2005
		 * Created For: Bug fixing.
		 */
		public static String GetListItemKey( ComboBox pCboSource, String pStrDefaultErrorValue )
		{
			return( clsFormUtil.GetListItemKey( pCboSource, pCboSource.SelectedIndex, pStrDefaultErrorValue ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 08/11/2005
		 * Created For: Bug fixing.
		 */
		public static String GetListItemKey( ComboBox pCboSource, int pNIndex, String pStrDefaultErrorValue )
		{
			String strResult = pStrDefaultErrorValue;
			clsListItems objListItem = null;

			if( pNIndex > -1 )
			{
				objListItem = ( clsListItems )pCboSource.Items[ pNIndex ];
				// On error return the default value.
				strResult = ( objListItem==null )? pStrDefaultErrorValue : objListItem.ItemKey;
			}

			return( strResult );
		}
		#endregion
	}
}
