using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using takshBE.Model;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using takshBE.Migrations;
using Microsoft.EntityFrameworkCore;
namespace takshBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly studentDbcontext _studentDbContext;

        public StudentsController( studentDbcontext context) {
        _studentDbContext = context;

        }
        
[HttpPost("register")]
        public async Task<Student> addstudent (Student stud) {
            
            stud.Doj = DateTime.Today;
            _studentDbContext.Students.Add(stud);
            
            await _studentDbContext.SaveChangesAsync();
            return stud;
        }
        [HttpGet("login")]
        public async Task<ActionResult> login(string username, string password)
        {
           var student=await _studentDbContext.Students.FirstOrDefaultAsync(e=>e.Username==username&& e.Password==password);
            if (student != null)
            {
                student.Password = "";
                return Ok(student);
            }
            return Unauthorized(new { message = "Invalid username or password" });

        }
        [HttpGet("getAll")]
        public async Task<ActionResult<Student>> Allstud() {
            var studs = await _studentDbContext.Students.ToListAsync();
            return Ok(studs);
        }
        [HttpGet("notification")]
        public async Task<ActionResult<Notification>> notification(int stan)
        {
            var nots=await _studentDbContext.Notifications.ToListAsync();
            
            return Ok(nots);
        }
        

    }
   
}
