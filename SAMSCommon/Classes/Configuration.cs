using System;
using Microsoft.Win32;

namespace SAMSCommon.Classes
{
    #region ENUMs
    /// <summary>
    /// Enum for Web Reports, action to perform
    /// <author> Uzair Ahmad </author>
    /// <date> 30 Aug 2005 </date>
    /// </summary>
    public enum REPORT_OPTIONS
    {
        Show,
        Email,
        ExportToExcel
    }
    public enum ApplicationType
    {
        Desktop,
        Server,
        Mobile,
        Default

    }

    public enum Language
    {
        English,
        Urdu

    }

    public enum Pack
    {
        Default,
        Custom

    }

    #endregion

    /// <summary>
    /// Configuration
    /// <author>Rizwan Ansari</author>
    /// <date>19-06-2007</date>
    /// </summary>
    public class Configuration
    {
        #region Constructors
        public Configuration()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Variables
        private static string mConnectionString;
        private static string mstrAppPath;
        private static string mstrDatabaseServer;
        private static string mstrDatabaseName;
        private static string mstrSMTPAddress;
        private static string mstrServerUserName;
        private static string mstrServerUserPswd;
        private static string mstrBackupFolder;
        private static string mstrServerAuthentication;
        private static string mstrErrorLogPath;
        private static int mDocumentDurationToShow = 3;//(in days) it will tell that all invoice which fall under this duration i.e (currentday - 3), will be shown in invoce\orderform

        #region Account Head

        private static string mPurchaseAccount;
        private static string mPurchasReturnAccount;
        private static string mTransferInAccount;
        private static string mTransferOutAccount;
        private static string mDiscountAccount;
        private static string mSchemeAccount;
        private static string mGSTAccount;
        private static string mPayableAccount;
        private static string mAccountReceivable;
        private static string mCashDefault;
        private static string mBankDefault;
        private static string mCurrentAssets;
        private static string mSaleAccount;
        private static string mSaleDiscount;
        private static string mSaleScheme;
        private static string mStockInHand;
        private static string mFreeStock;
        private static string mCashDefaultType;
        private static string mExpensDefaultType;
        private static string mBankDefaultType;
        private static string mPeatyCash;
        private static string mBuiltyExp;
        private static string mAdnvanceAC;
        private static string mBankCollectionAC;
        private static string mMainCashSaled;

        #region Add by Hazrat Ali
        /// <summary>
        /// Sale return related Account Heads
        /// DateTime: 2012-03-15 12:50 PM
        /// </summary>

        private static string mSaleReturnAccount;
        private static string mSaleReturnDiscount;
        private static string mSaleReturnGST;

        #endregion

        #endregion

        private static DateTime mSystemCurrentDate;
        private static DateTime mSystemCurrentDateTime;

        private static string m_strClientName;
        private static string m_strClientDetail;
        private static string m_strDesktopVersion;
        private static string m_strServerVersion;
        private static string m_ServerSettingURL;
        private static bool m_isApplicationRunning;
        private static string m_strTimeInterval;
        private static string m_strMailingServerAddress;
        private static string m_strMailSenderAddress;
        private static string m_strPrintType;
        private static string m_strPrintOnOrderForm;
        private static string m_strSKUonHandShowValue;
        private static string m_strSyncLog_Process_Path;
        private static string m_strServerFTPpath;
        private static string m_strThreadTime;
        private static string m_strUploadLog;
        private static string m_DownloadDirectory;
        private static string m_DownloadedFileName;
        private static int Distributor_Type_Id;
        private static string Distributor_Type_Code;
        private static string Distributor_Type_Name;
        public static string Distributor_Company;
        public static string Distributor_Address;
        public static string Distributor_RegisterationNo;

        private static string mQueryTimeOut;
        public static string HelpPath = Configuration.GetAppInstallationPath() + "UserManual_Desktop.chm";

        private static Language m_Language;
        private static Pack m_Pack;
        private static string mInboxPath; // 
        private static string mOutboxPath; //

        public static string ApplicationStatus;
        public static ApplicationType RunningApplicationType = ApplicationType.Default; //desktop, web, HandHeld, use enumeration ApplicationType.Desktop etc.
        public static bool IsFirstApprear = false;

