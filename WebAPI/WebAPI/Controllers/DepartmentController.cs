using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly WebAPIContext _db;
        public DepartmentController(IConfiguration configuration, WebAPIContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var list = _db.Department.ToList();

            return new JsonResult(list);
        }

        [HttpPost]
        public JsonResult Post(Department dep)
        {
            var record = _db.Department.Add(dep);

            _db.SaveChanges();

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(Department dep)
        {
            var record = _db.Department.FirstOrDefault(x => x.DepartmentId == dep.DepartmentId);

            if (record == null)
                return new JsonResult("Not found");

            record.DepartmentName = dep.DepartmentName;

            _db.SaveChanges();

            return new JsonResult("Updated Succeffuly");
        }

        [HttpDelete("{id}")]
        public JsonResult Put(int id)
        {
            var record = _db.Department.FirstOrDefault(x => x.DepartmentId == id);

            if (record == null)
                return new JsonResult("Not found");

            _db.Department.Remove(record);

            _db.SaveChanges();

            return new JsonResult("Updated Succeffuly");
        }
    }
}
