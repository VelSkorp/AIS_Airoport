using AIS_Airoport.Core;
using Microsoft.EntityFrameworkCore;

namespace AIS_Airoport.Relational
{
	/// <summary>
	/// The database context for the client data store
	/// </summary>
	public class DataStoreDbContext : DbContext
	{
		#region DbSets 

		/// <summary>
		/// Airlines data table
		/// </summary>
		public DbSet<Airline> Airlines { get; set; }

		/// <summary>
		/// Airplanes data table
		/// </summary>
		public DbSet<Airplane> Airplanes { get; set; }

		/// <summary>
		/// Destinations data table
		/// </summary>
		public DbSet<Destination> Destinations { get; set; }

		/// <summary>
		/// Discounts data table
		/// </summary>
		public DbSet<Discount> Discounts { get; set; }

		/// <summary>
		/// Flights data table
		/// </summary>
		public DbSet<FlightApiModel> Flights { get; set; }

		/// <summary>
		/// Passengers data table
		/// </summary>
		public DbSet<Passenger> Passengers { get; set; }

		/// <summary>
		/// Positions data table
		/// </summary>
		public DbSet<Position> Positions { get; set; }

		/// <summary>
		/// Staff data table
		/// </summary>
		public DbSet<EmployeeCredentialsApiModel> Staff { get; set; }

		/// <summary>
		/// Tickets data table
		/// </summary>
		public DbSet<TicketApiModel> Tickets { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Default constructor
		/// </summary>
		public DataStoreDbContext(DbContextOptions<DataStoreDbContext> options) : base(options) { }

		#endregion

		#region Model Creating

		/// <summary>
		/// Configures the database structure and relationships
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Fluent API

			// Configure
			// --------------------------
			//
			// Set primary keys
			modelBuilder.Entity<Airline>().HasKey(a => a.Code);
			modelBuilder.Entity<Airplane>().HasKey(a => a.Code);
			modelBuilder.Entity<Destination>().HasKey(a => a.Code);
			modelBuilder.Entity<Discount>().HasKey(a => a.DiscountName);
			modelBuilder.Entity<FlightApiModel>().HasKey(a => a.Code);
			modelBuilder.Entity<Passenger>().HasKey(a => a.ID);
			modelBuilder.Entity<Position>().HasKey(a => a.Code);
			modelBuilder.Entity<EmployeeCredentialsApiModel>().HasKey(a => a.ID);
			modelBuilder.Entity<TicketApiModel>().HasKey(a => a.TicketNumber);

			// TODO: Set up limits
			//modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.FirstName).HasMaxLength(50);
		}

		#endregion
	}
}