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
using AutoMapper;
using CommandApi.Dtos;

namespace CommandApi.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandApiRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandApiRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET: api/commands
        // <snippet_GetByID>
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(long id)
        {
            var commandItem = _repository.GetCommandByID(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

    }
}