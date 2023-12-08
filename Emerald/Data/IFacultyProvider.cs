using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data
{
  public interface IFacultyProvider
  {
    Task<IEnumerable<Faculty>> GetAllFaculty();
    Task<Faculty> GetFacultyById(string id);
    Task<IEnumerable<Faculty>> GetFacultyByCourse(string courseId);
  }
}
