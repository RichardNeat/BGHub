using BGHub.FE.Components;
using BGHub.Models;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
.AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingValue(sp =>
{
    var loggedInUser = new User()
    {
        Id = 1,
        Name = "Rich",
        Games = new List<Game>
    {
        new Game {Id=5, Name="Blood on the Clocktower", Owner=new User{ Id=1, Name="Rich"}, BGGId=240980, ImageUrl="https://cf.geekdo-images.com/HINb2nkFn5IiZxAlzQIs4g__original/img/e7izEwSmnBPiErsIF6hlWbgybBE=/0x0/filters:format(jpeg)/pic7009391.jpg"},
        new Game {Id=4, Name="Legendary Encounter: An Alien Deck Building Game", Owner=new User{ Id=1, Name="Rich"}, BGGId=146652, ImageUrl="https://cf.geekdo-images.com/jSz_KRUxsjGYitoqx9YH1Q__original/img/nrvJtT-4tYTD0fp3Cr57SKpfMfw=/0x0/filters:format(jpeg)/pic2225180.jpg" },
        new Game {Id=2, Name="Slay the Spire", Owner=new User{ Id=1, Name="Rich"}, BGGId=338960, ImageUrl="https://cf.geekdo-images.com/PQzVclEoOQ_wr4e1V86kxA__original/img/KXOf1hP1cIJQLabKhZulWP-e9wI=/0x0/filters:format(png)/pic8157856.png"},
        new Game {Id=1, Name="Terraforming Mars", Owner=new User{ Id=1, Name="Rich"}, BGGId=167791, ImageUrl="https://cf.geekdo-images.com/wg9oOLcsKvDesSUdZQ4rxw__original/img/thIqWDnH9utKuoKVEUqveDixprI=/0x0/filters:format(jpeg)/pic3536616.jpg"}
    },
        BGGUsername = "Gandolfini"
    };
    var source = new CascadingValueSource<User>(loggedInUser, isFixed: true);

    return source;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BGHub.FE.Client._Imports).Assembly);

app.Run();
