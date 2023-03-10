using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkDo1.Models;

public class UserModel
{
    public string id { get; set; } = "";
    public string name { get; set; } = "";
    public string avatar { get; set;} = "";
    public string team { get; set; } = "";
    public List<WorkOfDayModel> workOfDayList { get; set; } = new List<WorkOfDayModel>();
}
