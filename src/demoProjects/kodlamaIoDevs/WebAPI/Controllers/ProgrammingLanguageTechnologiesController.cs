using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageTechnologyQuery getListProgrammingLanguageTechnologyQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(getListProgrammingLanguageTechnologyQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListProgrammingLanguageTechnologyByDynamicQuery getListProgrammingLanguageTechnologyByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ProgrammingLanguageTechnologyListModel result = await Mediator.Send(getListProgrammingLanguageTechnologyByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageTechnologyQuery getByIdProgrammingLanguageTechnologyQuery)
        {
            GetByIdProgrammingLanguageTechnologyDto result = await Mediator.Send(getByIdProgrammingLanguageTechnologyQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologyCommand createProgrammingLanguageTechnologyCommand)
        {
            CreatedProgrammingLanguageTechnologyDto result = await Mediator.Send(createProgrammingLanguageTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnologyCommand)
        {
            UpdatedProgrammingLanguageTechnologyDto result = await Mediator.Send(updateProgrammingLanguageTechnologyCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageTechnologyCommand deleteProgrammingLanguageTechnologyCommand)
        {
            DeletedProgrammingLanguageTechnologyDto result = await Mediator.Send(deleteProgrammingLanguageTechnologyCommand);
            return Ok(result);
        }
    }
}
