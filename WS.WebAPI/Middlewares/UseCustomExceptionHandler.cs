﻿using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using WS.Business.CustomExceptions;

namespace WS.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = StatusCodes.Status500InternalServerError;

                    switch (exceptionFeature.Error)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;

                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;
                        case NoContentException:
                            statusCode = StatusCodes.Status204NoContent;
                            break;
                        default:
                            break;
                    }

                    context.Response.StatusCode = statusCode;
                    var response = ApiResponse<List<NoData>>.Fail(statusCode, exceptionFeature.Error.Message);


                    //LOGLAMA

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
