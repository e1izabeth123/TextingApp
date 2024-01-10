using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]  //api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _context; // so that its available to the class
    public UsersController(DataContext context) //this context is scoped to the http req only
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return users;//usually ok response
    }

    [HttpGet("{id}")] //api/users/123
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

}
