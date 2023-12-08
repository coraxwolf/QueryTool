using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Models
{
  public class CourseImport
  {
    public string SisId { get; set; }
    public string Term { get; set; }
    public string ClassNo { get; set; }
    public string Semester { get; set; }
    public string Subject { get; set; }
    public string Catalog { get; set; }
    public string Campus { get; set; }
    public string Location { get; set; }
    public string Title { get; set; }
    public string Mode { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public Int32 Enrolled { get; set; }
    public Int32 Cap { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public List<FacultyImport> AssignedFaculty { get; set; } = [];

    public CourseImport(
      string sisId,
      string term,
      string classNo,
      string semester,
      string subject,
      string catalog,
      string campus,
      string location,
      string title,
      string mode,
      string status,
      string notes,
      string enrolled,
      string cap,
      string startDate,
      string endDate
      )
    {
      SisId = sisId;
      Term = term;
      ClassNo = classNo;
      Semester = semester;
      Subject = subject;
      Catalog = catalog;
      Campus = campus;
      Location = location;
      Title = title;
      Mode = mode;
      Status = status == "A" ? "Active" : status == "S" ? "Stopped" : status == "X" ? "Canceled" : "Unknown";
      Notes = notes;
      Enrolled = Int32.Parse((enrolled.Length > 0) ? enrolled : "0");
      Cap = Int32.Parse((cap.Length > 0) ? cap : "0");
      StartDate = DateOnly.FromDateTime(DateTime.Parse(startDate));
      EndDate = DateOnly.FromDateTime(DateTime.Parse(endDate));
    }

  }
}
