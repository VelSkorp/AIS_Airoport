namespace AIS_Airport.Core
{
	/// <summary>
	/// Handles reading/writing and querying the file system
	/// </summary>
	public interface IFileManager
	{
		/// <summary>
		/// Writes the text to the specified file 
		/// </summary>
		/// <param name="text">The text to write</param>
		/// <param name="path">The path of the file to write to</param>
		/// <param name="append">If true writes text to the end of the file, otherwise overrides any existing file</param>
		/// <returns></returns>
		Task WriteTextToFileAsync(string text, string path, bool append = false);

		/// <summary>
		/// Asynchronously saves a ticket document to the specified path.
		/// </summary>
		/// <param name="ticket">The ticket containing the information to save.</param>
		/// <param name="path">The path where the document will be saved.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		Task SaveTicketDocumentAsync(Ticket ticket, string path);

		/// <summary>
		/// Normalizing a path based on the current operating system
		/// </summary>
		/// <param name="path">The path to normalize</param>
		/// <returns></returns>
		string NormalizePath(string path);

		/// <summary>
		/// Resolves any relative elements of the path to absolute
		/// </summary>
		/// <param name="path">The path to resolve</param>
		/// <returns></returns>
		string ResolvePath(string path);
	}
}