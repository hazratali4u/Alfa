using System;
using FtpLib;
using System.Collections;



namespace SAMSCommon.Classes
{
	public delegate void MessageMaker(string message);
	/// <summary>
	/// General
	/// <author>Rizwan Ansari</author>
	/// <date>22-08-2007</date>
	/// </summary>
	public class General
	{	
		#region Constructors
		public General()
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
		public static string ReplaceSymbols(string p_FormattedString)
		{
			try
			{
				p_FormattedString = p_FormattedString.Replace("%APPPATH%", Configuration.GetAppInstallationPath());
				p_FormattedString = p_FormattedString.Replace("%SERVERFTPPATH%", Configuration.ServerFTPpath);
			}
			catch(Exception exp)
			{
				throw exp;
			}

			return p_FormattedString;
		}
		
		// added by Ali Raza
		public static void ShowErrorMessage(string errMsg)
		{
			System.Windows.Forms.MessageBox.Show(errMsg,"SAMS",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning );
		}

		/// <summary>
		/// downloads specific file from ftp folder
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="FtpHost"></param>
		/// <param name="FTPPath"></param>
		/// <param name="mFTPFolder"></param>
		/// <param name="mFileName"></param>
		/// <returns></returns>
		public static bool DownloadFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string FileName, string SaveLocation)
		{
			try
			{
				bool flag = false;
				
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				//ff.setRemoteHost("");
				if(UserID!= "Null")
				{
					ff.setRemoteUser(UserID);
					ff.setRemotePass(Password);
					ff.login();
				}
				ff.chdir(FTPPath);

				string[] fileNames = ff.getFileList("*.*");
				for(int i=0;i < fileNames.Length;i++) 
				{
					if(fileNames[i].Equals(FileName+"\r"))
					{
						ff.download(fileNames[i].ToString(), SaveLocation + fileNames[i].ToString());
						flag=true;

					}
				}
				//ff.close();
				if(flag)
				{
					return true;
				}
				else
				{
					return false;
				}		

				return true;
			}
			catch  ( Exception exp) 
			{
				throw exp;
			}			
		}

		/// <summary>
		/// downloads all files from ftp folder
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="FtpHost"></param>
		/// <param name="FTPPath"></param>
		/// <param name="mFTPFolder"></param>
		/// <returns></returns>
		public static bool DownloadFolderFromFtp(string UserID, string Password, string FtpHost, string FTPPath , string SaveLocation)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				ff.setRemoteUser(UserID);
				ff.setRemotePass(Password);

				ff.login();
				ff.chdir(FTPPath);

