using System;
using System.Runtime.Serialization;

namespace IGS.Web.Api.Authorization.Route
{
	/// <summary>
	/// Throw when a route does not exist
	/// </summary>
	[Serializable]
	public sealed class RouteDoesNotExistException : Exception
	{
		private const string MessageFormat = "Failed to authorize request because route [{0}] doesn't exist. Either add the route or remove the authorization provider";
		
		/// <summary>
		/// Create a new <see cref="RouteDoesNotExistException"/>
		/// </summary>
		public RouteDoesNotExistException()
		{
		}

		/// <summary>
		/// Create a new <see cref="RouteDoesNotExistException"/>
		/// </summary>
		public RouteDoesNotExistException(string routeName) 
			: base(routeName, null)
		{
		}

		/// <summary>
		/// Create a new <see cref="RouteDoesNotExistException"/>
		/// </summary>
		/// <param name="routeName">The route name</param>
		/// <param name="innerException">The inner exception</param>
		public RouteDoesNotExistException(string routeName, Exception innerException)
			: base(string.Format(MessageFormat, routeName), innerException)
		{
		}

		/// <summary>
		/// Create a new instance of the <see cref="RouteDoesNotExistException"/>
		/// </summary>
		private RouteDoesNotExistException(SerializationInfo serializationInfo, StreamingContext streamingContext)
			: base(serializationInfo, streamingContext)
		{
		}
	}
}
