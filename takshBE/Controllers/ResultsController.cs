using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using takshBE.Model;
using Dapper;

using System.Collections.Generic;
using System.Threading.Tasks;
namespace takshBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    { 
        private readonly studentDbcontext _studentDbcontext;
        public ResultsController(studentDbcontext context) {
        _studentDbcontext = context;
        }
        [HttpPost("addresult")]
        public async Task<ActionResult<bool>> addresult(Result res)
        {
            res.resultid = new Guid();
            if (await _studentDbcontext.Results.Where(e => e.assesid == res.assesid && e.username == res.username).CountAsync() == 0)
            {
                _studentDbcontext.Results.Add(res);

                var asses = await _studentDbcontext.Assessments.FindAsync(res.assesid);
                asses.totalstud += 1;
                _studentDbcontext.Assessments.Update(asses);
                await _studentDbcontext.SaveChangesAsync();
                return Ok(true);
            }
            return Ok(false);
        }
        [HttpGet("get4result")]
        public async Task<ActionResult> getfour(string username)
        {

            var today=DateTime.Now;
            var result = await (from r in _studentDbcontext.Results join a in _studentDbcontext.Assessments on r.assesid equals a.assesid where r.username == username&& a.expirydate<=DateOnly.FromDateTime(today) orderby a.expirydate  descending
                                select new
                                {
                                    r.marks,
                                    a.assessename,
                                    a.subject,
                                    a.expirydate
                                }).Take(4).ToListAsync();
            return Ok( result);
        }
        [HttpGet("getallresult")]
        public async Task<ActionResult> getall(string username)
        {
            // Fetch raw data
            var rawResults = await (
                from r in _studentDbcontext.Results
                join a in _studentDbcontext.Assessments
                on r.assesid equals a.assesid
                where r.username == username
                select new
                {
                    r.marks,
                    a.subject,
                    expirydate = a.expirydate.Value
                }
            ).ToListAsync();

            // Process data in-memory
            var result = rawResults
                .GroupBy(x => new { x.expirydate.Month, x.expirydate.Year })
                .Select(g => new
                {
                    name = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMM"),
                    subjects = g.ToDictionary(x => x.subject, x => x.marks)
                })
                .ToList();

            return Ok(result);
        }

        [HttpGet("position")]
        public async Task<ActionResult> Position(string username)
        {
            var data = await _studentDbcontext.Results.ToListAsync();
            int pos = 0;
            // Group data by username and calculate the average marks for each user

            var result = data.GroupBy(x => x.username)
                  .Select(g => new
                  {
                      Username = g.Key,
                      Average = g.Average(x => x.marks)
                  }).OrderByDescending(x => x.Average)
                  .ToArray();
            var dt = data.GroupBy(x => x.username)
                .Where(x => x.Key == username)
                .Select(
                g => new
                {
                    total = g.Count(),
                    pass = g.Count(x => x.marks > 60),
                    fail = g.Count(x => x.marks <= 60),
                    
                    username = g.Key,
                    Average = g.Average(x => x.marks)

                });


            // Return the resu

            foreach (var i in result)
            {
                pos++;

                if (i.Username == username)
                    break;
            }
            var obj = new { data=dt,posi= pos };
            return Ok(obj);


            }
        [HttpGet("getAlldata")]
        public async Task<ActionResult> GetAlldata(string username)
        {
            var connection = _studentDbcontext.Database.GetDbConnection();

            // Open the connection if it is not already open
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            var results = await connection.QueryAsync<dynamic>(
               "getalldataforapi",
               new { username },
               commandType: CommandType.StoredProcedure
           );

            // Convert the results to a list of dynamic objects
            var resultList = results.ToList();
            connection.Close();
            return Ok(resultList);
        }
        [HttpGet("getquarterlyresult")]
        public async Task<ActionResult>getquarterlyresult(string username)
        {
            var connection=_studentDbcontext.Database.GetDbConnection();
            dynamic result;
            if(connection.State != ConnectionState.Open)
            {
                 await connection.OpenAsync();

            }
            using (connection)
            {
                result = await connection.QueryAsync<dynamic>(
                   "getquarterly",
                   new { username },
                   commandType: CommandType.StoredProcedure
                   );
            }
            /*  var resultList=result.ToList();*/
            /*connection.Close();*/
            
            Dictionary<string, Dictionary<string, decimal>> res = new Dictionary<string, Dictionary<string, decimal>>();
            foreach ( var item in result)
            {
                if (!res.ContainsKey(item.subject))
                {
                    // If not, create a new dictionary for this subject
                    res[item.subject] = new Dictionary<string, decimal>();
                }
                res[item.subject][item.quarter] = item.AverageMarks;
            }
            return Ok(res.ToList());

        }




    }
}
