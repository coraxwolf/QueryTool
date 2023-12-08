using Emerald.Data;
using Emerald.Data.DTOs;
using Emerald.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Services.DTOProviders
{
  public class DBCourseProvider : ICourseProvider
  {
    private LocalDatabaseContextFactory contextFactory;

    public DBCourseProvider(LocalDatabaseContextFactory factory)
    {
      contextFactory = factory;
    }

    private static Course ToCourse(CourseDTO record)
    {
      return new Course(
        record.SisId,
        record.Term,
        record.ClassNo,
        record.Subject,
        record.Catalog,
        record.Title,
        record.Mode,
        record.Campus,
        record.Location,
        record.Status,
        record.Enrolled,
        record.Cap,
        record.StartDate,
        record.EndDate,
        record.Notes,
        record.CanvasName,
        record.CanvasCode,
        record.CanvasState
        );
    }

    public async Task<IEnumerable<Course>> GetAllCourses()
    {
      using (EODbContext context = contextFactory.CreateDbContext())
      {
        IEnumerable<CourseDTO> courseRecords = await context.CourseRecords.ToListAsync();
        return courseRecords.Select(ToCourse);
      }
    }

    public async Task<Course> GetCourseById(string id)
    {
      using (EODbContext context = contextFactory.CreateDbContext())
      {
        CourseDTO courseRecord = await context.CourseRecords.FirstOrDefaultAsync((c) => c.SisId == id);
        return new Course(
        courseRecord.SisId,
        courseRecord.Term,
        courseRecord.ClassNo,
        courseRecord.Subject,
        courseRecord.Catalog,
        courseRecord.Title,
        courseRecord.Mode,
        courseRecord.Campus,
        courseRecord.Location,
        courseRecord.Status,
        courseRecord.Enrolled,
        courseRecord.Cap,
        courseRecord.StartDate,
        courseRecord.EndDate,
        courseRecord.Notes,
        courseRecord.CanvasName,
        courseRecord.CanvasCode,
        courseRecord.CanvasState
          ) ;
      }
    }

    public async Task<IEnumerable<Course>> GetCoursesByFaculty(string faculty)
    {
      {
      using (EODbContext context = contextFactory.CreateDbContext())
      {
        IEnumerable<CourseDTO> courseRecords = await context.CourseRecords.ToListAsync();
        return courseRecords.Select(ToCourse);
      }
      }
    }

    public async Task<IEnumerable<Course>> GetCoursesByMode(string mode)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Course>> GetCoursesByStart(DateOnly startDate)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Course>> GetCoursesBySubject(string subject)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Course>> GetCoursesByTerm(string term)
    {
      throw new NotImplementedException();
    }
  }
}
