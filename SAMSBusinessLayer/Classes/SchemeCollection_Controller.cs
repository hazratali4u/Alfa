using System;

namespace SAMSBusinessLayer.Classes
{
	/// <summary>
	/// <name>SchemeCollection_Controller </name>
	/// <author>Syed Ali Raza </author>
	/// <date>24 Aug 07 </date>
	/// <description>Class Responsible to call Scheme collection for values</description>
	/// </summary>
	public class SchemeCollection_Controller : System .Collections .CollectionBase
	{
		public SchemeCollection_Controller()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region Public Methods
		public void Add(Scheme_Collection p_SchCol)
		{
			List.Add (p_SchCol);			
		}

		public void Insert(int p_i , Scheme_Collection p_SchCol)
		{
			List.Insert (p_i , p_SchCol);
		}
		public void RemoveOn(int p_i)
		{
			List.RemoveAt (p_i);
		}	
		public Scheme_Collection Get(int p_Index)
		{
			return (Scheme_Collection) List[p_Index];
		}

		#endregion

	}
}
