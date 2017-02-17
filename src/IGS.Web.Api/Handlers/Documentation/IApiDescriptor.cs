namespace IGS.Web.Api.Handlers.Documentation
{
	/// <summary>
	/// Describes an API
	/// </summary>
	public interface IApiDescriptor
	{
		/// <summary>
		/// Gets the name of the API
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the description of the API
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Gets the docs json version
		/// </summary>
		string DocsVersion { get; }
	}
}
