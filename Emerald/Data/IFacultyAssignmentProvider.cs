using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data
{
  public interface IFacultyAssignmentProvider
  {
    Task<IEnumerable<FacultyAssignment>> GetFacultyAssignments();
    Task<FacultyAssignment> GetFacultyAssignment(string sisId, string facultyNo);

  }
}
