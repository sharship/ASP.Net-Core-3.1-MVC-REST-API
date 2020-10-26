using System.Collections.Generic;
using Command_Management_Tool.Data;
using Command_Management_Tool.Models;
using Microsoft.AspNetCore.Mvc;

namespace Command_Management_Tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICMTRepo _repo;

        public CommandsController(ICMTRepo repo)
        {
            _repo = repo;
        }

        // GET: api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();

            return Ok(commandItems);
        }

        // GET: api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);

            if (command is null)
                return NotFound();

            return command;
        }
              
    }


}