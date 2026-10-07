using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Fetching Data Of Inventory Reports
    /// </summary>
    public class RptInventoryController
    {
        #region Constructor

        /// <summary>
        /// Constructor for RptInventoryController
        /// </summary>
        public RptInventoryController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Public Methods

        /// <summary>
        /// Gets Data For Stock Reconciliation Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_USER_ID">User</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPrincipalStockReconcilation(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_UOM_ID, int p_PRICE_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                var objPrint = new uspRptSelectStockRegister();
                var ds = new Reports.DsReport();
                objPrint.Connection = mConnection;
                objPrint.distributor_id = p_Distributor_ID;
                objPrint.Company_Id = p_Principal_Id;
                objPrint.DateFrom = p_FromDate;
                objPrint.dateto = p_To_Date;
                objPrint.USER_ID = p_USER_ID;
                objPrint.UOM_ID = p_UOM_ID;
                objPrint.PRICE_TYPE = p_PRICE_TYPE;
                DataTable dt = objPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["StockRegister"].ImportRow(dr);
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
       
        public DataSet SelectDailySaleReport(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_UOM_ID, int p_PRICE_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                var objPrint = new uspRptDailySaleReport();
                var ds = new Reports.dsSalesPurchaseRegister();
                objPrint.Connection = mConnection;
                objPrint.distributor_id = p_Distributor_ID;
                objPrint.principal_id = p_Principal_Id;
                objPrint.DateFrom = p_FromDate;
                objPrint.dateto = p_To_Date;
                objPrint.USER_ID = p_USER_ID;
                objPrint.UOM_ID = p_UOM_ID;
                objPrint.PRICE_TYPE = p_PRICE_TYPE;
                DataTable dt = objPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["StockRegister"].ImportRow(dr);
                }

                var ObjPrint2 = new uspRptDailySaleReportRealization();
              
                ObjPrint2.Connection = mConnection;
                ObjPrint2.distributor_id = p_Distributor_ID;
                ObjPrint2.principal_id = p_Principal_Id;
                ObjPrint2.FROM_DATE = p_FromDate;
                ObjPrint2.TO_DATE = p_FromDate;
                ObjPrint2.USER_ID = p_USER_ID;
   
                DataTable dt2 = ObjPrint2.ExecuteTable();
            
                foreach (DataRow dr in dt2.Rows)
                {
                    ds.Tables["uspRptDailySaleReportRealization"].ImportRow(dr);
                }




                uspRptDailySaleReportCredit objPrintCredit = new uspRptDailySaleReportCredit();

                objPrintCredit.Connection = mConnection;
                objPrintCredit.distributor_id = p_Distributor_ID;
                objPrintCredit.principal_id = p_Principal_Id;
                objPrintCredit.FROM_DATE  = p_FromDate;
                objPrintCredit.TO_DATE = p_FromDate;
                objPrintCredit.USER_ID = p_USER_ID;

                DataTable dtCredit = objPrintCredit.ExecuteTable();

                foreach (DataRow dr in dtCredit.Rows)
                {
                    ds.Tables["RptDailySalesReportCredit"].ImportRow(dr);
                }


                uspRptDailySaleReportCheques objPrintCheque = new uspRptDailySaleReportCheques();

                objPrintCheque.Connection = mConnection;
                objPrintCheque.distributor_id = p_Distributor_ID;
                objPrintCheque.principal_id = p_Principal_Id;
                objPrintCheque.FROM_DATE = p_FromDate;
                objPrintCheque.TO_DATE = p_FromDate;
                objPrintCheque.USER_ID = p_USER_ID;

                DataTable dtCheque = objPrintCheque.ExecuteTable();

                foreach (DataRow dr in dtCheque.Rows)
                {
                    ds.Tables["uspRptDailySaleReportCheques"].ImportRow(dr);
                }





                uspRptDailySaleReportFuel ObjPrint3 = new uspRptDailySaleReportFuel();

                ObjPrint3.Connection = mConnection;
                ObjPrint3.distributor_id = p_Distributor_ID;
                ObjPrint3.principal_id = p_Principal_Id;
                ObjPrint3.FROM_DATE = p_FromDate;
                ObjPrint3.TO_DATE = p_FromDate;
                ObjPrint3.USER_ID = p_USER_ID;

                DataTable dt3 = ObjPrint3.ExecuteTable();
            
                foreach (DataRow dr in dt3.Rows)
                {
                    ds.Tables["uspRptDailySaleReportFuel"].ImportRow(dr);
                }



                uspRptDailySaleReportExpenses ObjPrint4 = new uspRptDailySaleReportExpenses();

                ObjPrint4.Connection = mConnection;
                ObjPrint4.distributor_id = p_Distributor_ID;
                ObjPrint4.principal_id = p_Principal_Id;
                ObjPrint4.FROM_DATE = p_FromDate;
                ObjPrint4.TO_DATE = p_FromDate;
                ObjPrint4.USER_ID = p_USER_ID;

                DataTable dt4 = ObjPrint4.ExecuteTable();

                foreach (DataRow dr in dt4.Rows)
                {
                    ds.Tables["uspRptDailySaleReportExpenses"].ImportRow(dr);
                }





                uspRptDailySaleReportDiscount objPrintDiscount = new uspRptDailySaleReportDiscount();

                objPrintDiscount.Connection = mConnection;
                objPrintDiscount.distributor_id = p_Distributor_ID;
                objPrintDiscount.principal_id = p_Principal_Id;
                objPrintDiscount.FROM_DATE = p_FromDate;
                objPrintDiscount.TO_DATE = p_FromDate;
                objPrintDiscount.USER_ID = p_USER_ID;

                DataTable dtdiscount = objPrintDiscount.ExecuteTable();

                foreach (DataRow dr in dtdiscount.Rows)
                {
                    ds.Tables["uspRptDailySaleReportDiscount"].ImportRow(dr);
                }

                uspRptDailySaleReportCommulativeDiscount objPrintComDisc = new uspRptDailySaleReportCommulativeDiscount();

                objPrintComDisc.Connection = mConnection;
                objPrintComDisc.distributor_id = p_Distributor_ID;
                objPrintComDisc.principal_id = p_Principal_Id;
                objPrintComDisc.FROM_DATE = p_FromDate;
                objPrintComDisc.TO_DATE = p_FromDate;
                objPrintComDisc.USER_ID = p_USER_ID;

                DataTable dtcomdis = objPrintComDisc.ExecuteTable();

                foreach (DataRow dr in dtcomdis.Rows)
                {
                    ds.Tables["uspRptDailySaleReportCommulativeDiscount"].ImportRow(dr);
                }


                uspRptDailySaleReportNote objPrintNote = new uspRptDailySaleReportNote();

                objPrintNote.Connection = mConnection;
                objPrintNote.distributor_id = p_Distributor_ID;
                objPrintNote.principal_id = p_Principal_Id;
                objPrintNote.FROM_DATE = p_FromDate;
                objPrintNote.TO_DATE = p_FromDate;
                objPrintNote.USER_ID = p_USER_ID;

                DataTable dtNote= objPrintNote.ExecuteTable();

                foreach (DataRow dr in dtNote.Rows)
                {
                    ds.Tables["uspRptDailySaleReportNote"].ImportRow(dr);
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
        /// Gets Data For Date Wise Stock Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_TypeId">Type</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPurchaseTransferStock(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId, int p_RATE_TYPE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDailyPurchaseTransfer ObjPrint = new UspDailyPurchaseTransfer();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.TYPEID = p_TypeId;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.RATE_TYPE = p_RATE_TYPE;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["DailyPurchaseTransferReport"].ImportRow(dr);
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

        #region Transfer In/Out Report

        /// <summary>
        /// Gets Data For Transfer In/Out Report (In Value)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_FromTime">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_TransferType">Type</param>
        /// <param name="p_type">ReportTyp</param>
        /// <returns>DataSet</returns>
        public DataSet TransferInOutValue(int p_Principal_ID, int p_Distributor_ID, DateTime p_FromTime, DateTime p_ToDate, string p_TransferType, int p_type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspTransferInOutValue mTransferIn = new UspTransferInOutValue();
                mTransferIn.Connection = mConnection;

                mTransferIn.PRINCIPAL_ID = p_Principal_ID;
                mTransferIn.DISTRIBUTOR_ID = p_Distributor_ID;
                mTransferIn.FromDate = p_FromTime;
                mTransferIn.ToDate = p_ToDate;
                mTransferIn.TransferType = p_TransferType;
                mTransferIn.ReportType = p_type;
                DataTable DT = mTransferIn.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptTransferInOutValueWise"].ImportRow(dr);
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
        /// Gets Data For Transfer In/Out Report (In Quantity And Carton)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_FromTime">DateFrom</param>
        /// <param name="p_ToDate">DateTo</param>
        /// <param name="p_TransferType">Type</param>
        /// <param name="p_type">ReportType</param>
        /// <returns>DataSet</returns>
        public DataSet TransferIn(int p_Principal_ID, int p_Distributor_ID, DateTime p_FromTime, DateTime p_ToDate, string p_TransferType, int p_type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                UspTransferInrpt mTransferIn = new UspTransferInrpt();
                mTransferIn.Connection = mConnection;

                mTransferIn.PRINCIPAL_ID = p_Principal_ID;
                mTransferIn.DISTRIBUTOR_ID = p_Distributor_ID;
                mTransferIn.FromDate = p_FromTime;
                mTransferIn.ToDate = p_ToDate;
                mTransferIn.TransferType = p_TransferType;
                mTransferIn.ReportType = p_type;
                DataTable DT = mTransferIn.ExecuteTable();

                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["TransferIn"].ImportRow(dr);
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

        #region  Physical Stock Report

        /// <summary>
        /// Gets Data For  Physical Stock Report (SKU Wise)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Date">Date</param>
        /// <returns>DataSet</returns>
        public DataSet PhysicalStockTaking(int p_Principal_ID, int p_Distributor_ID, DateTime p_Date)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                RptPhysicalStockTaking mStockTaking = new RptPhysicalStockTaking();

                mStockTaking.Connection = mConnection;
                mStockTaking.PRINCIPAL_ID = p_Principal_ID;
                mStockTaking.DISTRIBUTOR_ID = p_Distributor_ID;
                mStockTaking.Date = p_Date;

                DataTable DT = mStockTaking.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["PhysicalStockTaking"].ImportRow(dr);
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
        /// Gets Data For  Physical Stock Report (Value Wise)
        /// </summary>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Date">Date</param>
        /// <param name="p_UserId">User</param>
        /// <returns>DataSet</returns>
        public DataSet PhysicalStockTakingValueWise(int p_Principal_ID, int p_Distributor_ID, DateTime p_Date, int p_UserId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();

                RptPhysicalStockTakingSummary mStockTaking = new RptPhysicalStockTakingSummary();

                mStockTaking.Connection = mConnection;
                mStockTaking.PRINCIPAL_ID = p_Principal_ID;
                mStockTaking.DISTRIBUTOR_ID = p_Distributor_ID;
                mStockTaking.Date = p_Date;
                mStockTaking.USER_ID = p_UserId;

                DataTable DT = mStockTaking.ExecuteTable();
                foreach (DataRow dr in DT.Rows)
                {
                    ds.Tables["RptPhysicalStockValue"].ImportRow(dr);
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
        /// Gets Data For Purchase Document Report
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <param name="p_FromDate">DateFrom</param>
        /// <param name="p_To_Date">DateTo</param>
        /// <param name="p_TypeId">Type</param>
        /// <returns>DataSet</returns>
        public DataSet SelectPurchaseDocument(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_TypeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                GetPurchasedocument ObjPrint = new GetPurchasedocument();
                SAMSBusinessLayer.Reports.DsReport ds = new SAMSBusinessLayer.Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.TYPE_ID = p_TypeId;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["RptPurchaseDocument"].ImportRow(dr);
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
        /// Gets Data For Stock Valuation Report
        /// </summary>
        /// <param name="p_StockDate">Date</param>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_Principal_ID">Principal</param>
        /// <param name="p_USER_ID">User</param>
        /// <param name="p_ReportType">ReportType</param>
        /// <returns>DataSet</returns>
        public DataSet SelectStockValuation(DateTime p_StockDate, int p_Distributor_ID, int p_Principal_ID, int p_USER_ID, int p_ReportType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetStockValuation ObjPrint = new uspGetStockValuation();
                SAMSBusinessLayer.Reports.DsReport2 ds = new SAMSBusinessLayer.Reports.DsReport2();
                ObjPrint.Connection = mConnection;
                ObjPrint.STOCK_DATE = p_StockDate;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.PRINCIPAL_ID = p_Principal_ID;
                ObjPrint.USER_ID = p_USER_ID;
                ObjPrint.TYPE = p_ReportType;
                DataTable dt = ObjPrint.ExecuteTable();
                if (p_ReportType == 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ds.Tables["rptStockValuationDetail"].ImportRow(dr);
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ds.Tables["rptStockValuationSummary"].ImportRow(dr);
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


        public DataSet RptDamageDetial(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, string p_Damage_Type, int p_RATE_TYPE)
        {

            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspDamageDetailReport ObjPrint = new UspDamageDetailReport();
                Reports.DsReport ds = new Reports.DsReport();
                ObjPrint.Connection = mConnection;
                ObjPrint.DISTRIBUTOR_ID = p_Distributor_ID;
                ObjPrint.TYPEID = p_Damage_Type;
                ObjPrint.PRINCIPAL_ID = p_Principal_Id;
                ObjPrint.FROM_DATE = p_FromDate;
                ObjPrint.TO_DATE = p_To_Date;
                ObjPrint.RATE_TYPE = p_RATE_TYPE;
                DataTable dt = ObjPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["DailyPurchaseTransferReport"].ImportRow(dr);
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



        public DataSet SelectCreditLimitUsage(int p_Distributor_ID, int p_Principal_Id, DateTime p_FromDate, DateTime p_To_Date, int p_USER_ID, int p_Report_type, int p_User_Type )
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                var objPrint = new uspRptcreditLimitUsage();
                var ds = new Reports.dsSalesPurchaseRegister();
                objPrint.Connection = mConnection;
                objPrint.distributor_id = p_Distributor_ID;
               // objPrint.Company_Id = p_Principal_Id;
                objPrint.principal_id = p_Principal_Id;
                objPrint.DateFrom = p_FromDate;
                objPrint.dateto = p_To_Date;
                objPrint.USER_ID = p_USER_ID;
                objPrint.report_type = p_User_Type;
                objPrint.USER_TYPE = p_User_Type;
                DataTable dt = objPrint.ExecuteTable();
                foreach (DataRow dr in dt.Rows)
                {
                    ds.Tables["uspRptcreditLimitUsage"].ImportRow(dr);
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
    }
}
