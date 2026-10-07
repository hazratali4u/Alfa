using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;
using System.IO;
 
namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Ledger And GL Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Ledger Data And GL Data
    /// </item>
    /// <term>
    /// Update Ledger Data And GL Data
    /// </term>
    /// <item>
    /// Get Ledger Data And GL Data
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class LedgerController
    {
        #region Constuctor
        
        /// <summary>
        /// Constructor for LedgerController
        /// </summary>
        public LedgerController()
		{
			//
			// TODO: Add constructor logic here
			//
        }

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Gets Vouchers
        /// </summary>
        /// <remarks>
        /// Returns Vouchers as Datatable
        /// </remarks>
        /// <param name="p_Voucherdate">Date</param>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_VoucherTypeId">Type</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_VoucherNo">No</param>
        /// <returns>Vouchers as Datatable</returns>
        public DataTable SelectVoucherNo(DateTime p_Voucherdate, int p_Distributor_id, int p_VoucherTypeId, int p_UserId, string p_VoucherNo)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectGL_MASTER objSelect = new spSelectGL_MASTER();
                objSelect.Connection = mConnection;
                objSelect.VOUCHER_DATE = p_Voucherdate;
                objSelect.DISTRIBUTOR_ID = p_Distributor_id;
                objSelect.USER_ID = p_UserId;
                objSelect.VOUCHER_TYPE_ID = p_VoucherTypeId;
                objSelect.VOUCHER_NO = p_VoucherNo;
                objSelect.IS_POSTED = true;
                objSelect.IS_DELETED = false;
                DataTable dt = objSelect.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Vouchers Detail
        /// </summary>
        /// <remarks>
        /// Returns Vouchers Detail as Datatable
        /// </remarks>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_VoucherNo">No</param>
        /// <param name="p_VoucherTypeId">Type</param>
        /// <returns>Vouchers Detail as Datatable</returns>
        public DataTable SelectVoucherDetail(int p_Distributor_id, string p_VoucherNo, int p_VoucherTypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectGL_DETAIL objSelect = new spSelectGL_DETAIL();
                objSelect.Connection = mConnection;
                objSelect.DISTRIBUTOR_ID = p_Distributor_id;
                objSelect.VOUCHER_NO = p_VoucherNo;
                objSelect.VOUCHER_TYPE_ID = p_VoucherTypeId;
                objSelect.IS_DELETED = false;
                DataTable dt = objSelect.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Cheques Data
        /// </summary>
        /// <remarks>
        /// Returns Cheques Data as Datatable
        /// </remarks>
        /// <param name="p_PaymentMode_id">Mode</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_Principal_id">Principal</param>
        /// <param name="mDate">Date</param>
        /// <returns> Cheques Data as Datatable</returns>
        public DataTable SelectBankDeposit(int p_PaymentMode_id, int p_DistributorId, int p_Principal_id, DateTime mDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SelectBankTransction mMaxDNo = new SelectBankTransction();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.PAYMENT_MODE = p_PaymentMode_id;
                mMaxDNo.DISTRIBUTOR_ID = p_DistributorId;
                mMaxDNo.CLOSING_dATE = mDate;
                mMaxDNo.PRINCIPAL_ID = p_Principal_id;
                DataTable dt = mMaxDNo.ExecuteTable();

                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Customer Balance
        /// </summary>
        /// <remarks>
        /// Returns Customer Balance Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Account_Head_Id">AccountHead</param>
        /// <param name="p_DocumentType_id">Type</param>
        /// <param name="FDate">DateFrom</param>
        /// <param name="TDate">DateTo</param>
        /// <returns>Customer Balance Data as Datatable</returns>
        public DataTable SelectBankCashTransction(int p_Distributor_Id, int p_Account_Head_Id, int p_DocumentType_id, DateTime FDate, DateTime TDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectBankCashDetail mAccountHead = new UspSelectBankCashDetail();
                mAccountHead.Connection = mConnection;
                mAccountHead.Distributor_id = p_Distributor_Id;
                mAccountHead.Account_Head_id = p_Account_Head_Id;
                mAccountHead.Document_Type_Id = p_DocumentType_id;
                mAccountHead.From_Date = DateTime.Parse(FDate.ToShortDateString() + " 00:00:00");
                mAccountHead.To_Date = DateTime.Parse(TDate.ToShortDateString() + " 23:59:59");

                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Claim Data
        /// </summary>
        /// <remarks>
        /// Returns Claim Data as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_ClaimType_id">Type</param>
        /// <param name="FDate">DateFrom</param>
        /// <param name="TDate">DateTo</param>
        /// <returns>Claim Data as Datatable</returns>
        public DataTable SelectClaimDetail(int p_Distributor_Id, int p_ClaimType_id, DateTime FDate, DateTime TDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectClaimDetail mAccountHead = new UspSelectClaimDetail();
                mAccountHead.Connection = mConnection;
                mAccountHead.Distributor_id = p_Distributor_Id;
                mAccountHead.Claim_Type_Id = p_ClaimType_id;
                mAccountHead.From_Date = DateTime.Parse(FDate.ToShortDateString() + " 00:00:00");
                mAccountHead.To_Date = DateTime.Parse(TDate.ToShortDateString() + " 23:59:59");

                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Pending Credit Invoices
        /// </summary>
        /// <remarks>
        /// Returns Pending Credit Invoices as Datatable
        /// </remarks>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="Principal_id">Principal</param>
        /// <param name="From_Date">DateFrom</param>
        /// <param name="To_date">DateTo</param>
        /// <param name="p_Account_Head_Id"></param>
        /// <returns>Pending Credit Invoices as Datatable</returns>
        public DataTable SelectPendingInvoice(int p_DistributorId, int Principal_id, DateTime From_Date, DateTime To_date, long p_Account_Head_Id)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectLedgerDetail mpInvoice = new UspSelectLedgerDetail();
                mpInvoice.Connection = mConnection;
                mpInvoice.DISTRIBUTOR_ID = p_DistributorId;
                mpInvoice.PRINCIPAL_ID = Principal_id;
                mpInvoice.FROM_DATE = From_Date;
                mpInvoice.TO_DATE = To_date;
                mpInvoice.ACCOUNT_HEAD_ID = p_Account_Head_Id;
                DataTable dt = mpInvoice.ExecuteTable();
                return dt;
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                return null;
            }

        }

        /// <summary>
        /// Gets UnPosted Voucher Nos
        /// </summary>
        /// <remarks>
        /// Returns UnPosted Voucher Nos as Datatable
        /// </remarks>
        /// <param name="p_VoucherType_id">VoucherType</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_IS_POST">IsPost</param>
        /// <param name="p_FROM_DATE">DateFrom</param>
        /// <param name="p_TO_DATE">DateTo</param>
        /// <param name="p_TYPE">Type</param>
        /// <returns>UnPosted Voucher Nos as Datatable</returns>
        public DataTable SelectUnPostVoucherNo(int p_VoucherType_id, int p_DistributorId, int p_PrincipalId, bool p_IS_POST, DateTime p_FROM_DATE, DateTime p_TO_DATE, int p_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectVoucherNo mMaxDNo = new UspSelectVoucherNo();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.VOUCHER_TYPE_ID = p_VoucherType_id;
                mMaxDNo.DISTRIBUTOR_ID = p_DistributorId;
                mMaxDNo.IS_POST = p_IS_POST;
                mMaxDNo.FROM_DATE = p_FROM_DATE;
                mMaxDNo.TO_DATE = p_TO_DATE;
                mMaxDNo.PRINCIPAL_ID = p_PrincipalId;
                mMaxDNo.TYPE = p_TYPE;

                DataTable VouhcerId = mMaxDNo.ExecuteTable();
                return VouhcerId;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets UnPosted Voucher Detail
        /// </summary>
        /// <remarks>
        /// Returns UnPosted Voucher Detail as Datatable
        /// </remarks>
        /// <param name="p_Voucher_id">Voucher</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_VoucherType">Type</param>
        /// <returns>UnPosted Voucher Detail as Datatable</returns>
        public DataTable SelectUnPostLedger(string p_Voucher_id, int p_DistributorId, int p_VoucherType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectVoucher ObjLedger = new spSelectVoucher();
                ObjLedger.Connection = mConnection;
                ObjLedger.VOUCHER_NO = p_Voucher_id;
                ObjLedger.DISTRIBUTOR_ID = p_DistributorId;
                ObjLedger.VOUCHER_TYPE_ID = p_VoucherType;

                DataTable dt = ObjLedger.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Voucher Types
        /// </summary>
        /// <remarks>
        /// Returns Voucher Types as Datatable
        /// </remarks>
        /// <param name="p_User_Id">User</param>
        /// <returns>Voucher Types as Datatable</returns>
        public DataTable SelectVoucherType(int p_User_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetVoucherTypeRights mAccountHead = new UspGetVoucherTypeRights();
                mAccountHead.Connection = mConnection;
                mAccountHead.user_id = p_User_Id;

                DataTable dt = mAccountHead.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Max Document ID
        /// </summary>
        /// <remarks>
        /// Returns Max Document ID as String
        /// </remarks>
        /// <param name="p_Document_id">Document</param>
        /// <param name="p_DistributorId">Location</param>
        /// <returns>Max Document ID as String</returns>
        public string SelectLedgerMaxDocumentId(int p_Document_id, int p_DistributorId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectMaxDocumentNo mMaxDNo = new UspSelectMaxDocumentNo();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.Document_TypeId = p_Document_id;
                mMaxDNo.Distributor_id = p_DistributorId;
                DataTable MaxId = mMaxDNo.ExecuteTable();
                return MaxId.Rows[0][0].ToString();
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Max Voucher No
        /// </summary>
        /// <remarks>
        /// Returns Max Voucher No as String
        /// </remarks>
        /// <param name="p_Document_id">Document</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="mDate">Date</param>
        /// <returns>Max Voucher No as String</returns>
        public string SelectMaxVoucherId(int p_Document_id, int p_DistributorId, DateTime mDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectMaxVoucherNo mMaxDNo = new UspSelectMaxVoucherNo();
                mMaxDNo.Connection = mConnection;
                mMaxDNo.Document_TypeId = p_Document_id;
                mMaxDNo.Distributor_id = p_DistributorId;
                mMaxDNo.Month = mDate;
                DataTable MaxId = mMaxDNo.ExecuteTable();
                string MaxVoucherId = MaxId.Rows[0][0].ToString();

                if (MaxVoucherId.Length == 1)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-000" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-000" + MaxVoucherId;
                    }

                }
                else if (MaxVoucherId.Length == 2)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-00" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-00" + MaxVoucherId;
                    }

                }
                else if (MaxVoucherId.Length == 3)
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-0" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-0" + MaxVoucherId;
                    }

                }
                else
                {
                    if (mDate.Month.ToString().Length == 1)
                    {
                        MaxVoucherId = "0" + mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-" + MaxVoucherId;
                    }
                    else
                    {
                        MaxVoucherId = mDate.Month.ToString() + mDate.Year.ToString().Substring(2, 2) + "-" + MaxVoucherId;
                    }
                }
                return MaxVoucherId;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Customer Pending Credit Invoices
        /// </summary>
        /// <remarks>
        /// Returns Pending Credit Invoices as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_PRINCIPAL">Principal</param>
        /// <param name="p_CUSTOMER_ID">Customer</param>
        /// <param name="P_AREA_ID">Area</param>
        /// <returns>Pending Credit Invoices as Datatable</returns>
        public DataTable SelectCreditPendingInvoice(int p_Distributor_Id, int p_PRINCIPAL, long p_CUSTOMER_ID, int P_AREA_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                UspSelectPendingCreditInvoice mCust = new UspSelectPendingCreditInvoice();
                mCust.Connection = mConnection;
                mCust.PRINCIPAL_ID = p_PRINCIPAL;
                mCust.DISTRIBUTOR_ID = p_Distributor_Id;
                mCust.CUSTOMER_ID = p_CUSTOMER_ID;
                mCust.AREA_ID = P_AREA_ID;
                DataTable dt = mCust.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }

        public DataTable SelectCreditPendingInvoice2(int p_Distributor_Id, int p_PRINCIPAL, long p_CUSTOMER_ID, int P_AREA_ID, int P_DELIEVERYMAN_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                UspSelectPendingCreditInvoice mCust = new UspSelectPendingCreditInvoice();
                mCust.Connection = mConnection;
                mCust.PRINCIPAL_ID = p_PRINCIPAL;
                mCust.DISTRIBUTOR_ID = p_Distributor_Id;
                mCust.CUSTOMER_ID = p_CUSTOMER_ID;
                mCust.AREA_ID = P_AREA_ID;
                mCust.DELIEVERYMAN_ID = P_DELIEVERYMAN_ID;
                DataTable dt = mCust.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }



        public DataTable SelectWHTAX( long p_CUSTOMER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                GetCUSTOMERWHTAX mCust = new GetCUSTOMERWHTAX();
                mCust.Connection = mConnection;
             
                mCust.CUSTOMER_ID = p_CUSTOMER_ID;
             
                DataTable dt = mCust.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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
        /// Gets Assigned Voucher Types To a User
        /// </summary>
        /// <remarks>
        /// Returns Assigned Voucher Types To a User as Datatable
        /// </remarks>
        /// <param name="p_USER_ID">User</param>
        /// <returns>Assigned Voucher Types To a User as Datatable</returns>
        public DataTable GetAssignVoucherType(int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetAssignVoucherType mAssignVoucherType = new uspGetAssignVoucherType();
                mAssignVoucherType.Connection = mConnection;
                mAssignVoucherType.USER_ID = p_USER_ID;
                DataTable dt = mAssignVoucherType.ExecuteTable();
                return dt;

            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return null;
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

        #endregion

        #region Insert, Update, Delete

        /// <summary>
        /// Inserts Credit And Advance Invoices
        /// </summary>
        /// <param name="p_VoucherType">Type</param>
        /// <param name="p_VoucherNo">No</param>
        /// <param name="p_ACCOUNT_HEAD_ID">AccountHead</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Debit">Debit</param>
        /// <param name="p_Credit">Credit</param>
        /// <param name="p_Ledger_Date">Date</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="p_TimeStamp">CreatedOn</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_CUSTOMER_ID">Customer</param>
        /// <param name="p_DOCUMENT_NO">DocumentNo</param>
        /// <param name="p_MANUAL_DOCUMENT_NO">ManualualDocumentNo</param>
        /// <param name="p_DOCUMENT_TYPE_ID">DocumentType</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="mTransaction">Transaction</param>
        /// <param name="mConnection">Connection</param>
        /// <param name="p_Paymode">Mode</param>
        /// <param name="p_PayeesName">Payee</param>
        public void PostingInvoiceAccount(int p_VoucherType,long p_VoucherNo,long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_PRINCIPAL_ID,int p_CUSTOMER_ID, long p_DOCUMENT_NO,string p_MANUAL_DOCUMENT_NO, int p_DOCUMENT_TYPE_ID, int p_UserId, IDbTransaction mTransaction, IDbConnection mConnection,int p_Paymode,string p_PayeesName)
        {

            try
            {
                spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.Transaction = mTransaction;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VoucherType;
                mspInsertLedger.VOUCHER_NO = p_VoucherNo;  
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.DEBIT = p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
                mspInsertLedger.LEDGER_DATE = p_Ledger_Date;
                mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.TIME_STAMP = p_TimeStamp;
                mspInsertLedger.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mspInsertLedger.CUSTOMER_ID = p_CUSTOMER_ID;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DOCUMENT_TYPE_ID;
                mspInsertLedger.DOCUMENT_NO = p_DOCUMENT_NO;
                mspInsertLedger.MANUAL_DOCUMENT_NO = p_MANUAL_DOCUMENT_NO;
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.PAYMENT_MODE = p_Paymode; 
                mspInsertLedger.PAYEE_NAME = p_PayeesName;
                mspInsertLedger.IS_DELETED = 0; 
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        
        /// <summary>
        /// Inserts Cheque And Cash Realizations
        /// </summary>
        /// <param name="p_VOUCHER_TYPE_ID">Type</param>
        /// <param name="p_VOUCHER_NO">No</param>
        /// <param name="p_ACCOUNT_HEAD_ID">AccountHead</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Debit">Debit</param>
        /// <param name="p_Credit">Credit</param>
        /// <param name="p_Ledger_Date">Date</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="p_TimeStamp">CreatedOn</param>
        /// <param name="p_Customer_ID">Customer</param>
        /// <param name="p_Principal">Principal</param>
        /// <param name="p_Cheque_NO">Cheque</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_Document_Id">DocumentNo</param>
        /// <param name="p_Manual_Document_ID">ManualDocumentNo</param>
        /// <param name="p_DocumentTypeId">DocumentType</param>
        /// <param name="SlipNo">Slip</param>
        /// <param name="p_ChequeDate">ChequeDate</param>
        /// <param name="p_PaymentMode">Mode</param>
        /// <param name="p_PayeesName">Payee</param>
        public void PostingCash_Bank_Account(int p_VOUCHER_TYPE_ID, long p_VOUCHER_NO, long p_ACCOUNT_HEAD_ID, int p_Distributor_Id, decimal p_Debit, decimal p_Credit, DateTime p_Ledger_Date, string p_Remarks, DateTime p_TimeStamp, int p_Customer_ID, int p_Principal, string p_Cheque_NO, int p_UserId, long p_Document_Id,string p_Manual_Document_ID, int p_DocumentTypeId, string SlipNo, DateTime p_ChequeDate,int p_PaymentMode,string p_PayeesName)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                mspInsertLedger.Connection = mConnection;
                mspInsertLedger.ACCOUNT_HEAD_ID = p_ACCOUNT_HEAD_ID;
                mspInsertLedger.DISTRIBUTOR_ID = p_Distributor_Id;
                mspInsertLedger.VOUCHER_NO = p_VOUCHER_NO;
                mspInsertLedger.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mspInsertLedger.DEBIT = p_Debit;
                mspInsertLedger.CREDIT = p_Credit;
                mspInsertLedger.LEDGER_DATE = p_Ledger_Date;
                mspInsertLedger.DOCUMENT_NO = p_Document_Id;
                mspInsertLedger.MANUAL_DOCUMENT_NO = p_Manual_Document_ID;
                mspInsertLedger.DOCUMENT_TYPE_ID = p_DocumentTypeId;
                mspInsertLedger.REMARKS = p_Remarks;
                mspInsertLedger.TIME_STAMP = p_TimeStamp;
                mspInsertLedger.CUSTOMER_ID = p_Customer_ID;
                mspInsertLedger.PRINCIPAL_ID = p_Principal;
                mspInsertLedger.CHEQUE_NO = p_Cheque_NO;
                mspInsertLedger.USER_ID = p_UserId;
                mspInsertLedger.SLIP_NO = SlipNo;
                mspInsertLedger.CHQUE_DATE = p_ChequeDate;
                mspInsertLedger.PAYMENT_MODE = p_PaymentMode;
                mspInsertLedger.PAYEE_NAME = p_PayeesName;  
                mspInsertLedger.POSTING = 0;
                mspInsertLedger.IS_DELETED = 0; 
                mspInsertLedger.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        
        /// <summary>
        /// Inserts Cheque And Cash Realizations
        /// </summary>
        /// <param name="dtLedger">LedgerDataTable</param>
        public void PostingCash_Bank_Account(DataTable dtLedger)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                
                if (dtLedger.Rows.Count > 0)
                {
                    spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                    mspInsertLedger.Connection = mConnection;
                    mspInsertLedger.Transaction = mTransaction;

                    foreach (DataRow dr in dtLedger.Rows)
                    {
                        mspInsertLedger.ACCOUNT_HEAD_ID = Convert.ToInt32(dr["ACCOUNT_HEAD_ID"]);
                        mspInsertLedger.DISTRIBUTOR_ID = Convert.ToInt32(dr["Distributor_ID"]);
                        mspInsertLedger.VOUCHER_NO = Convert.ToInt64(dr["VOUCHER_NO"]);
                        mspInsertLedger.VOUCHER_TYPE_ID = Convert.ToInt32(dr["VOUCHER_TYPE_ID"]);
                        mspInsertLedger.DEBIT = Convert.ToDecimal(dr["DEBIT"]);
                        mspInsertLedger.CREDIT = Convert.ToDecimal(dr["CREDIT"]);
                        mspInsertLedger.LEDGER_DATE = Convert.ToDateTime(dr["Ledger_Date"]);
                        mspInsertLedger.DOCUMENT_NO = Convert.ToInt64(dr["Document_ID"]);
                        if (dr["Manual_Document_ID"] != null)
                        {
                            mspInsertLedger.MANUAL_DOCUMENT_NO = dr["Manual_Document_ID"].ToString();
                        }
                        mspInsertLedger.DOCUMENT_TYPE_ID = Convert.ToInt32(dr["DocumentTypeID"]);
                        mspInsertLedger.REMARKS = dr["Remarks"].ToString();
                        mspInsertLedger.TIME_STAMP = Convert.ToDateTime(dr["TimeStamp"]);
                        mspInsertLedger.CUSTOMER_ID = Convert.ToInt32(dr["Customer_ID"]);
                        mspInsertLedger.PRINCIPAL_ID = Convert.ToInt32(dr["Principal_ID"]);
                        mspInsertLedger.CHEQUE_NO = dr["Cheque_NO"].ToString();
                        mspInsertLedger.USER_ID = Convert.ToInt32(dr["UserID"]);
                        mspInsertLedger.SLIP_NO = dr["SlipNo"].ToString();
                        mspInsertLedger.CHQUE_DATE = Convert.ToDateTime(dr["ChequeDate"]);
                        mspInsertLedger.PAYMENT_MODE = Convert.ToInt32(dr["PaymentMode"]);
                        mspInsertLedger.PAYEE_NAME = dr["PayeesName"].ToString();
                        mspInsertLedger.POSTING = 0;
                        mspInsertLedger.IS_DELETED = 0;
                        mspInsertLedger.ExecuteQuery();
                    }
                }
                mTransaction.Commit();
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
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
        
        /// <summary>
        /// Inserts Cheque And Cash Realizations
        /// </summary>
        /// <param name="dtLedger">LedgerDataTable</param>
        /// <param name="p_SaleInvoice_ID">Invoice</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Current_Amount">Amount</param>
        public void PostingCash_Bank_Account(DataTable dtLedger, long p_SaleInvoice_ID, int p_Distributor_Id, decimal p_Current_Amount)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                if (dtLedger.Rows.Count > 0)
                {
                    spInsertLEDGER mspInsertLedger = new spInsertLEDGER();
                    mspInsertLedger.Connection = mConnection;
                    mspInsertLedger.Transaction = mTransaction;

                    foreach (DataRow dr in dtLedger.Rows)
                    {
                        mspInsertLedger.ACCOUNT_HEAD_ID = Convert.ToInt32(dr["ACCOUNT_HEAD_ID"]);
                        mspInsertLedger.DISTRIBUTOR_ID = Convert.ToInt32(dr["Distributor_ID"]);
                        mspInsertLedger.VOUCHER_NO = Convert.ToInt64(dr["VOUCHER_NO"]);
                        mspInsertLedger.VOUCHER_TYPE_ID = Convert.ToInt32(dr["VOUCHER_TYPE_ID"]);
                        mspInsertLedger.DEBIT = Convert.ToDecimal(dr["DEBIT"]);
                        mspInsertLedger.CREDIT = Convert.ToDecimal(dr["CREDIT"]);
                        mspInsertLedger.LEDGER_DATE = Convert.ToDateTime(dr["Ledger_Date"]);
                        mspInsertLedger.DOCUMENT_NO = Convert.ToInt64(dr["Document_ID"]);
                        if (dr["Manual_Document_ID"] != null)
                        {
                            mspInsertLedger.MANUAL_DOCUMENT_NO = dr["Manual_Document_ID"].ToString();
                        }
                        mspInsertLedger.DOCUMENT_TYPE_ID = Convert.ToInt32(dr["DocumentTypeID"]);
                        mspInsertLedger.REMARKS = dr["Remarks"].ToString();
                        mspInsertLedger.TIME_STAMP = Convert.ToDateTime(dr["TimeStamp"]);
                        mspInsertLedger.CUSTOMER_ID = Convert.ToInt32(dr["Customer_ID"]);
                        mspInsertLedger.PRINCIPAL_ID = Convert.ToInt32(dr["Principal_ID"]);
                        mspInsertLedger.CHEQUE_NO = dr["Cheque_NO"].ToString();
                        mspInsertLedger.USER_ID = Convert.ToInt32(dr["UserID"]);
                        mspInsertLedger.SLIP_NO = dr["SlipNo"].ToString();
                        mspInsertLedger.CHQUE_DATE = Convert.ToDateTime(dr["ChequeDate"]);
                        mspInsertLedger.PAYMENT_MODE = Convert.ToInt32(dr["PaymentMode"]);
                        mspInsertLedger.PAYEE_NAME = dr["PayeesName"].ToString();
                        mspInsertLedger.POSTING = 0;
                        mspInsertLedger.IS_DELETED = 0;
                        mspInsertLedger.ExecuteQuery();
                    }

                    spUpdateSALE_INVOICE_MASTER mSaleMaster = new spUpdateSALE_INVOICE_MASTER();
                    mSaleMaster.Connection = mConnection;
                    mSaleMaster.Transaction = mTransaction;
                    mSaleMaster.DISTRIBUTOR_ID = p_Distributor_Id;
                    mSaleMaster.SALE_INVOICE_ID = p_SaleInvoice_ID;
                    mSaleMaster.CURRENT_CREDIT_AMOUNT = p_Current_Amount;
                    mSaleMaster.IS_DELETED = false;
                    mSaleMaster.ExecuteQuery();
                }
                mTransaction.Commit();
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
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

        /// <summary>
        /// Updates Invoice Credit Amount After Realization
        /// </summary>
        /// <param name="p_SaleInvoice_ID">Invoice</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_Current_Amount">Amount</param>
        public void UpdateSaleInvoice(long p_SaleInvoice_ID, int p_Distributor_Id,decimal p_Current_Amount)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALE_INVOICE_MASTER mSaleMaster = new spUpdateSALE_INVOICE_MASTER();
                mSaleMaster.Connection = mConnection;
                mSaleMaster.DISTRIBUTOR_ID = p_Distributor_Id;
                mSaleMaster.SALE_INVOICE_ID = p_SaleInvoice_ID;
                mSaleMaster.CURRENT_CREDIT_AMOUNT = p_Current_Amount;
                mSaleMaster.IS_DELETED = false; 
                mSaleMaster.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
                //return null;

            }

        }
        
        /// <summary>
        /// Deletes Realization
        /// </summary>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_Document_Type">Type</param>
        /// <param name="p_Voucher_no">Voucher</param>
        /// <param name="Document_no">DocumentNo</param>
        /// <param name="TotalAmount">Amount</param>
        public void DeleteCashBankTransction(int p_DistributorId,int p_Document_Type,long p_Voucher_no,long Document_no,decimal TotalAmount)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDELETEBankCashDetail mSaleMaster = new UspDELETEBankCashDetail();
                mSaleMaster.Connection = mConnection;
                mSaleMaster.Distributor_id = p_DistributorId;
                mSaleMaster.Document_Type_Id = p_Document_Type;
                mSaleMaster.VOUCHER_NO = p_Voucher_no;
                mSaleMaster.DOCUMENT_NO = Document_no;
                mSaleMaster.AMOUNT = TotalAmount;  
                mSaleMaster.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }

        }
        
        /// <summary>
        /// Deletes Claim
        /// </summary>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_Document_Type">Type</param>
        /// <param name="p_Voucher_no">Voucher</param>
        /// <param name="Document_no">DocumentNo</param>
        /// <param name="TotalAmount">Amount</param>
        public void DeleteWareHouseLedger(int p_DistributorId, int p_Document_Type, long p_Voucher_no, long Document_no, decimal TotalAmount)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDELETEwareHouseLedger mSaleMaster = new UspDELETEwareHouseLedger();
                mSaleMaster.Connection = mConnection;
                mSaleMaster.Distributor_id = p_DistributorId;
                mSaleMaster.Document_Type_Id = p_Document_Type;
                mSaleMaster.VOUCHER_NO = p_Voucher_no;
                mSaleMaster.AMOUNT = TotalAmount;
                mSaleMaster.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }

        }
        
        /// <summary>
        /// Posts Voucher
        /// </summary>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_Voucher_no">Voucher</param>
        /// <param name="p_Voucher_type_Id">VoucherType</param>
        /// <param name="p_TypeId">Type</param>
        /// <param name="p_VoucherDate">Date</param>
        public void PostSelectVoucher(int p_DistributorId,string p_Voucher_no,int p_Voucher_type_Id,int p_TypeId,DateTime p_VoucherDate)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPostSelectVoucher mPostVoucher = new UspPostSelectVoucher();
                mPostVoucher.Connection = mConnection;
                mPostVoucher.DISTRIBUTOR_ID  = p_DistributorId;
                mPostVoucher.VOUCHER_NO = p_Voucher_no;
                mPostVoucher.VOUCHER_TYPE_ID = p_Voucher_type_Id;
                mPostVoucher.VOUCHER_DATE = p_VoucherDate;
                mPostVoucher.TYPE_ID = p_TypeId;  
                mPostVoucher.ExecuteQuery();
            }

            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
            }

        }
        
        /// <summary>
        /// Inserts Voucher
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_VOUCHER_NO">Voucher</param>
        /// <param name="p_VOUCHER_TYPE_ID">VoucherType</param>
        /// <param name="p_VOUCHER_DATE">Date</param>
        /// <param name="p_PAYMENT_MODE">Mode</param>
        /// <param name="p_PayeesName">Payee</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="ChequeDate">ChequeDate</param>
        /// <param name="ChequeNo">ChequeNo</param>
        /// <param name="dtVoucherDetail">VoucherDataTable</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_SlipNo">Slip</param>
        /// <param name="pDueDate">DueDate</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Add_Voucher(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, DateTime ChequeDate, string ChequeNo, DataTable dtVoucherDetail, int p_UserId, string p_SlipNo,DateTime pDueDate)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            
            try
            {
         
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spDeleteGL_MASTER mDelete = new spDeleteGL_MASTER();
                
                mDelete.Connection = mConnection;
                mDelete.Transaction = mTransaction;
                mDelete.DISTRIBUTOR_ID = p_Distributor_id;
                mDelete.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mDelete.VOUCHER_NO = p_VOUCHER_NO;
                mDelete.ExecuteQuery();
 
                spInsertGL_MASTER mISom = new spInsertGL_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;
                decimal MDebitAmount = 0;
                decimal MCreditAmount = 0;

                //------------Insert into Sale Order Master----------

                if (dtVoucherDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.PRINCIPAL_ID = Constants.IntNullValue;
                    mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                    mISom.VOUCHER_NO = p_VOUCHER_NO;
                    mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                    mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                    mISom.CHEQUE_DATE = ChequeDate;
                    mISom.CHEQUE_NO = ChequeNo;  
                    mISom.PAYEES_NAME = p_PayeesName;
                    mISom.REMARKS = p_Remarks;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.USER_ID = p_UserId;
                    mISom.Slip_No = p_SlipNo; 
                    mISom.IS_POSTED = false;
                    mISom.IS_DELETED = false;
                    mISom.DUE_DATE = pDueDate;
                    mISom.ExecuteQuery();


                    //----------------Insert into sale order detail-------------
                    spInsertGL_DETAIL mVoucherDetail = new spInsertGL_DETAIL();
                    mVoucherDetail.Connection = mConnection;
                    mVoucherDetail.Transaction = mTransaction;

                    

                    foreach (DataRow dr in dtVoucherDetail.Rows)
                    {
                        mVoucherDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mVoucherDetail.PRINCIPAL_ID = int.Parse(dr["PRINCIPAL_ID"].ToString());
                        mVoucherDetail.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        mVoucherDetail.VOUCHER_NO = p_VOUCHER_NO;
                        mVoucherDetail.ACCOUNT_HEAD_ID = long.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                        mVoucherDetail.DEBIT = decimal.Parse(dr["DEBIT"].ToString());
                        mVoucherDetail.CREDIT = decimal.Parse(dr["CREDIT"].ToString());
                        mVoucherDetail.GL_REMARKS = dr["REMARKS"].ToString();
                        mVoucherDetail.IS_DELETED = false;
                        mVoucherDetail.ExecuteQuery();

                        MDebitAmount += decimal.Parse(dr["DEBIT"].ToString());
                        MCreditAmount += decimal.Parse(dr["CREDIT"].ToString());
                    }
        
                }

                if (MDebitAmount > 0 && MCreditAmount > 0 && MDebitAmount == MCreditAmount)
                {
                    mTransaction.Commit();
                    return true;
                }
                else
                {
                    mTransaction.Rollback();
                    return false;
                }
            }
            catch (Exception exp)
            {
                mTransaction.Rollback(); 
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
        /// Inserts Voucher
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_VOUCHER_NO">No</param>
        /// <param name="p_VOUCHER_TYPE_ID">VoucherType</param>
        /// <param name="p_VOUCHER_DATE">Date</param>
        /// <param name="p_PAYMENT_MODE">Mode</param>
        /// <param name="p_PayeesName">Payee</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="ChequeDate">ChequeDate</param>
        /// <param name="ChequeNo">ChequeNo</param>
        /// <param name="dtVoucherDetail">VoucherDataTable</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_SlipNo">Slip</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Add_Voucher(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, DateTime ChequeDate, string ChequeNo, DataTable dtVoucherDetail, int p_UserId, string p_SlipNo)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spDeleteGL_MASTER mDelete = new spDeleteGL_MASTER();

                mDelete.Connection = mConnection;
                mDelete.Transaction = mTransaction;
                mDelete.DISTRIBUTOR_ID = p_Distributor_id;
                mDelete.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mDelete.VOUCHER_NO = p_VOUCHER_NO;
                mDelete.ExecuteQuery();

                spInsertGL_MASTER mISom = new spInsertGL_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;
                decimal MDebitAmount = 0;
                decimal MCreditAmount = 0;

                //------------Insert into Sale Order Master----------

                if (dtVoucherDetail.Rows.Count > 0)
                {
                    mISom.DISTRIBUTOR_ID = p_Distributor_id;
                    mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                    mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                    mISom.VOUCHER_NO = p_VOUCHER_NO;
                    mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                    mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                    mISom.CHEQUE_DATE = ChequeDate;
                    mISom.CHEQUE_NO = ChequeNo;
                    mISom.PAYEES_NAME = p_PayeesName;
                    mISom.REMARKS = p_Remarks;
                    mISom.TIME_STAMP = DateTime.Now;
                    mISom.USER_ID = p_UserId;
                    mISom.Slip_No = p_SlipNo;
                    mISom.IS_POSTED = false;
                    mISom.IS_DELETED = false;
                    mISom.DUE_DATE = Constants.DateNullValue;   
                    mISom.ExecuteQuery();


                    //----------------Insert into sale order detail-------------
                    spInsertGL_DETAIL mVoucherDetail = new spInsertGL_DETAIL();
                    mVoucherDetail.Connection = mConnection;
                    mVoucherDetail.Transaction = mTransaction;



                    foreach (DataRow dr in dtVoucherDetail.Rows)
                    {
                        mVoucherDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mVoucherDetail.PRINCIPAL_ID = int.Parse(dr["PRINCIPAL_ID"].ToString());
                        mVoucherDetail.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        mVoucherDetail.VOUCHER_NO = p_VOUCHER_NO;
                        mVoucherDetail.ACCOUNT_HEAD_ID = long.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                        mVoucherDetail.DEBIT = decimal.Parse(dr["DEBIT"].ToString());
                        mVoucherDetail.CREDIT = decimal.Parse(dr["CREDIT"].ToString());
                        mVoucherDetail.GL_REMARKS = dr["REMARKS"].ToString();
                        mVoucherDetail.IS_DELETED = false;
                        mVoucherDetail.ExecuteQuery();

                        MDebitAmount += decimal.Parse(dr["DEBIT"].ToString());
                        MCreditAmount += decimal.Parse(dr["CREDIT"].ToString());
                    }
                }

                if (MDebitAmount > 0 && MCreditAmount > 0 && MDebitAmount == MCreditAmount)
                {
                    mTransaction.Commit();
                    return true;
                }
                else
                {
                    mTransaction.Rollback();
                    return false;
                }
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
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
        /// Inserts Voucher
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_VOUCHER_NO">No</param>
        /// <param name="p_VOUCHER_TYPE_ID">VoucherType</param>
        /// <param name="p_VOUCHER_DATE">Date</param>
        /// <param name="p_ChequeDate">ChequeDate</param>
        /// <param name="p_PAYMENT_MODE">Mode</param>
        /// <param name="p_PayeesName">Payee</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="FileName">File</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>int</returns>
        public int  Import_Voucher(int p_Distributor_id, int p_PRINCIPAL_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE,DateTime p_ChequeDate, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks,string FileName,int p_UserId)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            FileStream Sourcefile = null;
            StreamReader ReadSourceFile = null;
            DataControl dc = new DataControl();
            int pReturnCode = 0;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                
                spInsertGL_MASTER mISom = new spInsertGL_MASTER();

                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                mISom.DISTRIBUTOR_ID = p_Distributor_id;
                mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mISom.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mISom.VOUCHER_NO = p_VOUCHER_NO;
                mISom.VOUCHER_DATE = p_VOUCHER_DATE;
                mISom.PAYMENT_MODE = p_PAYMENT_MODE;
                mISom.CHEQUE_DATE = Constants.DateNullValue ;
                mISom.CHEQUE_NO = null;
                mISom.PAYEES_NAME = null;
                mISom.REMARKS = p_Remarks;
                mISom.TIME_STAMP = DateTime.Now;
                mISom.USER_ID = p_UserId;
                mISom.IS_POSTED = false;
                mISom.IS_DELETED = false;
                mISom.ExecuteQuery();

                Sourcefile = new FileStream(FileName, FileMode.Open);
                ReadSourceFile = new StreamReader(Sourcefile);
                string FileContents = "";
                
                
                while ((FileContents = ReadSourceFile.ReadLine()) != null)
                {
                    string[] ParametersArr = FileContents.Split(Constants.File_Delimiter);

                    spSelectACCOUNT_HEAD Selectdata = new spSelectACCOUNT_HEAD();
                    Selectdata.Connection = mConnection;
                    Selectdata.Transaction = mTransaction;
                    Selectdata.ACCOUNT_CODE = ParametersArr[0].ToString();
                    Selectdata.IS_ACTIVE = true;
                    Selectdata.TIME_STAMP = Constants.DateNullValue;
                    Selectdata.LASTUPDATE_DATE = Constants.DateNullValue;   
                    DataTable  AccountHead  = Selectdata.ExecuteTable();
                    pReturnCode += 1;
                    if (AccountHead.Rows.Count > 0)
                    {
                        spInsertGL_DETAIL mVoucherDetail = new spInsertGL_DETAIL();
                        mVoucherDetail.Connection = mConnection;
                        mVoucherDetail.Transaction = mTransaction;

                        mVoucherDetail.ACCOUNT_HEAD_ID = long.Parse(AccountHead.Rows[0][0].ToString());
                        mVoucherDetail.DEBIT = decimal.Parse(dc.chkNull_0(ParametersArr[2].ToString()));
                        mVoucherDetail.CREDIT = decimal.Parse(dc.chkNull_0(ParametersArr[3].ToString()));
                        mVoucherDetail.DISTRIBUTOR_ID = p_Distributor_id;
                        mVoucherDetail.PRINCIPAL_ID = p_PRINCIPAL_ID;
                        mVoucherDetail.VOUCHER_NO = p_VOUCHER_NO;
                        mVoucherDetail.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        mVoucherDetail.IS_DELETED = false;
                        mVoucherDetail.GL_REMARKS = ParametersArr[1].ToString();
                        mVoucherDetail.ExecuteQuery();
                        
                    }
                    else
                    {
                        mTransaction.Rollback();
                        return pReturnCode; 
  
                    }
                    
                }
                mTransaction.Commit();
                return pReturnCode = 0; 
                            
                
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
                ExceptionPublisher.PublishException(exp);
                return pReturnCode;
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
        /// Inserts Opening Credit
        /// </summary>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_MANUAL_SALE_ID">ManulaInvoice</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_DocumentDate">Date</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_SOLD_TO">Customer</param>
        /// <param name="p_SHIP_TO">ShipTo</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliverman</param>
        /// <param name="p_TOTAL_NET_AMOUNT">NetAmount</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <param name="p_CreditType">Type</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool OpeningCredit(int p_Distributor_id, string p_MANUAL_SALE_ID, int p_TOWN_ID, long p_AREA_ID, DateTime p_DocumentDate, int p_PRINCIPAL_ID, long p_SOLD_TO, long p_SHIP_TO, int p_ORDERBOOKER_ID, int p_DELIVERYMAN_ID, decimal p_TOTAL_NET_AMOUNT, int p_UserId, int p_CreditType)
        {

            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);

                spInsertSALE_INVOICE_MASTER mISom = new spInsertSALE_INVOICE_MASTER();
                mISom.Connection = mConnection;
                mISom.Transaction = mTransaction;

                //------------Insert into Sale Order Master----------

                mISom.DISTRIBUTOR_ID = p_Distributor_id;
                mISom.MANUAL_INVOICE_ID = p_MANUAL_SALE_ID;
                mISom.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mISom.AREA_ID = p_AREA_ID;
                mISom.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mISom.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                mISom.DOCUMENT_DATE = p_DocumentDate;
                mISom.SOLD_TO = p_SOLD_TO;
                mISom.TOTAL_NET_AMOUNT = p_TOTAL_NET_AMOUNT;
                mISom.CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT;
                mISom.CURRENT_CREDIT_AMOUNT = p_TOTAL_NET_AMOUNT;
                mISom.TOWN_ID = p_TOWN_ID;
                mISom.USER_ID = p_UserId;
                mISom.SALE_ORDER_ID = -1;
                mISom.TIME_STAMP = DateTime.Now;
                mISom.LASTUPDATE_DATE = System.DateTime.Now;
                mISom.IS_DELETED = false;
                mISom.LEGEND_ID = p_CreditType;
                mISom.ExecuteQuery();

                #region Account Posting

                LedgerController LController = new LedgerController();
                Configuration.GetAccountHead();
                string VoucherNo = LController.SelectLedgerMaxDocumentId(Constants.Journal_Voucher, p_Distributor_id);
                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.AccountReceivable), p_Distributor_id, p_TOTAL_NET_AMOUNT, 0, mISom.DOCUMENT_DATE, "CASH Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, p_CreditType, p_DELIVERYMAN_ID.ToString());
                LController.PostingInvoiceAccount(Constants.Journal_Voucher, long.Parse(VoucherNo), long.Parse(Configuration.SaleAccount), p_Distributor_id, 0, p_TOTAL_NET_AMOUNT, mISom.DOCUMENT_DATE, "Sale Default", DateTime.Now, p_PRINCIPAL_ID, int.Parse(p_SOLD_TO.ToString()), mISom.SALE_INVOICE_ID, mISom.MANUAL_INVOICE_ID, Constants.Document_SaleInvoice, p_UserId, mTransaction, mConnection, p_CreditType, p_DELIVERYMAN_ID.ToString());

                #endregion

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return false;// exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
            return true;
        }
        
        #region Added By Hazrat Ali

        /// <summary>
        /// Inserts Rate Difference Voucher
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_VOUCHER_NO">No</param>
        /// <param name="p_VOUCHER_TYPE_ID">VoucherType</param>
        /// <param name="p_VOUCHER_DATE">Date</param>
        /// <param name="p_PAYMENT_MODE">Mode</param>
        /// <param name="p_PayeesName">Payee</param>
        /// <param name="p_Remarks">Remarks</param>
        /// <param name="ChequeDate">ChequeDate</param>
        /// <param name="ChequeNo">ChequeNo</param>
        /// <param name="dtVoucherDetail">VoucherDataTable</param>
        /// <param name="p_UserId">Inserted</param>
        /// <param name="p_SlipNo">Slip</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Add_RateDifference_Voucher(int p_Distributor_id, int p_Principal_ID, string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID, DateTime p_VOUCHER_DATE, int p_PAYMENT_MODE, string p_PayeesName, string p_Remarks, DateTime ChequeDate, string ChequeNo, DataTable dtVoucherDetail, int p_UserId, string p_SlipNo)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spDeleteGL_MASTER mDelete = new spDeleteGL_MASTER();

                mDelete.Connection = mConnection;
                mDelete.Transaction = mTransaction;
                mDelete.DISTRIBUTOR_ID = p_Distributor_id;
                mDelete.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mDelete.VOUCHER_NO = p_VOUCHER_NO;
                mDelete.ExecuteQuery();

                if (dtVoucherDetail.Rows.Count > 0)
                {
                    //------------GL Master----------
                    spInsertGL_MASTER mGLM = new spInsertGL_MASTER();
                    mGLM.Connection = mConnection;
                    mGLM.Transaction = mTransaction;
                    mGLM.DISTRIBUTOR_ID = p_Distributor_id;
                    mGLM.PRINCIPAL_ID = p_Principal_ID;
                    mGLM.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                    mGLM.VOUCHER_NO = p_VOUCHER_NO;
                    mGLM.VOUCHER_DATE = p_VOUCHER_DATE;
                    mGLM.PAYMENT_MODE = p_PAYMENT_MODE;
                    mGLM.CHEQUE_DATE = ChequeDate;
                    mGLM.CHEQUE_NO = ChequeNo;
                    mGLM.PAYEES_NAME = p_PayeesName;
                    mGLM.REMARKS = p_Remarks;
                    mGLM.TIME_STAMP = DateTime.Now;
                    mGLM.USER_ID = p_UserId;
                    mGLM.Slip_No = p_SlipNo;
                    mGLM.IS_POSTED = false;
                    mGLM.IS_DELETED = false;
                    mGLM.DUE_DATE = Constants.DateNullValue;
                    mGLM.ExecuteQuery();

                    //----------------GL Detail-------------
                    spInsertGL_DETAIL mGLD = new spInsertGL_DETAIL();
                    mGLD.Connection = mConnection;
                    mGLD.Transaction = mTransaction;

                    foreach (DataRow dr in dtVoucherDetail.Rows)
                    {
                        mGLD.DISTRIBUTOR_ID = p_Distributor_id;
                        mGLD.PRINCIPAL_ID = p_Principal_ID;
                        mGLD.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                        mGLD.VOUCHER_NO = p_VOUCHER_NO;
                        mGLD.ACCOUNT_HEAD_ID = long.Parse(dr["ACCOUNT_HEAD_ID"].ToString());
                        mGLD.DEBIT = decimal.Parse(dr["DEBIT"].ToString());
                        mGLD.CREDIT = decimal.Parse(dr["CREDIT"].ToString());
                        mGLD.GL_REMARKS = dr["REMARKS"].ToString();
                        mGLD.IS_DELETED = false;
                        mGLD.ExecuteQuery(); 
                    }
                }
                mTransaction.Commit();
                return true; 
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
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
        /// Deletes Voucher
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_Distributor_id">Location</param>
        /// <param name="p_VOUCHER_NO">No</param>
        /// <param name="p_VOUCHER_TYPE_ID">VoucherType</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Delete_Voucher(int p_Distributor_id,string p_VOUCHER_NO, int p_VOUCHER_TYPE_ID)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spDeleteGL_MASTER mDelete = new spDeleteGL_MASTER();

                mDelete.Connection = mConnection;
                mDelete.Transaction = mTransaction;
                mDelete.DISTRIBUTOR_ID = p_Distributor_id;
                mDelete.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mDelete.VOUCHER_NO = p_VOUCHER_NO;
                mDelete.ExecuteQuery();

                mTransaction.Commit();
                return true;
            }
            catch (Exception exp)
            {
                mTransaction.Rollback();
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
        /// Inserts VoucherType Assignment To User
        /// </summary>
        /// <remarks>
        /// Returns True On Success And False On Failure
        /// </remarks>
        /// <param name="p_VOUCHER_TYPE_ID">VoucherType</param>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_IS_DELETED">IsDeleted</param>
        /// <returns>True On Success And False On Failure</returns>
        public bool Assign_UnAssign_VoucherType(int p_VOUCHER_TYPE_ID, int p_USER_ID, bool p_IS_DELETED)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspAssignVoucherType mVoucherType = new uspAssignVoucherType();
                mVoucherType.Connection = mConnection;
                mVoucherType.VOUCHER_TYPE_ID = p_VOUCHER_TYPE_ID;
                mVoucherType.USER_ID = p_USER_ID;
                mVoucherType.IS_DELETED = p_IS_DELETED;
                bool Bvalue = mVoucherType.ExecuteQuery();
                return Bvalue;
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
        /// Deletes Opening Credit
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_LEGEND_ID">Legend</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_CUSTOMER_ID">Customer</param>
        /// <param name="p_SALE_INVOICE_ID">Invoice</param>
        /// <param name="p_USER_ID">InsertedBy</param>
        /// <returns>True On Scuccess And False On Failure</returns>
        public bool DeleteOpeningCredit(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_LEGEND_ID, DateTime p_DOCUMENT_DATE, int p_CUSTOMER_ID, long p_SALE_INVOICE_ID, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspDeleteOpeningCredit mOpening = new uspDeleteOpeningCredit();
                mOpening.Connection = mConnection;
                mOpening.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mOpening.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mOpening.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mOpening.CUSTOMER_ID = p_CUSTOMER_ID;
                mOpening.SALE_INVOICE_ID = p_SALE_INVOICE_ID;
                mOpening.LEGEND_ID = p_LEGEND_ID;
                mOpening.USER_ID = p_USER_ID;
                mOpening.ExecuteQuery();
                return true;

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

        #endregion

        #endregion

        #endregion
    } 	
}