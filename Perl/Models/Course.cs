using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perl.Models
{
    public class Course
    {
        public string SisId { get; }
        public string Term {  get; }
        public string ClassNo { get; }
        public string Semester { get; }
        public string Subject { get; }
        public string Catalog { get; }
        public string Title { get; }
        public string Mode { get; }
        public string Status { get; set; }
        public DateOnly StartDate { get; }
        public DateOnly EndDate { get; }
        public Int32 Enrolled {  get; }
        public Int32 Cap {  get; }
        public string? CanvasName { get; set; }
        public Int32? CanvasCode { get; set; }
        public string? CanvasState { get; set; }
        public List<Faculty>? FacultyAssigned { get; private set; } = null;

        public Course(string sisId, string term, string classNo, string semester, string subject, string catalog, string title, string mode, string status, DateOnly startDate, DateOnly endDate, int enrolled, int cap, string? canvasName, int? canvasCode, string? canvasState)
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

        public void AddFacultyAssignment(Faculty faculty)
        {
            if (FacultyAssigned != null)
            {
                FacultyAssigned.Add(faculty);
            } else
            {
                FacultyAssigned = new List<Faculty> { faculty };
            }
        }

        public void RemoveFacultyAssignment(string facultyNo)
        {
            if (FacultyAssigned != null)
            {
                Faculty? delFaculty = FacultyAssigned.FirstOrDefault(f => f.FacultyNo == facultyNo)?? null;
                if (delFaculty != null)
                {
                    FacultyAssigned.Remove(delFaculty);
                }
            }
        }
    }
}
