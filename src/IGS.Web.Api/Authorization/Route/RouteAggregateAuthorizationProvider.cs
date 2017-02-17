using System.Collections.Generic;
using System.Net.Http;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// An see <see cref="AggregateAuthorizationProvider"/> that implements <see cref="IRouteAuthorizationProvider"/> which requires all
	/// of the providers to validate the request successfully when the route is applicable
	/// </summary>
	public class RouteAggregateAuthorizationProvider : AggregateAuthorizationProvider, IRouteAuthorizationProvider
	{
		/// <summary>
		/// Create a new <see cref="RouteAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="routeName"></param>
		/// <param name="authorizationProviders"></param>
		public RouteAggregateAuthorizationProvider(string routeName, IEnumerable<IAuthorizationProvider> authorizationProviders)
			: base(authorizationProviders)
		{
			RoutName = routeName;
		}

		/// <summary>
		/// Create a new <see cref="RouteAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="routeName">The route name</param>
		public RouteAggregateAuthorizationProvider(string routeName) 
			: this(routeName, new IAuthorizationProvider[0])
		{
		}

		protected string RoutName { get; private set; }

		/// <summary>
		/// If the current route is applicable to this provider, it checks all <see cref="IAuthorizationProvider"/> to 
		/// ensure all providers authorize the request
		/// </summary>
		/// <param name="requestMessage"></param>
		public override void AuthorizeRequest(HttpRequestMessage requestMessage)
		{
			if (IsInRoute(requestMessage))
			{
				base.AuthorizeRequest(requestMessage);
			}
		}

		/// <inheritdoc cref="IRouteAuthorizationProvider" />
		public virtual bool IsInRoute(HttpRequestMessage requestMessage)
		{
			return requestMessage.HasRoute(RoutName);
		}
	}
}
