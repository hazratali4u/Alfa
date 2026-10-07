using System;
using System.IO;
using SAMSCommon.Util.Strings;
//using FileNamingConstants = DMSImportUtility.Globals.clsIUConstants.DataFilesConstants.FileNamingConstants;

namespace SAMSCommon.Util.IO
{
	/**
	 * Created By: Riyaz Ramzan Ali
	 * Created On: 27/10/2005
	 * Created For: Creating SAMS Import Utility.
	 */
	/// <summary>
	/// Summary description for clsFileUtil.
	/// </summary>
	public class clsFileUtil
	{
		#region Instance Members

		private clsFileUtil()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

		#region Static Members

		#region Static Properties
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating Import Utility.
		 */
		public static bool IsFullFileName( String pStrFileName )
		{
			bool bResult = false;
			String strName = null;
			String strPath = null;

			clsFileUtil.GetFileInfo( pStrFileName, out strPath, out strName );
			bResult = ( clsStringUtil.IsEmpty( strPath, true ) 
						&& clsStringUtil.IsEmpty( strName, true ) );
			
			return( bResult );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating Import Utility.
		 */
		public static void GetFileInfo( String pStrFileName, out String pStrPath, out String pStrName )
		{
			pStrName = null;
			pStrPath = null;
			
			int nIndex = 0;
			
			nIndex = pStrFileName.LastIndexOf( @"\" );
			// Get path.
			if( nIndex > 0 )
			{
				pStrPath = pStrFileName.Substring( 0, nIndex );
			}
			nIndex = ( nIndex >= 0 && nIndex + 1 < pStrFileName.Length )
					 ? nIndex + 1
					 : 0;
			// Get name.
			pStrName = pStrFileName.Substring( nIndex );
		}

		/**
			 * Created By: Mohammad Tariq
			 * Created On: 30/05/2006
			 * Created For: Changing Import Utility according to distributor files.
			 */
		public static String GetDistributorCode( String pStrFileName )
		{
			String strResult	= "";
			
			int nStartIndex = 0;
	
			//nIndex = strResult.IndexOf( "_" );
			int nEndIndex = pStrFileName.IndexOf( "_" );
			if( nEndIndex != -1 )
			{
				strResult = pStrFileName.Substring( nStartIndex, nEndIndex - nStartIndex );
			}
			return( strResult );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating Import Utility.
		 */
		public static String GetFileName( String pStrFileName )
		{
			return( clsFileUtil.GetFileName( pStrFileName, true ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating Import Utility.
		 */
		public static String GetFileName( String pStrFileName, bool pBWantExtension )
		{
			String strResult = null;
			String strFilePath = null;

			clsFileUtil.GetFileInfo( pStrFileName, out strFilePath, out strResult );
			
			if( ! pBWantExtension )
			{
				int nIndex = 0;
	
				nIndex = strResult.LastIndexOf( "." );
				if( nIndex > 0 
					&& nIndex + 1 < strResult.Length )
				{
					nIndex++;
					strResult = strResult.Substring( 0, nIndex - 1 );
				}
			}

			return( strResult );
		}
		#endregion

		#region Static Methods
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 27/10/2005
		 * Created For: Creating Import Utility.
		 */
		public static string Read( string pStrFilePath )
		{
			return( clsFileUtil.Read( pStrFilePath, 256 ) );
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 27/10/2005
		 * Created For: Creating Import Utility.
		 */
		public static string Read( string pStrFilePath, int pNBufferSize )
		{
			String strResult = null;
			FileStream objReadStream = null;
			byte[] bytBuffer = new byte[ pNBufferSize ];
			int nRead = 0;

			try
			{
				objReadStream = File.OpenRead( pStrFilePath );
				strResult = "";
				while( ( nRead = objReadStream.Read( bytBuffer, 0, bytBuffer.Length ) ) > 0 )
				{
					// conver the char to string.
					strResult += clsStringUtil.ToString( bytBuffer, nRead );
				}
			}
			finally
			{
				if( objReadStream != null )
				{
					objReadStream.Close();
					objReadStream = null;
				}
			}

			return( strResult );
		}

		
		#endregion

		#endregion
	}
}
