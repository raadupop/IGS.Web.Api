using IGS.Web.Api.Handlers.Documentation;

namespace IGS.Web.Api.Extensibility
{
	/// <summary>
	/// Implement this interface to define the startup configuration (<see cref="IApiStartupConfiguration"/>) that is needed in 
	/// any API (e.g. Products, Content, Cart, etc). Any plugins/extension to a core API should implement <see cref="IExtensionStartupConfiguration"/>
	/// </summary>
	public interface ICoreApiStartupConfiguration : IApiStartupConfiguration, IApiDescriptor
	{
	}
}
