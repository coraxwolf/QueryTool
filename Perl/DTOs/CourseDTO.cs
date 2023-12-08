using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.DTOs
{
  public class CourseDTO
  {
    [Key]
    public string SisId { get; set; }
    public string Term { get; set; }
    public string ClassNo { get; set;}
    public string Semester { get; set; }
    public string Subject { get; set; }
    public string Catalog { get; set; }
    public string Title { get; set; }
    public string Mode { get; set; }
    public string Status { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public Int32 Enrolled { get; set; }
    public Int32 Cap { get; set; }
    public string? CanvasName { get; set; }
    public Int32? CanvasCode { get; set; }
    public string? CanvasState { get; set; }

    public CourseDTO(
      string sisId,
      string term,
      string classNo,
      string semester,
      string subject,
      string catalog,
      string title,
      string mode,
      string status,
      DateOnly startDate,
      DateOnly endDate,
      int enrolled,
      int cap,
      string? canvasName = null,
      int? canvasCode = null,
      string? canvasState = null)
    {
      SisId = sisId;
      Term = term;
      ClassNo = classNo;
      Semester = semester;
      Subject = subject;
      Catalog = catalog;
      Title = title;
      Mode = mode;
      Status = status;
      StartDate = startDate;
      EndDate = endDate;
      Enrolled = enrolled;
      Cap = cap;
      CanvasName = canvasName;
      CanvasCode = canvasCode;
      CanvasState = canvasState;
    }
  }
}
