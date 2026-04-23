using HaircutSite.Infrastructure.Context;
using HaircutSite.Application.Services;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Infrastructure.Repositories;
using HaircutSite.Application.Interfaces.Services;
using HaircutSite.Application.Interfaces.Auth;
using HaircutSite.Infrastructure.Extensions;
using WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddControllers();

services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

services.AddDbContext<ApplicationContext>();

services.AddApiAuthentication(builder.Configuration);

services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IHaircutStyleService, HaircutStyleService>();
services.AddScoped<IHaircutStyleRepository, HaircutStylesRepository>();
services.AddScoped<IAppointmentService, AppointmentService>();
services.AddScoped<IAppoinmentsRepository, AppointmentsRepository>();

services.AddScoped<UserJWTService>();
services.AddScoped<IPasswordHashRepository, PasswordHash>();
services.AddScoped<IJwtRepository, JwtProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.AddApiEndpoints();

app.Run();
