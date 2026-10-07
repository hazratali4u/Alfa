using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// Summary description for PromoOffersCol_Controller.
	/// </summary>
	public class PromoOffersCol_Controller : System .Collections .CollectionBase
	{
		public PromoOffersCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Public Methods
		public void Add(PromoOffers_Collection  p_POCol)
		{
			List.Add (p_POCol);			
		}

		public PromoOffers_Collection Get(int p_Index)
		{
			return (PromoOffers_Collection) List[p_Index];
		}

		#endregion
	}
}
