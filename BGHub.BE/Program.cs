using BGHub.BE;
using BGHub.BE.Repositories;
using BGHub.BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevLocalhostPolicy", policy =>
    {
        policy.SetIsOriginAllowed(origin =>
            origin.StartsWith("https://localhost"))
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
    options.AddPolicy("StrictProductionPolicy", policy =>
    {
        policy.WithOrigins("") // Hosted frontend url will go here
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddScoped<IEventGameService, EventGameService>();
builder.Services.AddScoped<IEventGameRepository, EventGameRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<BGHubDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
}
else if (builder.Environment.IsProduction())
{
    // Live production DB creation currently in progress
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("DevLocalhostPolicy");
}
else
{
    app.UseCors("StrictProductionPolicy");
}


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BGHubDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
