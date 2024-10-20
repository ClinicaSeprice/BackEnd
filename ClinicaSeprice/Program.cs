using ClinicaSepriceAPI;

var builder = WebApplication.CreateBuilder(args);

// Validar configuraciones JWT
builder.Services.ConfigureJWT(builder.Configuration);

// Configuraci�n de servicios y dependencias
builder.Services.ConfigureServices();
builder.Services.ConfigureDbContext(builder.Configuration);

var app = builder.Build();

// Configuraci�n de Swagger para entornos de desarrollo y producci�n
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