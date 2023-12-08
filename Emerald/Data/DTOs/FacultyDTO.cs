﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.Data.DTOs
{
  public class FacultyDTO
  {
    [Key]
    public string FacultyNo { get; set; }
    public string Name { get; set; }
    public string? CanvasName { get; set; }
    public Int32? CanvasCode { get; set; }
    public string? Email { get; set; }
  }
}