        private static int mUserID = Constants.IntNullValue;
        public static int mCompanyID = 0;
        private static int mDistributorID = Constants.IntNullValue;
        private static string mstrDistributorName = "";
        private static int mUserTypeID = 50;
        private static int mSystemUserID = 49;
        private static int mRoleID = Constants.IntNullValue;
        private static int mDivisionID = Constants.IntNullValue;
        public static bool mIsTpUpdate;
        public static bool mIsRpUpdate;
        public static bool mIsTaxPriceUpdate;
        private static bool mIsDistReg;
        private static string mHHAppFilesFolder;
        private static string mDistCode = null;                //used for verifying file downloads in FilesController 
        private static string mDistPassword = null;			 //used for verifying file downloads in FilesController
        private static Enums.PrintPaper mPrintPaper = Enums.PrintPaper.A4;

        private static int mMaxDayClose = 3;
        public static long PrintingInvoicePurchaseMasterID = 0;
        public static int mDistributorCreditLevel;


        private static string m_DesktopInbox;
        private static string m_DesktopOutbox;
        private static string m_DeviceInbox;
        private static string m_DeviceOutbox;
        private static int m_PromotionId = -1;
        private static string m_ServerHttpPath;


        private static string m_ReportExportPath;



        #endregion

        #region public Properties
        static public void GetAccountHead()
        {
            string mstrAppPath = Configuration.GetAppInstallationPath();
            XmlUtil AccountHead = new XmlUtil(mstrAppPath + @"Settings\AccountHead.xml");
            mPurchaseAccount = AccountHead.GetNode("Purchase");
            mPurchasReturnAccount = AccountHead.GetNode("PurchaseReturn");
            mTransferOutAccount = AccountHead.GetNode("TransferOut");
            mTransferInAccount = AccountHead.GetNode("TransferIN");
            mDiscountAccount = AccountHead.GetNode("PurchaseDiscount");
            mSchemeAccount = AccountHead.GetNode("PurchaseScheme");
            mGSTAccount = AccountHead.GetNode("SalesTaxPayable");
            mPayableAccount = AccountHead.GetNode("PayabletoPrincipal");
            mAccountReceivable = AccountHead.GetNode("AccountReceivable");
            mCashDefault = AccountHead.GetNode("CashDefualt");
            mBankDefault = AccountHead.GetNode("BankDefualt");
            mCurrentAssets = AccountHead.GetNode("CurrentAssets");
            mSaleAccount = AccountHead.GetNode("SaleAccount");
            mSaleDiscount = AccountHead.GetNode("SaleDiscount");
            mSaleScheme = AccountHead.GetNode("SaleScheme");
            mStockInHand = AccountHead.GetNode("StockInHand");
            mFreeStock = AccountHead.GetNode("FreeStock");
            mCashDefaultType = AccountHead.GetNode("CashDefualtType");
            mBankDefaultType = AccountHead.GetNode("BankDefualtType");
            mExpensDefaultType = AccountHead.GetNode("ExpDefualtType");
            mPeatyCash = AccountHead.GetNode("PeatyCash");
            mBuiltyExp = AccountHead.GetNode("BuiltyExp");
            mAdnvanceAC = AccountHead.GetNode("mAdnvanceAC");
            mBankCollectionAC = AccountHead.GetNode("mBankCollectionAC");
            mMainCashSaled = AccountHead.GetNode("MainCashSale");
            mSaleReturnAccount = AccountHead.GetNode("SaleReturnAccount");
            mSaleReturnDiscount = AccountHead.GetNode("SaleReturnDiscount");
            mSaleReturnGST = AccountHead.GetNode("SaleReturnGST");
        }
        public static string ConnectionString
        {
            get
            {
                if (mConnectionString == null || mConnectionString == "")
                {
                    GetAppConfiguration();

                    if (DatabseAuthentication.Equals("Windows")) // windows method
                    {
                        mConnectionString = "Integrated Security=SSPI;Persist Security Info=False;";
                    }
                    else // MSDE mode
                    {
                        mConnectionString = " Persist Security Info=False; ";
                        mConnectionString += " User ID=" + ServerUserName + ";Password=" + ServerUserPwd + ";";
                    }
                    if (mQueryTimeOut != "")
                    {
                        mConnectionString += " Connection Timeout = " + QueryTimeOut + "; ";
                        mConnectionString += " Connection Lifetime = " + QueryTimeOut + "; ";
                    }
                    //common settings
                    mConnectionString += " Initial Catalog = " + DatabaseName + "; ";
                    mConnectionString += " Data Source= " + DatabseServer + " ";

                }
                return mConnectionString;
            }
        }
        public static int PromotionId
        {
            get
            {
                return m_PromotionId;
            }
            set
            {
                m_PromotionId = value;
            }
        }
        public static string BankCollection_Head
        {
            get
            {
                return mBankCollectionAC;
            }
            set
            {
                mBankCollectionAC = value;
            }
        }
        public static string AdvanceAC_Head
        {
            get
            {
                return mAdnvanceAC;
            }
            set
            {
                mAdnvanceAC = value;
            }
        }
        public static string MainCashSaled_Head
        {
            get
            {
                return mMainCashSaled;
            }
            set
            {
                mMainCashSaled = value;
            }
        }
        public static string DatabseServer
        {
            get
            {
                return mstrDatabaseServer;
            }
            set
            {
                mstrDatabaseServer = value;
            }
        }
        public static string DatabaseName
        {
            get
            {
                return mstrDatabaseName;
            }
            set
            {
                mstrDatabaseName = value;
            }
        }
        public static string SMTPAddress
        {
            get
            {
                return mstrSMTPAddress;
            }
            set
            {
                mstrSMTPAddress = value;
            }
        }
        public static bool IsDistReg
        {
            get
            {
                return mIsDistReg;
            }
            set
            {
                mIsDistReg = value;
            }
        }
        public static Enums.PrintPaper PrintPaper
        {
            get { return mPrintPaper; }
            set { mPrintPaper = value; }
        }
        public static string PurchaseAccount
        {
            get
            {
                return mPurchaseAccount;
            }
            set
            {
                mPurchaseAccount = value;
            }
        }
        public static string SaleDiscount
        {
            get
            {
                return mSaleDiscount;
            }
            set
            {
                mSaleDiscount = value;
            }
        }
        public static string SaleScheme
        {
            get
            {
                return mSaleScheme;
            }
            set
            {
                mSaleScheme = value;
            }
        }
        public static string CashDefaultType
        {
            get
            {
                return mCashDefaultType;
            }
            set
            {
                mCashDefaultType = value;
            }
        }
        public static string PeatyCash
        {
            get
            {
                return mPeatyCash;
            }
            set
            {
                mPeatyCash = value;
            }
        }
        public static string BankDefaultType
        {
            get
            {
                return mBankDefaultType;
            }
            set
            {
                mBankDefaultType = value;
            }
        }
        public static string ExpensDefaultType
        {
            get
            {
                return mExpensDefaultType;
            }
            set
            {
                mExpensDefaultType = value;
            }
        }

