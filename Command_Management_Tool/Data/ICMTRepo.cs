using System.Collections.Generic;
using Command_Management_Tool.Models;

namespace Command_Management_Tool.Data
{
    public interface ICMTRepo
    {
        // Get
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        bool SaveChanges();
        
        // Create
        void CreateCommand(Command cmd);

        // // Update
        // void UpdateCommand(int id, Command cmd);
        // void UpdatePartialCommand(int id, Command cmd);

        // // Delete
        // void DeleteCommandById(int id);
    }
}