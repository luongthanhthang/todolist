using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkDo1.Models;

namespace WorkDo1.Data;

public class StatusTodoListData
{
  public static List<TextColorModel> findAllPriority()
  {
    return new List<TextColorModel>() {
        new (){
          id = 1,
          text = "Bình thường",
          color = "#48c78e"
        },
         new (){
          id = 2,
          text = "Quan trọng",
          color = "#e5bf54"
        },
         new (){
          id = 3,
          text = "Rất quan trọng",
          color = "#f03a5f"
        }
      };
  }

   public static List<TextColorModel> findAllCategory()
  {
    return new List<TextColorModel>() {
        new (){
          id = 1,
          text = "Kế hoạch",
          color = "black"
        },
         new (){
          id = 2,
          text = "Đột xuất",
          color = "#355caa"
        },
         new (){
          id = 3,
          text = "Cấp trên giao",
          color = "#f03a5f"
        }
      };
  }

   public static List<TextColorModel> findAllStatusWork()
  {
    return new List<TextColorModel>() {
        new (){
          id = 1,
          text = "Todo",
          color = "black",
          backgroundColor = "white"
        },
         new (){
          id = 2,
          text = "Done",
          color = "white",
          backgroundColor = "#3ec487"
        },
         new (){
          id = 3,
          text = "Doing",
          color = "white",
          backgroundColor = "#3e56c4"
        },
         new (){
          id = 4,
          text = "Pending",
          color = "#864225",
          backgroundColor = "#ffdc7d"
        },
         new (){
          id = 5,
          text = "Cancel",
          color = "white",
          backgroundColor = "#2f2f2f"
        }
      };
  }
}
