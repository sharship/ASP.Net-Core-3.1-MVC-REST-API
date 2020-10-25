using System.Collections.Generic;
using Command_Management_Tool.Models;

namespace Command_Management_Tool.Data
{
    public interface ICMTRepo
    {
         IEnumerable<Command> GetAllCommands();

         Command GetCommandById(int id);
    }
}