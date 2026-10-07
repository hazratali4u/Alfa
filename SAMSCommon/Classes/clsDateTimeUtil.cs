using System;
using System.Globalization;

using SAMSCommon.Util.Bit;

/**
 * Updated By: Riyaz Ramzan Ali
 * Updated On: 15/10/2005
 * Updated For: Namespace changed for reusing the FareWheels class for the DMS application.
 */
namespace SAMSCommon.Util.Date
{
	/**
	 * Commented By: Riyaz Ramzan Ali
	 * Commented On: 11/02/2005
	 * Commented For: The Magnetic Card integration.
	 */
	public enum DateTimeResolution 
	{
		Day			= 128,
		Week		= 64,
		Month		= 32,
		Year		= 16,
		Hour		= 8,
		Minute		= 4,
		Second		= 2,
		MilliSecond	= 1
	};
	/**
	 * Created By: Riyaz Ramzan Ali
	 * Created On: 25/01/2005
	 * Created For: The implemenation of the licensed base synchronization.
	 */ 
	/// <summary>
	/// Providing DateTime utility methods.
	/// </summary>
	public class clsDateTimeUtil
	{
		#region Constants
		public const String STR_DB_SHORT_DATE_FORMAT = "MM/dd/yyyy";
		public const String STR_DB_LONG_DATE_FORMAT = "yyy/MM/dd hh:mm:ss.fff";
		public const char CHR_FULL_DATE_TIME_FORMAT = 'F';
		public const string FULL_DATE_TIME_FORMAT_IMPORT = "yyyyMMddHHmmss";
		public const String STR_STD_DATE_FORMAT = "dd-MMM-yyyy";
		#endregion

		#region Static Members
		#region Static Variables
		protected static byte DAYS_PER_WEEK	= 7;
		protected static byte DAYS_PER_MONTH	= 30;
		protected static short DAYS_PER_YEAR	= 365;
		protected static String FULL_DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
		#endregion

