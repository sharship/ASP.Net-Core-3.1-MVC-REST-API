using System.Collections.Generic;
using Command_Management_Tool.Models;

namespace Command_Management_Tool.Data
{
    public interface ICMTRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        // void UpdatePartialCommand(Command cmd);
        // void DeleteCommandById(int id);
    }
}