using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
    /// Class Responsible To Call AppliedPromotion_Collection for Values
    /// <remarks>
    /// Two Methods  
    /// <list type="bullet">
    /// <item>
    /// Add Item AppliedPromotion_Collection Type Item To System.Collections.IList
    /// </item>
    /// <item>
    /// Get Item AppliedPromotion_Collection Type from System.Collections.IList
    /// </item>
    /// </list>
    /// </remarks>
	/// </summary>
	public class AppliedPromotionCol_Controller: System .Collections .CollectionBase
	{
		#region Constructor

        /// <summary>
        /// Constructor for AppliedPromotionCol_Controller
        /// </summary>
		public AppliedPromotionCol_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion

		#region Public Methods

        /// <summary>
        /// Adds AppliedPromotion_Collection Type Item to System.Collections.IList
        /// </summary>
        /// <param name="p_APCol">AppliedPromotion_Collection</param>
		public void Add(AppliedPromotion_Collection p_APCol)
		{
			List.Add (p_APCol);			
		}
        
        /// <summary>
        /// Gets AppliedPromotion_Collection Type Item From System.Collections.IList
        /// </summary>
        /// <remarks>
        /// Returns AppliedPromotion_Collection Type Item From System.Collections.IList
        /// </remarks>
        /// <param name="p_Index">Index</param>
        /// <returns>AppliedPromotion_Collection Type Item From System.Collections.IList</returns>
		public AppliedPromotion_Collection GetItem(int p_Index)
		{
			return (AppliedPromotion_Collection) List[p_Index];
		}
		#endregion
	}
}
