using System;
using SAMSDatabaseLayer.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSCommon.Classes;
using System.Data;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class For Menu Related Tasks
    /// <example>
    /// <list type="bullet">
    /// <item>
    /// Insert Menu Level
    /// </item>
    /// <item>
    /// Get Menu Level
    /// </item>
    /// </list>
    /// </example>
    /// </summary>
    public class MenuController
    {
        #region Public Methods

        #region Select
        
        /// <summary>
        /// Gets Menu Level
        /// </summary>
        /// <param name="p_MODULE_ID">LevelID</param>
        /// <param name="p_MODULE_PARENT_ID">ParentID</param>
        /// <param name="p_MODULE_TYPE_ID">Type</param>
        /// <returns>Datatable</returns>
        public DataTable GetMenuLevel(int p_MODULE_ID, int p_MODULE_PARENT_ID, int p_MODULE_TYPE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetMenuLevel ObjSelect = new uspGetMenuLevel();
                ObjSelect.Connection = mConnection;
                ObjSelect.MODULE_ID = p_MODULE_ID;
                ObjSelect.MODULE_PARENT_ID = p_MODULE_PARENT_ID;
                ObjSelect.MODULE_TYPE_ID = p_MODULE_TYPE_ID;

                DataTable dt = ObjSelect.ExecuteTable();
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
        /// Gets All Menu Items not in Menu Level
        /// </summary>
        /// <param name="p_MODULE_PARENT_ID">ParentID</param>
        /// <returns>Datatable</returns>
        public DataTable GetMenuItem(int p_MODULE_PARENT_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspGetMenuItem ObjSelect = new uspGetMenuItem();
                ObjSelect.Connection = mConnection;                
                ObjSelect.MODULE_PARENT_ID = p_MODULE_PARENT_ID;

                DataTable dt = ObjSelect.ExecuteTable();
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

        #region Insert, Update, Delete

        /// <summary>
        /// Insert Menu Level
        /// </summary>
        /// <param name="p_MODULE_DESCRIPTION">LevelName</param>
        /// <param name="p_MODULE_PARENT_ID">ParentID</param>
        /// <param name="p_MODULE_TYPE_ID">Type</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool InsertMenuLevel(string p_MODULE_DESCRIPTION, int p_MODULE_PARENT_ID, int p_MODULE_TYPE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspInsertMenuLevel ObjInsert = new uspInsertMenuLevel();
                ObjInsert.Connection = mConnection;
                ObjInsert.MODULE_DESCRIPTION = p_MODULE_DESCRIPTION;
                ObjInsert.MODULE_PARENT_ID = p_MODULE_PARENT_ID;
                ObjInsert.MODULE_TYPE_ID = p_MODULE_TYPE_ID;
                bool Bvalue = ObjInsert.ExecuteQuery();
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
        /// Updates Menu Level
        /// </summary>
        /// <param name="p_MODULE_ID">LevelID</param>
        /// <param name="p_MODULE_DESCRIPTION">LevelName</param>
        /// <param name="p_MODULE_PARENT_ID">ParentID</param>
        /// <param name="p_MODULE_TYPE_ID">Type</param>
        /// <returns>True on Success And False on Failure</returns>
        public bool UpdateMenuLevel(int p_MODULE_ID, string p_MODULE_DESCRIPTION, int p_MODULE_PARENT_ID, int p_MODULE_TYPE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspUpdateMenuLevel ObjUpdate = new uspUpdateMenuLevel();
                ObjUpdate.Connection = mConnection;
                ObjUpdate.MODULE_ID = p_MODULE_ID;
                ObjUpdate.MODULE_DESCRIPTION = p_MODULE_DESCRIPTION;
                ObjUpdate.MODULE_PARENT_ID = p_MODULE_PARENT_ID;
                ObjUpdate.MODULE_TYPE_ID = p_MODULE_TYPE_ID;
                bool Bvalue = ObjUpdate.ExecuteQuery();
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
        /// InActivate Menu Level
        /// </summary>
        /// <param name="p_MODULE_ID">LevelID</param>
        /// <returns>Datatable</returns>
        public DataTable DeleteMenuLevel(int p_MODULE_ID)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                uspDeleteMenu ObjSelect = new uspDeleteMenu();
                ObjSelect.Connection = mConnection;
                ObjSelect.MODULE_ID = p_MODULE_ID;

                DataTable dt = ObjSelect.ExecuteTable();
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
    }
}
