using System;
using System.Data;
using System.Collections;

namespace SAMSCommon.Classes
{

    public class Constants
    {

        #region Data Constants



        public const long LongNullValue = long.MinValue; // bigint
        public const int IntNullValue = int.MinValue;  // int 
        public const short ShortNullValue = short.MinValue; // small int
        public const byte ByteNullValue = byte.MinValue; // tiny int
        public const decimal DecimalNullValue = decimal.MinValue;
        public const char CharNullValue = char.MinValue;
        public const float FloatNullValue = float.MinValue;



        public static DateTime DateNullValue = new DateTime(1900, 1, 1);
        public const int DefaultStatus = 1;
        public const string EncryptionKey = "19995";
        public const string FileEncryptionKey = "ENCRYPTE";
        public const int NumberOfDecimal = 2;

        // Edit by Ali raza
        public const int Dozen = 12;
        public const int UOM_ID_Unit = 1;
        public const int UOM_ID_Dozen = 2;
        public const int UOM_ID_Case = 3;
        public const int DTWareHouse = 3;
        #endregion

        #region SAMS Constants
        public static char[] File_Delimiter = { '\t', '~' };
        #endregion

        #region Auto Codes

        public const string AC_Customer = "OT";
        public const string AC_SalesForce = "SF";
        public const string AC_Area = "AR";
        public const string AC_Route = "RU";
        public const string AC_MerchandizingItem = "MI";
        public const string AC_HHImportBatchNumber = "HHBN";
        public const string AC_HHDeviceCode = "HHDC";
        public const string SaleDefult = "Sale Default";
        public const string SaleReturn = "Sale Return Default";



        #endregion

        #region Account Type Id
        public const int AC_MainTypeId = 91;
        public const int AC_SubTypeId = 92;
        public const int AC_DetailTypeId = 93;
        public const int AC_AccountHeadId = 94;
        #endregion

        #region Paymode
        public const int CashSales = 25;
        public const int CreditSale = 24;
        public const int CashSaleReturn = 26;
        public const int CashPayment = 19;
        public const int ChequePayment = 18;
        public const int DebitClaim = 378;
        public const int CreditClaim = 383;
        #endregion

        #region Exception Strings
        public const string expPublishExceptionError = "Error YE-1201 has occurred. Please contact System Administrator to resolve the issue.";
        #endregion

        #region UserInformation
        //public static int CompanyId;
        public const int UserType = 31;
        public const int SaleForce = 34;
        
        #endregion

        #region Sales Force
        public const int SALES_FORCE_ORDERBOOKER = 35;
        public const int SALES_FORCE_DELIVERYMAN = 36;
        public const int SALES_FORCE_SALESPERSON = 37;
        #endregion

        #region Folder Constants

        public static string fldLogFileFolder
        {
            get
            {
                return General.ReplaceSymbols("%APPPATH%Logs\\");
            }
        }
        public static string fldDistributorFolder
        {
            get
            {
                return General.ReplaceSymbols("%SERVERFTPPATH%\\Distributor\\");
            }
        }

        public static string fldPromotionFolder
        {
            get
            {
                return General.ReplaceSymbols("%SERVERFTPPATH%\\Promotion\\");
            }
        }
        public static string fldSKUFolder
        {
            get
            {
                return General.ReplaceSymbols("%SERVERFTPPATH%\\SKU\\");
            }
        }
        public static string fldOtherDataFolder
        {
            get
            {
                return General.ReplaceSymbols("%SERVERFTPPATH%\\OtherData\\");
            }
        }
        public static string fldPickSlipFolder
        {
            get
            {
                return General.ReplaceSymbols("%SERVERFTPPATH%\\PickSlip\\");
            }
        }
        public static string fldSkuStockFolder
        {
            get
            {
                return General.ReplaceSymbols("%SERVERFTPPATH%\\SkuStock\\");
            }
        }

        #endregion

        #region SKU Detail
        public const int SKUPrincipal = 57;
        public const int SKUDivision = 58;
        public const int SKUCategory = 59;
        public const int SKUBrand = 60;
        public const int SKUS = 61;
        
        #endregion

        #region Geo Hierarchy
        public const int Region = 51;
        public const int Zone = 52;
        public const int Territory = 53;
        public const int Town = 54;
        public const int Route = 55;
        public const int Market = 56;
        #endregion

        #region Customer Detail
        public const int CustomerChannelType = 46;
        public const int CustomerTypeBusiness = 47;
        public const int CustomerVolumeClassType = 48;
        #endregion

        #region Modules Detail
        public const int Mod_1st_Layer = 11;
        public const int Mod_2nd_Layer = 12;
        public const int Mod_3rd_Layer = 13;
        #endregion

        #region Promotion
        public const int Basket_On_Quantity = 82;
        public const int Basket_On_Amount = 83;
        public const int Basket_On_CTN = 84;
        #endregion

        #region EmployeeConstant
        public const int Employee_Depoartment_Id = 570;
        public const int Employee_Designation_Id = 34;
        public const int Employee_Type_Id = 571;
        public const int Employee_Norms_Id = 582;
        public const int Employee_LeaveAllow_Id = 0;
        public const int Employee_LeaveUsed_Id = 1;
        #endregion
        #region Order Constant

        public const int Order_Pending_Id = 111;
        public const int Order_Posted_Id = 112;
        public const int Order_Cancel_Id = 113;
        public const int Cash_Order_Id = 214;
        public const int Credit_Order_Id = 215;
        public const int Advance_PaymentOrder_id = 216; 
        
        #endregion

        #region Document Type Id
        public const int Document_Purchase = 2;
        public const int Document_Purchase_Return = 3;
        public const int Document_Transfer_In = 4;
        public const int Document_Transfer_Out = 5;
        public const int Document_Damaged = 6;
        public const int Document_Opening = 7;
        public const int Document_Short = 8;
        public const int Document_Acess = 9;
        public const int Document_Order = 12;
        public const int Document_Invoice = 13;
        public const int Document_Sale_Return = 14;
        public const int Document_Petty_Cash = 27;
        public const int Document_SaleInvoice = 13;
        public const int Document_SaleReturn = 14;
        public const int Cash_Voucher = 14;
        public const int Bank_Voucher = 15;
        public const int Journal_Voucher = 16;
        public const int Expanse_Voucher = 17;
        public const int Cheque_Relization = 18;
        public const int Cash_Relization = 19;
        public const int IncomeTax_Relization = 23;
        public const int Credit_TransferOut = 28;
        public const int Cheque_Advance = 20;
        public const int Cash_Advance = 21;
        public const int Bank_Deposit = 22;
        public const int Builty_Exp = 30;
        public const int Cheque_Pending = 527;
        public const int Cheque_Deposit = 528;
        public const int Cheque_Clear = 529;
        public const int Cheque_Bons = 530;
        public const int Cheque_Cancel = 560;
        #endregion
    }
}
