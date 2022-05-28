using WiredBrainCoffeeAdmin.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<WiredContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("WiredBrain")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddHttpClient();

// TODO: Register the typed HTTPClient here
builder.Services.AddHttpClient<ITicketService, TicketService>();

var app = builder.Build();

await EnsureDbCreated(app.Services, app.Logger);

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

async Task EnsureDbCreated(IServiceProvider services, ILogger logger)
{
    using var db = services.CreateScope()
        .ServiceProvider.GetRequiredService<WiredContext>();
    await db.Database.MigrateAsync();
}