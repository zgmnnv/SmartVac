using SmartVac.Api.Db.Child;
using SmartVac.Api.Db.User;
using SmartVac.Api.Db.Vaccine;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Получение строки подключения
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Регистрация репозитория в DI-контейнере
        builder.Services.AddSingleton<IUserRepository>(new UserRepository(connectionString));
        builder.Services.AddSingleton<IChildRepository>(new ChildRepository(connectionString));
        builder.Services.AddSingleton<IVaccineRepository>(new VaccineRepository(connectionString));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
