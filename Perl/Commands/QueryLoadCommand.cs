using CsvHelper;
using CsvHelper.Configuration;
using EO_Tool.Models;
using Microsoft.Win32;
using Perl.Models;
using Perl.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Perl.Commands
{
  public class QueryLoadCommand : CommandBase
  {
    private readonly QueryStore QueryStore;
    public QueryLoadCommand(QueryStore store)
    {
      QueryStore = store;
    }

    public override void Execute(object? parameter)
    {
      string queryFile = loadFile();
      if (queryFile != String.Empty)
      {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { MissingFieldFound = null, IgnoreBlankLines = true };
        using var FileReader = new StreamReader(queryFile);
        using var csv = new CsvReader(FileReader, config);
        {
          csv.Context.RegisterClassMap<QueryRowClassMap>();
          csv.Read();
          csv.ReadHeader();
          while (csv.Read())
          {
            QueryRow? record = csv.GetRecord<QueryRow>();
            if (record != null)
            {
              string id = record.Term + "-" + record.ClassNbr + "-" + record.Subject + "-" + record.Catalog;
              bool hasCourse = QueryStore.ContainsCourse(id);
              if (hasCourse)
              {
                Course? course = QueryStore.GetCourse(id);
                if (course != null)
                {
                  // Check if Faculty Record is already assigned
                  if (
                      (record.ID != String.Empty || record.ID != null) &&
                      (record.Name != String.Empty || record.Name != null)
                      )
                  {
                    bool newFac = !(course.FacultyAssigned?.Exists(f => f.FacultyNo == record.ID) ?? false);
                    if (newFac)
                    {
                      // Check if Faculty Record already Created for this Import
                      if (QueryStore.ContainsFaculty(record.ID))
                      {
                        Faculty? faculty = QueryStore.GetFaculty(record.ID);
                        if (faculty != null)
                        {
                          course.AddFacultyAssignment(faculty);
                        }
                        else
                        {
                          course.AddFacultyAssignment(new Faculty(record.ID, record.Name));
                        }
                      }
                      else
                      {
                        Faculty faculty = new Faculty(record.ID, record.Name);
                        QueryStore.AddFaculty(faculty);
                        course.AddFacultyAssignment(faculty);
                      }
                    }
                  }

                }

              }
              else
              {
                Course course = new(
                        id,
                        record.Term,
                        record.ClassNbr,
                        record.Session,
                        record.Subject,
                        record.Catalog,
                        record.Descr,
                        record.Mode,
                        record.ClassStat == "A" ? "Active" : record.ClassStat == "X" ? "Canceled" : record.ClassStat == "S" ? "Stopped" : "Unknown",
                        record.StartDate,
                        record.EndDate,
                        Int32.Parse(record.TotEnrl),
                        Int32.Parse(record.Cap),
                        null, null, null);
                // Capture Faculty
                if (
                    (record.ID != String.Empty || record.ID != null) &&
                    (record.Name != String.Empty || record.Name != null)
                    )
                {
                  // Check if Faculty Record already created for this query
                  if (QueryStore.ContainsFaculty(record.ID))
                  {
                    Faculty? faculty = QueryStore.GetFaculty(record.ID);
                    if (faculty != null)
                    {
                      course.AddFacultyAssignment(faculty);
                    }
                    else
                    {
                      faculty = new Faculty(record.ID, record.Name);
                      course.AddFacultyAssignment(faculty);
                    }
                  }
                  else
                  {
                    Faculty faculty = new(record.ID, record.Name);
                    QueryStore.AddFaculty(faculty);
                    course.AddFacultyAssignment(faculty);
                  }
                }
                QueryStore.AddCourse(course);
              }

            }
          }
        }
        Debug.Print(QueryStore.ToString());
        MessageBox.Show("Completed", "Finished", MessageBoxButton.OK, MessageBoxImage.Information);
      }
    }

    private static string loadFile()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Title = "Select Query CSV File";
      ofd.Filter = "Comma Separated Values (*.csv)|*.csv";
      ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

      bool? isOk = ofd.ShowDialog();

      if (isOk == true)
      {
        return ofd.FileName;
      }
      else
      {
        return String.Empty;
      }
    }
  }
}
