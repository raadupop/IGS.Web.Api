using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// Extension method related to <see cref="IRouteAuthorizationProvider"/>
	/// </summary>
	internal static class RouteAuthorizationProviderExtension
	{
		/// <summary>
		/// Check if the routeName is applicable to the request
		/// </summary>
		/// <param name="requestMessage"></param>
		/// <param name="routeNname"></param>
		/// <returns>True if the route matches the request</returns>
		public static bool HasRoute(this HttpRequestMessage requestMessage, string routeNname)
		{
			if (requestMessage.RequestUri == null)
			{
				return false;
			}
  
			// Get the route from WebApi route config first
			var httpConfiguration = requestMessage.GetConfiguration();
			IHttpRoute apiRoute;

			if (httpConfiguration.Routes.TryGetValue(routeNname, out apiRoute))
			{
				var requestRouteData = httpConfiguration.Routes.GetRouteData(requestMessage);

				return requestRouteData != null && requestRouteData.Route == apiRoute;
			}

			// TODO Get the route from THe MVC route table
			throw new RouteDoesNotExistException(routeNname, new KeyNotFoundException(string.Format("Could not find route name '{0}' in WebApi or *MVC route collection", routeNname)));
		}

		/// <summary>
		/// Determines whether a authorization provider is a wild card authorization provider
		/// </summary>
		/// <param name="provider"></param>
		/// <returns><c>true</c> if is wild card provider</returns>
		public static bool IsWildCardAuthorizationProvider(this IAuthorizationProvider provider)
		{
			return provider is WildCardAggregateAuthorizationProvider || provider is WildCardAnyOfAggregateAuthorizationProvider;
		}
	}
}
