using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Sale Force Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Sale Force, Sale Force Area, Sale Force Principal
    /// </item>
    /// <term>
    /// Update Sale Force, Sale Force Area, Sale Force Principal
    /// </term>
    /// <item>
    /// Get Sale Force, Sale Force Area, Sale Force Principal
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class SaleForceController
    {
        #region Constructor
        
        /// <summary>
        /// Constructor for SaleForceController
        /// </summary>
        public SaleForceController()
        {

        }

        #endregion

        #region Public Methods

        #region Select 

        /// <summary>
        /// Gets Cash Received From Sale Force
        /// </summary>
        /// <remarks>
        /// Returns Cash Received From Sale Force as Datatable
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_DELIVERYMAN_ID">SaleForce</param>
        /// <param name="p_FROM_DATE">DateFrom</param>
        /// <param name="p_TO_DATE">DateTo</param>
        /// <returns>Cash Received From Sale Force as Datatable</returns>
        public DataTable GetSaleForceCash(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_DELIVERYMAN_ID, DateTime p_FROM_DATE, DateTime p_TO_DATE)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetSaleForceCashReceived mSaleForceCash = new uspGetSaleForceCashReceived();
                mSaleForceCash.Connection = mConnection;

                mSaleForceCash.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mSaleForceCash.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mSaleForceCash.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mSaleForceCash.FROM_DATE = p_FROM_DATE;
                mSaleForceCash.TO_DATE = p_TO_DATE;
                DataTable dt = mSaleForceCash.ExecuteTable();
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
        /// Gets Routes Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns Routes Assigned To Sale Force as Datatable
        /// </remarks>
        /// <param name="p_Type">Type</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="Area_Id">Route</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Routes To Sale Force as Datatable</returns>
        public DataTable SelectSaleForceAssignedArea(int p_Type, int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSaleForce_AssignAreaInfo mDistUser = new uspSelectSaleForce_AssignAreaInfo();
                mDistUser.Connection = mConnection;
                mDistUser.TYPE = p_Type;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;
                mDistUser.AREA_ID = Area_Id;
                DataTable dt = mDistUser.ExecuteTable();
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
        /// Gets Routes Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns Routes Assigned To Sale Force as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="Area_Id">Route</param>
        /// <param name="Companyid">Company</param>
        /// <returns>Routes Assigned To Sale Force as Datatable</returns>
        public DataTable SelectSaleForceAssignedArea(int p_Distributor_Id, int Area_Id, int Companyid)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectSP_DM_AssignAreaInfo mDistUser = new uspSelectSP_DM_AssignAreaInfo();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_Id;
                mDistUser.COMPANY_ID = Companyid;
                mDistUser.AREA_ID = Area_Id;
                DataTable dt = mDistUser.ExecuteTable();
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
        /// Gets Routes Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns Routes Assigned To Sale Force as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleForce_Id">SaleForce</param>
        /// <param name="p_Area_Id">Route</param>
        /// <returns>Routes Assigned To Sale Force as Datatable</returns>
        public DataTable SelectSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id, long p_Area_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALEFORCE_AREA_ASSIGNMENT mArea = new spSelectSALEFORCE_AREA_ASSIGNMENT();
                mArea.Connection = mConnection;
                mArea.DISTRIBUTOR_ID = p_Distributor_Id;
                mArea.SALEFORCE_ID = p_SaleForce_Id;
                mArea.AREA_ID = p_Area_Id;
                DataTable dt = mArea.ExecuteTable();
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
        /// Gets Principals Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns Principals Assigned To Sale Force as Datatable
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleForce_Id">SaleForce</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <returns>Principals Assigned To Sale Force as Datatable</returns>
        public DataTable SelectSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectSALEFORCE_PRINCIPAL_ASSIGNMENT mPrincipal = new spSelectSALEFORCE_PRINCIPAL_ASSIGNMENT();
                mPrincipal.Connection = mConnection;
                mPrincipal.DISTRIBUTOR_ID = p_Distributor_Id;
                mPrincipal.SALEFORCE_ID = p_SaleForce_Id;
                mPrincipal.PRINCIPAL_ID = p_Principal_Id;
                DataTable dt = mPrincipal.ExecuteTable();
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
        /// Gets Sale Force
        /// <remarks>
        /// Returns Sale Force Data as Datatable
        /// </remarks>
        /// </summary>
        /// <param name="p_Distributor_ID">Location</param>
        /// <param name="p_USER_TYPE_ID">Type</param>
        /// <param name="p_IsActive">IsActive</param>
        /// <returns>Sale Force Data as Datatable</returns>
        public DataTable SelectDistributorSalesForceType(int p_Distributor_ID, int p_USER_TYPE_ID, bool p_IsActive)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectDISTRIBUTOR_USER mDistUser = new spSelectDISTRIBUTOR_USER();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor_ID;
                mDistUser.USER_TYPE_ID = p_USER_TYPE_ID;
                mDistUser.IS_ACTIVE = p_IsActive;
                DataTable dt = mDistUser.ExecuteTable();
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
        /// Gets SaleForce For Rollback
        /// </summary>
        /// <param name="p_Type">Type</param>
        /// <param name="p_Principal">Principal</param>
        /// <param name="p_Distributor">Location</param>
        /// <returns>SaleForce For Rollback as Datatable</returns>
        public DataTable SelectRollBackInvoiceSaleForce(int p_Type, int p_Principal, int p_Distributor)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectRolebackSaleForce mDistUser = new uspSelectRolebackSaleForce();
                mDistUser.Connection = mConnection;
                mDistUser.DISTRIBUTOR_ID = p_Distributor;
                mDistUser.PRINCIPAL_ID = p_Principal;
                mDistUser.DOCUMENT_TYPE = p_Type;
                DataTable dt = mDistUser.ExecuteTable();
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
        /// Gets Assigned Sale Force To a Route
        /// </summary>
        /// <remarks>
        /// Returns Assigned Sale Force To a Route as Datatable
        /// </remarks>
        /// <param name="p_TYPE">Type</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_AREA_ID">Route</param>
        /// <param name="p_COMPANY_ID">Company</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <returns>Assigned Sale Force To a Route as Datatable</returns>
        public DataTable SelectSaleForceAssignedArea(int p_TYPE, int p_DISTRIBUTOR_ID, int p_AREA_ID, int p_COMPANY_ID, int p_PRINCIPAL_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspSelectPrincipalAreaWiseSaleForce mDistUser = new uspSelectPrincipalAreaWiseSaleForce();
                mDistUser.Connection = mConnection;
                mDistUser.TYPE = p_TYPE;
                mDistUser.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mDistUser.COMPANY_ID = p_COMPANY_ID;
                mDistUser.AREA_ID = p_AREA_ID;
                mDistUser.PRINCIPAL_ID = p_PRINCIPAL_ID;
                DataTable dt = mDistUser.ExecuteTable();
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

        #region Insert, Update, Deleted

        /// <summary>
        /// Inserts Cash Received From Sale Force
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_DELIVERYMAN_ID">SaleForce</param>
        /// <param name="p_DOCUMENT_DATE">Date</param>
        /// <param name="p_AMOUNT">Amount</param>
        /// <param name="p_USER_ID">InsertedBy</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool InsertSaleForceCash(int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_DELIVERYMAN_ID, DateTime p_DOCUMENT_DATE, decimal p_AMOUNT, int p_USER_ID)
        {
            IDbConnection mConnection = null;

            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                uspInsertSaleForceCashReceived mSaleForceCash = new uspInsertSaleForceCashReceived();
                mSaleForceCash.Connection = mConnection;

                mSaleForceCash.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mSaleForceCash.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mSaleForceCash.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                mSaleForceCash.DOCUMENT_DATE = p_DOCUMENT_DATE;
                mSaleForceCash.AMOUNT = p_AMOUNT;
                mSaleForceCash.USER_ID = p_USER_ID;

                mSaleForceCash.ExecuteQuery();

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

        /// <summary>
        /// Deletes Cash Received From Sale Force
        /// </summary>
        /// Returns True on Success And False on Failure
        /// <param name="p_SALE_FORCE_CASH_ID">CashReceived</param>
        /// <param name="p_DISTRIBUTOR_ID">Location</param>
        /// <param name="p_PRINCIPAL_ID">Principal</param>
        /// <param name="p_DELIVERYMAN_ID">SaleForce</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool DeleteSaleForceCash(int p_SALE_FORCE_CASH_ID, int p_DISTRIBUTOR_ID, int p_PRINCIPAL_ID, int p_DELIVERYMAN_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspDeleteSaleForceCashReceived mSaleForceCash = new uspDeleteSaleForceCashReceived();
                mSaleForceCash.Connection = mConnection;

                mSaleForceCash.SALE_FORCE_CASH_ID = p_SALE_FORCE_CASH_ID;
                mSaleForceCash.DISTRIBUTOR_ID = p_DISTRIBUTOR_ID;
                mSaleForceCash.PRINCIPAL_ID = p_PRINCIPAL_ID;
                mSaleForceCash.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                
                mSaleForceCash.ExecuteQuery();
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

        /// <summary>
        /// Updates Routes Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleForce_Id">SaleForce</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool UpdateSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALEFORCE_AREA_ASSIGNMENT MArea = new spUpdateSALEFORCE_AREA_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                bool Bvalue = MArea.ExecuteQuery();
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
        /// Inserts Route Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleForce_Id">SaleForce</param>
        /// <param name="p_Area_Id">Route</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool InsertSalesForceArea(int p_Distributor_Id, int p_SaleForce_Id, int p_Area_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALEFORCE_AREA_ASSIGNMENT MArea = new spInsertSALEFORCE_AREA_ASSIGNMENT();
                MArea.Connection = mConnection;
                MArea.DISTRIBUTOR_ID = p_Distributor_Id;
                MArea.SALEFORCE_ID = p_SaleForce_Id;
                MArea.AREA_ID = p_Area_Id;
                MArea.TIME_STAMP = DateTime.Now;
                bool Bvalue = MArea.ExecuteQuery();
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
        /// Updates Principal Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleForce_Id">SaleForce</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool UpdateSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateSALEFORCE_PRINCIPAL_ASSIGNMENT MPrincipal = new spUpdateSALEFORCE_PRINCIPAL_ASSIGNMENT();
                MPrincipal.Connection = mConnection;
                MPrincipal.DISTRIBUTOR_ID = p_Distributor_Id;
                MPrincipal.SALEFORCE_ID = p_SaleForce_Id;
                bool Bvalue = MPrincipal.ExecuteQuery();
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
        /// Inserts Principal Assigned To Sale Force
        /// </summary>
        /// <remarks>
        /// Returns True on Success And False on Failure
        /// </remarks>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_SaleForce_Id">SaleForce</param>
        /// <param name="p_Principal_Id">Principal</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool InsertSalesForcePrincipal(int p_Distributor_Id, int p_SaleForce_Id, int p_Principal_Id)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertSALEFORCE_PRINCIPAL_ASSIGNMENT MPrincipal = new spInsertSALEFORCE_PRINCIPAL_ASSIGNMENT();
                MPrincipal.Connection = mConnection;
                MPrincipal.DISTRIBUTOR_ID = p_Distributor_Id;
                MPrincipal.SALEFORCE_ID = p_SaleForce_Id;
                MPrincipal.PRINCIPAL_ID = p_Principal_Id;
                MPrincipal.TIME_STAMP = DateTime.Now;
                bool Bvalue = MPrincipal.ExecuteQuery();
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

        #endregion

        #endregion
    }
}