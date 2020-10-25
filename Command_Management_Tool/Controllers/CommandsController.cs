using System.Collections.Generic;
using Command_Management_Tool.Models;
using Microsoft.AspNetCore.Mvc;

namespace Command_Management_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        // GET: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            return new List<Command> {
                new Command {Id = 1, HowTo="yes", Line = "yep", Platform = "YY"},
                new Command {Id = 2, HowTo="no", Line = "nope", Platform = "NN"}
            };
        } 
              
    }


}