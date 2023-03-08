using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WorkDo1.Helpers;
using WorkDo1.Models;

namespace WorkDo1.Data;

public class WorkOfDayData
{
    private IMongoCollection<WorkOfDayModel> _workOfDayTable = null;

     public WorkOfDayData() {
    ConnectMongoDB<WorkOfDayModel> connectData = new();
    _workOfDayTable = connectData.Connect("todolist", "WorkOfDay");
  }
    public void deleteById(string id) {
      _workOfDayTable.DeleteOne(item => item.id == id);
    }

    public WorkOfDayModel findById(string id) {
      return _workOfDayTable.Find(item => item.id == id).FirstOrDefault();
    }

    public List<WorkOfDayModel>findAll() {
      return _workOfDayTable.Find(i => true).ToList();
    }

    public void saveOfUpdate(WorkOfDayModel workOfDayModel) {
      var work = _workOfDayTable.Find(item => item.id == workOfDayModel.id).FirstOrDefault();
      if(work == null) 
      {
        _workOfDayTable.InsertOne(workOfDayModel);
      }
      else
      {
        _workOfDayTable.ReplaceOne(item => item.id == workOfDayModel.id, workOfDayModel);
      }
    }

    public List<WorkOfDayModel> getWorkOfDayHistoryList(List<WorkOfDayModel> workOfDayList) {
      return workOfDayList.OrderByDescending(workOfDay => (DateTime.Parse(workOfDay.dateWork)).Ticks).Take(5).ToList();
    }

     public List<WorkOfDayModel> sortWorkOfDayList(List<WorkOfDayModel> workOfDayList) {
      return workOfDayList.OrderBy(workOfDay => (DateTime.Parse(workOfDay.dateWork)).Ticks).ToList();
    }

    //----------------------------------------------------------------
    // xuất công việc của ngày tổng
    // List<WorkModel> = findWorkOfDay().workList
    public WorkOfDayModel findWorkOfDay(List<WorkOfDayModel> workOfDayList, string date) {
      // return workOfDayList.FirstOrDefault(workOfDay => workOfDay.dateWork == date);
      WorkOfDayModel workOfDayModel = new WorkOfDayModel();
      workOfDayModel.dateWork = date;
      workOfDayList
          .Where(workOfDay => workOfDay.dateWork == date)
          .ToList()
          .ForEach(
              (work) =>
              {
                workOfDayModel = work;
              }
          );
      return workOfDayModel;
    }
    public List<WorkModel> findAllWorkOfDayFilter(List<WorkModel> workList) {
        // lọc những công việc bỏ trống tiêu đề
        workList.RemoveAll(work => work.workName == "");
        return sortListByTime(workList);
    }
    public List<WorkModel> sortListByTime(List<WorkModel> workList) {
        return workList
            .OrderBy(
                work =>
                    TimeArray
                    .createTimeArray("7:00", "23:00", 10)
                    .FindIndex(item => work.startTime == item)
            )
            .ToList();
    }
    public void createWork(WorkModel work, WorkOfDayModel workOfDay, string date)
      {
          workOfDay.workList.Add(work);
          saveOfUpdate(workOfDay);
      }

    public void updateWork(WorkModel workUpdate, WorkOfDayModel workOfDay, string date) {
        int index = workOfDay.workList.FindIndex(i => i.id == workUpdate.id);
        workOfDay.workList[index] = workUpdate;
        saveOfUpdate(workOfDay);
    }
    public void deleteWorkById(WorkOfDayModel workOfDay, string date, string id) {
        workOfDay.workList.RemoveAll(item => item.id == id);
        saveOfUpdate(workOfDay);
    }
    public int countDoneWork(WorkOfDayModel workOfDay, string date) {
      List<WorkModel> workList = workOfDay.workList;
      int result = 0;
      workList.ForEach(
          (work) =>
          {
              if (work.status.id == 2)
              {
                  result++;
              }
          }
      );
      return result;
    }
}
