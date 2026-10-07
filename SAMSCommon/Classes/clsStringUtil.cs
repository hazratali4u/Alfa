using System;
using System.Collections;
using System.Text;

/**
 * Updated By: Riyaz Ramzan Ali
 * Updated On: 12/10/2005
 * Updated For: Namespace changed for reusing the FareWheels class for the SAMS application.
 */
namespace SAMSCommon.Util.Strings
{
	/**
	 * Inserted By: Riyaz Ramzan Ali
	 * Inserted On: 12/10/2005
	 * Inserted For: FareWheels code reused.
	 */
	/**
	 * Created By: Riyaz Ramzan Ali
	 * Created On: 12/11/2004
	 * Created For: Providing utility string methods.
	 */ 
	/// <summary>
	/// clsStringUtil provides string utility methods.
	/// </summary>
	public class clsStringUtil
	{
		#region Static Variables
		private const bool TRIM_REQUIRED = false;
		#endregion

		#region Static Methods

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 12/11/2004
		 * Created For: Providing utility string methods.
		 */ 
		/// <summary>
		/// Returns the specified substring, from the <code>pNStartIndex</code> to 
		/// the <code>pNLength</code> characters, of the given source <code>String</code> 
		/// object.
		/// </summary>
		/// <param name="pStrSource">A source object.</param>
		/// <param name="pNStartIndex">A start index value.</param>
		/// <param name="pNLength">The number of characters to be obtained.</param>
		/// <returns>A substring object.</returns>
		public static String Substring( String pStrSource, int pNStartIndex, int pNLength ) 
		{
			String strSubstring = "";
			if( pNStartIndex < pStrSource.Length ) 
			{
				if( pNStartIndex + pNLength <= pStrSource.Length ) 
				{
					strSubstring = pStrSource.Substring( pNStartIndex, pNLength );
				} 
				else 
				{
					strSubstring = pStrSource.Substring( pNStartIndex, pStrSource.Length - pNStartIndex  );
				}
			}
			return( strSubstring );
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 12/11/2004
		 * Created For: Providing utility string methods.
		 */ 
		/// <summary>
		/// Returns the specified substring, from the <code>pNStartIndex</code> to 
		/// the <code>pNLength</code> characters, of the given source <code>String</code> 
		/// object.
		/// </summary>
		/// <param name="pStrSource">A source object.</param>
		/// <param name="pNStartIndex">A start index value.</param>
		/// <returns>A substring object.</returns>
		public static String Substring( String pStrSource, int pNStartIndex ) 
		{
			return( clsStringUtil.Substring( pStrSource, pNStartIndex, pStrSource.Length ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 12/11/2004
		 * Created For: Providing utility string methods.
		 */ 
		/// <summary>
		/// Checks whether <code>pStrValue</code> is <code>null</code> or empty.
		/// </summary>
		/// <param name="pStrValue">Value to be checked.</param>
		/// <returns><code>true</code> if <code>pStrValue</code> 
		/// is <code>null</code> or empty.</returns>
		public static bool IsEmpty( String pStrValue ) 
		{
			return( clsStringUtil.IsEmpty( pStrValue, clsStringUtil.TRIM_REQUIRED ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 12/11/2004
		 * Created For: Providing utility string methods.
		 */ 
		/// <summary>
		/// Checks whether <code>pStrValue</code> is <code>null</code> or empty.
		/// </summary>
		/// <param name="pStrValue">Value to be checked.</param>
		/// <param name="pBTrimRequired">Is <code>pStrValue</code> trimming required?</param>
		/// <returns><code>true</code> if <code>pStrValue</code> 
		/// is <code>null</code> or empty.</returns>
		public static bool IsEmpty( String pStrValue, bool pBTrimRequired ) 
		{
			return( pStrValue==null 
				|| ( ( pBTrimRequired )? pStrValue.Trim()=="":pStrValue=="" ) );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 11/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		/// <summary>
		/// Converts a string to its equivalent byte array using 
		/// <code>Encoding.Default</code> encoding scheme.
		/// </summary>
		/// <param name="pStrToConvert">A string to be converted.</param>
		/// <returns>A converted byte array.</returns>
		public static byte[] ToByteArray( String pStrToConvert )
		{
			return( clsStringUtil.ToByteArray( pStrToConvert, Encoding.Default ) );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 11/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		/// <summary>
		/// Converts a <code>String</code> to its equivalent byte array using 
		/// <code>pObjEncoding</code>.
		/// </summary>
		/// <param name="pStrToConvert">A <code>String</code> to be converted.</param>
		/// <param name="pObjEncoding">An encoding used for conversion.</param>
		/// <returns>A converted <code>byte</code> array.</returns>
		public static byte[] ToByteArray( String pStrToConvert, Encoding pObjEncoding )
		{
			return( pObjEncoding.GetBytes( pStrToConvert ) );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 11/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		/// <summary>
		/// Returns the <code>String</code> equivalent of the <code>pBytArray</code> 
		/// using <code>Encoding.Default</code> encoding scheme.
		/// </summary>
		/// <param name="pBytArray">A <code>byte</code> array to be converted.</param>
		/// <returns>A converted <code>String</code> value.</returns>
		public static String ToString( byte[] pBytArray ) 
		{
			return( clsStringUtil.ToString( pBytArray, Encoding.Default ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 29/10/2005
		 * Created For: Creating SAMS Import Utility.
		 */
		/// <summary>
		/// Returns the <code>String</code> equivalent of the <code>pBytArray</code> 
		/// using <code>Encoding.Default</code> encoding scheme.
		/// </summary>
		/// <param name="pBytArray">A <code>byte</code> array to be converted.</param>
		/// <param name="pNLength">Length of byte to use.</param>
		/// <returns>A converted <code>String</code> value.</returns>
		public static String ToString( byte[] pBytArray, int pNLength ) 
		{
			return( clsStringUtil.ToString( pBytArray, pNLength, Encoding.Default ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 11/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		/// <summary>
		/// Returns the <code>String</code> equivalent of the <code>pBytArray</code> 
		/// using <code>pObjEncoding</code>.
		/// </summary>
		/// <param name="pBytArray">A <code>byte</code> array to be converted.</param>
		/// <param name="pObjEncoding">An encoding used for conversion.</param>
		/// <returns>A converted <code>String</code> value.</returns>
		public static String ToString( byte[] pBytArray, Encoding pObjEncoding ) 
		{
			#region Commented Code

			//			// LimitationChange.
			//			//return( pObjEncoding.GetString( pBytArray ) );
			//			return( pObjEncoding.GetString( pBytArray, 0, pBytArray.Length ) );

			#endregion
			return( clsStringUtil.ToString( pBytArray, pBytArray.Length, pObjEncoding ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 29/10/2005
		 * Created For: Creating SAMS Import Utility.
		 */
		/// <summary>
		/// Returns the <code>String</code> equivalent of the <code>pBytArray</code> 
		/// using <code>pObjEncoding</code>.
		/// </summary>
		/// <param name="pBytArray">A <code>byte</code> array to be converted.</param>
		/// <param name="pNLength">Length of byte to use.</param>
		/// <param name="pObjEncoding">An encoding used for conversion.</param>
		/// <returns>A converted <code>String</code> value.</returns>
		public static String ToString( byte[] pBytArray, int pNLength, Encoding pObjEncoding ) 
		{
			// LimitationChange.
			//return( pObjEncoding.GetString( pBytArray ) );
			int nLength = ( pNLength <= pBytArray.Length )? pNLength:pBytArray.Length;
			nLength = ( pNLength < 0 )? 0:pNLength;

			return( pObjEncoding.GetString( pBytArray, 0, nLength ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 21/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		/// <summary>
		/// Converts the given 2-dimensional <code>byte</code> array into 1-dimensional 
		/// <code>String</code>.
		/// </summary>
		/// <param name="pBytNumbers">A 2-dimensional array to be converted.</param>
		/// <returns>A converted 1-dimensional array.</returns>
		public static String[] ToStringArray( byte[][] pBytNumbers ) 
		{
			String[] strArrayResult = new String[ pBytNumbers.Length ];

			for( int x=0; x<pBytNumbers.Length; x++ ) 
			{
				strArrayResult[ x ] = clsStringUtil.ToString( pBytNumbers[ x ] );
			}
			
			return( strArrayResult );
		}
		

		#region New_Inserted_Methods
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 02/03/2005
		 * Created For: The implementation of the Fixed-TPM related work.
		 */ 
		/// <summary>
		/// Returns the <code>pStrValue</code> if not empty else returns the 
		/// <code>pStrDefaultValue</code>.
		/// </summary>
		/// <param name="pStrValue">A value to be checked and returned.</param>
		/// <param name="pStrDefaultValue">A default value to be returned 
		/// if <code>pStrValue</code> is empty.</param>
		/// <param name="pBTrimRequired">Is <code>pStrValue</code> trimming required?</param>
		/// <returns>A value based on the condition.</returns>
		public static String ToDefaultString( String pStrValue, String pStrDefaultValue, bool pBTrimRequired )
		{
			#region Commented code
//			if( pBTrimRequired ) 
//			{
//				return( clsStringUtil.IsEmpty( pStrValue, pBTrimRequired )? pStrDefaultValue.Trim() : pStrValue.Trim() );
//			} 
//			return( clsStringUtil.IsEmpty( pStrValue )? pStrDefaultValue: pStrValue );
			#endregion
			String strValue = ( pBTrimRequired )? pStrDefaultValue.Trim():pStrDefaultValue;
			
			if( ! clsStringUtil.IsEmpty( pStrValue, pBTrimRequired ) )
			{
				strValue = ( pBTrimRequired )? pStrValue.Trim():pStrValue;
			}
			return( strValue );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 02/03/2005
		 * Created For: The implementation of the Fixed-TPM related work.
		 */ 
		/// <summary>
		/// Returns the <code>pStrValue</code> if not empty else returns the 
		/// <code>pStrDefaultValue</code>.
		/// </summary>
		/// <param name="pStrValue">A value to be checked and returned.</param>
		/// <param name="pStrDefaultValue">A default value to be returned 
		/// if <code>pStrValue</code> is empty.</param>
		/// <returns>A value based on the condition.</returns>
		public static String ToDefaultString( String pStrValue, String pStrDefaultValue )
		{
			return( clsStringUtil.ToDefaultString( pStrValue, pStrDefaultValue, clsStringUtil.TRIM_REQUIRED ) );
		}
		/// <summary>
		/// Returns a value containing as many repeated <code>pCRepeatValue</code> as 
		/// <code>pLngRepetition</code>.
		/// </summary>
		/// <param name="pCRepeatValue">A character to be repeated.</param>
		/// <param name="pLngRepetition">Number of times a <code>pCRepeatValue</code> to be repeated.</param>
		/// <returns>A value containing repeated <code>pCRepeatValue</code>.</returns>
		public static String ToRepeatedString( char pCRepeatValue, long pLngRepetition )
		{
			return( clsStringUtil.ToRepeatedString( pCRepeatValue.ToString(), pLngRepetition ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 04/03/2005
		 * Created For: The implementation of the Fixed-TPM related work.
		 */ 
		/// <summary>
		/// Returns a value containing as many repeated <code>pStrRepeatValue</code> as 
		/// <code>pLngRepetition</code>.
		/// </summary>
		/// <param name="pStrRepeatValue">A character to be repeated.</param>
		/// <param name="pLngRepetition">Number of times a <code>pStrRepeatValue</code> to be repeated.</param>
		/// <returns>A value containing repeated <code>pStrRepeatValue</code>.</returns>
		public static String ToRepeatedString( String pStrRepeatValue, long pLngRepetition )
		{
			String strValue = "";

			for( long i=0; i<pLngRepetition; i++ )
			{
				strValue += pStrRepeatValue;
			}
			return( strValue );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 08/03/2005
		 * Created For: The implementation of the MassTransit's KCR related work.
		 */ 
		/// <summary>
		/// Returns a resolved <code>String</code> value as a <code>pStrValue</code> 
		/// if not empty else retuns an empty <code>String</code>.
		/// </summary>
		/// <param name="pStrValue">A <code>String</code> value to be checked and returned.</param>
		/// <param name="pBTrimRequired">Is <code>pStrValue</code> trimming required?</param>
		/// <returns>A resolved <code>String</code> value </returns>
		public static String ToString( String pStrValue, bool pBTrimRequired )
		{
			return( clsStringUtil.ToDefaultString( pStrValue, String.Empty, pBTrimRequired ) );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 08/03/2005
		 * Created For: The implementation of the MassTransit's KCR related work.
		 */ 
		/// <summary>
		/// Returns a resolved <code>String</code> value as a <code>pStrValue</code> 
		/// if not empty else retuns an empty <code>String</code>.
		/// </summary>
		/// <param name="pStrValue">A <code>String</code> value to be checked and returned.</param>
		/// <returns>A resolved <code>String</code> value </returns>
		public static String ToString( String pStrValue )
		{
			return( clsStringUtil.ToString( pStrValue, clsStringUtil.TRIM_REQUIRED ) );
		}

		#endregion

		#region New Methods: SAMS Import Utility
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 07/11/2005
		 * Created For: Creating Import Utility.
		 */
		/// <summary>
		/// Returns the tokens of the source string based on the given delimiter.
		/// </summary>
		/// <param name="pStrSource">The source string.</param>
		/// <param name="pStrDelimiter">The delimiter string.</param>
		/// <returns>The tokens.</returns>
		public static String[] GetTokens( String pStrSource, String pStrDelimiter )
		{
			String[] strResult = null;
			ArrayList objList = new ArrayList();
			String strLeftToken = null;
			String strRemainingPart = null;
			int nIndex = -1;
			
			strRemainingPart = pStrSource;
			if( ! clsStringUtil.IsEmpty( strRemainingPart ) )
			{
				do
				{
					nIndex = strRemainingPart.IndexOf( pStrDelimiter, 0 );

					if( nIndex > -1 )
					{
						strLeftToken = strRemainingPart.Substring( 0, nIndex );
						objList.Add( strLeftToken );
						strRemainingPart = strRemainingPart.Substring( nIndex + pStrDelimiter.Length );
					}
				} while( nIndex > -1 );
			}
			objList.Add( strRemainingPart );
			strResult = ( String[] )objList.ToArray( typeof( String ) );

			return( strResult );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 07/11/2005
		 * Created For: Creating Import Utility.
		 */
		/// <summary>
		/// Returns the token count of the source string based on the given delimiter.
		/// </summary>
		/// <param name="pStrSource">The source string.</param>
		/// <param name="pStrDelimiter">The delimiter string.</param>
		/// <returns>The token count.</returns>
		public static int GetTokenCount( String pStrSource, String pStrDelimiter )
		{
			return( clsStringUtil.GetTokens( pStrSource, pStrDelimiter ).Length );
		}
		#endregion

		#endregion
	}
}
