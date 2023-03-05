using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WorkDo1.Data;

namespace WorkDo1.Models;

public class WorkModel
{
  public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
  public string workName { get; set; } = "";
  public TextColorModel category { get; set; } = new TextColorModel();
  public TextColorModel priority { get; set; } = new TextColorModel();
  public string startTime { get; set; } = "";
  public string endTime { get; set; } = "";

  /// <summary>
  /// 1. todo, 2. done, 3. doing, 4.pending, 5. cancel
  /// </summary>
  /// <returns></returns>
  public TextColorModel status { get; set; } = new TextColorModel();
  public string details { get; set; } = "";
  public string result { get; set; } = "";
}
