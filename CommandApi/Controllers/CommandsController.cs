using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CommandApi.Data;

namespace CommandApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandApiRepo _repository;

        public CommandsController(ICommandApiRepo repository)
        {
            _repository = repository;
        }

        // private readonly MockCommandApiRepo _repository = new MockCommandApiRepo();
        // GET: api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(commandItems);
        }

        // GET: api/commands
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(long id)
        {
            var commandItem = _repository.GetCommandByID(id);
            return Ok(commandItem);
        }

    }
}