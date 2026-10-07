using System;
using System.IO;
using System.Text;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// ExceptionPublisher
	/// <author>Rizwan Ansari</author>
	/// <date>19-06-2007</date>
	/// </summary>
	public class ExceptionPublisher
	{	
		#region Constructors
		public ExceptionPublisher()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
				
		#region Private Variables
		#endregion

		#region public Properties
		#endregion
		
		#region public static Methods
		public static void PublishException(Exception exception)
		{
			try
			{
				string mLogFilePath = Constants.fldLogFileFolder;
				if(mLogFilePath == null || mLogFilePath == "")
				{
					throw new Exception("");
				}

				StringBuilder strInfo = new StringBuilder();

				// Record the contents of the AdditionalInfo collection.
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "Machine Name:" , Environment.MachineName.ToString ());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "User Name   :" , Environment.UserName.ToString ());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "OS Version  :" , Environment.OSVersion.ToString ());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "Date Time   :" , DateTime.Now.ToString ("dd MMM yy hh:mm:ss" ));			
			
				//Get File name with Date
				string mstrFileName=mLogFilePath + "SAMSErrorLog" + System.DateTime.Today.ToString ("yyyyMMdd") + ".log";

				// Append the exception text
				strInfo.AppendFormat("{0}Exception Information:{0}{1}", Environment.NewLine, exception.ToString());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "" , "----------------------------------");						
				// Write the entry to the log file.   
				using ( FileStream fs = File.Open(mstrFileName,
							FileMode.Append,FileAccess.Write ))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						sw.Write(strInfo.ToString());
					}
				}
			}
			catch(Exception exp)
			{
				throw new SAMSUserException(Constants.expPublishExceptionError, exp);
			}
		}
        public static void PublishException(string Message)
        {
            try
            {
                string mLogFilePath = Constants.fldLogFileFolder;
                if (mLogFilePath == null || mLogFilePath == "")
                {
                    throw new Exception("");
                }

                StringBuilder strInfo = new StringBuilder();

                // Record the contents of the AdditionalInfo collection.
                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Machine Name:", Environment.MachineName.ToString());
                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, "User Name   :", Environment.UserName.ToString());
                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, "OS Version  :", Environment.OSVersion.ToString());
                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, "Date Time   :", DateTime.Now.ToString("dd MMM yy hh:mm:ss"));

                //Get File name with Date
                string mstrFileName = mLogFilePath + "SAMSErrorLog" + System.DateTime.Today.ToString("yyyyMMdd") + ".log";

                // Append the exception text
                strInfo.AppendFormat("{0}Exception Information:{0}{1}", Environment.NewLine, Message.ToString());
                strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, "", "----------------------------------");
                // Write the entry to the log file.   
                using (FileStream fs = File.Open(mstrFileName,
                            FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(strInfo.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                throw new SAMSUserException(Constants.expPublishExceptionError, exp);
            }
        }

        public static void PublishExceptionforSync(Exception exception,string ExpDetail)
		{
			try
			{
				string mLogFilePath = Constants.fldLogFileFolder;
				if(mLogFilePath == null || mLogFilePath == "")
				{
					throw new Exception("");
				}

				StringBuilder strInfo = new StringBuilder();

				// Record the contents of the AdditionalInfo collection.
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "Machine Name:" , Environment.MachineName.ToString ());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "User Name   :" , Environment.UserName.ToString ());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "OS Version  :" , Environment.OSVersion.ToString ());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "Date Time   :" , DateTime.Now.ToString ("dd MMM yy hh:mm:ss" ));			
			
				//Get File name with Date
				string mstrFileName=mLogFilePath + "SAMSErrorLog" + System.DateTime.Today.ToString ("yyyyMMdd") + ".log";

				// Append the exception text
				strInfo.AppendFormat("{0}Exception Information:{0}{1}", Environment.NewLine, exception.ToString());
				strInfo.AppendFormat("{0}{1}: {2}" ,Environment.NewLine, "" , "----------------------------------");						
				strInfo.AppendFormat("{0}{1}: {2}",Environment.NewLine ,"Exp Detail ",ExpDetail); 
				// Write the entry to the log file.   
				using ( FileStream fs = File.Open(mstrFileName,
							FileMode.Append,FileAccess.Write ))
				{
					using (StreamWriter sw = new StreamWriter(fs))
					{
						sw.Write(strInfo.ToString());
					}
				}
			}
			catch(Exception exp)
			{
				throw new SAMSUserException(Constants.expPublishExceptionError, exp);
			}
		}
		#endregion

		#region Private Methods
		#endregion
		
		#region public Methods
		#endregion
	}
}