		#region Static Properties
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 16/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static byte DaysPerWeek 
		{
			get {	return( DAYS_PER_WEEK );	}
			set {	DAYS_PER_WEEK = value;		}
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 16/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static byte DaysPerMonth 
		{
			get {	return( DAYS_PER_MONTH );	}
			set {	DAYS_PER_MONTH = value;		}
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 16/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static short DaysPerYear 
		{
			get {	return( DAYS_PER_YEAR );	}
			set {	DAYS_PER_YEAR = value;		}
		}
		/// <summary>
		/// NullDateTime represents DateTime with the value  
		/// 1st Jan 1900 00:00:00
		/// </summary>
		public static DateTime NullDateTime 
		{
			get 
			{
				return( new DateTime( 1900, 1, 1, 0, 0, 0, 0 ) );
			}
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 15/10/2005
		 * Created For: Defining the DMS BL and form functionality.
		 */
		public static DateTime FirstDayDateTimeOfCurrentMonth
		{
			get
			{
				return( clsDateTimeUtil.DayDateTimeOfMonth( 1, DateTime.Now ) );
			}
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating DMS Import Utility.
		 */
		public static String FullDateTimeFormat
		{
			get {	return( clsDateTimeUtil.FULL_DATE_TIME_FORMAT );	}
			set {	clsDateTimeUtil.FULL_DATE_TIME_FORMAT = value;		}
		}
		#endregion

		#region Static Methods
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 15/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static DateTime Add( DateTime pDtmSource, int pNValue, DateTimeResolution pEnmResolution ) 
		{
			DateTime pDtmValue = pDtmSource;

			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Year ) )
				pDtmValue = pDtmValue.AddYears( pNValue );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Month ) )
				pDtmValue = pDtmValue.AddMonths( pNValue );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Day ) )
				pDtmValue = pDtmValue.AddDays( pNValue );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Week ) )
				pDtmValue = pDtmValue.AddDays( pNValue * 7 );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Hour ) )
				pDtmValue = pDtmValue.AddHours( pNValue );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Minute ) )
				pDtmValue = pDtmValue.AddMinutes( pNValue );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Second ) )
				pDtmValue = pDtmValue.AddSeconds( pNValue );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.MilliSecond ) )
				pDtmValue = pDtmValue.AddMilliseconds( pNValue );
			
			return( pDtmValue );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 15/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static DateTime Add( DateTime pDtmSource, DateTime pDtmDestination, DateTimeResolution pEnmResolution ) 
		{
			DateTime pDtmValue = pDtmDestination;

			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Year ) )
				pDtmValue = pDtmValue.AddYears( pDtmSource.Year );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Month ) )
				pDtmValue = pDtmValue.AddMonths( pDtmSource.Month );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Day ) )
				pDtmValue = pDtmValue.AddDays( pDtmSource.Day );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Hour ) )
				pDtmValue = pDtmValue.AddHours( pDtmSource.Hour );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Minute ) )
				pDtmValue = pDtmValue.AddMinutes( pDtmSource.Minute );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.Second ) )
				pDtmValue = pDtmValue.AddSeconds( pDtmSource.Second );
			if( clsMaskUtil.CheckByMask( ( byte )pEnmResolution, ( byte )DateTimeResolution.MilliSecond ) )
				pDtmValue = pDtmValue.AddMilliseconds( pDtmSource.Second );

			return( pDtmValue );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 15/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static DateTime AddWeeks( DateTime pDtmSource, int pNWeek ) 
		{
			DateTime pDtmValue;

			pDtmValue = pDtmSource.AddDays( pNWeek * 7 );

			return( pDtmValue );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 16/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static double GetPeriodByResolution( TimeSpan pTspSource, DateTimeResolution pEnmResolution ) 
		{
			double dblPeriod = -1;

			switch( pEnmResolution ) 
			{
				case DateTimeResolution.Year:
					dblPeriod = pTspSource.TotalDays / clsDateTimeUtil.DaysPerYear;
					break;
				case DateTimeResolution.Month:
					dblPeriod = pTspSource.TotalDays / clsDateTimeUtil.DaysPerMonth;
					break;
				case DateTimeResolution.Week:
					dblPeriod = pTspSource.TotalDays / clsDateTimeUtil.DaysPerWeek;
					break;
				case DateTimeResolution.Day:
					dblPeriod = pTspSource.TotalDays;
					break;
				case DateTimeResolution.Hour:
					dblPeriod = pTspSource.TotalHours;
					break;
				case DateTimeResolution.Minute:
					dblPeriod = pTspSource.TotalMinutes;
					break;
				case DateTimeResolution.Second:
					dblPeriod = pTspSource.TotalSeconds;
					break;
				case DateTimeResolution.MilliSecond:
					dblPeriod = pTspSource.TotalMilliseconds;
					break;
//				default:
//					dblPeriod = -1;
			}

			return( dblPeriod );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 22/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static bool IsValid( string pStrDate ) 
		{
			return( clsDateTimeUtil.IsValid( pStrDate, null, DateTimeStyles.None ) );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 22/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static bool IsValid( string pStrDate, IFormatProvider pObjFormatProvider ) 
		{
			return( clsDateTimeUtil.IsValid( pStrDate, pObjFormatProvider, DateTimeStyles.None ) );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 22/02/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static bool IsValid( string pStrDate, IFormatProvider pObjFormatProvider, DateTimeStyles pObjDateTimeStyle ) 
		{
			/*DateTime dtDate;*/
			bool bValid = true;
			try 
			{
				if( pObjFormatProvider == null ) 
					DateTime.Parse( pStrDate );
				else
					/*dtDate = */DateTime.Parse( pStrDate, pObjFormatProvider, pObjDateTimeStyle );
			}
			catch/*( Exception exc )*/  //( FormatException eFormatException ) 
			{
				// Failure due to the unrepresentable DateTime format.
				bValid = false;
			}
			return( bValid );
		}

		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 22/03/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static DateTime ToDateTime( Object pObjDateTime )
		{
			DateTime dtValue = clsDateTimeUtil.NullDateTime;
			
			try
			{
				dtValue = ( DateTime )pObjDateTime;
				dtValue = clsDateTimeUtil.ToDateTime( pObjDateTime.ToString() );
			}
			catch/*( Exception e )*/
			{
				dtValue = clsDateTimeUtil.NullDateTime;				
			}

			return( dtValue );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 22/03/2005
		 * Created For: The Magnetic Card integration.
		 */ 
		public static DateTime ToDateTime( String pStrDateTime )
		{
			DateTime dtValue = clsDateTimeUtil.NullDateTime;
			
			try
			{
				dtValue = DateTime.Parse( pStrDateTime );
			}
			catch/*( Exception e )*/
			{
				dtValue = clsDateTimeUtil.NullDateTime;				
			}

			return( dtValue );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 02/06/2005
		 * Created For: Solving the Shift report error identified at KCR by TO (Nazima).
		 */
		public static String ToLongDateTimeFormat( DateTime pDtmValue )
		{
			return( pDtmValue.ToString( clsDateTimeUtil.STR_DB_LONG_DATE_FORMAT ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 02/06/2005
		 * Created For: Solving the Shift report error identified at KCR by TO (Nazima).
		 */
		public static String ToShortDateTimeFormat( DateTime pDtmValue )
		{
			return( pDtmValue.ToString( clsDateTimeUtil.STR_DB_SHORT_DATE_FORMAT ) );
		}

		public static String ToStandardDateFormat( DateTime pDtmValue )
		{
			return( pDtmValue.ToString( clsDateTimeUtil.STR_STD_DATE_FORMAT ) );
		}
		
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 15/10/2005
		 * Created For: Defining the SAMS BL and form functionality.
		 */
		public static DateTime DayDateTimeOfMonth( int pNDay, DateTime pDtmMonth )
		{
			return( new DateTime( pDtmMonth.Year, pDtmMonth.Month, pNDay ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 15/10/2005
		 * Created For: Defining the SAMS BL and form functionality.
		 */
		public static DateTime FirstDayDateTimeOfMonth( DateTime pDtmMonth )
		{
			return( clsDateTimeUtil.DayDateTimeOfMonth( 1, pDtmMonth ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating SAMS Import Utility.
		 */
		public static DateTime ParseExact( String pStrDateTime, char pChrFormat, String pStrFormatPattern )
		{
			DateTimeFormatInfo fmtDateTime = new DateTimeFormatInfo();
			
			fmtDateTime.FullDateTimePattern = pStrFormatPattern;
			
			return( DateTime.ParseExact( pStrDateTime, "" + pChrFormat, fmtDateTime ) );
		}
		/**
			 * Created By: Mohammad Tariq
			 * Created On: 01/06/2006
			 * Created For: Creating SAMS Import Layer.
			 */
		public static DateTime ParseExact( String pStrDateTime, String pstrFormat, String pStrFormatPattern )
		{
			DateTimeFormatInfo fmtDateTime = new DateTimeFormatInfo();
			
			fmtDateTime.FullDateTimePattern = pStrFormatPattern;
			
			return( DateTime.ParseExact( pStrDateTime, "" + pstrFormat, fmtDateTime ) );
		}
	
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 31/10/2005
		 * Created For: Creating SAMS Import Utility.
		 */
		public static DateTime ParseFullDateTime( String pStrDateTime )
		{
			return( clsDateTimeUtil.ParseExact( pStrDateTime, clsDateTimeUtil.CHR_FULL_DATE_TIME_FORMAT, clsDateTimeUtil.FullDateTimeFormat ) );
		}
		/**
		 * Created By: Mohammad Tariq
		 * Created On: 01/06/2006
		 * Created For: Creating SAMS Import Layer.
		 */
		public static DateTime ParseFullDateTimeImport( String pStrDateTime )
		{
			return( clsDateTimeUtil.ParseExact( pStrDateTime, clsDateTimeUtil.FULL_DATE_TIME_FORMAT_IMPORT, clsDateTimeUtil.FullDateTimeFormat ) );
		}
	
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 01/11/2005
		 * Created For: Creating SAMS Import Utility.
		 */
		public static String ToFullDateTimeString( DateTime pDtmSource )
		{
			return( clsDateTimeUtil.ToFullDateTimeString( pDtmSource, clsDateTimeUtil.CHR_FULL_DATE_TIME_FORMAT, clsDateTimeUtil.FullDateTimeFormat ) );
		}
		/**
		 * Created By: Riyaz Ramzan Ali
		 * Created On: 01/11/2005
		 * Created For: Creating SAMS Import Utility.
		 */
		public static String ToFullDateTimeString( DateTime pDtmSource, char pChrFormat, String pStrFormatPattern )
		{
			DateTimeFormatInfo fmtDateTime = new DateTimeFormatInfo();
			
			fmtDateTime.FullDateTimePattern = pStrFormatPattern;

			return( pDtmSource.ToString( pChrFormat.ToString(), fmtDateTime ) );
		}
		#endregion
		#endregion
	}
}
