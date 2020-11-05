using System;

namespace AIS_Airoport.Core
{
	/// <summary>
	/// An airplane information
	/// </summary>
	public class Airplane
	{
		/// <summary>
		/// The code of airplane
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Airplane tail number
		/// </summary>
		public string BoardNumber { get; set; }

		/// <summary>
		/// Airplane model
		/// </summary>
		public string Model { get; set; }

		/// <summary>
		/// Airplane capacity
		/// </summary>
		public string Capacity { get; set; }

		/// <summary>
		/// Date of introduction into use
		/// </summary>
		public DateTime DateEntered { get; set; }
	}
}