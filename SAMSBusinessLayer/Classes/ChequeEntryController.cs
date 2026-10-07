using System;
using System.Data;
using SAMSDatabaseLayer.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSCommon.Classes;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Class For Cheque Related Tasks
    /// <example>
    /// <remarks>
    /// <list type="bullet">
    /// <item>
    /// Insert Cheque
    /// </item>
    /// <item>
    /// Update Cheque
    /// </item>
    /// <item>
    /// Get Cheque Data
    /// </item>
    /// <item>
    /// Rollback Cheque etc.
    /// </item>
    /// </list>
    /// </remarks>
    /// </example>
	/// </summary>
	public class ChequeEntryController
    {
        #region Constructor

        /// <summary>
        /// Constructor for ChequeEntryController
        /// </summary>
		public ChequeEntryController()
		{
			//
			// TODO: Add constructor logic here
			//
        }

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Gets InvoiceID for Cheque
        /// <remarks>
        /// Returns InvoiceID for Cheque as Datatable
        /// </remarks>
        /// </summary>
        /// <param name="p_CHEQUE_PROCESS_ID">ChequeProcess</param>
        /// <param name="p_Type_id">Type</param>
        /// <returns>InvoiceID for Cheque as Datatable</returns>
        public DataTable SelectChequeEntryInvoice(long p_CHEQUE_PROCESS_ID, int p_Type_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspChequeInvoice mspSelectChequeEntry = new UspChequeInvoice();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.TYEP_ID = p_Type_id;
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// Gets Cheque Data
        /// <remarks>
        /// Returns Cheque Data as Datatable
        /// </remarks>
        /// </summary>
        /// <param name="p_Status_Id">Status</param>
        /// <param name="p_ReceivedDate">RecevingDate</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_USER_ID">InsertedBy</param>
        /// <returns>Cheque Data as Datatable</returns>
        public DataTable SelectChequeEntry(int p_Status_Id, DateTime p_ReceivedDate, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_USER_ID)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                
                spSelectCHEQUE_PROCESS mspSelectChequeEntry = new spSelectCHEQUE_PROCESS();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.STATUS_ID = p_Status_Id;
                mspSelectChequeEntry.RECEIVED_DATE = p_ReceivedDate;
              
                mspSelectChequeEntry.USER_ID = p_USER_ID;
                mspSelectChequeEntry.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspSelectChequeEntry.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }


        public DataTable SelectChequeEntry2(int pStatusId, DateTime pReceivedDate, DateTime pChequeDateTo, int pDistributorId, int pPrincipalId, int pUserId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                //BY SAFDAR
                spSelectCHEQUE_PROCESS2 mspSelectChequeEntry = new spSelectCHEQUE_PROCESS2();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.STATUS_ID = pStatusId;
                mspSelectChequeEntry.CHEQUE_DATE = pReceivedDate;
                mspSelectChequeEntry.CHEQUE_DATE2 = pChequeDateTo;
                mspSelectChequeEntry.USER_ID = pUserId;
                mspSelectChequeEntry.PRINCIPAL_ID = pPrincipalId;
                mspSelectChequeEntry.DISTRIBUTOR_ID = pDistributorId;
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        public DataTable SelectChequeEntry3(int pStatusId, DateTime pChequeDate, DateTime pChequeDateTo, int pDistributorId, int pPrincipalId, int pUserId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                //BY SAFDAR
                spSelectCHEQUE_PROCESS2 mspSelectChequeEntry = new spSelectCHEQUE_PROCESS2();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.STATUS_ID = pStatusId;
                mspSelectChequeEntry.CHEQUE_DATE = pChequeDate;
                mspSelectChequeEntry.CHEQUE_DATE2 = pChequeDateTo;
                mspSelectChequeEntry.USER_ID = pUserId;
                mspSelectChequeEntry.PRINCIPAL_ID = pPrincipalId;
                mspSelectChequeEntry.DISTRIBUTOR_ID = pDistributorId;
                DataTable dt = mspSelectChequeEntry.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        #endregion

        #region Insert, Update, Delete

        /// <summary>
        /// Inserts Cheque
        /// <remarks>
        /// Returns Inserted Cheque ID as String
        /// </remarks>
        /// </summary>
        /// <param name="p_distributorId">Location</param>
        /// <param name="p_Principal_id">Principal</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Cheque_No">ChequeNo</param>
        /// <param name="p_Bank_Name">Bank</param>
        /// <param name="p_Cheque_Date">ChequeDate</param>
        /// <param name="p_Received_Date">RecevingDate</param>
        /// <param name="p_Deposit_Date">DepositDate</param>
        /// <param name="p_Realization_Date">RealizationDate</param>
        /// <param name="p_Cheque_Amount">Amount</param>
        /// <param name="p_Status_Id">Status</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_SlipNo">SlipNo</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="p_AccountHead">AccountHead</param>
        /// <returns>Inserted Cheque ID as String</returns>
        public string InsertChequeEntry(int p_distributorId, int p_Principal_id, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, int p_User_Id, string p_SlipNo, string p_Remarks,long p_AccountHead)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
			  	mConnection.Open();
                spInsertCHEQUE_PROCESS mspInsertCheque_Entry = new spInsertCHEQUE_PROCESS();
                mspInsertCheque_Entry.Connection = mConnection;
                mspInsertCheque_Entry.DISTRIBUTOR_ID = p_distributorId;
                mspInsertCheque_Entry.PRINCIPAL_ID = p_Principal_id;  
                mspInsertCheque_Entry.CUSTOMER_ID = p_Customer_Id;
                mspInsertCheque_Entry.CHEQUE_NO = p_Cheque_No;
			    mspInsertCheque_Entry.BANK_NAME  = p_Bank_Name;
                mspInsertCheque_Entry.CHEQUE_DATE = p_Cheque_Date;
                mspInsertCheque_Entry.RECEIVED_DATE = p_Received_Date;
                mspInsertCheque_Entry.DEPOSIT_DATE = p_Deposit_Date;
                mspInsertCheque_Entry.PROCESS_DATE  = p_Realization_Date;
                mspInsertCheque_Entry.CHEQUE_AMOUNT = p_Cheque_Amount;
                mspInsertCheque_Entry.STATUS_ID = p_Status_Id;
                mspInsertCheque_Entry.TIME_STAMP = p_Time_Stamp;
                mspInsertCheque_Entry.USER_ID = p_User_Id; 
                mspInsertCheque_Entry.LAST_UPDATED = DateTime.Now;
                mspInsertCheque_Entry.SlipNo = p_SlipNo;
                mspInsertCheque_Entry.Remarks = p_Remarks;
                mspInsertCheque_Entry.ACCOUNT_HEAD_ID = p_AccountHead;  
                String ChequeProceId =  mspInsertCheque_Entry.ExecuteQuery();
                return ChequeProceId;
                   
			 }
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return "0";
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		
		}

        /// <summary>
        /// Updates Cheque
        /// </summary>
        /// <param name="p_CHEQUE_PROCESS_ID">ChequeProcess</param>
        /// <param name="p_distributorId">Location</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Cheque_No">ChequeNo</param>
        /// <param name="p_Bank_Name">Bank</param>
        /// <param name="p_Cheque_Date">ChequeDate</param>
        /// <param name="p_Received_Date">RecevingDate</param>
        /// <param name="p_Deposit_Date">DepositDate</param>
        /// <param name="p_Realization_Date">RealizationDate</param>
        /// <param name="p_Cheque_Amount">Amount</param>
        /// <param name="p_Status_Id">Status</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_SlipNo">SlipNo</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="p_AccountHead">AccountHead</param>
        public void UpdateChequeEntry(long p_CHEQUE_PROCESS_ID, int p_distributorId, int p_PrincipalId, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, string p_SlipNo, int p_UserId, string p_Remarks,long p_AccountHead)
		{
			IDbConnection mConnection = null;
			
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spUpdateCHEQUE_PROCESS mspUpdateCheque_Entry = new spUpdateCHEQUE_PROCESS();
				mspUpdateCheque_Entry.Connection = mConnection;
                mspUpdateCheque_Entry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspUpdateCheque_Entry.DISTRIBUTOR_ID = p_distributorId;
                mspUpdateCheque_Entry.CUSTOMER_ID = p_Customer_Id;
                mspUpdateCheque_Entry.PRINCIPAL_ID = p_PrincipalId; 
                mspUpdateCheque_Entry.CHEQUE_NO = p_Cheque_No;
                mspUpdateCheque_Entry.BANK_NAME = p_Bank_Name;
                mspUpdateCheque_Entry.CHEQUE_DATE = p_Cheque_Date;
                mspUpdateCheque_Entry.RECEIVED_DATE = p_Received_Date;
                mspUpdateCheque_Entry.DEPOSIT_DATE = p_Deposit_Date;
                mspUpdateCheque_Entry.PROCESS_DATE = p_Realization_Date;
                mspUpdateCheque_Entry.CHEQUE_AMOUNT = p_Cheque_Amount;
                mspUpdateCheque_Entry.STATUS_ID = p_Status_Id;
                mspUpdateCheque_Entry.TIME_STAMP = p_Time_Stamp;
                mspUpdateCheque_Entry.LAST_UPDATED = DateTime.Now;
                mspUpdateCheque_Entry.SlipNo = p_SlipNo;
                mspUpdateCheque_Entry.USER_ID = p_UserId;
                mspUpdateCheque_Entry.Remarks = p_Remarks;
                mspUpdateCheque_Entry.ACCOUNT_HEAD_ID = p_AccountHead; 
                mspUpdateCheque_Entry.ExecuteQuery();
				
				                   
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				//return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		
		
		}

        /// <summary>
        /// Inserts Cheque Detail
        /// <remarks>
        /// Returns bool
        /// </remarks>
        /// </summary>
        /// <param name="p_CHEQUE_PROCESS_ID">ChequeProcess</param>
        /// <param name="p_Sale_Invoice_id">Invoice</param>
        /// <returns>bool</returns>
        public bool InsertChequeEntryInvoice(long p_CHEQUE_PROCESS_ID, long  p_Sale_Invoice_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                spInsertCHEQUE_PROCESS_DETAIL mspSelectChequeEntry = new spInsertCHEQUE_PROCESS_DETAIL();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.SALE_INVOICE_ID = p_Sale_Invoice_id;
                return mspSelectChequeEntry.ExecuteQuery();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        /// <summary>
        /// Rollbacks Cheque
        /// </summary>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_CHEQUE_NO">ChequeNo</param>
        /// <param name="p_CHEQUE_PROCESS_ID">ChequeProcess</param>
        /// <param name="p_VoucherNo">VoucherNo</param>
        public void  RollbackChequeEntry(int p_PRINCIPAL_ID, int p_DISTRIBUTOR_ID, string p_CHEQUE_NO, long p_CHEQUE_PROCESS_ID,long p_VoucherNo)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspRollbackChequeTran mspSelectChequeEntry = new UspRollbackChequeTran();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.CHEQUE_NO = p_CHEQUE_NO;
                mspSelectChequeEntry.VOUCHER_NO = p_VoucherNo;
                mspSelectChequeEntry.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspSelectChequeEntry.ExecuteQuery();
                
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                //return null;
                //return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }


        }

        /// <summary>
        /// Deletes Cheque
        /// </summary>
        /// <param name="p_ChequeProcessId">ChequeProcess</param>
        public void DeleteChequeEntry(long p_ChequeProcessId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspDeleteCheque_Process mUpdateCLevel = new UspDeleteCheque_Process();
                mUpdateCLevel.Connection = mConnection;
                mUpdateCLevel.CHEQUE_PROCESS_ID = p_ChequeProcessId;
                mUpdateCLevel.ExecuteQuery();


            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);


            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }


        }

        #region Added By Hazrat Ali
        
        /// <summary>
        /// Inserts Cheque
        /// <remarks>
        /// Returns bool
        /// </remarks>
        /// </summary>
        /// <param name="p_distributorId">Location</param>
        /// <param name="p_Principal_id">Principal</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Cheque_No">ChequeNo</param>
        /// <param name="p_Bank_Name">Bank</param>
        /// <param name="p_Cheque_Date">ChequeDate</param>
        /// <param name="p_Received_Date">RecevingDate</param>
        /// <param name="p_Deposit_Date">DepositDate</param>
        /// <param name="p_Realization_Date">RealizationDate</param>
        /// <param name="p_Cheque_Amount">Amount</param>
        /// <param name="p_Status_Id">Status</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_User_Id">InsertedBy</param>
        /// <param name="p_SlipNo">SlipNo</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="p_AccountHead">AccountHead</param>
        /// <param name="dtChequeInvoice">Invoice</param>
        /// <returns>bool</returns>
        public bool InsertChequeEntry(int p_distributorId, int p_Principal_id, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, int p_User_Id, string p_SlipNo, string p_Remarks, long p_AccountHead, DataTable dtChequeInvoice)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            bool flag = false;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertCHEQUE_PROCESS mspInsertCheque_Entry = new spInsertCHEQUE_PROCESS();
                mspInsertCheque_Entry.Connection = mConnection;
                mspInsertCheque_Entry.Transaction = mTransaction;

                mspInsertCheque_Entry.DISTRIBUTOR_ID = p_distributorId;
                mspInsertCheque_Entry.PRINCIPAL_ID = p_Principal_id;
                mspInsertCheque_Entry.CUSTOMER_ID = p_Customer_Id;
                mspInsertCheque_Entry.CHEQUE_NO = p_Cheque_No;
                mspInsertCheque_Entry.BANK_NAME = p_Bank_Name;
                mspInsertCheque_Entry.CHEQUE_DATE = p_Cheque_Date;
                mspInsertCheque_Entry.RECEIVED_DATE = p_Received_Date;
                mspInsertCheque_Entry.DEPOSIT_DATE = p_Deposit_Date;
                mspInsertCheque_Entry.PROCESS_DATE = p_Realization_Date;
                mspInsertCheque_Entry.CHEQUE_AMOUNT = p_Cheque_Amount;
                mspInsertCheque_Entry.STATUS_ID = p_Status_Id;
                mspInsertCheque_Entry.TIME_STAMP = p_Time_Stamp;
                mspInsertCheque_Entry.USER_ID = p_User_Id;
                mspInsertCheque_Entry.LAST_UPDATED = DateTime.Now;
                mspInsertCheque_Entry.SlipNo = p_SlipNo;
                mspInsertCheque_Entry.Remarks = p_Remarks;
                mspInsertCheque_Entry.ACCOUNT_HEAD_ID = p_AccountHead;
                long ChequeProceID = Convert.ToInt64(mspInsertCheque_Entry.ExecuteQuery());

                if (dtChequeInvoice.Rows.Count > 0)
                {
                    spInsertCHEQUE_PROCESS_DETAIL mspInsertChequeEntry = new spInsertCHEQUE_PROCESS_DETAIL();
                    mspInsertChequeEntry.Connection = mConnection;
                    mspInsertChequeEntry.Transaction = mTransaction;

                    foreach (DataRow dr in dtChequeInvoice.Rows)
                    {
                        mspInsertChequeEntry.Connection = mConnection;
                        mspInsertChequeEntry.CHEQUE_PROCESS_ID = ChequeProceID;
                        mspInsertChequeEntry.SALE_INVOICE_ID = Convert.ToInt64(dr["SALE_INVOICE_ID"]);
                        mspInsertChequeEntry.ExecuteQuery();
                    }
                }
                mTransaction.Commit();
                flag = true;
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
                flag = false;
                ExceptionPublisher.PublishException(exp);
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

            return flag;
        }

        /// <summary>
        /// Updates Cheque
        /// <remarks>
        /// bool
        /// </remarks>
        /// </summary>
        /// <param name="p_CHEQUE_PROCESS_ID">ChequeProcess</param>
        /// <param name="p_distributorId">Location</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_Cheque_No">ChequeNo</param>
        /// <param name="p_Bank_Name">Bank</param>
        /// <param name="p_Cheque_Date">ChequeDate</param>
        /// <param name="p_Received_Date">RecevingDate</param>
        /// <param name="p_Deposit_Date">DepositDate</param>
        /// <param name="p_Realization_Date">RealizationDate</param>
        /// <param name="p_Cheque_Amount">Amount</param>
        /// <param name="p_Status_Id">Status</param>
        /// <param name="p_Time_Stamp">CreatedOn</param>
        /// <param name="p_SlipNo">SlipNo</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="p_AccountHead">AccountHead</param>
        /// <param name="dtChequeInvoice">Invoice</param>
        /// <param name="p_Type_ID"></param>
        /// <returns>bool</returns>
        public bool UpdateChequeEntry(long p_CHEQUE_PROCESS_ID, int p_distributorId, int p_PrincipalId, long p_Customer_Id, string p_Cheque_No, string p_Bank_Name, DateTime p_Cheque_Date, DateTime p_Received_Date, DateTime p_Deposit_Date, DateTime p_Realization_Date, decimal p_Cheque_Amount, int p_Status_Id, DateTime p_Time_Stamp, string p_SlipNo, int p_UserId, string p_Remarks, long p_AccountHead, DataTable dtChequeInvoice, int p_Type_ID)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            bool flag = false;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spUpdateCHEQUE_PROCESS mspUpdateCheque_Entry = new spUpdateCHEQUE_PROCESS();
                mspUpdateCheque_Entry.Connection = mConnection;
                mspUpdateCheque_Entry.Transaction = mTransaction;

                mspUpdateCheque_Entry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspUpdateCheque_Entry.DISTRIBUTOR_ID = p_distributorId;
                mspUpdateCheque_Entry.CUSTOMER_ID = p_Customer_Id;
                mspUpdateCheque_Entry.PRINCIPAL_ID = p_PrincipalId;
                mspUpdateCheque_Entry.CHEQUE_NO = p_Cheque_No;
                mspUpdateCheque_Entry.BANK_NAME = p_Bank_Name;
                mspUpdateCheque_Entry.CHEQUE_DATE = p_Cheque_Date;
                mspUpdateCheque_Entry.RECEIVED_DATE = p_Received_Date;
                mspUpdateCheque_Entry.DEPOSIT_DATE = p_Deposit_Date;
                mspUpdateCheque_Entry.PROCESS_DATE = p_Realization_Date;
                mspUpdateCheque_Entry.CHEQUE_AMOUNT = p_Cheque_Amount;
                mspUpdateCheque_Entry.STATUS_ID = p_Status_Id;
                mspUpdateCheque_Entry.TIME_STAMP = p_Time_Stamp;
                mspUpdateCheque_Entry.LAST_UPDATED = DateTime.Now;
                mspUpdateCheque_Entry.SlipNo = p_SlipNo;
                mspUpdateCheque_Entry.USER_ID = p_UserId;
                mspUpdateCheque_Entry.Remarks = p_Remarks;
                mspUpdateCheque_Entry.ACCOUNT_HEAD_ID = p_AccountHead;
                mspUpdateCheque_Entry.ExecuteQuery();

                UspChequeInvoice mspSelectChequeEntry = new UspChequeInvoice();
                mspSelectChequeEntry.Connection = mConnection;
                mspSelectChequeEntry.Transaction = mTransaction;

                mspSelectChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                mspSelectChequeEntry.TYEP_ID = p_Type_ID;
                mspSelectChequeEntry.ExecuteTable();


                if (dtChequeInvoice.Rows.Count > 0)
                {
                    spInsertCHEQUE_PROCESS_DETAIL mspInsertChequeEntry = new spInsertCHEQUE_PROCESS_DETAIL();
                    mspInsertChequeEntry.Connection = mConnection;
                    mspInsertChequeEntry.Transaction = mTransaction;

                    foreach (DataRow dr in dtChequeInvoice.Rows)
                    {
                        mspInsertChequeEntry.Connection = mConnection;
                        mspInsertChequeEntry.CHEQUE_PROCESS_ID = p_CHEQUE_PROCESS_ID;
                        mspInsertChequeEntry.SALE_INVOICE_ID = Convert.ToInt64(dr["SALE_INVOICE_ID"]);
                        mspInsertChequeEntry.ExecuteQuery();
                    }
                }
                mTransaction.Commit();
                flag = true;
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
                flag = false;
                ExceptionPublisher.PublishException(exp);
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return flag;
        }
        #endregion

        #endregion

        #endregion
    }
}