        public static string StockInHand
        {
            get
            {
                return mStockInHand;
            }
            set
            {
                mStockInHand = value;
            }
        }
        public static string FreeStock
        {
            get
            {
                return mFreeStock;
            }
            set
            {
                mFreeStock = value;
            }
        }
        public static string PurchasReturnAccount
        {
            get
            {
                return mPurchasReturnAccount;
            }
            set
            {
                mPurchasReturnAccount = value;
            }
        }
        public static string TransferOutAccount
        {
            get
            {
                return mTransferOutAccount;
            }
            set
            {
                mTransferOutAccount = value;
            }
        }
        public static string TransferInAccount
        {
            get
            {
                return mTransferInAccount;
            }
            set
            {
                mTransferInAccount = value;
            }
        }
        public static string PayableAccount
        {
            get
            {
                return mPayableAccount;
            }
            set
            {
                mPayableAccount = value;
            }
        }
        public static string SchemeAccount
        {
            get
            {
                return mSchemeAccount;
            }
            set
            {
                mSchemeAccount = value;
            }
        }
        public static string DiscountAccount
        {
            get
            {
                return mDiscountAccount;
            }
            set
            {
                mDiscountAccount = value;
            }
        }
        public static string GSTAccount
        {
            get
            {
                return mGSTAccount;
            }
            set
            {
                mGSTAccount = value;
            }
        }
        public static string SaleAccount
        {
            get
            {
                return mSaleAccount;
            }
            set
            {
                mSaleAccount = value;
            }
        }
        public static string AccountReceivable
        {
            get
            {
                return mAccountReceivable;
            }
            set
            {
                mAccountReceivable = value;
            }
        }
        public static string CashDefault
        {
            get
            {
                return mCashDefault;
            }
            set
            {
                mCashDefault = value;
            }
        }
        public static string BankDefault
        {
            get
            {
                return mBankDefault;
            }
            set
            {
                mBankDefault = value;
            }
        }
        public static string CurretnAssets
        {
            get
            {
                return mCurrentAssets;
            }
            set
            {
                mCurrentAssets = value;
            }
        }
        public static string BuiltyExp
        {
            get
            {
                return mBuiltyExp;
            }
            set
            {
                mBuiltyExp = value;
            }
        }
        public static string DatabseAuthentication
        {
            get
            {
                return mstrServerAuthentication;
            }
            set
            {
                mstrServerAuthentication = value;
            }
        }

