using Command_Management_Tool.Models;
using Microsoft.EntityFrameworkCore;

namespace Command_Management_Tool.Data
{
    public class CMTContext : DbContext
    {
        public CMTContext(DbContextOptions<CMTContext> opt)
            : base(opt)
        {
            
        }
        public DbSet<Command> Commands { get; set; }
    }
}