using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Models
{
  public class Faculty
  {
    public string Name { get; set; }
    public string FacultyNo { get; set; }
    public string? CanvasName { get; set; }
    public Int32? CanvasCode { get; set; }
    public string? Email { get; set; }

    public Faculty(string name, string facultyNo, string? canvasName, int? canvasCode, string? email)
    {
      Name = name;
      FacultyNo = facultyNo;
      CanvasName = canvasName;
      CanvasCode = canvasCode;
      Email = email;
    }
  }
}
