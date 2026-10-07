using System;


namespace SAMSBusinessLayer.Classes
{
    public class PromotionCustVolclassColl_Controller : System.Collections.CollectionBase   
    {
        #region Contructor
        public PromotionCustVolclassColl_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods
        public void Add(PromotionCustomerVolClass_Collection p_PCustVolClassCol)
		{
            List.Add(p_PCustVolClassCol);			
		}
        public void Insert(int p_i, PromotionCustomerVolClass_Collection p_PCustVolClassCol)
		{
            List.Insert(p_i, p_PCustVolClassCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}
        public PromotionCustomerVolClass_Collection Get(int p_Index)
		{
            return (PromotionCustomerVolClass_Collection)List[p_Index];
		}
		#endregion
    }
}
