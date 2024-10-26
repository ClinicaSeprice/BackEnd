using ClinicaSepriceAPI;

var builder = WebApplication.CreateBuilder(args);

// Validar configuraciones JWT
builder.Services.ConfigureJWT(builder.Configuration);

// Configuración de servicios y dependencias
builder.Services.ConfigureServices();
builder.Services.ConfigureDbContext(builder.Configuration);

var app = builder.Build();

// Configuración de Swagger para entornos de desarrollo y producción
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
        c.RoutePrefix = string.Empty;
    });
}

// Middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Mapear los controladores de la API
app.MapControllers();

app.Run();