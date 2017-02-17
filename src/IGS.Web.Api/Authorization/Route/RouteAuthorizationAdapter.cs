using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// RouteAuthorizationAdapter is an adapter to authorize using <see cref="IRouteAuthorizationProvider"/>
	/// </summary>
	public sealed class RouteAuthorizationAdapter : IAuthorizationProvider
	{
		private readonly List<IRouteAuthorizationProvider> _namedRouteAuthorizationProviders = new List<IRouteAuthorizationProvider>();
		private IRouteAuthorizationProvider _wildCardAuthorizationProvider;


		/// <summary>
		/// Create a new <see cref="RouteAuthorizationAdapter"/>
		/// </summary>
		public RouteAuthorizationAdapter()
		{
		}

		/// <summary>
		/// Create a new <see cref="RouteAuthorizationAdapter"/>
		/// </summary>
		/// <param name="authorizationProviders">The collection of see<see cref="IRouteAuthorizationProvider"/></param>
		public RouteAuthorizationAdapter(IEnumerable<IRouteAuthorizationProvider> authorizationProviders)
		{
			authorizationProviders.ToList().ForEach(provider => Add(provider));
		}

		/// <summary>
		/// Add the <param name="authorizationProvider"></param>
		/// </summary>
		/// <param name="authorizationProvider">The <see cref="IRouteAuthorizationProvider"/></param>
		/// <returns>This instance</returns>
		public RouteAuthorizationAdapter Add(IRouteAuthorizationProvider authorizationProvider)
		{
			if (authorizationProvider.IsWildCardAuthorizationProvider())
			{
				_wildCardAuthorizationProvider = authorizationProvider;
			}
			else
			{
				_namedRouteAuthorizationProviders.Add(authorizationProvider);
			}

			return this;
		}

		/// <summary>
		/// Authorize the current request
		/// </summary>
		/// <param name="requestMessage"></param>
		public void AuthorizeRequest(HttpRequestMessage requestMessage)
		{
			var provider = _namedRouteAuthorizationProviders.FirstOrDefault(p => p.IsInRoute(requestMessage)) ?? _wildCardAuthorizationProvider;

			if (provider != null)
			{
				provider.AuthorizeRequest(requestMessage);
			}
		}
	}
}