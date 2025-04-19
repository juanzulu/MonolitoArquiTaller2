using MonolitoTaller.Models.DAO;
using MonolitoTaller.Utils;
using System.IO;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EstudianteDAO>();
builder.Services.AddScoped<AsignaturaDAO>();
builder.Services.AddScoped<NotaDAO>();

var app = builder.Build();

// Ejecutar script de inicialización
try
{
    var loggerFactory = LoggerFactory.Create(logging => logging.AddConsole());
    var logger = loggerFactory.CreateLogger("DBInit");

    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    string rutaScript = Path.Combine(AppContext.BaseDirectory, "sql", "init.sql");

    DatabaseInitializer.VerificarYCrearBase(
        masterConnection: connectionString.Replace("Database=GestionAcademica", "Database=master"),
        dbName: "GestionAcademica",
        scriptPath: rutaScript,
        logger: logger
    );
}
catch (Exception ex)
{
    Console.WriteLine("❌ Error crítico al inicializar la base de datos: " + ex.Message);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
