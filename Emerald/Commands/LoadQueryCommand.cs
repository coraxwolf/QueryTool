using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Emerald.Models;
using Emerald.ViewModels;
using Microsoft.Win32;

namespace Emerald.Commands
{
  public class LoadQueryCommand : CommandBase
  {
    private readonly ObservableCollection<ChangeRecordViewModel> changeLog;
    private readonly Dictionary<string, Course> courseList;
    private readonly Dictionary<string, Faculty> facultyList;

    public LoadQueryCommand(ObservableCollection<ChangeRecordViewModel> changes, Dictionary<string, Course> courses, Dictionary<string, Faculty> faculty)
    {
      changeLog = changes;
      courseList = courses;
      facultyList = faculty;
    }

    public override void Execute(object? parameter)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Title = "Select Query File";
      dialog.Filter = "Comma Seperated Values (*.csv)|*.csv";
      dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      bool? fileOk = dialog.ShowDialog();

      if (fileOk == true)
      {
        Dictionary<string, CourseImport> courses = [];
        string queryFilePath = dialog.FileName;
        var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
        {
          MissingFieldFound = null,
          IgnoreBlankLines = true,
        };
        using var fileReader = new StreamReader(queryFilePath);
        using var csv = new CsvReader(fileReader, config);
        {
          csv.Context.RegisterClassMap<QueryRowClassMap>();
          csv.Read();
          csv.ReadHeader();
          while (csv.Read())
          {
            QueryRow? row = csv.GetRecord<QueryRow>();
            if (row != null)
            {
              // Get Course Key Value
              string id = $"{row.Term}-{row.ClassNbr}-{row.Subject}-{row.Catalog}";
              // Get Faculty Key Value
              if (row.ID != string.Empty && row.ID.Length > 0)
              {
                string fid = row.ID.PadLeft(9, '0');
                // Check if Faculty is new Record
                if (!facultyList.ContainsKey(fid))
                {
                  Faculty facultyRecord = new Faculty(fid, row.Name, null, null, null);
                  facultyList.Add(fid, facultyRecord);
                  changeLog.Add(new ChangeRecordViewModel(new ChangeRecord(null, new FacultyImport(fid, row.Name), DateOnly.FromDateTime(DateTime.Now), ChangeRecord.RecordType.NewFaculty, null)));
                } else
                {
                  Faculty facultyRecord = facultyList[fid];
                }
              }

              if (courses.ContainsKey(id))
              {
                CourseImport course = courses[id];
                bool newFac = true;
                foreach (FacultyImport fac in course.AssignedFaculty)
                {
                  if (fac.FacultyNo == row.ID.PadLeft(9, '0') || fac.Name == row.Name)
                  {
                    newFac = false;
                    break;
                  }
                }
                if (newFac)
                {
                  FacultyImport faculty = new FacultyImport(row.ID.PadLeft(9, '0'), row.Name);
                  course.AssignedFaculty.Add(faculty);
                }
                // Check if notes are new
                if (course.Notes != row.Descrlong_A_Clsnotes)
                {
                  course.Notes = row.Descrlong_A_Clsnotes;
                  changeLog.Add(new ChangeRecordViewModel(new ChangeRecord(course, null, DateOnly.FromDateTime(DateTime.Now), ChangeRecord.RecordType.NotesChanges, row.Descrlong_A_Clsnotes)));
                }
              }
              else
              {
                // New Course
                CourseImport course = new CourseImport(
                  id,
                  row.Term,
                  row.ClassNbr,
                  row.Session,
                  row.Subject,
                  row.Catalog,
                  row.Campus,
                  row.Location,
                  row.Descr,
                  row.Mode,
                  row.ClassStat,
                  row.Descrlong_A_Clsnotes,
                  row.TotEnrl,
                  row.Cap,
                  row.StartDate,
                  row.EndDate
                  );
                if (row.ID != string.Empty && row.ID.Length > 0)
                {
                  FacultyImport faculty = new FacultyImport(row.ID.PadLeft(9, '0'), row.Name);
                  course.AssignedFaculty.Add(faculty);
                }
                ChangeRecordViewModel changeVM = new ChangeRecordViewModel(new ChangeRecord(course, null, DateOnly.FromDateTime(DateTime.Now), ChangeRecord.RecordType.NewCourse, null));
                changeLog.Add(changeVM);
              }
            }
          }
          // Match Each Couse with Existing Course Records
          foreach(KeyValuePair<string, CourseImport> kvp in courses)
          {
            // Look for existing Course Entry
            if (courseList.TryGetValue(kvp.Key, out var courseRecord))
            {
              // Match Up Import Properties with Record
              if (courseRecord.Status != kvp.Value.Status)
              {
                courseRecord.Status = kvp.Value.Status;
                // Check if Course is Canceled
                if (kvp.Value.Status == "Canceled")
                {
                  changeLog.Add(new ChangeRecordViewModel(new ChangeRecord(kvp.Value, null, DateOnly.FromDateTime(DateTime.Now), ChangeRecord.RecordType.CanceledCourse, null)));
                }
                if (kvp.Value.Enrolled != courseRecord.Enrolled)
                {
                  courseRecord.Enrolled = kvp.Value.Enrolled;
                }
                if (courseRecord.Notes != kvp.Value.Notes)
                {
                  courseRecord.Notes = kvp.Value.Notes;
                  changeLog.Add(new ChangeRecordViewModel(new ChangeRecord(kvp.Value, null, DateOnly.FromDateTime(DateTime.Now), ChangeRecord.RecordType.NotesChanges, kvp.Value.Notes)));
                }
              }
            } else
            {
              Course newCourse = new Course(
                kvp.Value.SisId,
                kvp.Value.Term,
                kvp.Value.ClassNo,
                kvp.Value.Subject,
                kvp.Value.Catalog,
                kvp.Value.Title,
                kvp.Value.Mode,
                kvp.Value.Campus,
                kvp.Value.Location,
                kvp.Value.Status,
                kvp.Value.Enrolled,
                kvp.Value.Cap,
                kvp.Value.StartDate,
                kvp.Value.EndDate,
                kvp.Value.Notes,
                null,
                null,
                null
                );
              courseList.Add(newCourse.SisId, newCourse);
              changeLog.Add(new ChangeRecordViewModel(new ChangeRecord(kvp.Value, null, DateOnly.FromDateTime(DateTime.Now), ChangeRecord.RecordType.NewCourse, null)));
            }
          }
        }
      }
    }
  }
}
