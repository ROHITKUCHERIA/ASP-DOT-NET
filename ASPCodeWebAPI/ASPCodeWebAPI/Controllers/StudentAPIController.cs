using ASPCodeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCodeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly AspDotNetDatabaseContext context;

        public StudentAPIController(AspDotNetDatabaseContext context) {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentById(int id)
        {
            var data = await context.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student std)
        {
            // Find the existing student in the database by id
            var data = await context.Students.FindAsync(id);
            if (data == null)
            {
                // Return not found if the student doesn't exist
                return NotFound();
            }

            // Update only the properties that you want to change
            data.StudentName = std.StudentName; // Assuming Name is a property
            data.Age = std.Age; // Example property to update
                                // Update other fields as necessary

            // Save changes
            await context.SaveChangesAsync();

            // Return the updated student
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var data = await context.Students.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            context.Students.Remove(data);
            await context.SaveChangesAsync();
            return Ok(data);
        }

    }
}
