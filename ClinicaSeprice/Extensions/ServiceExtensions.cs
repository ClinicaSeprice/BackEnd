
using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.Helpers;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Profiles;
using ClinicaSepriceAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ClinicaSepriceAPI
{
    public static class ServiceExtensions
    {
        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            JwtHelper.ValidarConfiguracionJWT(configuration);
            services.AddAuthentication(options =>
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
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(AutoMapperProfileService));

            //Inyectar dependencias Usuarios
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Inyectar dependencias Persona
            services.AddScoped<IDireccionService, DireccionService>();

            //Inyectar dependencias Paciente
            services.AddScoped<IPacienteService, PacienteService>();

            //Inyectar dependencia de Rol
            services.AddScoped<IRolService, RolService>();

            //Inyectar dependendia de Medico
            services.AddScoped<IMedicoService, MedicoService>();

            //Inyectar dependencia de Obras Sociales
            services.AddScoped<IObraSocialService, ObraSocialService>();
            services.AddScoped<IPlanObraSocialService, PlanObraSocialService>();
            //Inyectar dependencia de Historia Clínica
            services.AddScoped<IHistoriaClinicaService, HistoriaClinicaService>();

            services.AddScoped<IHorarioDisponibleService, HorarioDisponibleService>();          

            services.AddScoped<IMetodoDePagosService, MetodoDePagoService>();


        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 2))));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

        }
    }
}
