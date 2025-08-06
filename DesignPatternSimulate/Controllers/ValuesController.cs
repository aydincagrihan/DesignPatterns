using DesignPatternSimulate.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternSimulate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //Postmanden istek atarak db connectionun bir kez yapıldığını ve diğer işlemlerde çağırılmadığını görebiliriz.
        [HttpGet("[action]")]
        public IActionResult X()
        {

            DatabaseService databaseService= DatabaseService.GetInstance;
            databaseService.Connect();
            databaseService.Disconnect();
            return Ok(databaseService.Count);

        }

        [HttpGet("[action]")]
        public IActionResult Y()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connect();
            databaseService.Disconnect();
            return Ok(databaseService.Count);


        }
    }
}
