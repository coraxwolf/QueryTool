using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data.DTOs
{
  [PrimaryKey(nameof(SisId), nameof(FacultyNo))]
  public class FacultyAssignmentsDTO
  {
    [Key]
    public string SisId { get; set; }
    [Key]
    public string FacultyNo { get; set; }
  }
}
