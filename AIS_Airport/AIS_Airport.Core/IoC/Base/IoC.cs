﻿using Dna;
using Ninject;

namespace AIS_Airport.Core
{
	/// <summary>
	/// The IoC container for our application
	/// </summary>
	public static class IoC
	{
		#region Public Properties

		/// <summary>
		/// The kernel for our IoC container
		/// </summary>
		public static IKernel Kernel { get; private set; } = new StandardKernel();
		/// <summary>
		/// A shortcut to access the <see cref="ILogFactory"/>
		/// </summary>
		public static ILogFactory Logger => Get<ILogFactory>();

		/// <summary>
		/// A shortcut to access the <see cref="IFileManager"/>
		/// </summary>
		public static IFileManager File => Get<IFileManager>();

		/// <summary>
		/// A shortcut to access the <see cref="ITaskManager"/>
		/// </summary>
		public static ITaskManager Task => Get<ITaskManager>();

		/// <summary>
		/// A shortcut to access the <see cref="ApplicationViewModel"/>
		/// </summary>
		public static ApplicationViewModel Application => Get<ApplicationViewModel>();

		/// <summary>
		/// A shortcut to access toe <see cref="IClientDataStore"/> service
		/// </summary>
		public static IDataStore DataStore => Framework.Service<IDataStore>();

		/// <summary>
		/// A shortcut to access the <see cref="IUIManager"/>
		/// </summary>
		public static IUIManager UI => Get<IUIManager>();

		#endregion

		#region Construction

		/// <summary>
		/// Sets up the IoC container, binds all information required and is ready for use
		/// NOTE: Must be called as soon as your application starts up to ensure all 
		///       services can be found
		/// </summary>
		public static void Setup()
		{
			// Bind all required view models
			BindViewModels();
		}

		/// <summary>
		/// Binds all singleton view models
		/// </summary>
		private static void BindViewModels()
		{
			// Bind to a single instance of Application view model
			Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
		}

		#endregion

		/// <summary>
		/// Get's a service from the IoC, of the specified type
		/// </summary>
		/// <typeparam name="T">The type to get</typeparam>
		/// <returns></returns>
		public static T Get<T>()
		{
			return Kernel.Get<T>();
		}
	}
}