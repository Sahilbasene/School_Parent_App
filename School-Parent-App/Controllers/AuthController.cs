using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using School_Parent_App.Data;

using School_Parent_App.Models;
namespace SchoolParentApp.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class AuthController : ControllerBase

    {

        private readonly ApplicationDbContext dbContext;

        public AuthController(ApplicationDbContext dbContext)

        {

            this.dbContext = dbContext;

        }


        [HttpPost]
        [Route("ParentLogin")]
        public async Task<IActionResult> Login(Login login)
        {
            var parent = await dbContext.Parents.FirstOrDefaultAsync(p => p.RegistrationId == login.RegistrationId && p.Password == login.Password);
            if (parent != null)
            {
                return Ok(parent.RegistrationId);
            }
            else
            {
                return BadRequest();
            }

        }

      


        


    }

}