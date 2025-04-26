using HaircutSite.Application.Interfaces;
using HaircutSite.Infrastructure.Context;
using HaircutSite.Application.Services;
using HaircutSite.Domain.Interfaces;
using HaircutSite.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHaircutStyleService, HaircutStyleService>();
builder.Services.AddScoped<IHaircutStyleRepository, HaircutStylesRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppoinmentsRepository, AppointmentsRepository>();

builder.Services.AddDbContext<ApplicationContext>();


var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
