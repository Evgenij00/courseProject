using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using courseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace courseProject.Controllers
{
    public class UserController : ApplicationController
    {
        public UserController(ApplicationDbContext context) : base(context) { }

        public async Task<IActionResult> IndexAsync()
        {
            string userName = User.Identity.Name;

            User currentUser = DataContext.Users.FirstOrDefault(u => u.Email == userName);

            if (currentUser == null)
            {
                return NotFound();
            }

            return View(currentUser);
        }
    }
}