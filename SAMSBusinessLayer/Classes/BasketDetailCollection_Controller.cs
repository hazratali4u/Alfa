using System;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class Responsible To Call Basket_Detail_Collection for Values
    /// <remarks>
    /// Three Methods
    /// <list type="bullet">
    /// <item>
    /// Add Basket_Detail_Collection Type Item To System.Collections.IList
    /// </item>
    /// <term>
    /// Insert Basket_Detail_Collection Type Item To System.Collections.IList
    /// </term>
    /// <item>
    /// Remove Basket_Detail_Collection Type from System.Collections.IList
    /// </item>
    /// <item>
    /// Get Basket_Detail_Collection Type from System.Collections.IList
    /// </item>
    /// </list>
    /// </remarks>
    /// </summary>
	public class BasketDetailCollection_Controller : System .Collections .CollectionBase
	{
		#region Constructor

        /// <summary>
        /// Constructor for BasketDetailCollection_Controller
        /// </summary>
		public BasketDetailCollection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#endregion
				
		#region Public Methods

        /// <summary>
        /// Adds Basket_Detail_Collection Type Item to System.Collections.IList
        /// </summary>
        /// <param name="p_BDetCol">Basket_Detail_Collection</param>
		public void Add(Basket_Detail_Collection p_BDetCol)
		{
			List.Add (p_BDetCol);			
		}

        /// <summary>
        /// Inserts Basket_Detail_Collection Type Item to System.Collections.IList
        /// </summary>
        /// <param name="p_i">Index</param>
        /// <param name="p_BDetCol">Basket_Detail_Collection</param>
		public void Insert(int p_i , Basket_Detail_Collection p_BDetCol)
		{
			List.Insert (p_i ,p_BDetCol);
		}

        /// <summary>
        /// Removes Basket_Detail_Collection Type Item from System.Collections.IList
        /// </summary>
        /// <param name="p_i">Index</param>
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	

        /// <summary>
        /// Gets Basket_Detail_Collection Type Item From System.Collections.IList
        /// <remarks>
        /// Returns Basket_Detail_Collection Type Item From System.Collections.IList
        /// </remarks>
        /// </summary>
        /// <param name="p_Index">Index</param>
        /// <returns>Basket_Detail_Collection Type Item From System.Collections.IList</returns>
		public Basket_Detail_Collection Get(int p_Index)
		{
			return (Basket_Detail_Collection) List[p_Index];
		}
		#endregion
	}
}
