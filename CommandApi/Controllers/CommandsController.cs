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
using Azure;
using Microsoft.AspNetCore.JsonPatch;
using CommandApi.Migrations;

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

        // GET: api/commands/{id}
        // <snippet_GetByID>
        [HttpGet("{id}", Name ="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(long id)
        {
            var commandItem = _repository.GetCommandByID(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }
        // <snippet_GetByID>

        // POST: api/commands
        // <snippet_Create>
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }
        // <snippet_Create>

        // PUT: api/commands/{id}
        // <snippet_Update>
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(long id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        // <snippet_Update>

        // PATCH: api/commands/{id}
        // <snippet_Update>
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(long id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);
            
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
        // <snippet_Update>

        // DELETE: api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(long id)
        {
            var commandModelFromRepo = _repository.GetCommandByID(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}