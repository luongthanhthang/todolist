using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDo1.Models;

public class WorkOfDayModel
{
  public string id { get; set; } = "";
  public string dateWork { get; set; } = "";
  public bool isCheckIn { get; set; } = false;
  public bool isCheckOut { get; set; } = false;
  public long dateCheckIn { get; set; } = 0;
  public long dateCheckOut { get; set; } = 0;
  public bool isConfirm { get; set; } = false;
  public List<WorkModel> workList { get; set; } = new List<WorkModel>();
  public bool isActive { get; set; } = false;
}
