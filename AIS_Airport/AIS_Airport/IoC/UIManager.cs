﻿using System.Windows;
using AIS_Airport.Core;

namespace AIS_Airport
{
	/// <summary>
	/// The applications implementation of the <see cref="IUIManager"/>
	/// </summary>
	public class UIManager : IUIManager
	{
		/// <summary>
		/// Displays a single message box to the user
		/// </summary>
		/// <param name="viewModel">The view model</param>
		/// <returns></returns>
		public Task ShowMessage(MessageBoxDialogViewModel viewModel)
		{
			return Application.Current.Dispatcher.Invoke(() =>
			{
				return new DialogMessageBox().ShowDialog(viewModel);
			});
		}
	}
}