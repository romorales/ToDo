namespace backend_todo
{
    using backend_todo.Context;
    using Microsoft.EntityFrameworkCore;

    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Database connection string.
            // Make sure to update the Password value below from "Your_password123" to your actual password.
            var connection = @"Server=db;Database=master;User=sa;Password=Your_password123;";

            // This line uses 'UseSqlServer' in the 'options' parameter
            // with the connection string defined above.
            // builder.Services.AddDbContext<ApplicationDbContext>(
            //     options => options.UseSqlServer(connection));
            
            builder.Services.AddDbContext<AplicationDbContext>(options =>
             options.UseSqlServer(connection));
            //                                                     options.UseSqlServer((builder.Configuration.GetConnectionString(""))));
            builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                                builder => builder.AllowAnyOrigin()
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowWebApp");
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

    }
}
