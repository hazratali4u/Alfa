using System;
using System.Data;
using SAMSCommon.Classes;
using SAMSDataAccessLayer.Classes;
using SAMSDatabaseLayer.Classes;

namespace SAMSBusinessLayer.Classes
{
    
    public class EmployeController
    {
        #region Constructor
        public EmployeController()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion


        #region Public Methods
        public int  InsertEmployee(string p_EmpName,string p_FatherName,string p_AccountNo,string p_BankName,string p_BranchName,int p_Locationid,int p_Departmentid,
                                        int p_DesignationId , int p_EmpTypeid,string p_NICNo,string p_Nationalty,string p_Region,DateTime p_dateofBirth, DateTime p_dateofJoin,
                                        string p_Gender, string p_matrialStatus, string p_Bloodgroup, string p_PresentAddress, string p_PermentAddress, int p_Townid, int p_Areaid, string p_Phoneno, string p_CellNo, string p_EmailAddress,DataTable p_dtQulification,DataTable p_dtExprience,DataTable  p_dtReference,decimal p_BasicSalary,int p_SalaryRole)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {
                
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spInsertEMPLOYEE_INFORMATION mDistributorUser = new spInsertEMPLOYEE_INFORMATION();
                mDistributorUser.Connection = mConnection;
                mDistributorUser.Transaction = mTransaction;
                mDistributorUser.EMPLOYEE_NAME = p_EmpName;
                mDistributorUser.FATHER_NAME = p_FatherName;
                mDistributorUser.ACCOUNT_NO = p_AccountNo;
                mDistributorUser.BANK_NAME = p_BankName;
                mDistributorUser.BRANCH = p_BranchName;
                mDistributorUser.LOCATION_ID = p_Locationid;
                mDistributorUser.DEPARTMENT_ID = p_Departmentid;
                mDistributorUser.DESIGNATION_ID = p_DesignationId;
                mDistributorUser.EMPLOYEE_TYPE_ID = p_EmpTypeid;
                mDistributorUser.NIC_NO = p_NICNo;
                mDistributorUser.NATIONALTY = p_Nationalty;
                mDistributorUser.RELIGION = p_Region;
                mDistributorUser.DATE_BIRTH = p_dateofBirth;
                mDistributorUser.DATE_JOIN = p_dateofJoin;
                mDistributorUser.GENDER = p_Gender;
                mDistributorUser.MATRIAL_STATUS = p_matrialStatus;
                mDistributorUser.BLOOD_GROUP = p_Bloodgroup;
                mDistributorUser.PRESENT_ADDRESS = p_PresentAddress;
                mDistributorUser.PERMANENT_ADDRESS = p_PermentAddress;
                mDistributorUser.PHONE_NO = p_Phoneno;
                mDistributorUser.CELL_NO = p_CellNo;
                mDistributorUser.EMAIL_ADDRESS = p_EmailAddress;
                mDistributorUser.LASTUPDATED = DateTime.Now;   
                mDistributorUser.IS_ACTIVE = true;
                mDistributorUser.BASIC_SALARY = p_BasicSalary;
                mDistributorUser.EMPLOYEE_NORMS_ID = p_SalaryRole;  
                mDistributorUser.ExecuteQuery();

                foreach (DataRow dr in p_dtQulification.Rows)
                {
                    spInsertEMPLOYEE_QULIFICATION mUserQulification = new spInsertEMPLOYEE_QULIFICATION();
                    mUserQulification.Connection = mConnection;
                    mUserQulification.Transaction = mTransaction;
                    mUserQulification.EMPLOYEE_ID = mDistributorUser.EMPLOYEE_ID;
                    mUserQulification.INSTUTITION_NAME = dr["InstituteName"].ToString();
                    mUserQulification.FROM_DATE = dr["FromDate"].ToString();
                    mUserQulification.TO_DATE = dr["ToDate"].ToString();
                    mUserQulification.MAJ_SUBJECT = dr["Maj_Subject"].ToString();
                    mUserQulification.DEVISION = dr["Division"].ToString();
                    mUserQulification.EDUCATION_ACHIVEMENT = dr["Education_Achivement"].ToString();
                    mUserQulification.ExecuteQuery();  
                }
                foreach (DataRow dr in p_dtExprience.Rows)
                {
                    spInsertEMPLOYEE_EXPERIENCE mUserExperience = new spInsertEMPLOYEE_EXPERIENCE();
                    mUserExperience.Connection = mConnection;
                    mUserExperience.Transaction = mTransaction;
                    mUserExperience.EMPLOYEE_ID = mDistributorUser.EMPLOYEE_ID;
                    mUserExperience.ORGANIZATION = dr["ORGANIZATION"].ToString();
                    mUserExperience.FROM_DATE = dr["FromDate"].ToString();
                    mUserExperience.TO_DATE = dr["ToDate"].ToString();
                    mUserExperience.DESIGNATION = dr["DESIGNATION"].ToString();
                    mUserExperience.SALARY = decimal.Parse(dr["SALARY"].ToString());
                    mUserExperience.PHONE = dr["PHONE"].ToString();
                    mUserExperience.BUSINESS_TYPE = dr["BUSINESS_TYPE"].ToString();
                    mUserExperience.ExecuteQuery();
                }
                foreach (DataRow dr in p_dtReference.Rows)
                {
                    spInsertEMPLOYEE_REFERENCE mUserRefernce = new spInsertEMPLOYEE_REFERENCE();
                    mUserRefernce.Connection = mConnection;
                    mUserRefernce.Transaction = mTransaction;
                    mUserRefernce.EMPLOYEE_ID = mDistributorUser.EMPLOYEE_ID;
                    mUserRefernce.REFERENCE_NAME = dr["REFERENCE_NAME"].ToString();
                    mUserRefernce.COMPANY_NAME = dr["COMPANY_NAME"].ToString();
                    mUserRefernce.ADDRESS = dr["ADDRESS"].ToString();
                    mUserRefernce.CONTACT = dr["CONTACT"].ToString();
                    mUserRefernce.RELATION = dr["RELATION"].ToString();
                    mUserRefernce.DURATION = dr["DURATION"].ToString() ;
                    mUserRefernce.ExecuteQuery();
                }
                mTransaction.Commit();
                return mDistributorUser.EMPLOYEE_ID;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();  
                return -1;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }

