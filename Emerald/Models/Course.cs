using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Models
{
  public class Course
  {
    public string SisId { get; }
    public string Term { get; }
    public string ClassNo { get; }
    public string Subject { get; set; }
    public string Catalog { get; set; }
    public string Title { get; set; }
    public string Mode { get; set; }
    public string Campus {  get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public Int32 Enrolled { get; set; }
    public Int32 Cap {  get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string? Notes { get; set; }
    public string? CanvasName { get; set; }
    public Int32? CanvasCode { get; set; }
    public string? CanvasState { get; set; }


    public string CourseName { get => $"{Subject} {Catalog} {Title} ({ClassNo}"; }

    public Course(
      string sisId,
      string term,
      string classNo,
      string subject,
      string catalog,
      string title,
      string mode,
      string campus,
      string location,
      string status,
      Int32 enrolled,
      Int32 cap,
      DateOnly startDate,
      DateOnly endDate,
      string? notes,
      string? canvasname,
      Int32? canvasCode,
      string? canvasState)
    {
      SisId = sisId;
      Term = term;
      ClassNo = classNo;
      Subject = subject;
      Catalog = catalog;
      Title = title;
      Mode = mode;
      Campus = campus;
      Location = location;
      Status = status;
      Enrolled = enrolled;
      Cap = cap;
      StartDate = startDate;
      EndDate = endDate;
      Notes = notes ?? null; 
      CanvasName = canvasname?? null;
      CanvasCode = canvasCode?? null;
      CanvasState = canvasState?? null;
    }

  }
}
