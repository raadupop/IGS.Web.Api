using System.Web.Http;
using IGS.Web.Api.Authorization;

namespace IGS.Web.Api.Extensibility
{
	/// <summary>
	/// Default (empty) implementation of <see cref="ICoreApiStartupConfiguration"/>. All off the IGS APIs may 
	/// implement only the startup configuration methods they need.
	/// </summary>
	public abstract class DefaultApiStartupConfiguration : ICoreApiStartupConfiguration
	{
		/// <inheritdoc/>
		public abstract string Name { get; }

		/// <inheritdoc/>
		public abstract string Description { get; }

		/// <inheritdoc/>
		public abstract string DocsVersion { get; }

		/// <inheritdoc/>
		public void SetupHttpRoutes(HttpRouteCollection routes)
		{
		}

		/// <inheritdoc/>
		public virtual void SetupRouteAuthorisation(IRouteAuthorizationBuilder builder)
		{
		}
	}
}
