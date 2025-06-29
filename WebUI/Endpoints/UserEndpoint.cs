using HaircutSite.Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebUI.Contracts.User;

namespace WebUI.Endpoints
{
    public static class UserEndpoint
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(
            UserRequest request, 
            [FromServices]UserJWTService userJWTService) 
        {
            await userJWTService.RegisterUser(request.Name, request.Password);
            return Results.Ok("User registered successfully.");
        }

        private static async Task<IResult> Login(
            UserRequest request,
            [FromServices]UserJWTService userJWTService,
            HttpContext context)
        {
            var token = await userJWTService.Login(request.Name, request.Password);

            context.Response.Cookies.Append("cookies", token);

            return Results.Ok(token);
        }
    }
}
