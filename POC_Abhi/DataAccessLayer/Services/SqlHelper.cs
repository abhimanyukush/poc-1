using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Services
{
    public class SqlHelper : ISqlHelper
    {
        private readonly IConfiguration _config;
        public string Connectionstring { get; set; }
        public SqlHelper(IConfiguration configuration)
        {
            _config = configuration;
            Connectionstring = _config.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
