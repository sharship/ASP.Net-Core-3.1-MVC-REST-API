using System.Collections.Generic;
using System.Linq;
using Command_Management_Tool.Models;

namespace Command_Management_Tool.Data
{
    public class SqlCMTRepo : ICMTRepo
    {
        private readonly CMTContext _context;

        public SqlCMTRepo(CMTContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            var commandItems = _context.Commands.ToList<Command>();

            return commandItems;
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.FirstOrDefault<Command>(c => c.Id == id);

            return command;
        }
    }
}