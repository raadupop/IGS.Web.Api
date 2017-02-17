using System.Collections.Generic;
using System.Net.Http;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// An <see cref="RouteAnyAggregateAuthorizationProvider"/> that implements <see cref="IRouteAuthorizationProvider"/> which require only one of 
	/// the providers to validate the request successfully (when the route is applicable)
	/// </summary>
	public class RouteAnyAggregateAuthorizationProvider : AnyOfAggregateAuthorizationProvider, IRouteAuthorizationProvider
	{
		/// <summary>
		/// Create a new <see cref="RouteAnyAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="routeName"></param>
		public RouteAnyAggregateAuthorizationProvider(string routeName)
			: this(routeName, new IAuthorizationProvider[0])
		{	
		}

		/// <summary>
		/// Create a new <see cref="RouteAnyAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="routeName"></param>
		/// <param name="authorizationProviders"></param>
		public RouteAnyAggregateAuthorizationProvider(string routeName, IEnumerable<IAuthorizationProvider> authorizationProviders)
			: base(authorizationProviders)
		{
			RouteName = routeName;
		}

		/// <summary>
		/// THe Route which this is applicable
		/// </summary>
		protected string RouteName { get; private set; }

		public override void AuthorizeRequest(HttpRequestMessage requestMessage)
		{
			if (IsInRoute(requestMessage))
			{
				base.AuthorizeRequest(requestMessage);
			}
		}

		/// <inheritdoc cref="IRouteAuthorizationProvider"/>
		public virtual bool IsInRoute(HttpRequestMessage requestMessage)
		{
			return requestMessage.HasRoute(RouteName);
		}
	}
}
