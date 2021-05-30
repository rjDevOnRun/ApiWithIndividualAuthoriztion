using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace ApiWithAuth.App_Start
{
    /// <summary>
    ///  For adding a new route to the SWAGGER scope
    /// </summary>
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, 
            SchemaRegistry schemaRegistry, 
            IApiExplorer apiExplorer)
        {
            /// Adds a 'token' route
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    /// Adds a 'Auth' TAB header to swagger page
                    tags = new List<string> { "Auth" },
                    /// into the data
                    consumes = new List<string>
                    {
                        "application/x-www-form-urlencoded"
                    },
                    /// Parameters
                    parameters = new List<Parameter>
                    {
                        new Parameter
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in = "formData",
                            @default = "password"
                        },

                        new Parameter
                        {
                            type = "string",
                            name = "username",
                            required = false,
                            @in = "formData"
                        },

                        new Parameter
                        {
                            type = "string",
                            name = "password",
                            required = false,
                            @in = "formData"
                        }
                    }
                }
            });
        }
    }
}