using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppStudent.Models;

namespace WebAppStudent.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext (DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppStudent.Models.Student> Student { get; set; } = default!;

        public DbSet<WebAppStudent.Models.SubjectMarks>? SubjectMarks { get; set; }
    }
}
