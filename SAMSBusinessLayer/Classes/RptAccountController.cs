using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Fetching Data Of Account Reports
    /// </summary>
    public class RptAccountController
    {
        #region Constructor

        /// <summary>
        /// Constructor for RptAccountController
        /// </summary>
        public RptAccountController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Public Methods

        /// <summary>
        /// Gets Data For Voucher View Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_VoucherNo">Voucher</param>
        /// <param name="p_Voucher_Type">Type</param>
        /// <returns>DataSet</returns>
        public DataSet SelectUnpostVoucherForPrint(int p_Distributor_ID, string p_VoucherNo, int p_Voucher_Type)
        {
            IDbConnection mConnection = null;
            try
            {
                LedgerController LControler = new LedgerController();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                DataTable dt = LControler.SelectUnPostLedger(p_VoucherNo, p_Distributor_ID, p_Voucher_Type);
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptVoucherView"].ImportRow(dr);
                }

                return ds;
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

        #region Petty Expense Report

        /// <summary>
        /// Gets Data For Petty Expense Report (Petty Expense Statament)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_ParentAccountId">ParentAccountHead</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPetyCashStatment(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, string p_ParentAccountId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptPetyCashStatment ObjPrint = new RptPetyCashStatment();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.ACCOUNT_PARENT_ID = p_ParentAccountId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["dbo_PetyCashSummary"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Petty Expense Report (Petty Cash Statment)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_USER_ID">User</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPetyCashSummary(int p_Distributor_ID, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptPettyCashSummery ObjPrint = new UspRptPettyCashSummery();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DistributorId = p_Distributor_ID;
                ObjPrint.FromDate = p_FromDate;
                ObjPrint.ToDate = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["PettyCashSummery"].ImportRow(dr);
                }

                return ds;
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

        /// <summary>
        /// Gets Data For Deposit Slip Detail Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Fromdate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_Account_Head_Id">AccountHead</param>
        /// <returns>DataSet</returns>
        public DataSet BankDepositSlipDetail(int p_Principal_ID, int p_Distributor_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_Account_Head_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspRptBankDepositSlip mBankDeposit = new UspRptBankDepositSlip();
                mBankDeposit.Connection = mConnection;

                mBankDeposit.PRINCIPAL_ID = p_Principal_ID;
                mBankDeposit.DISTRIBUTOR_ID = p_Distributor_ID;
                mBankDeposit.FromDate = p_Fromdate;
                mBankDeposit.ToDate = p_ToDate;
                mBankDeposit.ACCOUNT_HEAD_ID = p_Account_Head_Id;

                DataTable DT = mBankDeposit.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["BankDepositSlipDetail"].ImportRow(dr);
                }
                return ds;
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
        /// Gets Data For General Ledger Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Account_Head_ID">AccountHead</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_Posted">Post</param>
        /// <returns>DataSet</returns>
        public DataSet GeneralLedger_View(int p_Principal_ID, long p_Account_Head_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, int p_Posted)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspLedgerReport mLedger = new UspLedgerReport();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.ACCOUNT_HEAD_ID = p_Account_Head_ID;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;
                mLedger.POSTED = p_Posted;
                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptLedgerView"].ImportRow(dr);
                }
                return ds;
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
        /// Gets Opening Credit For General Ledger Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Account_Head_ID">AccountHead</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_Posted">Post</param>
        /// <returns>Decimal</returns>
        public decimal GeneralLedgerOpening(int p_Principal_ID, long p_Account_Head_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, int p_Posted)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                UspGetGLOpening mLedger = new UspGetGLOpening();
                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.ACCOUNT_HEAD_ID = p_Account_Head_ID;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;
                mLedger.POSTED = p_Posted;
                DataTable DT = mLedger.ExecuteTable();

                return decimal.Parse(DT.Rows[0][0].ToString());
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return 0;
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
        /// Gets Data For Petty Expense Summary Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_StartDate">DateFrom</param>
        /// <param name="p_EndDate">DateTo</param>
        /// <param name="p_CatagoryIDS">Categories</param>
        /// <param name="p_ReportType">ReportType</param>
        /// <returns>DataSet</returns>
        public DataSet PrincipalWiseSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, string p_CatagoryIDS, int p_ReportType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspPrincipalWiseExp mOutletwiseSale = new UspPrincipalWiseExp();
                mOutletwiseSale.Connection = mConnection;

                mOutletwiseSale.PRINCIPAL_ID = p_Principal_ID;
                mOutletwiseSale.DISTRIBUTOR_ID = p_Distributor_ID;
                mOutletwiseSale.FROM_DATE = p_StartDate;
                mOutletwiseSale.TO_DATE = p_EndDate;
                mOutletwiseSale.ACCOUNT_IDs = p_CatagoryIDS;
                mOutletwiseSale.TYPE_ID = p_ReportType;

                DataTable DT = mOutletwiseSale.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptPrincipalWiseExp"].ImportRow(dr);
                }
                return ds;
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
        /// Gets Data For Trial Balance Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_Account_Type_ID">AccountType</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_Level">Level</param>
        /// <param name="p_FromCode">CodeFrom</param>
        /// <param name="p_ToCode">CodeTo</param>
        /// <param name="p_Posted">Post</param>
        /// <returns>DataSet</returns>
        public DataSet TrialBalance(int p_Principal_ID, int p_DistributorId, int p_Account_Type_ID, DateTime p_From_Date, DateTime p_ToDate, int p_Level, string p_FromCode, string p_ToCode, int p_Posted)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspPrintTrialBalance mLedger = new UspPrintTrialBalance();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.ACCOUNT_TYPE_ID = p_Account_Type_ID;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;
                mLedger.LEAVEL_ID = p_Level;
                mLedger.FROM_CODE = p_FromCode;
                mLedger.TO_CODE = p_ToCode;
                mLedger.POSTING = p_Posted;
                DataTable DT = mLedger.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptTrialBalance"].ImportRow(dr);
                }
                return ds;
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
        /// Gets Data For  Chart of Account Report
        /// </summary>
        /// <param name="p_account_category">Category</param>
        /// <param name="p_account_typeid">Type</param>
        /// <param name="p_accountsub_typeid">SubType</param>
        /// <param name="p_AccountDetail_TypeId">DetailType</param>
        /// <returns>DataSet</returns>
        public DataSet SelectRptChartofAccount(int p_account_category, int p_account_typeid, int p_accountsub_typeid, int p_AccountDetail_TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPrintChartofAccount ObjPrint = new UspPrintChartofAccount();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.account_category = p_account_category;
                ObjPrint.account_typeid = p_account_typeid;
                ObjPrint.accountsub_typeid = p_accountsub_typeid;
                ObjPrint.AccountDetail_TypeId = p_AccountDetail_TypeId;
                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["Account_Head_View"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Daily NCS vs Deposit Report
        /// </summary>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet SelectNCSvsDeposit(int p_Principal_Id, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspcalNcsVSBankDepositDayWise ObjPrint = new UspcalNcsVSBankDepositDayWise();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBTRIBUTOR_ID = Constants.IntNullValue;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.DAY_CLOSED = p_To_Date;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptDayWiseNCSVSBankDeposit"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Sale Tax Return on Sale Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_Type">Type</param>
        /// <param name="p_REGISTERED">Registered</param>
        /// <param name="p_Route_ID">Route</param>
        /// <param name="p_Customer_ID">Customer</param>
        /// <returns>DataSet</returns>
        public DataSet SelectRptSaleTaxReport(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_Type, int p_REGISTERED, int p_Route_ID, int p_Customer_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptTaxView ObjPrint = new UspRptTaxView();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.Type = p_Type;
                ObjPrint.REGISTERED = p_REGISTERED;
                ObjPrint.ROUTE_ID = p_Route_ID;
                ObjPrint.CUSTOMER_ID = p_Customer_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptSalesTaxReturn"].ImportRow(dr);
                }

                return ds;
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

        #region Investment Analysis Report

        /// <summary>
        /// Gets Data For Investment Analysis Report (Day Wise Investment)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet SelectDailyBalance(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetDailyBalances ObjPrint = new UspGetDailyBalances();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptDailyBalance"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Investment Analysis Report (Sources and Utilization)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">FromDate</param>
        /// <returns>DataSet</returns>
        public DataSet SelectUtilizationFound(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspGetUtilzationFunds ObjPrint = new UspGetUtilzationFunds();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.DAY_CLOSED = p_FromDate;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptUtilizationFound"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Investment Analysis Report (Average Investment & Ratios)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet SelectDailyBalanceSummary(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspProcessDailyBalances ObjPrint = new UspProcessDailyBalances();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptDailyBalanceSummary"].ImportRow(dr);
                }

                return ds;
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

        #region Added By Hazrat Ali

        /// <summary>
        /// Gets Data For Sale Tax Return on Purchase Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="P_PrincipalID">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet GetPurchaseInvoices(int p_Distributor_ID, int P_PrincipalID, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();

                uspGetPurchaseInvoices ObjPurchaseInvoices = new uspGetPurchaseInvoices();
                ObjPurchaseInvoices.Connection = mConnection;
                ObjPurchaseInvoices.FROM_DATE = p_FromDate;
                ObjPurchaseInvoices.TO_DATE = p_To_Date;
                ObjPurchaseInvoices.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPurchaseInvoices.PRINCIPAL_ID = P_PrincipalID;


                DataTable dt = ObjPurchaseInvoices.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptPurchaseInvoices"].ImportRow(dr);
                }
                return ds;
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
        /// Gets Data For GL Log Detail Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_VocherTypeID">Type</param>
        /// <param name="p_UserID">User</param>
        /// <param name="p_From_Date">DataFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_FILTER_ON">SortBy</param>
        /// <returns>DataSet</returns>
        public DataSet SelectGLLog_VoucherDetail(int p_Distributor_ID, int p_VocherTypeID, int p_UserID, DateTime p_From_Date, DateTime p_To_Date, int p_FILTER_ON)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetGLLogVoucherDetail ObjPrint = new uspGetGLLogVoucherDetail();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.FROM_DATE = p_From_Date;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_UserID;
                ObjPrint.VOUCHER_TYPE_ID = p_VocherTypeID;
                ObjPrint.FILTER_ON = p_FILTER_ON;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspGetGLLogVoucherDetail"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Investment & Cash Flow Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Distributor_Type">LocationType</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_UserID">User</param>
        /// <returns>DataSet</returns>
        public DataSet SelectInvestmentAndCash(int p_Distributor_ID, int p_Principal_Id, int p_Distributor_Type, DateTime p_FromDate, DateTime p_To_Date, int p_UserID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetInvestmentCashFlow ObjPrint = new uspGetInvestmentCashFlow();
                SAMSBusinessLayer.Reports.dsSalesPurchaseRegister ds = new SAMSBusinessLayer.Reports.dsSalesPurchaseRegister();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.DISTRIBUTOR_TYPE_ID = p_Distributor_Type;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_UserID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspGetInvestmentCashFlow2"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Compound Entry for Bank Reconciliation Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Account_Head_ID">AccountHead</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet GetCompoundBankReconciliation(int p_Distributor_ID, int p_Principal_Id, int p_Account_Head_ID, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspGetCompoundBankReconciliation ObjPrint = new uspGetCompoundBankReconciliation();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.ACCOUNT_HEAD_ID = p_Account_Head_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                DataSet dsResult = ObjPrint.ExecuteDatSet();

                foreach (DataRow dr in dsResult.Tables[0].Rows)
                {
                    ds.Tables["uspGetCompoundBankReconciliation"].ImportRow(dr);
                }

                foreach (DataRow dr in dsResult.Tables[1].Rows)
                {
                    ds.Tables["uspGetCompoundTaxDeducted"].ImportRow(dr);
                }

                foreach (DataRow dr in dsResult.Tables[2].Rows)
                {
                    ds.Tables["uspGetCompoundTotal"].ImportRow(dr);
                }

                return ds;
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
        /// Gets Data For Sales Purchase Register Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Report_Type">ReportType</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_UserID">User</param>
        /// <returns>DataSet</returns>
        public DataSet SelectSalesPurchaseRegister(int p_Distributor_ID, int p_Principal_Id, int p_Report_Type, DateTime p_FromDate, DateTime p_To_Date, int p_UserID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetSalesPurchaseRegister ObjPrint = new uspGetSalesPurchaseRegister();
                SAMSBusinessLayer.Reports.dsSalesPurchaseRegister ds = new SAMSBusinessLayer.Reports.dsSalesPurchaseRegister();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.REPORT_TYPE = p_Report_Type;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_UserID;
                DataTable dt = ObjPrint.ExecuteTable();
                if (p_Report_Type == 6)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ds.Tables["SalesPurchaseStockRegister"].ImportRow(dr);
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ds.Tables["SalesPurchaseTaxableRegister"].ImportRow(dr);
                    }
                }

                return ds;
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
        /// Gets Data For Sales Purchase Format Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_ReportType">Type</param>
        /// <returns>DataSet</returns>
        public DataSet GetSalesPurchaseFormat(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date,int p_IS_REGISTERED, int p_ReportType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetSalesPurchaseFormat ObjPrint = new uspGetSalesPurchaseFormat();
                SAMSBusinessLayer.Reports.dsSalesPurchaseRegister ds = new SAMSBusinessLayer.Reports.dsSalesPurchaseRegister();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.IS_REGISTERED = p_IS_REGISTERED;
                ObjPrint.REPORT_TYPE = p_ReportType;
                DataTable dt = ObjPrint.ExecuteTable();

                if (p_ReportType == 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ds.Tables["uspGetSalesFormat"].ImportRow(dr);
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ds.Tables["uspGetPurchaseFormat"].ImportRow(dr);
                    }
                }

                return ds;
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
    }
}
