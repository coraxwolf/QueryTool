using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data
{
  public class LocalDatabaseDesignTimeContextFactory : IDesignTimeDbContextFactory<EODbContext>
  {
    public EODbContext CreateDbContext(string[] args)
    {
      DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=EOTool.db").Options;
      return new EODbContext(options);
    }
  }
}
