using HaircutSite.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<Interface, Class>();

builder.Services.AddDbContext<ApplicationContext>();


var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
