using System;
using System.Data;
using System.Collections;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// Summary description for clsDataSetUtil.
	/// </summary>
	public class clsDataSetUtil
	{
		public clsDataSetUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName , ArrayList SelectedColumn)
		{	
			DataTable dt = new DataTable(TableName);
			foreach( String ColName in SelectedColumn )
			{
					dt.Columns.Add(ColName, SourceTable.Columns[ColName].DataType);	
			}		
			
			object LastValue = null; 
			foreach (DataRow dr in SourceTable.Select("",  FieldName))
			{
				if (  LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])) ) 
				{					
					LastValue = dr[FieldName]; 
					
					DataRow NewDr = dt.NewRow() ;
					
					foreach( String ColName in SelectedColumn )
					{
						NewDr[ ColName ] = dr[ColName] ;
					}	
					
					dt.Rows.Add( NewDr );
				}
			}
			
			return dt;
		}
		
		private static bool ColumnEqual(object A, object B)
		{
	
			// Compares two values to see if they are equal. Also compares DBNULL.Value.
			// Note: If your DataTable contains object fields, then you must extend this
			// function to handle them in a meaningful way if you intend to group on them.
			
			if ( A == DBNull.Value && B == DBNull.Value ) //  both are DBNull.Value
				return true; 
			if ( A == DBNull.Value || B == DBNull.Value ) //  only one is DBNull.Value
				return false; 
			return ( A.Equals(B) );  // value type standard comparison
		}
	}
}
