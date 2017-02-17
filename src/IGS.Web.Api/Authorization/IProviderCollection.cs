using System.Collections.Generic;

namespace IGS.Web.Api.Authorization
{
	/// <summary>
	/// A collection of <see cref="IAuthorizationProvider"/>
	/// </summary>
	public interface IProviderCollection : IEnumerable<IAuthorizationProvider>
	{
		/// <summary>
		/// Clear the collection 
		/// </summary>
		/// <returns>The cleared collection</returns>
		IProviderCollection Clear();

		/// <summary>
		/// Add an <see cref="IAuthorizationProvider"/>
		/// </summary>
		/// <param name="authorizationProvider"></param>
		/// <returns>The collection</returns>
		IProviderCollection Add(IAuthorizationProvider authorizationProvider);
	}
}
