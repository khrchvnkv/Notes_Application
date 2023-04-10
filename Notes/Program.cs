using BusinessLayer;
using BusinessLayer.Implementation;
using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EFDBContext>(op => op.UseSqlServer(connection,
    b => b.MigrationsAssembly("DataLayer")));
builder.Services.AddTransient<IDirectoriesRepository, EFDirectoryRepository>();
builder.Services.AddTransient<IMaterialsRepository, EFMaterialsRepository>();
builder.Services.AddScoped<DataManager>();

builder.Services.AddMvc();

var app = builder.Build();

#region Middleware
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// Test DB
using (IServiceScope scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<EFDBContext>();
    SampleData.InitData(context);
}

app.Run();
#endregion
