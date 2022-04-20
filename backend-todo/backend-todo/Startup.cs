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
            builder.Services.AddDbContext<AplicationDbContext>(options =>
                                                                options.UseSqlServer((builder.Configuration.GetConnectionString(""))));
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
