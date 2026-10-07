using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Fetching Data Of Customer Reports
    /// </summary>
    public class RptCustomerController
    {
        #region Constructor

        /// <summary>
        /// Constructor for RptCustomerController
        /// </summary>
        public RptCustomerController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Public Methods

        #region Credit Report

        /// <summary>
        /// Gets Data For Credit Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_SortType">SortType</param>
        /// <param name="p_OrderBookerId">OrderBooker</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_ChannelTypeId">ChannelType</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="p_TAGID">Tag</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPrincipalCreditDetail(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_SortType, int p_OrderBookerId, int p_CustomerId, int p_ChannelTypeId, int p_AreaId, int p_TAGID, int p_SALE_PERSON, int p_CREDIT_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptCreditSummary ObjPrint = new UspRptCreditSummary();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.ORDERBOOKER_ID = p_OrderBookerId;
                ObjPrint.CUSTOMER_ID = p_CustomerId;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.CHANNEL_TYPE_ID = p_ChannelTypeId;
                ObjPrint.SALE_PERSON = p_SALE_PERSON;

                if (p_TAGID == 0)
                {
                    ObjPrint.TAGID = Constants.IntNullValue;
                }
                else
                {
                    ObjPrint.TAGID = p_TAGID;
                }

                if (p_CREDIT_TYPE == 0)
                {
                    ObjPrint.CREDIT_TYPE = Constants.IntNullValue;
                }
                else
                {
                    ObjPrint.CREDIT_TYPE = p_CREDIT_TYPE;
                }

                DataTable dt = ObjPrint.ExecuteTable();
                DataView dv = new DataView(dt);
                if (p_SortType == 0)
                {
                    dv.Sort = "CUSTOMER_NAME";
                }
                else
                {
                    dv.Sort = "LEDGER_DATE";
                }
                dt = dv.ToTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCreditSummary"].ImportRow(dr);
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
        /// Gets Data For Credit Report (Credit Limit)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_UserId">User</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCustomerCreditCeiling(int p_Distributor_ID, int p_Principal_Id, int p_UserId, string p_CUSTOMER_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCreditLimitReport ObjPrint = new UspCreditLimitReport();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.userid = p_UserId;
                if (p_CUSTOMER_TYPE == "0")
                {
                    ObjPrint.CUSTOMER_TYPE = null;
                }
                else
                {
                    ObjPrint.CUSTOMER_TYPE = p_CUSTOMER_TYPE;
                }
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerWiseCreditSelling"].ImportRow(dr);
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

        #region Added By Hazrat Ali

        /// <summary>
        /// Gets Data For Credit Report (Closing Credit Wise)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_SortType">SortType</param>
        /// <param name="p_OrderBookerId">OrderBooker</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_ChannelTypeId">ChannelType</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="p_TAGID">Tag</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPrincipalCreditDetailClosingWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_SortType, int p_OrderBookerId, int p_CustomerId, int p_ChannelTypeId, int p_AreaId, int p_TAGID, int p_SALE_PERSON, int p_CREDIT_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspRptCreditSummaryClosingWise ObjPrint = new UspRptCreditSummaryClosingWise();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.ORDERBOOKER_ID = p_OrderBookerId;
                ObjPrint.CUSTOMER_ID = p_CustomerId;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.CHANNEL_TYPE_ID = p_ChannelTypeId;
                ObjPrint.SALE_PERSON = p_SALE_PERSON;

                if (p_TAGID == 0)
                {
                    ObjPrint.TAGID = Constants.IntNullValue;
                }
                else
                {
                    ObjPrint.TAGID = p_TAGID;
                }

                if (p_CREDIT_TYPE == 0)
                {
                    ObjPrint.CREDIT_TYPE = Constants.IntNullValue;
                }
                else
                {
                    ObjPrint.CREDIT_TYPE = p_CREDIT_TYPE;
                }

                DataTable dt = ObjPrint.ExecuteTable();
                DataView dv = new DataView(dt);
                if (p_SortType == 0)
                {
                    dv.Sort = "ClosingAmount ASC";
                }
                else
                {
                    dv.Sort = "ClosingAmount DESC";
                }
                dt = dv.ToTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCreditSummaryClosingWise"].ImportRow(dr);
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

        #region Customer Wise (DSR) Report

        /// <summary>
        /// Gets Data For Customer Wise (DSR) Report (Product Wise)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="User_Id">User</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="ChannelTypeId">ChannelType</param>
        /// <param name="TypeId">ReprotType</param>
        /// <param name="p_SalesForce_Id">Deliverman</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCustomerDSRProDuctWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, int TypeId, int p_SalesForce_Id, int p_ORDERBOOKER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                RptCustomerDSRProductWise ObjPrint = new RptCustomerDSRProductWise();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = User_Id;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.CHANNEL_TYPE_ID = ChannelTypeId;
                ObjPrint.TYPE_ID = TypeId;
                ObjPrint.DELIVERYMAN_ID = p_SalesForce_Id;
                ObjPrint.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerProductDSR"].ImportRow(dr);
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
        /// Gets Data For Customer Wise (DSR) Report (Value Wise)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="User_Id">User</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="ChannelTypeId">ChannelType</param>
        /// <param name="p_IS_REGISTERED">IsRegistered</param>
        /// <param name="p_SaleForceId">Deliveryman</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCustomerDSRValueWise(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, bool p_IS_REGISTERED, int p_SaleForceId, int p_ORDERBOOKER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                UspPrintCustomerDSR ObjPrint = new UspPrintCustomerDSR();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.USER_ID = User_Id;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.DELIVERYMAN_ID = p_SaleForceId;
                ObjPrint.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                if (p_IS_REGISTERED == true)
                {
                    ObjPrint.IS_REGISTERED = 1;
                }
                else
                {
                    ObjPrint.IS_REGISTERED = Constants.IntNullValue;
                }
                ObjPrint.CHANNEL_TYPE_ID = ChannelTypeId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["CUSTOMER_TRANSCTIONDETAIL"].ImportRow(dr);
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

        #region Booking vs Execution Repot

        #region Added By Hazrat Ali

        /// <summary>
        /// Gets Data For Booking vs Execution Report (Date Wise)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_OrderBookerID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Fromdate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet BookingVsExecution(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, int p_DELIVERYMAN_ID, DateTime p_Fromdate, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                RptOrderVsExecution mOrder = new RptOrderVsExecution();

                mOrder.Connection = mConnection;
                mOrder.PRINCIPAL_ID = p_Principal_ID;
                mOrder.DISTRIBUTOR_ID = p_Distributor_ID;
                mOrder.ORDERBOOKER_ID = p_OrderBookerID;
                mOrder.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mOrder.FROM_DATE = p_Fromdate;
                mOrder.TO_DATE = p_ToDate;
                DataTable Dt_Order = mOrder.ExecuteTable();

                foreach (DataRow dr in Dt_Order.Rows)
                {
                    ds.Tables["BookingSupplyMonitoring"].ImportRow(dr);
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
        /// Gets Data For Booking vs Execution Report (SKU Wise)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_OrderBookerID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Fromdate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_REPORT_TYPE">ReportType</param>
        /// <returns>DataSet</returns>
        public DataSet SKUWiseBookingVsExecution(int p_Principal_ID, int p_Distributor_ID, int p_OrderBookerID, int p_DELIVERYMAN_ID, DateTime p_Fromdate, DateTime p_ToDate, int p_REPORT_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();

                RptSKUWiseBookingVsExecution mOrder = new RptSKUWiseBookingVsExecution();

                mOrder.Connection = mConnection;
                mOrder.PRINCIPAL_ID = p_Principal_ID;
                mOrder.DISTRIBUTOR_ID = p_Distributor_ID;
                mOrder.ORDERBOOKER_ID = p_OrderBookerID;
                mOrder.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mOrder.FROM_DATE = p_Fromdate;
                mOrder.TO_DATE = p_ToDate;
                mOrder.REPORT_TYPE = p_REPORT_TYPE;
                DataTable Dt_Order = mOrder.ExecuteTable();

                foreach (DataRow dr in Dt_Order.Rows)
                {
                    ds.Tables["RptSKUWiseBookingVsExecution"].ImportRow(dr);
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

        #region  Customer Monthly Report

        /// <summary>
        /// Gets Data For  Customer Monthly Reports
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="Category_Id">Category</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="ChannelTypeId">ChannelType</param>
        /// <param name="TypeId">Type</param>
        /// <param name="p_SKU_ID">SKU</param>
        /// <param name="p_ORDERBOOKER_ID">OrderBooker</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCustomerMonthlySales(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int Category_Id, int p_AreaId, int ChannelTypeId, int TypeId, int p_SKU_ID, int p_ORDERBOOKER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspCustomerMonthlySales ObjPrint = new UspCustomerMonthlySales();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.Distributor_id = p_Distributor_ID;
                ObjPrint.Principal_id = p_Principal_Id;
                ObjPrint.From_date = p_FromDate;
                ObjPrint.To_Date = p_To_Date;
                ObjPrint.Area_id = p_AreaId;
                ObjPrint.ChanneltypeId = ChannelTypeId;
                ObjPrint.Type_Id = TypeId;
                ObjPrint.SKU_ID = p_SKU_ID;
                ObjPrint.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                ObjPrint.Category_id = Category_Id;

                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["CustomerMonthlySales"].ImportRow(dr);
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

        #region Customer Invoice Wise Sales Report

        /// <summary>
        /// Gets Data For Customer Invoice Wise Sales Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Customer_Id">Customer</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_showAll">Type</param>
        /// <returns>DataSet</returns>
        public DataSet SelectBillCustomerDetail(int p_Principal_ID, string p_Customer_Id, string p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, Byte p_showAll)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspBillWiseCustomerReport mLedger = new UspBillWiseCustomerReport();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.CUSTOMER_ID = p_Customer_Id;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;
                mLedger.ShowAll = p_showAll;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptBillCustomerReport"].ImportRow(dr);
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

        #region  Catagory Wise Customer Report

        /// <summary>
        /// Gets Data For Catagory Wise Customer Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_StartDate">DateFrom</param>
        /// <param name="p_EndDate">DateTo</param>
        /// <param name="p_CatagoryIDS">Categories</param>
        /// <returns>DataSet</returns>
        public DataSet OutletWiseSale(int p_Principal_ID, int p_Distributor_ID, DateTime p_StartDate, DateTime p_EndDate, string p_CatagoryIDS)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                RptOutletWiseSale mOutletwiseSale = new RptOutletWiseSale();
                mOutletwiseSale.Connection = mConnection;

                mOutletwiseSale.Principal_ID = p_Principal_ID;
                mOutletwiseSale.Distributor_ID = p_Distributor_ID;
                mOutletwiseSale.FromDate = p_StartDate;
                mOutletwiseSale.ToDate = p_EndDate;
                mOutletwiseSale.Catagory_IDs = p_CatagoryIDS;

                DataTable DT = mOutletwiseSale.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["OutletWiseSale"].ImportRow(dr);
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

        #region Customer Ledger Report

        /// <summary>
        /// Gets Data For Customer Ledger Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet CustomerLedger_View(int p_Principal_ID, int p_DistributorId, int p_CustomerId, DateTime p_From_Date, DateTime p_ToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspCustomerLedger mLedger = new UspCustomerLedger();

                mLedger.Connection = mConnection;
                mLedger.principal_id = p_Principal_ID;
                mLedger.Distributor_id = p_DistributorId;
                mLedger.customer_id = p_CustomerId;
                mLedger.From_Date = p_From_Date;
                mLedger.To_Date = p_ToDate;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCustomerLedgerView"].ImportRow(dr);
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

        #region Credit Aging Report

        /// <summary>
        /// Gets Data For Credit Aging Report
        /// </summary>
        /// <param name="P_DistributorType">LocationType</param>
        /// <param name="P_PrincipalId">Principal</param>
        /// <param name="P_DistributorId">Location</param>
        /// <param name="p_UserId">User</param>
        /// <param name="p_Type">Type</param>
        /// <param name="p_Start_Date">DateFrom</param>
        /// <param name="p_EndDate">DateTo</param>
        /// <param name="p_ChannelTypeId">ChannelType</param>
        /// <returns>DataSet</returns>
        public DataSet GetCreditAgingReport(int P_DistributorType, int P_PrincipalId, int P_DistributorId, int p_UserId, int p_Type, DateTime p_Start_Date, DateTime p_EndDate, int p_ChannelTypeId)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                DataTable DT;

                if (p_Type == 2)
                {
                    UspGetCreditAgingdayWise obj_regionwise = new UspGetCreditAgingdayWise();
                    obj_regionwise.Connection = mConnection;
                    obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                    obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                    obj_regionwise.StartDate = p_Start_Date;
                    obj_regionwise.EndDate = p_EndDate;
                    DT = obj_regionwise.ExecuteTable();
                }
                else
                {
                    UspCreditAgintReport obj_regionwise = new UspCreditAgintReport();
                    obj_regionwise.Connection = mConnection;
                    obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                    obj_regionwise.DISTRIBUTOR_TYPE_ID = P_DistributorType;
                    obj_regionwise.TYPE_ID = p_Type;
                    obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                    obj_regionwise.USER_ID = p_UserId;
                    obj_regionwise.DOCUMENT_DATE = p_EndDate;
                    obj_regionwise.CHANNEL_TYPE_ID = p_ChannelTypeId;
                    DT = obj_regionwise.ExecuteTable();
                }
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCreditAgingReport"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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

        #region Town Wise Sales Report

        /// <summary>
        /// Gets Data For Town Wise Sales Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_Type">Type</param>
        /// <returns>DataSet</returns>
        public DataSet SelectTownWiseSales(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_Type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspTownWiseSaleReport ObjPrint = new UspTownWiseSaleReport();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.TYPE_ID = p_Type;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptTownSalesReport"].ImportRow(dr);
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

        #region Claim Voucher Report

        /// <summary>
        /// Gets Data For Claim Voucher Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_PaymentMode">PaymentMode</param>
        /// <returns>DataSet</returns>
        public DataSet CustomerClaim_Slip(int p_Principal_ID, int p_DistributorId, int p_CustomerId, DateTime p_From_Date, DateTime p_ToDate, int p_PaymentMode)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspPrintClaimSlip mLedger = new UspPrintClaimSlip();

                mLedger.Connection = mConnection;
                mLedger.principal_id = p_Principal_ID;
                mLedger.Distributor_id = p_DistributorId;
                mLedger.customer_id = p_CustomerId;
                mLedger.From_Date = p_From_Date;
                mLedger.To_Date = p_ToDate;
                mLedger.Payment_Mode = p_PaymentMode;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptClaimSlipDetail"].ImportRow(dr);
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

        #region Payment Receiving Report

        /// <summary>
        /// Gets Data For Payment Receiving Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns></returns>
        public DataSet SelectPaymentReceived(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectPartyStatment ObjPrint = new UspSelectPartyStatment();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;

                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptPaymentReceied"].ImportRow(dr);
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

        #region  Party Statement Report

        /// <summary>
        /// Gets Data For Party Statement Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPartystatment(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspPartyStatement ObjPrint = new UspPartyStatement();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;

                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerStatment"].ImportRow(dr);
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

        #region   Order VS Dispatch Report

        /// <summary>
        /// Gets Data For Order VS Dispatch Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_Type">Type</param>
        /// <returns>DataSet</returns>
        public DataSet SelectOrderVSExcusion(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_Type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectOrderVSExceusion ObjPrint = new UspSelectOrderVSExceusion();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.REPORTTYPE = p_Type;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptOrderExcustionSummary"].ImportRow(dr);
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

        #region Damage Claim Detail Report

        /// <summary>
        /// Gets Data For Damage Claim Detail Report
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_From_Date">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="ClaimType">ClaimType</param>
        /// <returns>DataSet</returns>
        public DataSet SelectClaimReport(int p_Principal_ID, int p_DistributorId, DateTime p_From_Date, DateTime p_ToDate, int ClaimType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspClaimDetailReport mLedger = new UspClaimDetailReport();

                mLedger.Connection = mConnection;
                mLedger.PRINCIPAL_ID = p_Principal_ID;
                mLedger.DISTRIBUTOR_ID = p_DistributorId;
                mLedger.CLAIM_TYPE = ClaimType;
                mLedger.FROM_DATE = p_From_Date;
                mLedger.TO_DATE = p_ToDate;

                DataTable DT = mLedger.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptClaimManagmentReport"].ImportRow(dr);
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

        #region Customer Classification Report

        /// <summary>
        /// Gets Data For Customer Classification Report(Summary Report)
        /// </summary>
        /// <param name="P_PrincipalId">Principal</param>
        /// <param name="P_DistributorId">Location</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_QueryAnalysis">Query</param>
        /// <param name="p_ChannelType_id">ChannelType</param>
        /// <param name="p_devision_id">Division</param>
        /// <param name="p_Category_id">Category</param>
        /// <param name="p_Brand_Id">Brand</param>
        /// <param name="p_SKU_id">SKU</param>
        /// <returns>DataSet</returns>
        public DataSet GetCustomerClassfication(int P_PrincipalId, int P_DistributorId, DateTime p_FromDate, DateTime p_ToDate, string p_QueryAnalysis, int p_ChannelType_id, int p_devision_id, int p_Category_id, int p_Brand_Id, int p_SKU_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                UspShowCustomerClassificationReport obj_regionwise = new UspShowCustomerClassificationReport();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                obj_regionwise.FROM_DATE = p_FromDate;
                obj_regionwise.TO_DATE = p_ToDate;
                obj_regionwise.String = p_QueryAnalysis;
                obj_regionwise.CHANNEL_TYPE_ID = p_ChannelType_id;
                obj_regionwise.Division = p_devision_id;
                obj_regionwise.Category = p_Category_id;
                obj_regionwise.Brand = p_Brand_Id;
                obj_regionwise.SKU_ID = p_SKU_id;
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCustomerClassfication"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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
        /// Gets Data For Customer Classification Report(Detail Report)
        /// </summary>
        /// <param name="P_PrincipalId">Principal</param>
        /// <param name="P_DistributorId">Location</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_QueryAnalysis">Query</param>
        /// <param name="p_ChannelType_id">ChannelType</param>
        /// <param name="p_devision_id">Division</param>
        /// <param name="p_Category_id">Category</param>
        /// <param name="p_Brand_Id">Brand</param>
        /// <param name="p_SKU_id">SKU</param>
        /// <returns>DataSet</returns>
        public DataSet GetCustomerClassficationDetail(int P_PrincipalId, int P_DistributorId, DateTime p_FromDate, DateTime p_ToDate, string p_QueryAnalysis, int p_ChannelType_id, int p_devision_id, int p_Category_id, int p_Brand_Id, int p_SKU_id)
        {

            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                UspShowCustomerClassificationReport obj_regionwise = new UspShowCustomerClassificationReport();
                obj_regionwise.Connection = mConnection;
                obj_regionwise.DISTRIBUTOR_ID = P_DistributorId;
                obj_regionwise.PRINCIPAL_ID = P_PrincipalId;
                obj_regionwise.FROM_DATE = p_FromDate;
                obj_regionwise.TO_DATE = p_ToDate;
                obj_regionwise.String = p_QueryAnalysis;
                obj_regionwise.CHANNEL_TYPE_ID = p_ChannelType_id;
                obj_regionwise.Division = p_devision_id;
                obj_regionwise.Category = p_Category_id;
                obj_regionwise.Brand = p_Brand_Id;
                obj_regionwise.SKU_ID = p_SKU_id;
                DataTable DT = obj_regionwise.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptCustomerClassificationDetail"].ImportRow(dr);
                }
                return ds;
            }
            catch (Exception excp)
            {
                ExceptionPublisher.PublishException(excp);
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

        #region Cheque Detail Report

        /// <summary>
        /// Gets Data For Cheque Detail Report(Cheque Detail)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_Area_id">Route</param>
        /// <param name="p_CustomerId">Customer</param>
        /// <param name="p_ChannelType_Id">ChannelType</param>
        /// <param name="p_Status_id">Status</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_UserId">User</param>
        /// <param name="p_ReportFilter">Filter</param>
        /// <returns>DataSet</returns>
        public DataSet SelectCustomerCreditReport(int p_Distributor_ID, int p_Principal_Id, int p_Area_id, int p_CustomerId, int p_ChannelType_Id, int p_Status_id, DateTime p_FromDate, DateTime p_To_Date, int p_UserId, int p_ReportFilter)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspChequeDetailReport ObjPrint = new UspChequeDetailReport();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.AREA_ID = p_Area_id;
                ObjPrint.CHANNEL_TYPE_ID = p_ChannelType_Id;
                ObjPrint.CUSTOMER_ID = p_CustomerId;
                ObjPrint.STATUS_ID = p_Status_id;
                ObjPrint.ReportType = p_ReportFilter;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptChequeDetail"].ImportRow(dr);
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

        #region Added By Hazrat Ali

        /// <summary>
        /// Gets Data For Cheque Detail Report(Customer Credit)
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet GetCustomerCredit(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspCustomerCredit ObjPrint = new uspCustomerCredit();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                                
                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspCustomerCredit"].ImportRow(dr);
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

        #region OrderBooker Credit Aging Report

        /// <summary>
        /// Gets Data For OrderBooker Credit Aging Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_OrderBookerId">OrderBooker</param>
        /// <param name="p_Days">Days</param>
        /// <param name="p_Option">Option</param>
        /// <param name="p_ChannelType">ChannelType</param>
        /// <returns>DataSet</returns>
        public DataSet SelectOrderBookerCreditAging(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, int p_USER_ID, int p_OrderBookerId, int p_Days, int p_Option, int p_ChannelType, int p_DELIVERYMAN_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspOrderBookerCreditAging ObjPrint = new UspOrderBookerCreditAging();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.Credit_date = p_FromDate;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.ORDERBOOKER_ID = p_OrderBookerId;
                ObjPrint.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                ObjPrint.DAYS = p_Days;
                ObjPrint.TYPE_ID = p_Option;
                ObjPrint.CHANNEL_TYPE_ID = p_ChannelType;
                DataTable dt = ObjPrint.ExecuteTable();

                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCreditAgingOrderbooker"].ImportRow(dr);
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

        #region Customer Sale Report

        /// <summary>
        /// Gets Data For Customer Sale Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="User_Id">User</param>
        /// <param name="p_AreaId">Route</param>
        /// <param name="ChannelTypeId">ChannelType</param>
        /// <param name="p_IS_REGISTERED">IsRegistered</param>
        /// <param name="p_SaleForceId">SaleForce</param>
        /// <returns>DataTypes</returns>
        public DataSet SelectCustomerSaleReport(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int User_Id, int p_AreaId, int ChannelTypeId, bool p_IS_REGISTERED, int p_SaleForceId, int p_ORDERBOOKER_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();


                UspCustomerSaleReport ObjPrint = new UspCustomerSaleReport();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.AREA_ID = p_AreaId;
                ObjPrint.CHANNEL_TYPE_ID = ChannelTypeId;
                ObjPrint.SALEFORCE_ID = p_SaleForceId;
                ObjPrint.ORDERBOOKER_ID = p_ORDERBOOKER_ID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptCustomerSaleReport"].ImportRow(dr);
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

        #region Route Efficiency Report

        /// <summary>
        /// Gets Data For Route Efficiency Report
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_TOPCOUNT">Count</param>
        /// <param name="p_ORDERBOOKERID">OrderBooker</param>
        /// <returns>DataSet</returns>
        public DataSet GetRouteEfficiencyData(int p_DISTRIBUTOR_ID, int p_AREA_ID, int p_PRINCIPAL_ID, DateTime p_FromDate, DateTime p_To_Date, int p_TOPCOUNT, int p_ORDERBOOKERID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetRouteEfficiencyDate ObjPrint = new uspGetRouteEfficiencyDate();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjPrint.AREA_ID = p_AREA_ID;
                ObjPrint.PRINCIPAL_ID = p_PRINCIPAL_ID;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.TOPCOUNT = p_TOPCOUNT;
                ObjPrint.ORDERBOOKERID = p_ORDERBOOKERID;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspGetRouteEfficiencyDate"].ImportRow(dr);
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

        #region Non Productive Customer List Report

        /// <summary>
        /// Gets Data For Non Productive Customer List Report
        /// </summary>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_TOWN_ID">Town</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_CHANNEL_TYPE_ID">ChannelType</param>
        /// <param name="p_FROM_DATE">DateFrom</param>
        /// <param name="p_TO_DATE">DateTo</param>
        /// <returns>DataSet</returns>
        public DataSet GetUnProductiveCustomerList(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_TOWN_ID, int p_AREA_ID, int p_CHANNEL_TYPE_ID, DateTime p_FROM_DATE, DateTime p_TO_DATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspUnProductiveCustomerList ObjPrint = new uspUnProductiveCustomerList();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                ObjPrint.PRINCIPAL_ID = p_PRINCIPAL_ID;
                ObjPrint.TOWN_ID = p_TOWN_ID;
                ObjPrint.AREA_ID = p_AREA_ID;
                ObjPrint.CHANNEL_TYPE_ID = p_CHANNEL_TYPE_ID;
                ObjPrint.FROM_DATE = p_FROM_DATE;
                ObjPrint.TO_DATE = p_TO_DATE;

                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["ViewPrincipalWise_Customer"].ImportRow(dr);
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

        #endregion
    }
}