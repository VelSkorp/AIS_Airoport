﻿using System.Security;

namespace AIS_Airport.Core
{
	/// <summary>
	/// An interface for a class that can provide a secure password
	/// </summary>
	public interface IHavePassword
	{
		/// <summary>
		/// The secure password
		/// </summary>
		SecureString Password { get; }
	}
}