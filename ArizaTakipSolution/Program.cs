using ArizaTakip.Infrastructure;
using ArizaTakip.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ----------------- DI (Dependency Injection) -----------------
builder.Services.AddControllers();

// AutoMapper: Application.Mappings içindeki profilleri tara

// Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS (gerekirse)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------- HTTP Pipeline -----------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS (auth'dan önce olabilir, sende auth yok; sorun deðil)
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();