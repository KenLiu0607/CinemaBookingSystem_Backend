namespace Backend.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAllServices(this IServiceCollection services)
        {
            services.AddScoped<BookingService>();
            services.AddScoped<HomeService>();
            return services;
        }
    }
}
