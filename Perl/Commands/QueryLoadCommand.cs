using CsvHelper;
using CsvHelper.Configuration;
using EO_Tool.Models;
using Microsoft.Win32;
using Perl.Models;
using Perl.Stores;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                        bool newFac = course.FacultyAssigned?.Exists(f => f.FacultyNo == record.ID)?? false;
                                        if (newFac)
                                        {
                                            course.AddFacultyAssignment(new Faculty(record.ID, record.Name));
                                        }
                                    }

                                }

                            } else
                            {
                                Course course = new Course(
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
                                    Faculty faculty = new Faculty(record.ID, record.Name);
                                    course.AddFacultyAssignment(faculty);
                                }
                                QueryStore.AddCourse(course);
                            }

                        }
                    }
                }
            }
        }

        private string loadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Query CSV File";
            ofd.Filter = "Comma Separated Values (*.csv)|*.csv";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            bool? isOk = ofd.ShowDialog();

            if (isOk == true)
            {
                return ofd.FileName;
            } else
            {
                return String.Empty;
            }
        }
    }
}
