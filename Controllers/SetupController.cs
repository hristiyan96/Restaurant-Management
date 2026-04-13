using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Data;
using RestaurantManagement.Models;
using BCrypt.Net;

namespace RestaurantManagement.Controllers
{
    public class SetupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SetupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CreateManager()
        {
            // Check if administrator already exists
            var existingManager = await _context.Users
                .FirstOrDefaultAsync(u => u.Role == UserRole.Administrator);

            if (existingManager != null)
            {
                return Content($"<h1>Manager User Already Exists!</h1>" +
                    $"<p>Email: <strong>{existingManager.Email}</strong></p>" +
                    "<p>You can log in with this account, or update an existing user to Manager role.</p>" +
                    "<a href='/Auth/Login'>Go to Login</a>", "text/html");
            }

            var manager = new User
            {
                Id = Guid.NewGuid(),
                Email = "manager@restaurant.com",
                FullName = "Мениджър",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("manager123"),
                Role = UserRole.Administrator,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(manager);
            await _context.SaveChangesAsync();

            return Content($"<h1>✅ Manager User Created Successfully!</h1>" +
                $"<h3>Login Credentials:</h3>" +
                $"<p><strong>Email:</strong> manager@restaurant.com</p>" +
                $"<p><strong>Password:</strong> manager123</p>" +
                $"<hr>" +
                $"<p><a href='/Auth/Login' class='btn'>Go to Login Page</a></p>" +
                $"<style>body{{font-family:Arial;padding:40px;}} a{{display:inline-block;padding:10px 20px;background:#007bff;color:white;text-decoration:none;border-radius:5px;margin-top:20px;}}</style>", 
                "text/html");
        }
    }
}








