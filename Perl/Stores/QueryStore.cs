using Perl.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Stores
{
  public class QueryStore
  {
    private Dictionary<string, Course> queryCourses;
    private Dictionary<string, Faculty> queryFaculty;
    private List<ChangeRecord> changes;

    public IEnumerable<Course> Courses
    {
      get
      {
        return queryCourses.Values;
      }
    }
    public IEnumerable<ChangeRecord> Changes
    {
      get
      {
        return changes;
      }
    }

    public IEnumerable<Faculty> Faculty
    {
      get
      {
        return queryFaculty.Values;
      }
    }

    public QueryStore()
    {
      queryCourses = new Dictionary<string, Course>();
      queryFaculty = new Dictionary<string, Faculty>();
      changes = new List<ChangeRecord>();
    }

    public Faculty? GetFaculty(string id)
    {
      return queryFaculty.TryGetValue(id, out var faculty) ? faculty : null;
    }
    public Course? GetCourse(string id)
    {
      return queryCourses.TryGetValue(id, out var course) ? course : null;
    }
    public void AddCourse(Course course)
    {
      queryCourses.Add(course.SisId, course);
      QueryRecordChanged?.Invoke();
    }
    public void AddFaculty(Faculty faculty)
    {
      queryFaculty.Add(faculty.FacultyNo, faculty);
      QueryRecordChanged?.Invoke();
    }

    public void UpdateCourse(Course course)
    {
      Course oldCourse = queryCourses[course.SisId];
      if (oldCourse != null)
      {
        queryCourses.Remove(oldCourse.SisId);
        queryCourses.Add(course.SisId, course);
        QueryRecordChanged?.Invoke();
      }
    }

    public bool ContainsCourse(string courseId)
    {
      return queryCourses.ContainsKey(courseId);
    }

    public bool ContainsFaculty(string id)
    {
      return queryFaculty.ContainsKey(id);
    }

    public void AddChangeRecord(ChangeRecord changeRecord)
    {
      changes.Add(changeRecord);
    }

    public event Action? QueryRecordChanged;
  }
}
