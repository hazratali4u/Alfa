using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For HHT Order Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert HHT Order
    /// </item>
    /// Get HHT Orders
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class HHPostingController
    {

        #region Constructor

        /// <summary>
        /// Constructor for HHPostingController
        /// </summary>
        public HHPostingController()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

        #region Public Methods

        #region Select

        /// <summary>
        /// Gets HHT Orders
        /// </summary>
        /// <param name="p_OrderBookerID">OrderBooker</param>
        /// <param name="p_AreaID">Market</param>
        /// <returns>HHT Orders as Datatable</returns>
        public DataTable GetOrders(int p_OrderBookerID, int p_AreaID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();

                UspGetSaleOrderforPosting mGetOrder = new UspGetSaleOrderforPosting();

                mGetOrder.Connection = mConnection;
                mGetOrder.AREA_ID = p_AreaID;
                mGetOrder.ORDERBOOKER_ID = p_OrderBookerID;

                DataTable dt = mGetOrder.ExecuteTable();
                return dt;
            }
            catch (Exception exp)
            {
                //ExceptionPublisher.PublishException(exp);		
                exp.ToString();
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

        #region Insert

        /// <summary>
        /// Post HHT Orders To Database
        /// </summary>
        /// <param name="p_HHSaleOrderId">HHOrder</param>
        /// <param name="p_OrderBookerID">OrderBooker</param>
        /// <param name="p_DELIVERYMAN_ID">Deliveryman</param>
        /// <param name="p_Order_Type_ID">Type</param>
        /// <param name="p_UserID">InsertedBy</param>
        /// <returns></returns>
        public bool InsertSaleOrderMaster(int p_HHSaleOrderId,int p_OrderBookerID, int p_DELIVERYMAN_ID, int p_Order_Type_ID, int p_UserID)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                UspPostingHHOrder pInsert = new UspPostingHHOrder();
                pInsert.Connection = mConnection;
                pInsert.Transaction = mTransaction;
                pInsert.HHSaleOrderId = p_HHSaleOrderId;
                pInsert.ORDERBOOKER_ID = p_OrderBookerID;
                pInsert.DELIVERYMAN_ID = p_DELIVERYMAN_ID;
                pInsert.ORDER_TYPE_ID  = p_Order_Type_ID;
                pInsert.UserID = p_UserID;
               
                bool Bvalue1 = pInsert.ExecuteQuery();
                if (Bvalue1 == true)
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
                ExceptionPublisher.PublishException(exp);		
                mTransaction.Rollback();  
                exp.ToString();
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
