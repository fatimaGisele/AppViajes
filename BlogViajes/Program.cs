using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using BlogViajesAccesoDatos.Data.Init;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<Cliente, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();

builder.Services.AddControllersWithViews();


//agregar containerT al contenedor IoC de inyeccion de dependencias
builder.Services.AddScoped<IContainerT, ContainerT> ();

//siembra de datos
//builder.Services.AddScoped<IInit, Init>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

//SiembraDeDatos();

app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

//app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=RegularUser}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();
   //.WithStaticAssets();

app.Run();

/*void SiembraDeDatos()
{
    using (var s = app.Services.CreateScope())
    {
        var inicializadorBD = s.ServiceProvider.GetRequiredService<IInit>();
        inicializadorBD.Inicializar();
    }
}*/
