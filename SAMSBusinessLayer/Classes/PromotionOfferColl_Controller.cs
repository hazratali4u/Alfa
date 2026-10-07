using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>PromotionOfferCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>24 Aug 07 </date>
	/// <description>Class Responsible to call PromotionOffer_Collection for values</description>
	/// </summary>
	public class PromotionOfferColl_Controller : System .Collections .CollectionBase
	{
		#region Constructor
		public PromotionOfferColl_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
		public void Add(PromotionOffer_Collection p_POfferCol)
		{
			List.Add (p_POfferCol);			
		}

		public void Insert(int p_i , PromotionOffer_Collection p_POfferCol)
		{
			List.Insert (p_i , p_POfferCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public PromotionOffer_Collection Get(int p_Index)
		{
			return (PromotionOffer_Collection) List[p_Index];
		}

		#endregion
	}
}