        public static string ServerUserName
        {
            get
            {
                return mstrServerUserName;
            }
            set
            {
                mstrServerUserName = value;
            }
        }

        public static string ServerUserPwd
        {
            get
            {
                return mstrServerUserPswd;
            }
            set
            {
                mstrServerUserPswd = value;
            }
        }

        public static string BackupFolder
        {
            get
            {
                return mstrBackupFolder;
            }
            set
            {
                mstrBackupFolder = value;
            }
        }

        public static string ErrorLogPath
        {
            get
            {
                mstrErrorLogPath = GetAppInstallationPath() + "Logs";

                return mstrErrorLogPath;
            }
            set
            {
                mstrErrorLogPath = value;
            }
        }


        public static int DistributorId
        {
            get { return mDistributorID; }
            set { mDistributorID = value; }
        }

        public static int DistributorTypeId
        {
            get { return Distributor_Type_Id; }
            set { Distributor_Type_Id = value; }
        }

        public static string DistributorTypeCode
        {
            get { return Distributor_Type_Code; }
            set { Distributor_Type_Code = value; }
        }

        public static string DistributorTypeName
        {
            get { return Distributor_Type_Name; }
            set { Distributor_Type_Name = value; }
        }

        public static string DistributorName
        {
            get { return mstrDistributorName; }
            set { mstrDistributorName = value; }
        }
        public static int DistributorCreditLevel
        {
            get { return mDistributorCreditLevel; }
            set { mDistributorCreditLevel = value; }
        }

        public static int RoleId
        {
            get { return mRoleID; }
            set { mRoleID = value; }
        }

        public static int UserTypeId
        {
            get { return mUserTypeID; }
            set { mUserTypeID = value; }
        }

        public static int SystemUserId
        {
            get { return mSystemUserID; }
            set { mSystemUserID = value; }
        }

        public static int DivisionID
        {
            get
            {
                return mDivisionID;
            }
            set
            {
                mDivisionID = value;
            }
        }

        public static bool IsTpUpdate
        {
            get { return mIsTpUpdate; }
            set { mIsTpUpdate = value; }
        }

        public static bool IsRpUpdate
        {
            get { return mIsRpUpdate; }
            set { mIsRpUpdate = value; }
        }

        public static bool IsTaxPriceUpdate
        {
            get { return mIsTaxPriceUpdate; }
            set { mIsTaxPriceUpdate = value; }
        }

        public static int CompanyId
        {
            get { return mCompanyID; }
            set { mCompanyID = value; }
        }

        public static string DistributorCode
        {
            get
            {
                return mDistCode;
            }
            set
            {
                mDistCode = value;
            }
        }

        public static string DistributorPassword
        {
            get
            {
                return mDistPassword;
            }
            set
            {
                mDistPassword = value;
            }
        }


        public static int DocumentDurationToShow
        {
            get { return mDocumentDurationToShow; }
            set { mDocumentDurationToShow = value; }
        }
        public static DateTime SystemCurrentDate
        {
            get { return mSystemCurrentDate; }
            set { mSystemCurrentDate = value; }
        }
        /// <summary>
        /// Current Open Date 
        /// </summary>
        public static DateTime CurrentOpenDate
        {
            get { return mSystemCurrentDate; }
            set { mSystemCurrentDate = value; }
        }
        /// <summary>
        /// DATE time for all document date's and stock date's to insert in all records
        /// </summary>
        public static DateTime TransactionDateTime
        {
            get { return mSystemCurrentDate.Date + DateTime.Now.TimeOfDay; }
        }

