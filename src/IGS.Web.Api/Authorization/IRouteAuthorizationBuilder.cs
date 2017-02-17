using System;

namespace IGS.Web.Api.Authorization
{
	/// <summary>
	/// Builds route based on authorization providers 
	/// </summary>
	public interface IRouteAuthorizationBuilder
	{
		/// <summary>
		/// Configure provider for all routes
		/// </summary>
		/// <param name="setupProviders"></param>
		/// <returns>A <see cref="IRouteAuthorizationBuilder"/></returns>
		IRouteAuthorizationBuilder ConfigureWildCardProviders(Action<IProviderCollection> setupProviders);

		/// <summary>
		/// Configure provider for a specific route
		/// </summary>
		/// <param name="routeName"></param>
		/// <param name="setupProvider"></param>
		/// <returns>A <see cref="IRouteAuthorizationBuilder"/></returns>
		IRouteAuthorizationBuilder ConfigureRouteProvider(string routeName, Action<IProviderCollection> setupProvider);

		/// <summary>
		/// Build the <see cref="IRouteAuthorizationBuilder"/>
		/// </summary>
		/// <returns>A <see cref="IAuthorizationProvider"/></returns>
		IAuthorizationProvider BuildProvider();
	}
}
