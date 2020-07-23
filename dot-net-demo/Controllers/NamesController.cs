using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dot_net_demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly ILogger<NamesController> _logger; 
        private readonly ThisRepo thisRepo;
        public NamesController(ILogger<NamesController> logger, ThisRepo repo)
        {
            _logger = logger; 
            thisRepo = repo;
        }
        // GET api/names
        [HttpGet]
        public async Task<IActionResult> Get() 
            => await GetActionResultAsync(thisRepo.GetBabyNamesAsync());

        // GET api/names/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id = null)
            => await GetActionResultAsync(thisRepo.GetBabyNamesAsync(id));

        private async Task<IActionResult> GetActionResultAsync<T>(Task<IEnumerable<T>> getterAsync, string msg = "No data returned")
        {
            _logger.LogInformation($"");

            try
            {
                IEnumerable<T> result = await getterAsync;
                bool success = result.Any();
                return Ok(new { success, message = success ? "" : msg, data = result });
            }
            catch (Exception ex)
            {
                LogExceptions(ex);
                throw;
            }
        }

        private void LogExceptions(Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
