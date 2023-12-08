using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data.DTOs
{
  public class CourseDTO
  {
    [Key]
    public string SisId { get; set; }
    public string Term { get; set; }
    public string ClassNo { get; set; }
    public string Semester {  get; set; }
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
  }
}
