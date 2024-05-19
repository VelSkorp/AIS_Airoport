using System.Runtime.InteropServices;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AIS_Airport.Core
{
	/// <summary>
	/// Handles reading/writing and querying the file system
	/// </summary>
	public class FileManager : IFileManager
	{
		/// <summary>
		/// Writes the text to the specified file 
		/// </summary>
		/// <param name="text">The text to write</param>
		/// <param name="path">The path oF the file to write to</param>
		/// <param name="append">If true writes text to the end of the file, otherwise overrides any existing file</param>
		/// <returns></returns>
		public async Task WriteTextToFileAsync(string text, string path, bool append = false)
		{
			// TODO: Add exception catching

			// Normalize path
			path = NormalizePath(path);

			// Resolve to absolute path
			path = ResolvePath(path);

			// Lock the Task
			await AsyncAwaiter.AwaitAsync(nameof(WriteTextToFileAsync) + path, async () =>
			{
				// Run the synchronous file access as a new task
				await IoC.Task.Run(() =>
				{
					// Write the log message to file
					using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
					{
						fileStream.Write(text); 
					}
				});
			});
		}

		/// <summary>
		/// Asynchronously saves a ticket document to the specified path.
		/// </summary>
		/// <param name="ticket">The ticket containing the information to save.</param>
		/// <param name="path">The path where the document will be saved.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task SaveTicketDocumentAsync(Ticket ticket, string path)
		{
			path = NormalizePath(path);
			path = ResolvePath(path);

			await AsyncAwaiter.AwaitAsync(nameof(SaveTicketDocumentAsync) + path, async () =>
			{
				await IoC.Task.Run(() =>
				{
					using (var document = DocX.Create(path))
					{
						document.MarginLeft = 40;
						document.MarginRight = 40;
						document.MarginTop = 40;
						document.MarginBottom = 40;

						document.InsertParagraph("Boarding Pass")
							.FontSize(24)
							.Bold()
							.Color(System.Drawing.Color.Blue)
							.Alignment = Alignment.center;

						document.InsertParagraph("Flight Ticket Information")
							.FontSize(18)
							.Bold()
							.SpacingAfter(20)
							.Alignment = Alignment.center;

						var table = document.AddTable(8, 2);
						table.Alignment = Alignment.center;
						table.Design = TableDesign.LightShadingAccent1;

						table.Rows[0].Cells[0].Paragraphs[0].Append("Ticket Number").Bold();
						table.Rows[0].Cells[1].Paragraphs[0].Append(ticket.TicketNumber);

						table.Rows[1].Cells[0].Paragraphs[0].Append("Flight Number").Bold();
						table.Rows[1].Cells[1].Paragraphs[0].Append(ticket.FlightNumber);

						table.Rows[2].Cells[0].Paragraphs[0].Append("Airline").Bold();
						table.Rows[2].Cells[1].Paragraphs[0].Append(ticket.Airline);

						table.Rows[3].Cells[0].Paragraphs[0].Append("Destination").Bold();
						table.Rows[3].Cells[1].Paragraphs[0].Append(ticket.Destination);

						table.Rows[4].Cells[0].Paragraphs[0].Append("Passenger").Bold();
						table.Rows[4].Cells[1].Paragraphs[0].Append(ticket.Passenger);

						table.Rows[5].Cells[0].Paragraphs[0].Append("Employee").Bold();
						table.Rows[5].Cells[1].Paragraphs[0].Append(ticket.Employee);

						table.Rows[6].Cells[0].Paragraphs[0].Append("Departure Date").Bold();
						table.Rows[6].Cells[1].Paragraphs[0].Append(ticket.DepartureDate.ToString("yyyy-MM-dd HH:mm"));

						table.Rows[7].Cells[0].Paragraphs[0].Append("Cost").Bold();
						table.Rows[7].Cells[1].Paragraphs[0].Append(ticket.Cost.ToString("C"));

						document.InsertTable(table);

						document.InsertParagraph().SpacingAfter(20);

						document.InsertParagraph("Thank you for choosing our airline!")
							.FontSize(14)
							.Italic()
							.SpacingBefore(20)
							.Alignment = Alignment.center;

						document.Save();
					}
				});
			});
		}

		/// <summary>
		/// Normalizing a path based on the current operating system
		/// </summary>
		/// <param name="path">The path to normalize</param>
		/// <returns></returns>
		public string NormalizePath(string path)
		{
			// If on Windows...
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				// Replace any / with \
				return path.Replace('/', '\\').Trim();
			}

			// If on Linux/Mac
			// Replace any \ with /
			return path.Replace('\\', '/').Trim();
		}

		/// <summary>
		/// Resolves any relative elements of the path to absolute
		/// </summary>
		/// <param name="path">The path to resolve</param>
		/// <returns></returns>
		public string ResolvePath(string path)
		{
			// Resolve the path to absolute
			return Path.GetFullPath(path);
		}
	}
}