        public static DateTime SystemCurrentDateTime
        {
            get { return mSystemCurrentDateTime; }
            set { mSystemCurrentDateTime = value; }
        }

        //uzair , 8 april 2005
        //FOR CLIENT NAME
        public static string ClientName
        {
            get { return m_strClientName; }
            set { m_strClientName = value; }
        }

        //uzair , 8 april 2005
        // FOR CLIENT DETAIL
        public static string ClientDetail
        {
            get { return m_strClientDetail; }
            set { m_strClientDetail = value; }
        }


        public static string DesktopVersion
        {
            get
            {
                return m_strDesktopVersion;
            }
        }

        public static string ServerVersion
        {
            get
            {
                return m_strServerVersion;
            }

        }

        public static string ServerSettingURL
        {
            get
            {
                return m_ServerSettingURL;
            }
        }

        public static bool IsApplicationRunning
        {
            get
            {
                return m_isApplicationRunning;
            }
            set
            {
                m_isApplicationRunning = value;
            }
        }

        public static string TimeInterval
        {
            get
            {
                return m_strTimeInterval;
            }
            set
            {
                m_strTimeInterval = value;
            }
        }

        public static string MailingServerAddress
        {
            get
            {
                return m_strMailingServerAddress;
            }
            set
            {
                m_strMailingServerAddress = value;
            }
        }

        public static string MailSenderAddress
        {
            get
            {
                return m_strMailSenderAddress;
            }
            set
            {
                m_strMailSenderAddress = value;
            }
        }
        public static string PrintType
        {
            get
            {
                return m_strPrintType;
            }
            set
            {
                m_strPrintType = value;
            }
        }

        public static string PrintOnOrderForm
        {
            get
            {
                return m_strPrintOnOrderForm;
            }
            set
            {
                m_strPrintOnOrderForm = value;
            }
        }

        public static string SKUonHandShowValue
        {
            get
            {
                return m_strSKUonHandShowValue;
            }
            set
            {
                m_strSKUonHandShowValue = value;
            }
        }
        public static string SyncLog_Process_Path
        {
            get
            {
                return m_strSyncLog_Process_Path;
            }
            set
            {
                m_strSyncLog_Process_Path = value;
            }
        }
        public static string ServerFTPpath
        {
            get
            {
                return m_strServerFTPpath;
            }
            set
            {
                m_strServerFTPpath = value;
            }
        }
        public static string ServerHttpPath
        {
            get
            {
                return m_ServerHttpPath;
            }
            set
            {
                ServerHttpPath = value;
            }
        }
        public static string ThreadTime
        {
            get
            {
                return m_strThreadTime;
            }
            set
            {
                m_strThreadTime = value;
            }
        }

        public static string UploadLog
        {
            get
            {
                return m_strUploadLog;
            }
            set
            {
                m_strUploadLog = value;
            }
        }
        public static string QueryTimeOut
        {
            get
            {
                return mQueryTimeOut;
            }
            set
            {
                mQueryTimeOut = value;
            }
        }
        public static Language Languages
        {
            get
            {
                return m_Language;
            }
            set
            {
                m_Language = value;
            }

        }
        public static Pack Packs
        {
            get
            {
                return m_Pack;
            }
            set
            {
                m_Pack = value;
            }
        }
        public static string InboxPath
        {
            get { return mInboxPath; }
            set { mInboxPath = value; }
        }
        public static string OutboxPath //
        {
            get { return mOutboxPath; }
            set { mOutboxPath = value; }
        }

        public static int UserID
        {
            get { return mUserID; }
            set { mUserID = value; }
        }


        public static int MaxDayClose
        {
            get { return mMaxDayClose; }
            set { mMaxDayClose = value; }
        }

        public static string DesktopInbox
        {
            get
            {
                return m_DesktopInbox;
            }
        }

        public static string DesktopOutbox
        {
            get
            {
                return m_DesktopOutbox;
            }
        }

        public static string DeviceInbox
        {
            get
            {
                return m_DeviceInbox;
            }
        }

        public static string DeviceOutbox
        {
            get
            {
                return m_DeviceOutbox;
            }
        }

