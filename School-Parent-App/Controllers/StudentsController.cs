using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using School_Parent_App.Data;
using School_Parent_App.Models;
using System.Linq;

namespace School_Parent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await dbContext.Students.ToListAsync();
            return Ok(students);


        }



        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest("Invalid Student Data");
            }
            if (dbContext == null)
            {
                return StatusCode(500, "db context not initilization");
            }
            dbContext.Students.Add(student);
            // await dbContext.Students.AddAsync(student);

            await dbContext.SaveChangesAsync();
            return Ok(student);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditStudent([FromRoute] int id, Student student)
        {

            var students = await dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == student.StudentId);
            dbContext.Entry(students).CurrentValues.SetValues(student);
            await dbContext.SaveChangesAsync();

            return Ok(student);


        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            dbContext.Students.Remove(student);
            await dbContext.SaveChangesAsync();


            return Ok(student);



        }



    }
}