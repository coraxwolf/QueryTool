using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data
{
  public interface ICourseProvider
  {
    Task<IEnumerable<Course>> GetAllCourses();
    Task<IEnumerable<Course>> GetCoursesByTerm(string term);

    Task<IEnumerable<Course>> GetCoursesByFaculty(string faculty);
    Task<IEnumerable<Course>> GetCoursesBySubject(string subject);
    Task<IEnumerable<Course>> GetCoursesByMode(string mode);
    Task<IEnumerable<Course>> GetCoursesByStart(DateOnly startDate);
    Task<Course> GetCourseById(string id);
  }
}
