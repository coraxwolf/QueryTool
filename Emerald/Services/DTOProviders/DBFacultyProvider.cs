using Emerald.Data;
using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Services.DTOProviders
{
  public class DBFacultyProvider : IFacultyProvider
  {
    public Task<IEnumerable<Faculty>> GetAllFaculty()
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Faculty>> GetFacultyByCourse(string courseId)
    {
      throw new NotImplementedException();
    }

    public Task<Faculty> GetFacultyById(string id)
    {
      throw new NotImplementedException();
    }
  }
}
