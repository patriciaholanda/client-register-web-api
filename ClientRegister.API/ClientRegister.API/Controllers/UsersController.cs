using AutoMapper;
using ClientRegister.Application.Models.UserModels;
using ClientRegister.Domain.Entities;
using ClientRegister.Domain.Services;
using ClientRegister.Domain.ValueObjects.UserVOs;
using Microsoft.AspNetCore.Mvc;

namespace ClientRegister.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> GetUsers()
    {
        List<User> users = await _userService.GetUsers();
        List<UserModel> userModels = _mapper.Map<List<UserModel>>(users);
        return Ok(userModels);
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<UserModel>> GetUserById(string userId)
    {
        User user = await _userService.GetUserById(userId);
        UserModel userModel = _mapper.Map<UserModel>(user);
        return Ok(userModel);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> AddUser(AddUserVO userVO)
    {
        User user = await _userService.AddUser(userVO);
        UserModel userModel = _mapper.Map<UserModel>(user);
        return Ok(userModel);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser(UpdateUserVO userVO)
    {
        await _userService.UpdateUser(userVO);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser(UpdateUserVO userVO)
    {
        await _userService.UpdateUser(userVO);
        return NoContent();
    }
}