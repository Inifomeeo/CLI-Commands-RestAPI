using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CommandApi.Models;

namespace CommandApi.Data
{
    public interface ICommandApiRepo
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandByID(long id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
    }
}