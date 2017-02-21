#Introduction 

IGS.Web.Api is a shared class library part of the ISG.Web.Core libraries implemented with a pluggable architecture that should be consumed by the any of IGS components. 

The primary goal of the underlying core library in the context of the IGS systems is to decouple common core functionalities from the middleware tier avoiding in this way inconsistency and incompleteness implementation between the modules.

The second goal of this library is to accelerate the developing process by providing utilities and extensions for the e.g. media formatters, caching, etc. that would be consumed by the most IGS API’s.

#Functionality provided

Logging,
Exceptions,
Authorization, 
Formatters,
Caching,
Service status,
Mappers,
Handlers.

#Authorization infrastructure

IGS.Web.Api will provide an extendable infrastructure for wrapping at the high level of configuration the authorization systems of IGS components. 

The authorization process will be performed by the authorization providers in a custom ways. Those types of providers will be abstracted by two types of generics providers: 

WildCardAuthorizationProvider: Authorize all of the request for all of the route

RouteAuthorizationProvider: Authorize the request for a custom route
 
Using the Builder pattern for creating those generics providers IGS.Web.Api expose an interface IAuthorizationBuilder that is injected into the SetupRouteAuthorization method where will be registered the authorization providers:

E.g:
TokenAuthorizationProvider,
LocalIpAuthorizationProvider,
DataAccessAutorizationProvider, etc 
