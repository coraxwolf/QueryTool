using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data
{
  public class LocalDatabaseContextFactory
  {
    private string connectionString;

    public LocalDatabaseContextFactory(string connectString)
    {
      connectionString = connectString;
    }
    public EODbContext CreateDbContext()
    {
      DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;
      return new EODbContext(options);
    }
  }
}
