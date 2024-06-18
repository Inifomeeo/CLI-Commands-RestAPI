using Microsoft.EntityFrameworkCore;
using CommandApi.Models;

namespace CommandApi.Data
{
    public class CommandApiContext : DbContext
    {
        public CommandApiContext(DbContextOptions<CommandApiContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}