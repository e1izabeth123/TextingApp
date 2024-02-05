using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository  _userRepository;
    private readonly IMapper _mapper;

    //private readonly DataContext _context; // so that its available to the class
    public UsersController(IUserRepository userRepository, IMapper mapper) //this context is scoped to the http req only
    {
        _userRepository = userRepository;
        _mapper= mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();
       
       var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);

       return Ok(usersToReturn);
    }

    [HttpGet("{username}")] //api/users/123
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user= await _userRepository.GetMemberAsync(username);

        return _mapper.Map<MemberDto>(user);
    }

}
