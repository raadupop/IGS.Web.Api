using System.Collections.Generic;
using System.Net.Http;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// An <see cref="AggregateAuthorizationProvider"/> that implements <see cref="IRouteAuthorizationProvider"/> which require all of the providers to validate the request.
	/// </summary>
	public sealed class WildCardAggregateAuthorizationProvider : RouteAggregateAuthorizationProvider
	{
		/// <summary>
		/// Create a new <see cref="WildCardAggregateAuthorizationProvider"/>
		/// </summary>
		public WildCardAggregateAuthorizationProvider()
			: base(null)
		{
		}

		/// <summary>
		/// Create a new <see cref="WildCardAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="authorizationProvider"></param>
		public WildCardAggregateAuthorizationProvider(IEnumerable<IAuthorizationProvider> authorizationProvider)
			: base(null, authorizationProvider)
		{
		}

		/// <summary>
		/// All route are applicable
		/// </summary>
		/// <param name="requestMessage"></param>
		/// <returns>True for all route because this is a wildcard route provider</returns>
		public override bool IsInRoute(HttpRequestMessage requestMessage)
		{
			return true;
		}
	}
}
