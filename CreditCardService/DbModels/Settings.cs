using Microsoft.Extensions.Configuration;

namespace CreditCardService.DbModels
{
    public class Settings
    {
        public string ConnectionString;
        public string Database;
        public IConfigurationRoot iConfigurationRoot;
    }
}