        public int UpdatedEmployee(int p_EmpId,string p_EmpName, string p_FatherName, string p_AccountNo, string p_BankName, string p_BranchName, int p_Locationid, int p_Departmentid,
                                       int p_DesignationId, int p_EmpTypeid, string p_NICNo, string p_Nationalty, string p_Region, DateTime p_dateofBirth, DateTime p_dateofJoin,
                                       string p_Gender, string p_matrialStatus, string p_Bloodgroup, string p_PresentAddress, string p_PermentAddress, int p_Townid, int p_Areaid, string p_Phoneno, string p_CellNo, string p_EmailAddress,DataTable p_dtQulification,DataTable p_dtExprience,DataTable  p_dtReference,decimal p_BasicSalary,int p_SalaryRole)
        {
            IDbConnection mConnection = null;
            IDbTransaction mTransaction = null;
            try
            {

                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                mTransaction = ProviderFactory.GetTransaction(mConnection);
                spUpdateEMPLOYEE_INFORMATION mDistributorUser = new spUpdateEMPLOYEE_INFORMATION();
                mDistributorUser.Connection = mConnection;
                mDistributorUser.Transaction = mTransaction;
                mDistributorUser.EMPLOYEE_ID = p_EmpId;  
                mDistributorUser.EMPLOYEE_NAME = p_EmpName;
                mDistributorUser.FATHER_NAME = p_FatherName;
                mDistributorUser.ACCOUNT_NO = p_AccountNo;
                mDistributorUser.BANK_NAME = p_BankName;
                mDistributorUser.BRANCH = p_BranchName;
                mDistributorUser.LOCATION_ID = p_Locationid;
                mDistributorUser.DEPARTMENT_ID = p_Departmentid;
                mDistributorUser.DESIGNATION_ID = p_DesignationId;
                mDistributorUser.EMPLOYEE_TYPE_ID = p_EmpTypeid;
                mDistributorUser.NIC_NO = p_NICNo;
                mDistributorUser.NATIONALTY = p_Nationalty;
                mDistributorUser.RELIGION = p_Region;
                mDistributorUser.DATE_BIRTH = p_dateofBirth;
                mDistributorUser.DATE_JOIN = p_dateofJoin;
                mDistributorUser.GENDER = p_Gender;
                mDistributorUser.MATRIAL_STATUS = p_matrialStatus;
                mDistributorUser.BLOOD_GROUP = p_Bloodgroup;
                mDistributorUser.PRESENT_ADDRESS = p_PresentAddress;
                mDistributorUser.PERMANENT_ADDRESS = p_PermentAddress;
                mDistributorUser.PHONE_NO = p_Phoneno;
                mDistributorUser.CELL_NO = p_CellNo;
                mDistributorUser.EMAIL_ADDRESS = p_EmailAddress;
                mDistributorUser.LASTUPDATED = DateTime.Now;
                mDistributorUser.IS_ACTIVE = true;
                mDistributorUser.BASIC_SALARY = p_BasicSalary;
                mDistributorUser.EMPLOYEE_NORMS_ID = p_SalaryRole;  
                mDistributorUser.ExecuteQuery();
                mTransaction.Commit();

                //delete employee detail 
                UspDeleteEmployeeDetail mDelete = new UspDeleteEmployeeDetail();
                mDelete.Connection = mConnection;
                mDelete.Transaction = mTransaction;
                mDelete.EMPLOYEE_ID = p_EmpId;
                mDelete.ExecuteQuery();
  
                foreach (DataRow dr in p_dtQulification.Rows)
                {
                    spInsertEMPLOYEE_QULIFICATION mUserQulification = new spInsertEMPLOYEE_QULIFICATION();
                    mUserQulification.Connection = mConnection;
                    mUserQulification.Transaction = mTransaction;
                    mUserQulification.EMPLOYEE_ID = mDistributorUser.EMPLOYEE_ID;
                    mUserQulification.INSTUTITION_NAME = dr["InstituteName"].ToString();
                    mUserQulification.FROM_DATE = dr["FromDate"].ToString();
                    mUserQulification.TO_DATE = dr["ToDate"].ToString();
                    mUserQulification.MAJ_SUBJECT = dr["Maj_Subject"].ToString();
                    mUserQulification.DEVISION = dr["Division"].ToString();
                    mUserQulification.EDUCATION_ACHIVEMENT = dr["Education_Achivement"].ToString();
                    mUserQulification.ExecuteQuery();  
                }
                foreach (DataRow dr in p_dtExprience.Rows)
                {
                    spInsertEMPLOYEE_EXPERIENCE mUserExperience = new spInsertEMPLOYEE_EXPERIENCE();
                    mUserExperience.Connection = mConnection;
                    mUserExperience.Transaction = mTransaction;
                    mUserExperience.EMPLOYEE_ID = mDistributorUser.EMPLOYEE_ID;
                    mUserExperience.ORGANIZATION = dr["ORGANIZATION"].ToString();
                    mUserExperience.FROM_DATE = dr["FromDate"].ToString();
                    mUserExperience.TO_DATE = dr["ToDate"].ToString();
                    mUserExperience.DESIGNATION = dr["DESIGNATION"].ToString();
                    mUserExperience.SALARY = decimal.Parse(dr["SALARY"].ToString());
                    mUserExperience.PHONE = dr["PHONE"].ToString();
                    mUserExperience.BUSINESS_TYPE = dr["BUSINESS_TYPE"].ToString();
                    mUserExperience.ExecuteQuery();  
                }
                foreach (DataRow dr in p_dtReference.Rows)
                {
                    spInsertEMPLOYEE_REFERENCE mUserRefernce = new spInsertEMPLOYEE_REFERENCE();
                    mUserRefernce.Connection = mConnection;
                    mUserRefernce.Transaction = mTransaction;
                    mUserRefernce.EMPLOYEE_ID = mDistributorUser.EMPLOYEE_ID;
                    mUserRefernce.REFERENCE_NAME = dr["REFERENCE_NAME"].ToString();
                    mUserRefernce.COMPANY_NAME = dr["COMPANY_NAME"].ToString();
                    mUserRefernce.ADDRESS = dr["ADDRESS"].ToString();
                    mUserRefernce.CONTACT = dr["CONTACT"].ToString();
                    mUserRefernce.RELATION = dr["RELATION"].ToString();
                    mUserRefernce.DURATION = dr["DURATION"].ToString();
                    mUserRefernce.ExecuteQuery();  
                }
                return p_EmpId;
            }
            catch (Exception exp)
            {
                ExceptionPublisher.PublishException(exp);
                mTransaction.Rollback();
                return -1;
            }
            finally
            {
                if (mConnection != null && mConnection.State == ConnectionState.Open)
                {
                    mConnection.Close();
                }
            }

        }
        public DataTable UspSelectEmployee(int p_Distributor_Id, string p_FIELDNAME, string p_PARAMETERNAME)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectEmployee mCustData = new UspSelectEmployee();
                mCustData.Connection = mConnection;
                mCustData.FEILDNAME = p_FIELDNAME;
                mCustData.PARAMETER = p_PARAMETERNAME;
                mCustData.DISTRIBUTOR_ID = p_Distributor_Id;
                DataTable dt = mCustData.ExecuteTable();
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
        public void InsertEmployeerole(string p_RoleDescription)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertEMPLOYEE_ROLESMASTER mCustData = new spInsertEMPLOYEE_ROLESMASTER();
                mCustData.Connection = mConnection;
                mCustData.ROLE_DESCRIPTION = p_RoleDescription;
                mCustData.TIME_STAMPS = DateTime.Now;
                mCustData.ExecuteQuery();

           
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
        public void InsertEmployeeNorms(int p_Role,int p_NormsId,bool p_Taxable,decimal p_Amount)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertEMPLOYEE_ROLEDETAIL mCustData = new spInsertEMPLOYEE_ROLEDETAIL();
                mCustData.Connection = mConnection;
                mCustData.ROLE_ID = p_Role;
                mCustData.NORMS_ID = p_NormsId;
                mCustData.IS_TAXABLE = p_Taxable;
                mCustData.AMOUNT = p_Amount; 
                mCustData.TIME_STAMP = DateTime.Now;
                mCustData.ExecuteQuery();


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
        public DataTable SelectEmployeerole()
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_ROLESMASTER mSelect = new spSelectEMPLOYEE_ROLESMASTER();
                mSelect.Connection = mConnection;
                mSelect.ROLE_DESCRIPTION = null;
                mSelect.ROLE_ID = Constants.IntNullValue;
                mSelect.TIME_STAMPS = Constants.DateNullValue;
                DataTable dt =  mSelect.ExecuteTable();
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
        public DataTable SelectEmployeeNormsDetail(int p_RoleId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_ROLEDETAIL mSelect = new spSelectEMPLOYEE_ROLEDETAIL();
                mSelect.Connection = mConnection;
                mSelect.NORMS_ID = Constants.IntNullValue;
                mSelect.ROLE_ID = p_RoleId;
                DataTable dt = mSelect.ExecuteTable();
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
        public void DeleteEmployeerole(int p_Roleid,int p_NormsId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spDeleteEMPLOYEE_ROLEDETAIL mCustData = new spDeleteEMPLOYEE_ROLEDETAIL();
                mCustData.Connection = mConnection;
                mCustData.ROLE_ID = p_Roleid;
                mCustData.NORMS_ID = p_NormsId;
                mCustData.ExecuteQuery();


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
        public DataTable SelectEmployeeQulification(int p_EmployeeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_QULIFICATION mSelect = new spSelectEMPLOYEE_QULIFICATION();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_ID = p_EmployeeId;
                DataTable dt = mSelect.ExecuteTable();
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
        public DataTable SelectEmployeeExperience(int p_EmployeeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_EXPERIENCE mSelect = new spSelectEMPLOYEE_EXPERIENCE();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_ID = p_EmployeeId;
                DataTable dt = mSelect.ExecuteTable();
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
        public DataTable SelectEmployeeReference(int p_EmployeeId)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_REFERENCE mSelect = new spSelectEMPLOYEE_REFERENCE();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_ID = p_EmployeeId;
                DataTable dt = mSelect.ExecuteTable();
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
        public DataTable SelectEmployeebyLocation(int p_LocationId,int p_Designation,bool p_Bool)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_INFORMATION mSelect = new spSelectEMPLOYEE_INFORMATION();
                mSelect.Connection = mConnection;
                mSelect.LOCATION_ID  = p_LocationId ;
                mSelect.DESIGNATION_ID = p_Designation;
                mSelect.EMPLOYEE_ID = Constants.IntNullValue;
                mSelect.EMPLOYEE_TYPE_ID = Constants.IntNullValue;
                mSelect.TOWN_ID = Constants.IntNullValue;
                mSelect.DEPARTMENT_ID = Constants.IntNullValue;   
                mSelect.IS_ACTIVE = p_Bool;
                DataTable dt = mSelect.ExecuteTable();
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
        public void InsertEmployeeLeave(int p_EmployeeId, int p_DayTyeId,int p_LeaveTypeId,DateTime p_FromDate,DateTime p_ToDate,decimal  p_AllowDays,decimal  p_UsedDays,bool p_Iscancel,string pRemarks)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spInsertEMPLOYEE_LEAVE mSelect = new spInsertEMPLOYEE_LEAVE();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_ID  = p_EmployeeId;
                mSelect.LEAVE_TYPE_ID = p_LeaveTypeId;
                mSelect.DAY_TYPE_ID = p_DayTyeId;
                mSelect.FROM_DATE = p_FromDate;
                mSelect.TO_DATE = p_ToDate;
                mSelect.ALLOW_DAYS = p_AllowDays;
                mSelect.USED_DAYS = p_UsedDays;
                mSelect.IS_CANCEL = p_Iscancel;
                mSelect.TIME_STAMP = DateTime.Now;
                mSelect.REMARKS = pRemarks;  
                mSelect.ExecuteQuery();  
                
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
        public void UpdateEmployeeLeave(long p_EmployeeLeavid,bool p_Iscancel)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spUpdateEMPLOYEE_LEAVE mSelect = new spUpdateEMPLOYEE_LEAVE();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_LEAVE_ID = p_EmployeeLeavid;  
                mSelect.EMPLOYEE_ID = Constants.IntNullValue;
                mSelect.LEAVE_TYPE_ID = Constants.IntNullValue;
                mSelect.DAY_TYPE_ID = Constants.IntNullValue;
                mSelect.FROM_DATE = Constants.DateNullValue;
                mSelect.TO_DATE = Constants.DateNullValue;
                mSelect.ALLOW_DAYS = Constants.DecimalNullValue;
                mSelect.USED_DAYS = Constants.DecimalNullValue;
                mSelect.IS_CANCEL = p_Iscancel;
                mSelect.TIME_STAMP = Constants.DateNullValue;   
                mSelect.REMARKS = null; 
                mSelect.ExecuteQuery();

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
        public DataTable SelectEmployeeLeave(int p_EmployeeId,int p_EmployeeLeaveType)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                spSelectEMPLOYEE_LEAVE mSelect = new spSelectEMPLOYEE_LEAVE();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_ID  = p_EmployeeId;
                mSelect.DAY_TYPE_ID = p_EmployeeLeaveType; 
                DataTable dt = mSelect.ExecuteTable();
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
        public DataTable SelectEmployeeLeaveDetail(int p_EmployeeId, int p_EmployeeLeaveType,DateTime pFromDate,DateTime pToDate)
        {
            IDbConnection mConnection = null;
            try
            {
                mConnection = ProviderFactory.GetConnection(Configuration.ConnectionString, EnumProviders.SQLClient);
                mConnection.Open();
                UspSelectEMPLOYEE_LEAVE mSelect = new UspSelectEMPLOYEE_LEAVE();
                mSelect.Connection = mConnection;
                mSelect.EMPLOYEE_ID = p_EmployeeId;
                mSelect.DAY_TYPE_ID = p_EmployeeLeaveType;
                mSelect.FROM_DATE = pFromDate;
                mSelect.TO_DATE = pToDate;
                mSelect.IS_CANCEL = false;   
                DataTable dt = mSelect.ExecuteTable();
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

    }
}