using System;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// SAMSUserException
	/// <author>Rizwan Ansari</author>
	/// <date></date>
	/// </summary>
	public class SAMSUserException : Exception
	{	
		#region Constructors
		public SAMSUserException(string Message, Exception InnerException) : base(Message, InnerException)
		{
		}
		#endregion
				
		#region Private Variables
		#endregion

		#region public Properties
		#endregion
		
		#region public static Methods
		#endregion

		#region Private Methods
		#endregion
		
		#region public Methods
		#endregion
	}
}
