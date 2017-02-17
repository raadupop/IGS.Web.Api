using System;
using System.Collections.Generic;
using System.Net.Http;

namespace IGS.Web.Api.Authorization
{
	/// <summary>
	/// An <see cref="AnyOfAggregateAuthorizationProvider"/> that requires only one of the set of providers to perform the AuthorizeRequest
	/// </summary>
	public class AnyOfAggregateAuthorizationProvider : AggregateAuthorizationProvider
	{
		/// <summary>
		/// Create a new instance of <see cref="AnyOfAggregateAuthorizationProvider"/>
		/// </summary>
		/// <param name="authorizationProviders"></param>
		public AnyOfAggregateAuthorizationProvider(IEnumerable<IAuthorizationProvider> authorizationProviders)
			: base(authorizationProviders)
		{
		}

		/// <summary>
		/// If applicable to the route, this will authorize the request if one of the <see cref="IAuthorizationProvider"/>s can validate the request  
		/// </summary>
		/// <remarks>
		/// Only the last authorization exception will be tracked and thrown, even if 
		/// multiple providers fail authorization, so the authorization providers 
		/// should be set up in specific order
		/// </remarks>
		/// <param name="requestMessage"></param>
		public override void AuthorizeRequest(HttpRequestMessage requestMessage)
		{
			for (var i = 0; i < AuthorizationProviders.Count; i++)
			{
				try
				{
					AuthorizationProviders[i].AuthorizeRequest(requestMessage);
					return;
				}
				catch (Exception)
				{
					if (i == AuthorizationProviders.Count - 1)
					{
						throw;
					}
				}
			}
		}
	}
}
