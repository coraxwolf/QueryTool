using Perl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.ViewModels
{
    public class QueryCourseRecordViewModel : ViewModelBase
    {

        public Course? CourseRecord { get; set; } = null;
        public string CourseName { get => CourseRecord?.SisId?? String.Empty; }
        public Int32 Enrolled { get => CourseRecord?.Enrolled ?? 0;  }

        public QueryCourseRecordViewModel(Course course)
        {
            CourseRecord = course;
        }
    }
}
