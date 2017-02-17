using System;
using IGS.Web.Api.Authorization.Route;
using IGS.Web.Api.Infrastructure;

namespace IGS.Web.Api.Authorization
{
	/// <inheritdoc />
	public sealed class RouteAuthorizationBuilder : IRouteAuthorizationBuilder
	{
		private readonly RouteAuthorizationAdapter _provider;
		private readonly bool _useOrLogicForAuthorizationProviders;

		/// <summary>
		/// Create a new instance of <see cref="RouteAuthorizationBuilder"/>
		/// </summary>
		/// <param name="apiConfiguration"></param>
		public RouteAuthorizationBuilder(IApiConfiguration apiConfiguration)
		{
			_provider = new RouteAuthorizationAdapter();
			_useOrLogicForAuthorizationProviders = apiConfiguration.SkipAuthorization;
		}

		/// <summary>
		/// Configure wildcard provider
		/// </summary>
		/// <param name="setupProviders"></param>
		/// <returns>This instance</returns>
		public IRouteAuthorizationBuilder ConfigureWildCardProviders(Action<IProviderCollection> setupProviders)
		{
			var manager = new ProviderCollection();
			setupProviders(manager);

			if (_useOrLogicForAuthorizationProviders)
			{
				_provider.Add(new WildCardAnyOfAggregateAuthorizationProvider(manager));
			}
			else
			{
				_provider.Add(new WildCardAggregateAuthorizationProvider(manager));
			}

			return this;
		}

		/// <summary>
		/// Configure route provider
		/// </summary>
		/// <param name="routeName"></param>
		/// <param name="setupProvider"></param>
		/// <returns>This instance</returns>
		public IRouteAuthorizationBuilder ConfigureRouteProvider(string routeName, Action<IProviderCollection> setupProvider)
		{
			var manager = new ProviderCollection();
			setupProvider(manager);

			if (_useOrLogicForAuthorizationProviders)
			{
				_provider.Add(new RouteAnyAggregateAuthorizationProvider(routeName, manager));
			}
			else
			{
				_provider.Add(new RouteAggregateAuthorizationProvider(routeName, manager));
			}

			return this;
		}

		/// <summary>
		/// Get the current instance of <see cref="IAuthorizationProvider"/>
		/// </summary>
		/// <returns>The current <see cref="IAuthorizationProvider"/></returns>
		public IAuthorizationProvider BuildProvider()
		{
			return _provider;
		}
	}
}
