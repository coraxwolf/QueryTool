using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Models
{
  public class FacultyImport
  {
    public string Name { get; set; }
    public string FacultyNo { get; set; }

    public FacultyImport(string number, string name)
    {
      Name = name;
      FacultyNo = number;
    }
  }
}