        public static string ReportExportPath
        {
            get
            {
                return m_ReportExportPath;
            }
        }

        public static string HHAppFilesFolder
        {
            get
            {
                return mHHAppFilesFolder;
            }
        }

        public static string SaleReturnAccount
        {
            get
            {
                return mSaleReturnAccount;
            }
            set
            {
                mSaleReturnAccount = value;
            }
        }

        public static string SaleReturnDiscount
        {
            get
            {
                return mSaleReturnDiscount;
            }
            set
            {
                mSaleReturnDiscount = value;
            }
        }

        public static string SaleReturnGST
        {
            get
            {
                return mSaleReturnGST;
            }
            set
            {
                mSaleReturnGST = value;
            }
        }
        #endregion

        #region public static Methods
        static public string GetAppInstallationPath()
        {
            try
            {
                if (mstrAppPath == null || mstrAppPath == "")
                {

                    mstrAppPath = System.Configuration.ConfigurationSettings.AppSettings["AppPath"];

                }

            }
            catch (Exception ex)
            {
                throw new SAMSException("Registry Key Not Found.", ex);
            }

            return mstrAppPath;
        }

        static public void GetAppConfiguration()
        {
            string mstrAppPath = Configuration.GetAppInstallationPath();
            Encryption obEncDecrypt = new Encryption();
            XmlUtil NewSetting = new XmlUtil(mstrAppPath + @"Settings\AppSettings.xml");

            mstrDatabaseServer = NewSetting.GetNode("Server");
            mstrDatabaseName = NewSetting.GetNode("DBName");

            mstrServerUserName = NewSetting.GetNode("DBUser");
            mstrServerUserPswd = NewSetting.GetNode("DBPassword");

           // mstrServerUserPswd = SAMSCommon.Classes.Cryptography.Decrypt(NewSetting.GetNode("DBPassword"), "b0tin@74");

            mQueryTimeOut = NewSetting.GetNode("QueryTimeOut");
            mstrBackupFolder = NewSetting.GetNode("BackupFolder");

            mstrServerAuthentication = NewSetting.GetNode("DBAuthentication");
            m_strDesktopVersion = NewSetting.GetNode("V2");
            m_strServerVersion = NewSetting.GetNode("V1");
            m_ServerSettingURL = NewSetting.GetNode("ServerSettingURL");

            m_strTimeInterval = NewSetting.GetNode("TimeInterval");
            m_strMailingServerAddress = NewSetting.GetNode("MailingserverAddress");
            m_strMailSenderAddress = NewSetting.GetNode("MailSenderAddress");

            m_strPrintType = NewSetting.GetNode("PrintType");  // add by Zeeshan
            m_strPrintOnOrderForm = NewSetting.GetNode("PrintOnOrderForm");  // add by Zeeshan
            m_strSKUonHandShowValue = NewSetting.GetNode("SKUonHandShowValue");  // add by Zeeshan

            m_strSyncLog_Process_Path = NewSetting.GetNode("SyncLog_Process_Path");  // only for server add by Zeeshan
            m_strServerFTPpath = NewSetting.GetNode("ServerFTPpath");
            m_ServerHttpPath = NewSetting.GetNode("ServerHttpPath"); // only for server add by Zeeshan

            m_strThreadTime = NewSetting.GetNode("ThreadTime");  // only for server add by Zeeshan
            m_strUploadLog = NewSetting.GetNode("UploadLog");  // only for server add by Zeeshan

            mInboxPath = NewSetting.GetNode("Inbox");
            mOutboxPath = NewSetting.GetNode("Outbox");

            m_DesktopInbox = NewSetting.GetNode("DesktopInbox");
            m_DesktopOutbox = NewSetting.GetNode("DesktopOutbox");
            m_DeviceInbox = NewSetting.GetNode("DeviceInbox");
            m_DeviceOutbox = NewSetting.GetNode("DeviceOutbox");

            m_ReportExportPath = NewSetting.GetNode("ReportExportPath");

            mHHAppFilesFolder = Configuration.GetAppInstallationPath() + @"\SAMSMobile\";

            NewSetting.CloseDocument();

            NewSetting = null;

        }

        #endregion

        #region Private Methods
        #endregion

        #region public Methods
        #endregion
    }
}
