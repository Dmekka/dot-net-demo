using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace dot_net_demo
{
    public class ThisRepo
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILogger<ThisRepo> _logger;
        private readonly string _ApiUrl;
        private readonly string connectionString;

        public ThisRepo(ILogger<ThisRepo> logger, AppConfig appconfig)
        {
            _logger = logger;
            connectionString = appconfig.ConnectionString;
            _ApiUrl = appconfig.ApiUrl;
        }
        public async Task<IEnumerable<dynamic>> GetBabyNamesAsync(int? cityId = null)
        {
            string sp = "[dbo].[spGetBabyNames]";

            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync(sp, param: new { cityId }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> SaveBabyNamesAsync(string jsonArrValues = null)
        {
            string sp = "[dbo].[spInsertBabyNames]";

            using var conn = new SqlConnection(connectionString);
            return await conn.ExecuteAsync(sp, param: new { jsonArrValues }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<HttpResponseMessage> GetApiBabyNamesAsync()
        => await client.GetAsync(_ApiUrl);

    }
}
