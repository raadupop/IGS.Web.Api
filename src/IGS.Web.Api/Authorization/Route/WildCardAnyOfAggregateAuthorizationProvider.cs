using System.Collections.Generic;
using System.Net.Http;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// An <see cref="WildCardAnyOfAggregateAuthorizationProvider"/> that implements <seealso cref="IRouteAuthorizationProvider"/> which require only 
	/// one of the providers to validate the request  successfully; all route are applicable.
	/// </summary>
	public sealed class WildCardAnyOfAggregateAuthorizationProvider : RouteAnyAggregateAuthorizationProvider
	{
		/// <summary>
		/// Create an new instance of <see cref="WildCardAnyOfAggregateAuthorizationProvider"/>
		/// </summary>
		public WildCardAnyOfAggregateAuthorizationProvider()
			: base(null)
		{
		}

		/// <summary>
		/// Create a new instance of <see cref="WildCardAnyOfAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="authorizationProviders"></param>
		public WildCardAnyOfAggregateAuthorizationProvider(IEnumerable<IAuthorizationProvider> authorizationProviders)
			: base(null, authorizationProviders)
		{
		}

		/// <summary>
		/// All route are applicable
		/// </summary>
		/// <param name="requestMessage"></param>
		/// <returns>True for all route, since this is a wildcard route provider</returns>
		public override bool IsInRoute(HttpRequestMessage requestMessage)
		{
			return true;
		}
	}
}
