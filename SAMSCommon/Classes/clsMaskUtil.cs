/**
 * Updated By: Riyaz Ramzan Ali
 * Updated On: 15/10/2005
 * Updated For: Namespace changed for reusing the FareWheels class for the SAMS application.
 */
namespace SAMSCommon.Util.Bit
{
	/**
	 * Created By: Riyaz Ramzan Ali
	 * Created On: 12/02/2005
	 * Created For: The Magnetic Card integration.
	 */
	/// <summary>
	/// Summary description for clsMaskUtil.
	/// </summary>
	public class clsMaskUtil
	{
		public const byte OnMask	= 0xFF; //255;	//1111 1111
		public const byte OffMask	= 0x00; //0;	//0000 0000

		/**
		 * Commented By: Riyaz Ramzan Ali
		 * Commented On: 12/02/2005
		 * Commented For: The Magnetic Card integration.
		 */
		public static bool CheckByMask( byte pBValue, byte pBMask ) 
		{
			return( ( pBValue & pBMask ) == pBMask );
		}
		
		/**
		 * Commented By: Riyaz Ramzan Ali
		 * Commented On: 12/02/2005
		 * Commented For: The Magnetic Card integration.
		 */
		public static bool CheckByReverseMask( byte pBValue, byte pBReverseMask ) 
		{
			return( ( pBValue | pBReverseMask ) == pBReverseMask );
		}
	}
}
