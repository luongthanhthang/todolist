using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDo1.Helpers;

public class TimeArray
{
  public static List<string> createTimeArray(string start, string finish, int step)
  {
    int startHour = Convert.ToInt32(start.Split(':')[0]);
    int startMin = Convert.ToInt32(start.Split(':')[1]);
    int endHour = Convert.ToInt32(finish.Split(':')[0]);
    int endMin = Convert.ToInt32(finish.Split(':')[1]);

    if (startHour > endHour) return null;
    if (startHour == endHour && startMin > endMin) return null;
    int[] currentTime = { startHour, startMin };

    List<string> timeArrayResult = new List<string>();

    while (currentTime[0] < endHour || ((currentTime[0] == endHour && currentTime[1] <= endMin)))
    {
      timeArrayResult.Add((currentTime[0] < 10 ? "0" + currentTime[0] : currentTime[0]) + ":" + (currentTime[1] < 10 ? "0" + currentTime[1] : currentTime[1]));
      if (currentTime[1] + step >= 60)
      {
        currentTime[0] += 1;
        currentTime[1] = currentTime[1] + step - 60;
      }
      else
      {
        currentTime[1] = currentTime[1] + step;
      }
    }
    return timeArrayResult;
  }

  public static string getDateOfWeek(DateTime current)
  {
    int day = Convert.ToInt32(current.DayOfWeek);
    return day == 0 ? "CN" : "T" + (day + 1);
  }
}
