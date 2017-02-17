using System.Web.Http;
using IGS.Web.Api.Authorization;
using IGS.Web.Api.Handlers.Documentation;

namespace IGS.Web.Api.Extensibility
{
	/// <summary>
	/// Implement this interface from an extension to define additional API Startup configuration including: added and replace Routes, Parameter Bindings, Providers.
	/// </summary>
	public interface IExtensionStartupConfiguration : IApiDescriptor
	{
		/// <summary>
		/// Place to add new route mappings to collection provider
		/// </summary>
		/// <param name="routes"></param>
		void SetupHttpRouteAdditions(HttpRouteCollection routes);

		/// <summary>
		/// Sets the route authorization
		/// </summary>
		/// <param name="builder"></param>
		void SetupRouteAuthorization(IRouteAuthorizationBuilder builder);
	}
}
