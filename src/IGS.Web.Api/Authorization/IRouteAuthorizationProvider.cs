using System.Net.Http;

namespace IGS.Web.Api.Authorization
{
	/// <summary>
	/// Represents an <see cref="IAuthorizationProvider"/> that is specific to a route
	/// </summary>
	public interface IRouteAuthorizationProvider : IAuthorizationProvider
	{
		/// <summary>
		/// Verify if route matches this provider
		/// </summary>
		/// <param name="requestMessage"></param>
		/// <returns>True if this provider is configured for the current route</returns>
		bool IsInRoute(HttpRequestMessage requestMessage);
	}
}
