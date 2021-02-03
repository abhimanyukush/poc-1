using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Services
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _config;
        public string Connectionstring { get; set; }
        public AppSettings(IConfiguration configuration)
        {
            _config = configuration;
            Connectionstring = _config.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
