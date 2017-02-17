namespace IGS.Web.Api.Infrastructure
{
	/// <summary>
	/// Common API Configuration 
	/// </summary>
	public interface IApiConfiguration
	{
		/// <summary>
		/// When is true, request authorization is skipped
		/// </summary>
		bool SkipAuthorization { get; }
	}
}
