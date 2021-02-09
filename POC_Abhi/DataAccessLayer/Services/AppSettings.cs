using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Services
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _config;
        public string Connectionstring { get; set; }        
        private readonly IHostingEnvironment _environment;
        public AppSettings(IConfiguration configuration, IHostingEnvironment environment)
        {
            _config = configuration;
            //doubt
            _environment = environment;
            var env = _environment.EnvironmentName;
            var path = $"appsettings.{ env }.json";            
            Connectionstring = _config.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
