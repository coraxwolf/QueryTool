using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Models
{
  public class ChangeRecord
  {

    public enum ChangeType
    {
      NewCourse,
      CanceledCourse,
      StoppedCourse,
      NewFaculty,
      FacultyAdded,
      FacultyRemoved,
    }
    public Guid RunId { get; }
    public Course Course { get; }
    public Faculty? Faculty { get; }
    public DateTime ChangeDate { get; }
    public ChangeType TypeofChange { get; }
    public string Note { get; }

    public ChangeRecord(Guid runId, Course course, Faculty? faculty, DateTime changeDate, ChangeType changeType, string note)
    {
      RunId = runId;
      Course = course;
      Faculty = faculty;
      ChangeDate = changeDate;
      TypeofChange = changeType;
      Note = note;
    }
  }
}
