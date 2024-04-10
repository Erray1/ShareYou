namespace ShareYou.Application.SecretsManagement;
public static partial class ServiceCollectionIoC
{
    public static IServiceCollection AddSecretsManagement(this IServiceCollection services)
    {
        services.AddScoped<ISecretsManager, AppConfigurationSecretsManager>();
        return services;
    }
}

