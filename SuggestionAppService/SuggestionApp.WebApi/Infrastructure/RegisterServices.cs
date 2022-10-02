using SuggestionApp.BusinessLogic.Domain;
using SuggestionApp.BusinessLogic.Mappers;
using SuggestionApp.DataAccess.DbContext;
using SuggestionApp.DataAccess.Repositories;

namespace SuggestionApp.WebApi.Infrastructure
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMemoryCache();

            builder.Services.AddSingleton<IDbConnection, DbConnection>();   
            builder.Services.AddSingleton<ICategoryRepo, CategoryRepo>();
            builder.Services.AddSingleton<IStatusRepo, StatusRepo>();
            builder.Services.AddSingleton<IUserRepo, UserRepo>();
            builder.Services.AddSingleton<ISuggestionRepo, SuggestionRepo>();

            builder.Services.AddScoped<ICategoryProvider, CategoryProvider>();
            builder.Services.AddScoped<IStatusProvider, StatusProvider>();

            builder.Services.AddSingleton<CategoryMapper>();
            builder.Services.AddSingleton<StatusMapper>();
        }
    }
}
