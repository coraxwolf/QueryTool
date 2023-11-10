using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Models
{
    public class Faculty
    {
        public string FacultyName { get; }
        public string FacultyNo { get; }
        public string? CanvasName { get; set; }
        public Int32? CanvasCode { get; set; }

        public Faculty(string facultyName, string facultyNo, string? canvasName = null, int? canvasCode = null)
        {
            FacultyName = facultyName;
            FacultyNo = facultyNo;
            CanvasName = canvasName;
            CanvasCode = canvasCode;
        }
    }
}
