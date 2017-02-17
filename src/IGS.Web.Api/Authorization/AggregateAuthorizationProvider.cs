using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace IGS.Web.Api.Authorization
{
	/// <summary>
	/// Class for multiple authorization providers. When the token authorization provider isn't enough than use this class to add the token  
	/// authorization provider along with more specific providers (e.g. RoleAuthorizationProvider, DataAccessAuthorizationProvider)
	/// </summary>
	public class AggregateAuthorizationProvider : IAuthorizationProvider
	{
		/// <summary>
		/// Create a new <see cref="AggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="authorizationProviders"></param>
		public AggregateAuthorizationProvider(IEnumerable<IAuthorizationProvider> authorizationProviders)
		{
			AuthorizationProviders = authorizationProviders.ToList();
		}

		/// <summary>
		/// The set of <see cref="IAuthorizationProvider"/>s to check
		/// </summary>
		protected List<IAuthorizationProvider> AuthorizationProviders { get; private set; }

		/// <summary>
		/// Adds a new <see cref="IAuthorizationProvider"/>
		/// </summary>
		/// <param name="authorizationProvider"></param>
		/// <returns>This instance</returns>
		public IAuthorizationProvider Add(IAuthorizationProvider authorizationProvider)
		{
			AuthorizationProviders.Add(authorizationProvider);
			return this;
		}

		/// <inheritdoc cref="IAuthorizationProvider" />
		public virtual void AuthorizeRequest(HttpRequestMessage requestMessage)
		{
			AuthorizationProviders.ForEach(p => p.AuthorizeRequest(requestMessage));
		}
	}
}
