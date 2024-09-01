using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using takshBE.Model;

namespace takshBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly studentDbcontext _studentdbcontext;
        public LearningController(studentDbcontext dbcontext) {
            _studentdbcontext = dbcontext;
        }
        [HttpPost("addTopic")]
        public async Task<ActionResult<NextTopic>> addtopic(NextTopic nextTopic)
        {
            _studentdbcontext.NextTopics.Add(nextTopic);
            await _studentdbcontext.SaveChangesAsync();
            return Ok(nextTopic);
        }
        [HttpGet("getTopic")]
        public async Task<ActionResult<List<NextTopic>>> addtopic(int stan)
        {
            var data =await _studentdbcontext.NextTopics.Where(e => e.stand == stan).ToListAsync();
            return Ok(data);
        }
        [HttpPost("uploadpdf")]
        public async Task<ActionResult<studyMaterial>> uploadpdf(IFormFile studymaterial, int standard, string subjectname)

        {
            using var memory = new MemoryStream();
            await studymaterial.CopyToAsync(memory);
            var fileBytes = memory.ToArray();

            var study = new studyMaterial
            {
                pdfcontent = fileBytes,
                pdfname = studymaterial.FileName,
                standard = standard,
                subjectname = subjectname
            };
            _studentdbcontext.Materials.Add(study);
            await _studentdbcontext.SaveChangesAsync();
            return Ok(study);


        }
        [HttpGet("downloadpdf")]
        public async Task<IActionResult> DownloadPdf(int standard)
        {
            var studyMaterial = await _studentdbcontext.Materials
                .Where(s => s.standard == standard )
                .FirstOrDefaultAsync();


            if(studyMaterial == null)
            {
                return Ok("no data available");
            }
            else
            return File(studyMaterial.pdfcontent, "application/pdf", studyMaterial.pdfname);
        }

    }
}
    

