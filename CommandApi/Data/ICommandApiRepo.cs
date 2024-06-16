using CommandApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CommandApi.Data
{
    public interface ICommandApiRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandByID(long id);
    }
}