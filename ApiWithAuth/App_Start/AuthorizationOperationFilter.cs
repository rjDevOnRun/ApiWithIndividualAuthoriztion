using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ApiWithAuth.App_Start
{
    /// <summary>
    /// Adds Authorzation Parameter to Swagger Routes
    /// </summary>
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, 
            SchemaRegistry schemaRegistry, 
            ApiDescription apiDescription)
        {
            if(operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            /// Adds parameters for authorization into 
            /// header section of requests
            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "Access Token",
                required = false,
                type = "string",
                @default = "bearer "
            });
        }
    }
}