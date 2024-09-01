using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using takshBE.Model;

namespace takshBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly studentDbcontext _studentDbcontext;
        public NoticeController(studentDbcontext context) { 
            _studentDbcontext = context;
        }
        [HttpGet("getall")]
        public async Task<ActionResult<Notice>> allnotice() {
            var notices=await _studentDbcontext.Notices.ToListAsync();
            return Ok(notices);
        }
        [HttpPost("addnotice")]
        public async Task<ActionResult<Notice>> addnotice(Notice not)
        {
            not.noticeid = new Guid();
            _studentDbcontext.Notices.Add(not);
            await _studentDbcontext.SaveChangesAsync();
            return Ok(not);
        }

    }
}
