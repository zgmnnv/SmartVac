using System.Text;
using Microsoft.IdentityModel.Tokens;
using SmartVac.Api.Db.Child;
using SmartVac.Api.Db.Manipulation;
using SmartVac.Api.Db.User;
using SmartVac.Api.Db.Vaccine;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SmartVac.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Получение строку подключения к БД
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
        
        // Регистрация таблиц БД в DI-контейнере
        builder.Services.AddSingleton<IUserRepository>(new UserRepository(connectionString));
        builder.Services.AddSingleton<IChildRepository>(new ChildRepository(connectionString));
        builder.Services.AddSingleton<IVaccineRepository>(new VaccineRepository(connectionString));
        builder.Services.AddSingleton<IManipulationRepository>(new ManipulationRepository(connectionString));
        builder.Services.AddSingleton(appSettings);
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.SecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowLocalClient");
        app.UseCors(policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed((host) => true));
        
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
