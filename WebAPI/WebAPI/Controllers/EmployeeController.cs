using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebAPI.Data;
using WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly WebAPIContext _db;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration, WebAPIContext db, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _db = db;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var list = _db.Employee.ToList();

            return new JsonResult(list);
        }

        [HttpPost]
        public JsonResult Post(Employee dep)
        {
            var record = _db.Employee.Add(dep);

            _db.SaveChanges();

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Employee emp)
        {
            var record = _db.Employee.FirstOrDefault(x => x.EmployeeId == emp.EmployeeId);

            if (record == null)
                return new JsonResult("Not found");

            record.Department = emp.Department;
            record.EmployeeName = emp.EmployeeName;
            record.PhotoFileName = emp.PhotoFileName;
            record.DateOfJoining = emp.DateOfJoining;

            _db.SaveChanges();

            return new JsonResult("Updated Succeffuly");
        }

        [HttpDelete("{id}")]
        public JsonResult Put(int id)
        {
            var record = _db.Employee.FirstOrDefault(x => x.EmployeeId == id);

            if (record == null)
                return new JsonResult("Not found");

            _db.Employee.Remove(record);

            _db.SaveChanges();

            return new JsonResult("Updated Succeffuly");
        }

        [Route("Savefile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var pyhsicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(pyhsicalPath,FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(fileName);
            }
            catch (Exception)
            {

                return new JsonResult("anoynous.png");
            }
        }
    }
}
