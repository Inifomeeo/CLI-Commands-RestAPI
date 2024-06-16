using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CommandApi.Models;

namespace CommandApi.Data
{
    public interface ICommandApiRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandByID(long id);
    }
}