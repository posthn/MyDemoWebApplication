var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions
    {
        WebRootPath = Directory.GetCurrentDirectory() + @"\node_modules",
        Args = args
    }
);

builder.Services.AddControllersWithViews();
builder.Services.AddSQLiteRepository(
    builder.Configuration["Data:ConnectionStrings:SQLite"],
    typeof(City),
    typeof(Person)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
