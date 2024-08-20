using Aplication.Service.Habitaciones;
using Aplication.Service.Hoteles;
using Aplication.Service.HotelesPreferidos;
using Aplication.Service.Reservas;
using Aplication.Service.Seguridad;
using Aplication.Service.TiposHabitaciones;
using Application.Service.Roles;
using Application.Service.Users;
using Domain.Repository;
using Infrastructure.Data;
using Infrastructure.RepositoryImpl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar JWT Authentication
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
builder.Services.AddAuthorization();


// Configurar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
connectionString = Environment.ExpandEnvironmentVariables(connectionString);
Console.WriteLine("Connection String: " + connectionString);


// Registrar ApplicationDbContext con la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRolRepository, RoleRepositoryImpl>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IHotelRepository, HotelRepositoryImpl>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IHabitacionRepository, HabitacionRepositoryImpl>();
builder.Services.AddScoped<IHabitacionService, HabitacionService>();
builder.Services.AddScoped<ITipoHabitacionRepository, TipoHabitacionRepositoryImpl>();
builder.Services.AddScoped<ITipoHabitacionService, TipoHabitacionService>();
builder.Services.AddScoped<IReservasRepository, ReservasRepositoryImpl>();
builder.Services.AddScoped<IReservasService, ReservasService>();
builder.Services.AddScoped<IHotelesPreferidosRepository, HotelesPreferidosRepositoryImpl>();
builder.Services.AddScoped<IHotelesPreferidosService, HotelesPreferidosService>();





builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Generar hash de la contraseña (esto es solo para demostración o prueba)
string plainPassword = "Taylor/1214.";
string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
Console.WriteLine($"Hashed Password: {hashedPassword}"); // Solo para desarrollo/prueba





// Agregar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelBookingSolution", Version = "v1" });

    // Configurar el esquema de seguridad JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});


var app = builder.Build();

// Configurar Swagger en la tubería de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
