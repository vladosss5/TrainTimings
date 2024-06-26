﻿namespace TrainTimings.Api.Middlewares;

public static class CustomExceptionHandlerMiddlewareExtentions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}