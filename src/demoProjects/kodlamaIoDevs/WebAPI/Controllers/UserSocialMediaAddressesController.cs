using Application.Features.UserSocialMediaAddresses.Commands.CreateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.DeleteUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Commands.UpdateUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Models;
using Application.Features.UserSocialMediaAddresses.Queries.GetByIdUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Queries.GetListUserSocialMediaAddressByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediaAddressesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserSocialMediaAddressQuery getListUserSocialMediaAddressQuery = new() { PageRequest = pageRequest };
            UserSocialMediaAddressListModel result = await Mediator.Send(getListUserSocialMediaAddressQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListUserSocialMediaAddressByDynamicQuery getListUserSocialMediaAddressByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            UserSocialMediaAddressListModel result = await Mediator.Send(getListUserSocialMediaAddressByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserSocialMediaAddressQuery getByIdUserSocialMediaAddressQuery)
        {
            GetByIdUserSocialMediaAddressDto result = await Mediator.Send(getByIdUserSocialMediaAddressQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaAddressCommand createUserSocialMediaAddressCommand)
        {
            CreatedUserSocialMediaAddressDto result = await Mediator.Send(createUserSocialMediaAddressCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaAddressCommand updateUserSocialMediaAddressCommand)
        {
            UpdatedUserSocialMediaAddressDto result = await Mediator.Send(updateUserSocialMediaAddressCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserSocialMediaAddressCommand deleteUserSocialMediaAddressCommand)
        {
            DeletedUserSocialMediaAddressDto result = await Mediator.Send(deleteUserSocialMediaAddressCommand);
            return Ok(result);
        }
    }
}
