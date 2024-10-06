using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Repositories;
using ClinicaSepriceAPI.Services;
using ClinicaSepriceAPI.Helpers;  // Añadimos el using para usar JwtHelper
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Validar configuraciones JWT
JwtHelper.ValidarConfiguracionJWT(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar el UsuarioService
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

// Configurar autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Configurar DbContext para MySql
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 2))));

var app = builder.Build();

// Configuración para Swagger en entornos de desarrollo y producción
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicaSepriceAPI v1");
        c.RoutePrefix = string.Empty;  // Sirve Swagger UI en la raíz
    });
}

// Middleware para manejar la autenticación
app.UseAuthentication();

// Middleware para manejar autorización
app.UseAuthorization();

// Redirección a HTTPS
app.UseHttpsRedirection();

// Mapear los controladores de la API
app.MapControllers();

app.Run();