				string[] fileNames = ff.getFileList("*.*");
				for(int i=0;i < fileNames.Length;i++) 
				{
					if(!(fileNames[i].Equals("")))
					{
						ff.download(fileNames[i].ToString(), SaveLocation + fileNames[i].ToString());
					}
				}
				return true;
			}
			catch
			{
				throw;
			}			
		}


		/// <summary>
		/// downloads all files from ftp folder except files in the string array
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="FtpHost"></param>
		/// <param name="FTPPath"></param>
		/// <param name="mFTPFolder"></param>
		/// <param name="mExceptionFiles"></param>
		/// <returns></returns>
		public static bool DownloadUnSelectedFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation, string[] mExceptionFiles)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				if(UserID!= "Null")
				{
					ff.setRemoteUser(UserID);
				}
				if(Password!= "Null")
				{
					ff.setRemotePass(Password);
					ff.login();
				}
				ff.chdir(FTPPath);
				ArrayList expFile = new ArrayList(2);
				for(int j=0;j<mExceptionFiles.Length;j++)
				{
					expFile.Add(mExceptionFiles[j].ToString().Trim());
				}

				

				string[] fileNames = ff.getFileList("*.dat");
				for(int i=0;i < fileNames.Length;i++) 
				{
					if(!(expFile.Contains(fileNames[i].ToString().Trim())))
					{
						if(!(fileNames[i].ToString().Trim().Equals("")))
						{
							ff.download(fileNames[i].ToString(), SaveLocation + fileNames[i].ToString());
						}
					}
				}
				return true;
			}
			catch
			{
				throw;
			}			
		}


		public static bool DownloadUnSelectedFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				if(UserID!= "Null")
				{
					ff.setRemoteUser(UserID);
				}
				if(Password!= "Null")
				{
					ff.setRemotePass(Password);
					ff.login();
				}
				ff.chdir(FTPPath);
				string[] fileNames = ff.getFileList("*.dat");
				for(int i=0;i < fileNames.Length;i++) 
				{
						if(!(fileNames[i].ToString().Trim().Equals("")))
						{
							ff.download(fileNames[i].ToString(), SaveLocation + fileNames[i].ToString());
						}
					
				}
				return true;
			}
			catch
			{
				throw;
			}			
		}


		public static bool DeleteFileFtp(string UserID, string Password, string FtpHost, string FTPPath)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				if(UserID!= "Null")
				{
					ff.setRemoteUser(UserID);
				}
				if(Password!= "Null")
				{
					ff.setRemotePass(Password);
					ff.login();
				}
				ff.chdir(FTPPath);
				string[] fileNames = ff.getFileList("*.dat");
				for(int i=0;i < fileNames.Length;i++) 
				{
					if(!(fileNames[i].ToString().Trim().Equals("")))
					{
						ff.deleteRemoteFile(fileNames[i].ToString()); 
					}
					
				}
				return true;
			}
			catch
			{
				throw;
			}			
		}

		/// <summary>
		/// downloads all selected files from ftp folder files in the string array
		/// </summary>
		/// <param name="UserID"></param>
		/// <param name="Password"></param>
		/// <param name="FtpHost"></param>
		/// <param name="FTPPath"></param>
		/// <param name="mFTPFolder"></param>
		/// <param name="mExceptionFiles"></param>
		/// <returns></returns>
		public static bool DownloadSelectedFileFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation, string[] mExceptionFiles)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				ff.setRemoteUser(UserID);
				ff.setRemotePass(Password);
				
				ArrayList expFile = new ArrayList(2);
				for(int j=0;j<mExceptionFiles.Length;j++)
				{
					expFile.Add(mExceptionFiles[j].ToString().Trim());
				}

				ff.login();
				ff.chdir(FTPPath);

				string[] fileNames = ff.getFileList("*.*");
				for(int i=0;i < fileNames.Length;i++) 
				{
					if((expFile.Contains(fileNames[i].ToString().Trim())))
					{
						if(!(fileNames[i].ToString().Trim().Equals("")))
						{
							// download
							ff.download(fileNames[i].ToString(), SaveLocation + fileNames[i].ToString());
						}
					}
				}
				return true;
			}
			catch
			{
				throw;
			}			
		}

		public static bool UploadFileFtp(string UserID, string Password, string FtpHost, string FTPPath, string LogFileName)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				if(UserID!= "Null")
				{
					ff.setRemoteUser(UserID);
					ff.setRemotePass(Password);
					ff.login();
				}
				
				ff.chdir(FTPPath);
				ff.upload(LogFileName,true);
				return true;
			}
			catch
			{
				throw;
			}
		}
		public static bool DownloadTXTFilesFromFtp(string UserID, string Password, string FtpHost, string FTPPath, string SaveLocation, string FileExtention)
		{
			try
			{
				FTPFactory ff = new FTPFactory();
				ff.setDebug(true);
				ff.setRemoteHost(FtpHost);
				if(UserID!= "Null")
				{
					ff.setRemoteUser(UserID);
				}
				if(Password!= "Null")
				{
					ff.setRemotePass(Password);
					ff.login();
				}
				ff.chdir(FTPPath);
				string[] fileNames = ff.getFileList("");

				for(int i=0;i < fileNames.Length;i++) 
				{
					if(!(fileNames[i].ToString().Trim().Equals("")))
					{
						ff.download(fileNames[i].ToString(),SaveLocation + fileNames[i].ToString());	
					}

				}
				return true;
			}
			catch
			{
				throw;
			}			
		}

		#endregion

		#region Private Methods
		#endregion
		
		#region public Methods
		#endregion
	}
}
