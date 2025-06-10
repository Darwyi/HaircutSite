namespace WebUI.Endpoints
{
    public class UserEndpoint
    {
        public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("login", Login);

            return app;
        }

        private static async
    }
}
