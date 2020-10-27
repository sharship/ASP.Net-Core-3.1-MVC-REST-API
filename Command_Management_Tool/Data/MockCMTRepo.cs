using System.Collections.Generic;
using Command_Management_Tool.Models;

namespace Command_Management_Tool.Data
{
    public class MockCMTRepo : ICMTRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command> {
                new Command {Id = 1, HowTo="yes", Line = "yep", Platform = "YY"},
                new Command {Id = 2, HowTo="no", Line = "nope", Platform = "NN"}
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command {Id = 3, HowTo="NA", Line = "Mem", Platform = "OK"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}