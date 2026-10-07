using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// SymmCrypto is a wrapper of System.Security.Cryptography.SymmetricAlgorithm classes
	/// and simplifies the interface. It supports customized SymmetricAlgorithm as well.
	/// </summary>
	public class Encryption
	{
		/// <remarks>
		/// Supported .Net intrinsic SymmetricAlgorithm classes.
		/// </remarks>
		
		#region Private Members
		private static byte[] bytKey; 
		private static byte[] bytIV; 
		private SymmetricAlgorithm mobjCryptoService;

		/// <remarks>
		/// Constructor for using an intrinsic .Net SymmetricAlgorithm class.
		/// </remarks>
		 

		#endregion

		#region Private Methods  
		#region Create A Key 
    
		//************************* 
		//** Create A Key 
		//************************* 
    
		private static byte[] CreateKey(string strPassword) 
		{ 
			//Convert strPassword to an array and store in chrData. 
			char[] chrData = strPassword.ToCharArray(); 
			//Use intLength to get strPassword size. 
			int intLength = chrData.GetUpperBound(0); 
			//Declare bytDataToHash and make it the same size as chrData. 
			byte[] bytDataToHash = new byte[intLength + 1]; 
        
			//Use For Next to convert and store chrData into bytDataToHash. 
			for (int i = 0; i <= chrData.GetUpperBound(0); i++) 
			{ 
				bytDataToHash[i] = (byte)(chrData[i]); 
			} 
        
			//Declare what hash to use. 
			System.Security.Cryptography.SHA512Managed SHA512 = new System.Security.Cryptography.SHA512Managed(); 
			//Declare bytResult, Hash bytDataToHash and store it in bytResult. 
			byte[] bytResult = SHA512.ComputeHash(bytDataToHash); 
			//Declare bytKey(31). It will hold 256 bits. 
			byte[] bytKey = new byte[32]; 
        
			//Use For Next to put a specific size (256 bits) of 
			//bytResult into bytKey. The 0 To 31 will put the first 256 bits 
			//of 512 bits into bytKey. 
			for (int i = 0; i <= 31; i++) 
			{ 
				bytKey[i] = bytResult[i]; 
			} 
        
			return bytKey; 
			//Return the key. 
		} 
    
		#endregion 
    
		#region Create An IV  
    
		//************************* 
		//** Create An IV 
		//************************* 
    
		private static byte[] CreateIV(string strPassword) 
		{ 
			//Convert strPassword to an array and store in chrData. 
			char[] chrData = strPassword.ToCharArray(); 
			//Use intLength to get strPassword size. 
			int intLength = chrData.GetUpperBound(0); 
			//Declare bytDataToHash and make it the same size as chrData. 
			byte[] bytDataToHash = new byte[intLength + 1]; 
        
			//Use For Next to convert and store chrData into bytDataToHash. 
			for (int i = 0; i <= chrData.GetUpperBound(0); i++) 
			{ 
				bytDataToHash[i] = System.Convert.ToByte(chrData[i]); 
			} 
        
			//Declare what hash to use. 
			System.Security.Cryptography.SHA512Managed SHA512 = new System.Security.Cryptography.SHA512Managed(); 
			//Declare bytResult, Hash bytDataToHash and store it in bytResult. 
			byte[] bytResult = SHA512.ComputeHash(bytDataToHash); 
			//Declare bytIV(15). It will hold 128 bits. 
			byte[] bytIV = new byte[16]; 
        
			//Use For Next to put a specific size (128 bits) of 
			//bytResult into bytIV. The 0 To 30 for bytKey used the first 256 bits. 
			//of the hashed password. The 32 To 47 will put the next 128 bits into bytIV. 
			for (int i = 32; i <= 47; i++) 
			{ 
				bytIV[i - 32] = bytResult[i]; 
			} 
        
			return bytIV; 
			//return the IV 
		} 
    
		#endregion 
		
		#endregion

		#region Public Methods
        
		public enum SymmProvEnum : int
		{
			DES, RC2, Rijndael
		}


		public Encryption()
		{
			/// <remarks>
			/// Constructor for using a customized SymmetricAlgorithm class.
			/// </remarks>
			//		public SymmCrypto(SymmetricAlgorithm ServiceProvider)
			//		{
			//			mobjCryptoService = ServiceProvider;
			//		}

			mobjCryptoService = new DESCryptoServiceProvider();
		}


		public string Encrypting(string Source, string Key)
		{
			byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(Source);
			// create a MemoryStream so that the process can be done without I/O files
			System.IO.MemoryStream ms = new System.IO.MemoryStream();

			byte[] bytKey = GetLegalKey(Key);

			// set the private key
			mobjCryptoService.Key = bytKey;
			mobjCryptoService.IV = bytKey;

			// create an Encryptor from the Provider Service instance
			ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();

			// create Crypto Stream that transforms a stream using the encryption
			CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

			// write out encrypted content into MemoryStream
			cs.Write(bytIn, 0, bytIn.Length);
			cs.FlushFinalBlock();
            
			// get the output and trim the '\0' bytes
			byte[] bytOut = ms.GetBuffer();
			int i = 0;
			for (i = 0; i < bytOut.Length; i++)
				if (bytOut[i] == 0)
					break;
                    
			// convert into Base64 so that the result can be used in xml
			return System.Convert.ToBase64String(bytOut, 0, i);
		}

		
		public string Decrypting(string Source, string Key)
		{
			// convert from Base64 to binary
			byte[] bytIn = System.Convert.FromBase64String(Source);
			// create a MemoryStream with the input
			System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);

			byte[] bytKey = GetLegalKey(Key);

			// set the private key
			mobjCryptoService.Key = bytKey;
			mobjCryptoService.IV = bytKey;

			// create a Decryptor from the Provider Service instance
			ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
 
			// create Crypto Stream that transforms a stream using the decryption
			CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

			// read out the result from the Crypto Stream
			System.IO.StreamReader sr = new System.IO.StreamReader( cs );
			return sr.ReadToEnd();
		}


		public static string EncryptFiles(string pSourceFileName, string pKey)
		{
			FileStream fsOutput=null;
			FileStream fsInput=null;
			
			string EncFile = pSourceFileName.Substring(0,pSourceFileName.IndexOf('.'));//removing".txt" from filename
			EncFile +=".dat";//attaching extension with filename
			//EncFile = EncFile.Replace('\\','/');

			bytKey = CreateKey(pKey); 
			//Send the password to the CreateIV function. 
			bytIV = CreateIV(pKey); 
	 	
			try 
			{ 
				//In case of errors. 
            
				//Setup file streams to handle input and output. 
				fsInput = new System.IO.FileStream(pSourceFileName, FileMode.Open, FileAccess.Read); 
				fsOutput = new System.IO.FileStream(EncFile, FileMode.OpenOrCreate, FileAccess.Write); 
				fsOutput.SetLength(0); 
				//make sure fsOutput is empty 
            
				//Declare variables for encrypt/decrypt process. 
				byte[] bytBuffer = new byte[4097]; 
				//holds a block of bytes for processing 
				long lngBytesProcessed = 0; 
				//running count of bytes processed 
				long lngFileLength = fsInput.Length; 
				//the input file's length 
				int intBytesInCurrentBlock; 
				//current bytes being processed 
				CryptoStream csCryptoStream = null; 
				//Declare your CryptoServiceProvider. 
				System.Security.Cryptography.RijndaelManaged cspRijndael = new System.Security.Cryptography.RijndaelManaged(); 
				//pbStatus.Value = 0;
				//Setup Progress Bar 
				//	pbStatus.Maximum = 100; 
            
				//Determine if ecryption or decryption and setup CryptoStream. 
				csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write); 
				
            
				//Use While to loop until all of the file is processed. 
				while (lngBytesProcessed < lngFileLength) 
				{ 
					//Read file with the input filestream. 
					intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096); 
					//Write output file with the cryptostream. 
					csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock); 
					//Update lngBytesProcessed 
					lngBytesProcessed = lngBytesProcessed + intBytesInCurrentBlock; 
					int progress = (int)(lngBytesProcessed / lngFileLength) * 100;
					
				} 
            
				//Close FileStreams and CryptoStream. 
				csCryptoStream.Close(); 
				fsInput.Close(); 
				fsOutput.Close(); 
            
				//If encrypting then delete the original unencrypted file. 
				FileInfo fileOriginal = new FileInfo(pSourceFileName); 
				//fileOriginal.Delete(); 
						 
				return EncFile; 
			} 
			catch(FileNotFoundException excp)  
			{
				throw excp;
			} 
			catch 
			{ 
				fsInput.Close(); 
				fsOutput.Close(); 
            
				FileInfo fileDelete = new FileInfo(pSourceFileName); 
				fileDelete.Delete(); 
                
				return null;
			} 
		}
			

		public static string DecryptFiles(string pEncryptedSourceFile, string pKey)
		{
			FileStream fsInput=null;
			FileStream fsOutput = null;
			
			string DecFile = pEncryptedSourceFile.Substring(0,pEncryptedSourceFile.IndexOf('.'));//removing".dat" from filename
			DecFile +=".zip";//attaching extension with filename
			
			bytKey = CreateKey(pKey); 
			//Send the password to the CreateIV function. 
			bytIV = CreateIV(pKey); 
			
			try
			{
				//In case of errors. 
				//Setup file streams to handle input and output. 
				fsInput = new System.IO.FileStream(pEncryptedSourceFile, FileMode.Open, FileAccess.Read); 
				fsOutput = new System.IO.FileStream(DecFile, FileMode.OpenOrCreate, FileAccess.Write); 
				fsOutput.SetLength(0); 
				//make sure fsOutput is empty 
            
				//Declare variables for encrypt/decrypt process. 
				byte[] bytBuffer = new byte[4097]; 
				//holds a block of bytes for processing 
				long lngBytesProcessed = 0; 
				//running count of bytes processed 
				long lngFileLength = fsInput.Length; 
				//the input file's length 
				int intBytesInCurrentBlock; 
				//current bytes being processed 
				CryptoStream csCryptoStream = null; 
				//Declare your CryptoServiceProvider. 
				System.Security.Cryptography.RijndaelManaged cspRijndael = new System.Security.Cryptography.RijndaelManaged(); 
				
				//Determine if ecryption or decryption and setup CryptoStream. 
			    
				csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write); 
				//Use While to loop until all of the file is processed. 
				while (lngBytesProcessed < lngFileLength) 
				{ 
					//Read file with the input filestream. 
					intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096); 
					//Write output file with the cryptostream. 
					csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock); 
					//Update lngBytesProcessed 
					lngBytesProcessed = lngBytesProcessed + (long)intBytesInCurrentBlock; 
					//Update Progress Bar 
			

				} 
            
				//Close FileStreams and CryptoStream. 
				csCryptoStream.Close(); 
				fsInput.Close(); 
				fsOutput.Close(); 
            
				//If encrypting then delete the original unencrypted file. 
				
				//If decrypting then delete the encrypted file. 
				 
				FileInfo fileEncrypted = new FileInfo(pEncryptedSourceFile); 
				//fileEncrypted.Delete(); 
			
				return DecFile;
			} 
			catch(FileNotFoundException excp)  
			{
				throw excp;
				//return null;
			} 
        
				//Catch all other errors. And delete partial files. 
			catch 
			{ 
				fsInput.Close(); 
				fsOutput.Close(); 
            
				FileInfo fileDelete = new FileInfo(DecFile); 
				fileDelete.Delete(); 
					
				return null;
			} 
		}


