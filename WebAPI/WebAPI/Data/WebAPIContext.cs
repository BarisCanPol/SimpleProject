using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> options):base(options)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
