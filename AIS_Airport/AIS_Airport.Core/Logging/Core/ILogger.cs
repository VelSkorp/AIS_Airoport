﻿namespace AIS_Airport.Core
{
	/// <summary>
	/// A logger that will handle log messages form a <see cref="ILogFactory"/>
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// Handles the logged message being passed in 
		/// </summary>
		/// <param name="message">The message being log</param>
		/// <param name="level">The level of the log message</param>
		void Log(string message, LogLevel level);
	}
}