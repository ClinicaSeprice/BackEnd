using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Repositories;
using ClinicaSepriceAPI.Services;
using ClinicaSepriceAPI.Helpers;  // A�adimos el using para usar JwtHelper
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

// Configurar autenticaci�n JWT
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

// Configuraci�n para Swagger en entornos de desarrollo y producci�n
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
        c.RoutePrefix = string.Empty;  // Sirve Swagger UI en la ra�z
    });
}

// Middleware para manejar la autenticaci�n
app.UseAuthentication();

// Middleware para manejar autorizaci�n
app.UseAuthorization();

// Redirecci�n a HTTPS
app.UseHttpsRedirection();

// Mapear los controladores de la API
app.MapControllers();

app.Run();
