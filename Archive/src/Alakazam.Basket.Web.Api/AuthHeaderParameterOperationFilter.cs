using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alakazam.Basket.Web.Api
{
    public sealed class AuthHeaderParameterOperationFilter
        : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "user-id",
                In = ParameterLocation.Header,
                Required = true,

            });
        }
    }
}