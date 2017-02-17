using System.Net.Http;

namespace IGS.Web.Api.Authorization
{
  /// <summary>
  /// Authorize a request using the <see cref="HttpRequestMessage"/>
  /// </summary>
  public interface IAuthorizationProvider
  {
    /// <summary>
    /// Decide if the current request can be served 
    /// </summary>
    /// <param name="requestMessage"></param>
    void AuthorizeRequest(HttpRequestMessage requestMessage);
  }
}
