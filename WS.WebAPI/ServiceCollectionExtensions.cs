using System.Text.Json.Serialization;

namespace WS.WebAPI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers()
                    .AddJsonOptions(options =>
                                    {
                                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                                    });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
