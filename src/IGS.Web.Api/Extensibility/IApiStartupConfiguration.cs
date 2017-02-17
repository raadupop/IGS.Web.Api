using System.Web.Http;
using IGS.Web.Api.Authorization;
using IGS.Web.Api.Infrastructure;

namespace IGS.Web.Api.Extensibility
{
	/// <summary>
	/// API Startup configuration including: *Filters, Authorization Providers, *MessageHandlers, *Parameter Binding Rules and *Media Formatters
	/// </summary>
	public interface IApiStartupConfiguration
	{
		/// <summary>
		/// Place to add routes
		/// </summary>
		/// <param name="routes"></param>
		void SetupHttpRoutes(HttpRouteCollection routes);

		/// <summary>
		/// Place to set up route authorization.
		/// If <see cref="IApiConfiguration"/> has SkipAuthorization set to true, this will not be called by the setup manager.
		/// </summary>
		/// <param name="builder"></param>
		void SetupRouteAuthorisation(IRouteAuthorizationBuilder builder);
	}
}
