using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using takshBE.Model;

namespace takshBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssesmentController : ControllerBase
    {
        private readonly studentDbcontext _studentDbcontext;
        private async Task<List<Guid>> GetQuestion(int standard, string subject)
        {
            // Retrieve only the IDs to avoid loading unnecessary data
            List<Guid> questionIds = await _studentDbcontext.Questions
                .Where(q => q.subject == subject && q.standard == standard)
                .Select(q => q.quesid) // Only select the quesid
                .ToListAsync();

            // Optionally log the result (for debugging)
            Console.WriteLine($"Retrieved {questionIds.Count} question IDs.");

            return questionIds;
        }


        public AssesmentController(studentDbcontext _context ) {
            _studentDbcontext = _context;
        }
        [HttpPost("addasses")]
        public async Task<ActionResult<Assessment>> addasses(Assessment asses)
        {
            asses.assesid = new Guid();
            asses.questions=await GetQuestion(asses.stan,asses.subject);
            _studentDbcontext.Assessments.Add(asses);
            await _studentDbcontext.SaveChangesAsync();
            return Ok(asses);
        }
        [HttpGet("getasses")]
        public async Task<ActionResult<Assessment>> getasses(int stan)
        {
            var asses = await _studentDbcontext.Assessments.Where(e=>e.stan==stan).ToListAsync();
            
            return Ok(asses);
        }

        [HttpGet("asses{assesid}")]
        public async Task<ActionResult<List<Question>>> giveques(Guid assesid)
        {
            try
            {
                var ids = await _studentDbcontext.Assessments.FindAsync(assesid);
                List<Question> quesbank = new List<Question>();
                foreach (var id in ids.questions)
                {
                    var ques = await _studentDbcontext.Questions.FindAsync(id);
                    quesbank.Add(ques);
                }
                return Ok(quesbank);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while processing your request." });
            }
        }
        [HttpGet("recent 3")]
        public async Task<ActionResult<List<Assessment>>> recentthree(int stan)
        {
            var today=DateTime.Today;
            var asses = await _studentDbcontext.Assessments.Where(e => e.stan == stan&&e.expirydate >=DateOnly.FromDateTime(today)).OrderBy(e=>e.expirydate).Take(3).ToListAsync();
            return asses;
        }
    }
}
