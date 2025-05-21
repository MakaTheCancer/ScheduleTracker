using Microsoft.AspNetCore.Mvc;
using ScheduleTracker.EntityFamework;
using ScheduleTracker.Domain.Models;
using System.Linq;
using ScheduleTracker.AuthApi.Controllers;
using ScheduleTracker.WPF.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ScheduleTrackerDbContext _context;

    public AuthController(ScheduleTrackerDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto login)
    {
        var user = _context.Users.FirstOrDefault(u =>
            u.Email == login.Email && u.Password == login.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        return Ok("Login successful");
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto register)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == register.Email);
        if (existingUser != null)
        {
            return BadRequest("User with this email already exists.");
        }

        var newUser = new User
        {
            Username = register.Username,
            Email = register.Email,
            Password = register.Password,
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Ok("Registration successful");
    }
}
