using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ticket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly PasswordHasher<ApplicationUser> passwordHasher;
        public ApplicationUserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFromName([FromQuery] string? name)
        {
            if (name == null)
            {
                List<ApplicationUser> list = await userManager.Users.ToListAsync();
                return list.Count == 0 ? BadRequest("There are no users found.") : Ok(list);
            }
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await userManager.Users.FirstOrDefaultAsync(t => t.UserName == name);
                return user == null ? BadRequest("No user could be found.") : Ok(user);
            }
            else
            {
                return BadRequest("No user could be found.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpdateUser([FromBody] UserUpdateCreateDTO user)
        {
            bool userHasNoName = user.userName == null;
            bool isANewUser = user.isNewUser == true;

            if (!ModelState.IsValid || (!isANewUser && userHasNoName))
            {
                return BadRequest("Invalid User.");
            }

            else
            {
                if (isANewUser)
                {
                    ApplicationUser newUser = new()
                    {
                        UserName = user.userName,
                        Email = user.email,
                    };
                    newUser.PasswordHash = passwordHasher.HashPassword(newUser, user.password);
                    _ = await userManager.CreateAsync(newUser);


                }
                if (!isANewUser && !userHasNoName)
                {
                    ApplicationUser userToUpdate = await userManager.Users.FirstOrDefaultAsync(t => t.UserName == user.userName);

                    if (userToUpdate == null)
                    {
                        return BadRequest("Error.");
                    }

                    userToUpdate.UserName = user.userName;
                    userToUpdate.Email = user.email;
                    userToUpdate.PasswordHash = passwordHasher.HashPassword(userToUpdate, user.password);

                    _ = await userManager.UpdateAsync(userToUpdate);
                }
            }


            return Ok(user);
        }

    }
}

