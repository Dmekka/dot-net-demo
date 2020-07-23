using Microsoft.Extensions.Configuration;

namespace dot_net_demo
{
    public class AppConfig
    {
        public string ApiUrl { get; set; }
        public string ConnectionString { get; set; }

        public AppConfig(IConfiguration config)
        {
            ApiUrl = config.GetSection(nameof(ApiUrl)).Value;
            ConnectionString = config.GetConnectionString("defaultConnection");
        }
    }
}
