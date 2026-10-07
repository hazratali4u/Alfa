using System;

namespace SAMSCommon.Classes
{
	/// <summary>
	/// Enums
	/// <author>Rizwan Ansari</author>
	/// <date>2007-09-05</date>
	/// </summary>
	public class Enums
	{	
		public enum TransactionType
		{
			Debit = 76,
			Credit = 75
		}

		public enum PrintPaper
		{
			A5=5,
			A4=4
		}

		public enum PaymentMode
		{
			Cash = 66,
			Cheque = 67,
			Credit = 68,
			Both = 69
		}

		public enum PartyType
		{
            Supplier=64,
			Customer=65,
			FixedAssets=62,
			Expense=61,
			Bank=60,
			Cash=63,
			SalesForce=100,
			SaleType  = 106,
			Purchase = 123
		}

		public enum ClaimType
		{
			PromotionalClaim = 51,
			SalesReturnClaim = 52,
			DamageClaim = 108,
			TADAClaims = 53,
			IncentivesClaim = 54,
			OtherClaim = 55
		}
		
		public enum ClaimStatus
		{
			Pending = 56,
			Approved = 57,
			Cancelled = 58,
			Rejected = 59
		}

		public enum ClaimTo
		{
			HeadOffice = 0, 
			Factory = 1,
			Distributor = 2
		}

		public enum PurchaseType
		{
			Pickslip=94,
			Invoice=95,
			Requisition=101,
			ReturnPickSlip=109
		}

		public enum DisputeStatus
		{
			Pending=0,
			Approved=1,
			Rejected=2
		}

		public enum SalesForceType
		{
			Delieryman = 98,
			OrderBooker = 97,
			SalesPerson = 99
		}
		public enum CheckEntries
		{
			Unhandled = 0,
			Bounced = 1,
			Cleared =2,
			Deposit  = 3
		  
		
		}
	}
}
