using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDo1.Models;

public class TextColorModel
{
  public int id { get; set; }
  public string text { get; set; } = "";
  public string color { get; set; } = "";
  public string backgroundColor { get; set; } = "#ffffff";
}
