using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniManagement_MVC.Models;

namespace UniManagement_MVC.Data
{
    public class UniDbContext : DbContext
    {

        public DbSet<Department> Department { get; set; }
        public DbSet<Lecturer> Lecture { get; set; }

        public DbSet<Module> Module { get; set; }

        public DbSet<Service> Service { get; set; }

        public UniDbContext(DbContextOptions<UniDbContext> options)
            : base(options)
        {
        }


        public UniDbContext()
        {

        }
    }
}
