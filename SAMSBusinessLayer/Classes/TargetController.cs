using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Target Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Target
    /// </item>
    /// <term>
    /// Update Target
    /// </term>
    /// <item>
    /// Get Target
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
	public class TargetController
    {
        #region Constructor

        /// <summary>
        /// Constructor For TargetController
        /// </summary>
		public TargetController()
		{
			//
			// TODO: Add constructor logic here
			//
        }

        #endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Gets Target For SaleForce
        /// </summary>
        /// <param name="p_TargetMonth">Month</param>
        /// <param name="p_Target_For_Type_Id">Type</param>
        /// <param name="p_Target_For_Id">SaleForce</param>
        /// <param name="p_Distributor_Id">Location</param>
        /// <param name="p_PrincipalId">Prnicipal</param>
        /// <returns>Target For SaleForce as Datatable</returns>
        public DataTable SelectTarget(DateTime p_TargetMonth, int p_Target_For_Type_Id, int p_Target_For_Id, int p_Distributor_Id, int p_PrincipalId, int tag)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
				uspSelectTARGETInfo mTarget = new uspSelectTARGETInfo();
				mTarget.Connection = mConnection;

				mTarget.TARGET_MONTH = p_TargetMonth;
				mTarget.TARGET_FOR_TYPE_ID = p_Target_For_Type_Id;
				mTarget.TARGET_FOR_ID = p_Target_For_Id;
				mTarget.DISTRIBUTOR_ID = p_Distributor_Id;
                mTarget.PRINCIPAL_ID = p_PrincipalId;
                mTarget.TAG = tag;
				DataTable dt = mTarget.ExecuteTable();
				return dt;
				
			}
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return null;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}

        }

        #endregion

        #region Insert, Update

        /// <summary>
        /// Updates Target
        /// </summary>
        /// <param name="p_TargetId">Target</param>
        /// <param name="p_Distributor">Location</param>
        /// <param name="p_SKUUnitPrice">Price</param>
        /// <param name="p_Qty">Quantitiy</param>
        /// <param name="p_IS_ACTIVE">IsActive</param>
        /// <returns>"Record Updated"</returns>
        public string UpdateTarget(long p_TargetId, int p_Distributor, decimal p_SKUUnitPrice, int p_Qty, bool p_IS_ACTIVE)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spUpdateTARGET mTarget = new spUpdateTARGET();
                mTarget.Connection = mConnection;
                mTarget.TARGET_ID = p_TargetId;
                mTarget.DISTRIBUTOR_ID = p_Distributor;
                mTarget.TARGET_MONTH = Constants.DateNullValue;
                mTarget.TARGET_FOR_TYPE_ID = Constants.IntNullValue;
                mTarget.TARGET_FOR_ID = Constants.LongNullValue;
                mTarget.SKU_ID = Constants.LongNullValue;
                mTarget.UNIT_PRICE = p_SKUUnitPrice;
                mTarget.QUANTITY = p_Qty;
                mTarget.IS_ACTIVE = p_IS_ACTIVE;
                mTarget.VALUE_TYPE = 1;   
                mTarget.ExecuteQuery();

				return "Record Updated";				
			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
		}
        public string UpdateTarget(long p_TargetId, int p_Distributor, decimal p_SKUUnitPrice, int p_Qty, bool p_IS_ACTIVE, int p_VALUE_type)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateTARGET mTarget = new spUpdateTARGET();
                mTarget.Connection = mConnection;
                mTarget.TARGET_ID = p_TargetId;
                mTarget.DISTRIBUTOR_ID = p_Distributor;
                mTarget.TARGET_MONTH = Constants.DateNullValue;
                mTarget.TARGET_FOR_TYPE_ID = Constants.IntNullValue;
                mTarget.TARGET_FOR_ID = Constants.LongNullValue;
                mTarget.SKU_ID = Constants.LongNullValue;
                mTarget.UNIT_PRICE = p_SKUUnitPrice;
                mTarget.QUANTITY = p_Qty;
                mTarget.IS_ACTIVE = p_IS_ACTIVE;
                mTarget.VALUE_TYPE = p_VALUE_type;
                mTarget.ExecuteQuery();

                return "Record Updated";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
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
        public string UpdateTarget(long p_TargetId, int p_DistributorId, DateTime p_TargetMonth, int p_TargetForTypeId, int p_TargetForId, int p_SKUId, decimal p_SKUUnitPrice, int p_Qty, int p_PrincipalId, int p_UserId, int p_VALUE_type, bool is_active)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateTARGET mTarget = new spUpdateTARGET();
                mTarget.Connection = mConnection;
                mTarget.TARGET_ID = p_TargetId;
                mTarget.DISTRIBUTOR_ID = p_DistributorId;
                mTarget.TARGET_MONTH = p_TargetMonth;
                mTarget.TARGET_FOR_TYPE_ID = p_TargetForTypeId;
                mTarget.TARGET_FOR_ID = p_TargetForId;
                mTarget.SKU_ID = p_SKUId ;
                mTarget.PRINCIPAL_ID = p_PrincipalId;
                mTarget.USER_ID = p_UserId;
                mTarget.UNIT_PRICE = p_SKUUnitPrice;
                mTarget.QUANTITY = p_Qty;
                mTarget.IS_ACTIVE = is_active;
                mTarget.VALUE_TYPE = p_VALUE_type;
              
                mTarget.ExecuteQuery();

                return "Record Updated";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }
        }
        /// Inserts Target
        /// </summary>
        /// <param name="p_DistributorId">Location</param>
        /// <param name="p_TargetMonth">Month</param>
        /// <param name="p_TargetForTypeId">Type</param>
        /// <param name="p_TargetForId">SaleForce</param>
        /// <param name="p_SKUId">SKU</param>
        /// <param name="p_SKUUnitPrice">Price</param>
        /// <param name="p_Qty">Quantity</param>
        /// <param name="p_PrincipalId">Principal</param>
        /// <param name="p_UserId">InsertedBy</param>
        /// <returns>"Record Inserted"</returns>
        public string InsertTarget(int p_DistributorId, DateTime p_TargetMonth, int p_TargetForTypeId, int p_TargetForId, int p_SKUId, decimal p_SKUUnitPrice, int p_Qty, int p_PrincipalId, int p_UserId)
		{
			IDbConnection mConnection = null;
			try
			{
				mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
				mConnection.Open();
                spInsertTARGET mTarget = new spInsertTARGET();
                mTarget.Connection = mConnection;
                mTarget.DISTRIBUTOR_ID = p_DistributorId;
                mTarget.TARGET_MONTH = p_TargetMonth;
                mTarget.TARGET_FOR_TYPE_ID = p_TargetForTypeId;
                mTarget.TARGET_FOR_ID = p_TargetForId;
                mTarget.SKU_ID = p_SKUId;
                mTarget.UNIT_PRICE = p_SKUUnitPrice;
                mTarget.QUANTITY = p_Qty;
                mTarget.USER_ID = p_UserId;
                mTarget.PRINCIPAL_ID = p_PrincipalId;
                mTarget.IS_ACTIVE = true;
               mTarget.VALUE_TYPE = 1;  // 1 mean value wise
                mTarget.ExecuteQuery();
                return "Record Inserted";				
			}			
			catch(Exception exp)
			{
				ExceptionPublisher.PublishException(exp);				
				return exp.Message;
			}
			finally
			{
				if(mConnection != null && mConnection.State == ConnectionState.Open)
				{
					mConnection.Close();
				}
			}
        }

        public string InsertTarget(int p_DistributorId, DateTime p_TargetMonth, int p_TargetForTypeId, int p_TargetForId, int p_SKUId, decimal p_SKUUnitPrice, int p_Qty, int p_PrincipalId, int p_UserId, DataTable SkuDetail)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertTARGET mTarget = new spInsertTARGET();
                mTarget.Connection = mConnection;
                foreach (DataRow dr in SkuDetail.Rows)
                {
                    mTarget.DISTRIBUTOR_ID = p_DistributorId;
                    mTarget.TARGET_MONTH = p_TargetMonth;
                    mTarget.TARGET_FOR_TYPE_ID = p_TargetForTypeId;
                    mTarget.TARGET_FOR_ID = p_TargetForId;
                    mTarget.SKU_ID = int.Parse(dr["SKU_ID"].ToString());
                    mTarget.UNIT_PRICE = decimal.Parse(dr["TOTAL_AMOUNT"].ToString());
                    mTarget.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    mTarget.USER_ID = p_UserId;
                    mTarget.PRINCIPAL_ID = p_PrincipalId;
                    mTarget.IS_ACTIVE = true;
                    mTarget.VALUE_TYPE = 2; // mean sku wise
                    mTarget.ExecuteQuery();
                }
                return "Record Inserted";
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                return exp.Message;
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
