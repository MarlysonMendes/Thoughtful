﻿namespace Thoughtful.Api.Abstractions
{
    public interface IModule
    {
        WebApplicationBuilder RegisterModule(WebApplicationBuilder builder);
        IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder endpoints);
    }
}
