using System.Collections;
using System.Collections.Generic;

namespace IGS.Web.Api.Authorization
{
	/// <inheritdoc />
	public class ProviderCollection : IProviderCollection
	{
		private readonly List<IAuthorizationProvider> _providers;

		/// <summary>
		/// Create a new instance of <see cref="ProviderCollection"/>
		/// </summary>
		public ProviderCollection()
		{
			_providers = new List<IAuthorizationProvider>();
		}

		/// <inheritdoc />
		public IEnumerator<IAuthorizationProvider> GetEnumerator()
		{
			return _providers.GetEnumerator();
		}

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		/// <inheritdoc />
		public IProviderCollection Clear()
		{
			_providers.Clear();
			return this;
		}

		/// <inheritdoc />
		public IProviderCollection Add(IAuthorizationProvider authorizationProvider)
		{
			_providers.Add(authorizationProvider);
			return this;
		}
	}
}
