using Perl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Interfaces
{
  public interface ICourseProvider
  {
    Task<IEnumerable<Course>> GetAllCourses();
    Task<IEnumerable<Course>> GetAllCoursesByTerm(string term);

# Get by full Course ID (SisId)
    Task<Course> GetCourse(string courseId);
# Get by Term and Class Number
    Task<Course> GetCourse(string term, string classNo);
  }
}
