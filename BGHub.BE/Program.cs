using BGHub.BE;
using BGHub.BE.Repositories;
using BGHub.BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddScoped<IGameService, GameService>();
//builder.Services.AddScoped<IGameRepository, GameRepository>();

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
    builder.Services.AddDbContext<BGHubDbContext>(options =>
       options.UseSqlServer("DefaultConnection"));
}

var app = builder.Build();

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
