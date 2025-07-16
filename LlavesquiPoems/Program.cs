using System.Reflection;
using LlavesquiPoems.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Setup PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add controllers
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Repositories and Services by convention
var assembly = Assembly.GetExecutingAssembly();

var typesWithInterfaces = assembly.GetTypes()
    .Where(t =>
        t.IsClass &&
        !t.IsAbstract &&
        t.Namespace != null &&
        (t.Namespace.StartsWith("Repositories") || t.Namespace.StartsWith("Services"))
    )
    .Select(t => new {
        Impl = t,
        Interface = t.GetInterfaces().FirstOrDefault(i =>
            i.Name == "I" + t.Name &&
            i.Namespace != null &&
            (i.Namespace.StartsWith("IRepositories") || i.Namespace.StartsWith("IServices"))
        )
    })
    .Where(x => x.Interface != null);

foreach (var item in typesWithInterfaces)
{
    builder.Services.AddScoped(item.Interface, item.Impl);
}

var app = builder.Build();

// Swagger UI only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();