using Emerald.Data;
using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Services.DTOProviders
{
  public class DBFacultyAssignmentProvider : IFacultyAssignmentProvider
  {
    public Task<FacultyAssignment> GetFacultyAssignment(string sisId, string facultyNo)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<FacultyAssignment>> GetFacultyAssignments()
    {
      throw new NotImplementedException();
    }
  }
}