//		public static bool CompressFiles(string p_filepath)
//		{
//			//string p_filepath = @"D:\3_41_200794104054.txt";
//			string zipFileName = p_filepath.Substring(0,p_filepath.IndexOf('.'));//removing".txt" from filename
//			zipFileName +=".zip";//attaching extension with filename
//			//zipFileName = zipFileName.Replace('\\','/');
//		
//			//compress file
//			try
//			{
//				// Output stream 
//				java.io.FileOutputStream fos = new java.io.FileOutputStream(zipFileName); 
//
//				// Tie to zip stream 
//				java.util.zip.ZipOutputStream zos = new java.util.zip.ZipOutputStream(fos); 
//
//				// Stream with source file 
//				java.io.FileInputStream fis = new java.io.FileInputStream(p_filepath); 
//
//				// It's our entry in zip 
//				string filename = p_filepath.Substring(p_filepath.LastIndexOf('\\')).Remove(0,1);
//				java.util.zip.ZipEntry ze = new java.util.zip.ZipEntry(filename ); 
//				zos.putNextEntry(ze); 
//				// Read and write until done 
//				sbyte[] buffer = new sbyte[1024]; 
//				int len; 
//
//				// Read and write until done 
//				while((len = fis.read(buffer)) >= 0) 
//				{ 
//					zos.write(buffer, 0, len); 
//				}
//				// Close everything 
//				zos.closeEntry(); 
//				fis.close(); 
//				zos.close(); 
//				fos.close(); 
//				//	m_LogMessage("Create zip file --> "+filename + " completed successfully");
//				
//				return true;
//			}
//			catch(Exception excp)
//			{
//				//	m_LogMessage(excp.Message);
//				return false;
//				//throw excp;
//				
//			}
//		}
//
//
//		public static bool UnCompressFiles(string zipFileName)
//		{
//			//string zipFileName=@"D:\3_41_200794104054.zip";
//			string txtFileName = "";
//			//zipFileName=Compressed File path
//			string error = "";
//			java.io.FileInputStream fis = null;
//			java.util.zip.ZipInputStream zis = null;
//			java.io.FileOutputStream fos = null;
//			try
//			{
//				error = "fis new object excp for file" + zipFileName;
//				if(File.Exists(zipFileName))
//				{
//					fis = new java.io.FileInputStream(zipFileName);
//					error = "zis new";
//					zis = new java.util.zip.ZipInputStream(fis);
//				
//					java.util.zip.ZipEntry ze2;
//					sbyte[] buf = new sbyte[1024];
//					int len;
//					string fileName;
//					while ((ze2 = zis.getNextEntry()) != null)
//					{
//						fileName = ze2.getName();
//						
//						txtFileName = fileName;
//											
//						//fileName = clsConstants.SyncLog_Monitor + fileName;
//						
//						fileName=zipFileName.ToLower().Replace("zip","txt");
//						
//						
//						//	fileName = zipFileName;
//
//						fos = new java.io.FileOutputStream(fileName);
//												
//						while ((len = zis.read(buf)) >= 0)
//						{
//							fos.write(buf, 0, len);
//						}
//						fos.close();
//					}
//					return true;
//					//MessageBox.Show("Unzip successful ");
//
//				}
//				else
//				{
//					//m_LogMessage("File not found : " + zipFileName);
//					return false;
//				}
//			}
//			catch (Exception excp)
//			{
//				//clsExceptionPublisher.Publish_Log(excp,clsConstants.SyncLog_Logging_Path); 
//				//m_LogMessage(error);
//				return false;
//			} 
//			finally 
//			{
//				
//				try
//				{
//					if(fos!=null)
//						fos.close();
//				}
//				catch
//				{
//					Console.WriteLine("ok");
//				}
//				if (zis!=null)
//					zis.close();
//				if (fis!=null)
//					fis.close();
//				
//			}
//			return true;
//		}
//		

		#endregion


		#region Private Methods

		
		/// <remarks>
		/// Depending on the legal key size limitations of a specific CryptoService provider
		/// and length of the private key provided, padding the secret key with space character
		/// to meet the legal size of the algorithm.
		/// </remarks>
		/// 
	private byte[] GetLegalKey(string Key)
		{
			string sTemp;
			if (mobjCryptoService.LegalKeySizes.Length > 0)
			{
				int lessSize = 0, moreSize = mobjCryptoService.LegalKeySizes[0].MinSize;
				// key sizes are in bits
				while (Key.Length * 8 > moreSize)
				{
					lessSize = moreSize;
					moreSize += mobjCryptoService.LegalKeySizes[0].SkipSize;
				}
				sTemp = Key.PadRight(moreSize / 8, ' ');
			}
			else
				sTemp = Key;

			// convert the secret key to byte array
			return ASCIIEncoding.ASCII.GetBytes(sTemp);
		}

		

		#endregion

	}
}