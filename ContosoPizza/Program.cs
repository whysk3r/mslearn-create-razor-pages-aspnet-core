using ContosoPizza.Data;
using ContosoPizza.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlite("Data Source=ContosoPizza.db"));

builder.Services.AddScoped<PizzaService>(); //ajoute le service PizzaService au conteneur de services.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Cette ligne force une redirection vers HTTPS si une requête HTTP est reçue.
app.UseStaticFiles(); // Cette ligne permet à l'application de servir des fichiers statiques, comme les images, les fichiers CSS et les scripts JavaScript.
app.UseRouting(); // Cette ligne active le routage, qui détermine comment une application répond à une demande client.
app.UseAuthorization(); // Cette ligne active l'autorisation, qui détermine les ressources auxquelles un utilisateur authentifié peut accéder.
app.MapRazorPages(); // Cette ligne mappe les Razor Pages dans l'application.


app.Run();
