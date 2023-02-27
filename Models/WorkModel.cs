using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkDo1.Data;

namespace WorkDo1.Models;

public class WorkModel
{
  public long id { get; set; } = 0;
  public string workName { get; set; } = "";
  public TextColorModel category { get; set; } = new TextColorModel();
  public TextColorModel priority { get; set; } = new TextColorModel();
  public string startTime { get; set; } = "";
  public string endTime { get; set; } = "";
  public TextColorModel status { get; set; } = new TextColorModel();
  public string details { get; set; } = "";
  public string result { get; set; } = "";
}
