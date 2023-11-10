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
        private Dictionary<string, Course> queryRecords;
        public IEnumerable<Course> QueryRecords { get => queryRecords.Values; }

        public QueryStore()
        {
            queryRecords = new Dictionary<string, Course>();
        }

        public Course? GetCourse(string id)
        {
            return queryRecords.TryGetValue(id, out var course)? course : null;
        }
        public void AddCourse(Course course)
        {
            queryRecords.Add(course.SisId, course);
            QueryRecordChanged?.Invoke();
        }

        public void UpdateCourse(Course course)
        {
            Course oldCourse = queryRecords[course.SisId];
            if (oldCourse != null)
            {
                queryRecords.Remove(oldCourse.SisId);
                queryRecords.Add(course.SisId, course);
                QueryRecordChanged?.Invoke();
            }
        }

        public bool ContainsCourse(string courseId)
        {
            return queryRecords.ContainsKey(courseId);
        }


        public event Action? QueryRecordChanged;
    }
}
