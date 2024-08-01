using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Parent_App.Data;
using School_Parent_App.Models;

namespace School_Parent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ParentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpPost]
        public async Task<IActionResult> AddParent(Parent parent)
        {
            try
            {
                parent.Status = "Submitted";
                long registrationId = GenerateRandomRegistrationId();
                parent.RegistrationId = registrationId;
                parent.Password = parent.Password;
                if (parent.Password == parent.SetPassword)
                {
                    dbContext.Parents.Add(parent);
                    await dbContext.SaveChangesAsync();
                    return Ok(new { registrationId = parent.RegistrationId });
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        
        private long GenerateRandomRegistrationId()
        {
            Random random = new Random();
            long registrationId = ((long)random.Next(10000, 99999) * 100000) + (long)random.Next(10000, 99999);
            return registrationId;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllParents()
        {
            var parents = await dbContext.Parents.ToListAsync();
            return Ok(parents);
        }

        [HttpGet("{RegistrationId:long}")]
        public async Task<ActionResult<Parent>> GetParent(long RegistrationId)
        {
            try
            {
                // Log the RegistrationId being searched for
                Console.WriteLine($"Searching for parent with RegistrationId: {RegistrationId}");

                var result = await dbContext.Parents.FirstOrDefaultAsync(p => p.RegistrationId == RegistrationId);

                if (result == null)
                {
                    // Log if not found
                    Console.WriteLine("Parent not found.");
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPut]
        [Route("{RegistrationId:long}")]
        public async Task<IActionResult> EditParent([FromRoute] long RegistrationId, Parent parent)
        {

            var parents = await dbContext.Parents.FirstOrDefaultAsync(x => x.RegistrationId == parent.RegistrationId);
            if (parent.Password == parent.SetPassword)
            {
                dbContext.Entry(parents).CurrentValues.SetValues(parent);
                await dbContext.SaveChangesAsync();
            }
            else return BadRequest();


            return Ok(parent);

        }

        //public async Task<IActionResult> EditParent([FromRoute] long RegistrationId, Parent parent)
        //{

        //    var parents = await dbContext.Parents.FirstOrDefaultAsync(x => x.RegistrationId == parent.RegistrationId);
        //    dbContext.Entry(parents).CurrentValues.SetValues(parent);
        //    await dbContext.SaveChangesAsync();

        //    return Ok(parent);

        //}


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteParent([FromRoute] int id)
        {
            var parent = await dbContext.Parents.FirstOrDefaultAsync(x => x.ParentId == id);
            dbContext.Parents.Remove(parent);
            await dbContext.SaveChangesAsync();

            return Ok(parent);



        }



    }
}