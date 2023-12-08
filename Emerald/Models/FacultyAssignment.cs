using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Models
{
  public class FacultyAssignment
  {
    public string SisId { get; set; }
    public string FacultyNo { get; set; }

    public FacultyAssignment(string sisId, string facultyNo)
    {
      SisId = sisId;
      FacultyNo = facultyNo;
    }
  }
}
