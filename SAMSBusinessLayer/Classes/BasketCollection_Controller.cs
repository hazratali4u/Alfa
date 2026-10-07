using System;

namespace SAMSBusinessLayer.Classes
{
    /// <summary>
    /// Class Responsible To Call Basket_Collection for Values
    /// <remarks>
    /// Three Methods
    /// <list type="bullet">
    /// <item>
    /// Add Basket_Collection Type Item To System.Collections.IList
    /// </item>
    /// <term>
    /// Insert Basket_Collection Type Item To System.Collections.IList
    /// </term>
    /// <item>
    /// Remove Basket_Collection Type Item from System.Collections.IList
    /// </item>
    /// <item>
    /// Get Basket_Collection Type Item from System.Collections.IList
    /// </item>
    /// </list>
    /// </remarks>
    /// </summary>
	public class BasketCollection_Controller : System .Collections .CollectionBase
	{
		#region Constructor

        /// <summary>
        /// Constructor for BasketCollection_Controller
        /// </summary>
		public BasketCollection_Controller()
		{
			
		}
		#endregion

		#region Public Methods

        /// <summary>
        /// Adds Basket_Collection Type Item to System.Collections.IList
        /// </summary>
        /// <param name="p_APCol">Basket_Collection</param>
		public void Add(Basket_Collection p_BCol)
		{
			List.Add (p_BCol);			
		}

        /// <summary>
        /// Inserts Basket_Collection Type Item to System.Collections.IList
        /// </summary>
        /// <param name="p_i">Index</param>
        /// <param name="p_BCol">Basket_Collection</param>
        public void Insert(int p_i , Basket_Collection p_BCol)
		{
			List.Insert (p_i ,p_BCol);
		}

        /// <summary>
        /// Removes Basket_Collection Type Item from System.Collections.IList
        /// </summary>
        /// <param name="p_i">Index</param>
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	

        /// <summary>
        /// Gets Basket_Collection Type Item from System.Collections.IList
        /// </summary>
        /// <remarks>
        /// Returns Basket_Collection Type Item From System.Collections.IList
        /// </remarks>
        /// <param name="p_Index">Index</param>
        /// <returns>Basket_Collection Type Item From System.Collections.IList</returns>
		public Basket_Collection Get(int p_Index)
		{
			return (Basket_Collection) List[p_Index];
		}
		#endregion
	}
}
