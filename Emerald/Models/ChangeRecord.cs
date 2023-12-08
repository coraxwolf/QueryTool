using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Models
{
  public class ChangeRecord
  {
    public enum RecordType
    {
      NewCourse,
      CanceledCourse,
      NewFaculty,
      FacultyAdded,
      FacultyRemoved,
      NotesChanges,
      UnknownErr
    };

    private readonly CourseImport? course;
    private readonly FacultyImport? faculty;
    private readonly string? note;
    private readonly DateOnly changeDate;
    private readonly RecordType changetype;

#pragma warning disable IDE0290 // Use primary constructor
    public ChangeRecord(CourseImport? course, FacultyImport? faculty, DateOnly changeDate, RecordType changetype, string? note)
    {
      this.course = course;
      this.faculty = faculty;
      this.changeDate = changeDate;
      this.changetype = changetype;
      this.note = note;
    }

    public override string ToString()
    {
      return changetype switch
      {
        RecordType.NewCourse => $"[{changeDate}] New Course Added {course?.SisId}.",
        RecordType.CanceledCourse => $"[{changeDate}] Course Canceled: {course?.SisId}.",
        RecordType.NewFaculty => $"[{changeDate}] New Faculty Record Created {faculty?.Name} ({faculty?.FacultyNo}).",
        RecordType.FacultyAdded => $"[{changeDate}] Faculty {faculty?.Name} ({faculty?.FacultyNo}) Added to Course {course?.SisId}.",
        RecordType.FacultyRemoved => $"[{changeDate}] Faculty {faculty?.Name} ({faculty?.FacultyNo}) Removed from Course {course?.SisId}.",
        RecordType.NotesChanges => $"[{changeDate}] Course Notes for Course {course?.SisId}: {note}",
        _ => "Unknown Event Recorded!!",
      };
    }
  }
}
