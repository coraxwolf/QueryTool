using Emerald.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data
{
  public class EODbContext : DbContext
  {
    public EODbContext(DbContextOptions options) : base(options) { }
    public DbSet<CourseDTO> CourseRecords { get; set; }
    public DbSet<FacultyDTO> FacultyRecords { get;set; }
    public DbSet<FacultyAssignmentsDTO> FacultyAssignmentRecords { get; set; }
  }
}
