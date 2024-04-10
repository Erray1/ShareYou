namespace ShareYou.Application.SecretsManagement;
public class AppConfigurationSecretsManager : ISecretsManager
{
    private readonly IConfiguration _config;
    public AppConfigurationSecretsManager(IConfiguration config)
    {
        _config = config;
    }
    public string GetDbConnectionString(string dbConnectionStringName)
    {
        var connectionString = _config.GetConnectionString(dbConnectionStringName);
        if (connectionString is null)
        {
            throw new Exception($"Не найден ключ подключения с именем {dbConnectionStringName}");
        }
        return connectionString;
    }
}

