namespace ShareYou.Application.SecretsManagement;

public interface ISecretsManager
{
    public string GetDbConnectionString(string dbConnectionStringName);
    public string GetJWTSecurityKey();
}
