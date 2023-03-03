using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkDo1.Models;
using WorkDo1.Helpers;
using MongoDB.Driver;
namespace WorkDo1.Data;

public class WorkTodoListData
{
    public static UserModel userData =
        new()
        {
            id = "1",
            avatar = "https://avatars.dicebear.com/api/adventurer-neutral/231441AAFA.svg",
            name = "Lương Thanh Thắng",
            team = "DOCORP / CONANDO / Team Dev",
            workOfDayList = new List<WorkOfDayModel>()
            {
                new()
                {
                    id = "Thang" + "-" + DateTime.Now.Ticks,
                    dateWork = "25-02-2023",
                    isCheckIn = true,
                    dateCheckIn = 638129130497030602,
                    workList = new List<WorkModel>()
                    {
                        new()
                        {
                            id = "638125882439019711",
                            workName = "Test",
                            category = StatusTodoListData
                                .findAllCategory()
                                .First(category => category.id == 2),
                            priority = StatusTodoListData
                                .findAllPriority()
                                .First(priorty => priorty.id == 1),
                            details = "test detail",
                            startTime = "18:00",
                            endTime = "19:00",
                            result = "test result",
                            status = StatusTodoListData
                                .findAllStatusWork()
                                .First(status => status.id == 1)
                        },
                        new()
                        {
                            id = "638125899095715888",
                            workName = "Test2",
                            category = StatusTodoListData
                                .findAllCategory()
                                .First(category => category.id == 1),
                            priority = StatusTodoListData
                                .findAllPriority()
                                .First(priorty => priorty.id == 2),
                            details = "test detail2",
                            startTime = "13:00",
                            endTime = "15:00",
                            status = StatusTodoListData
                                .findAllStatusWork()
                                .First(status => status.id == 3)
                        },
                        new()
                        {
                            id = "638125901709548520",
                            workName = "Test3",
                            category = StatusTodoListData
                                .findAllCategory()
                                .First(category => category.id == 1),
                            priority = StatusTodoListData
                                .findAllPriority()
                                .First(priorty => priorty.id == 2),
                            details = "test detail3",
                            startTime = "15:00",
                            endTime = "17:30",
                            result = "test result3",
                            status = StatusTodoListData
                                .findAllStatusWork()
                                .First(status => status.id == 3)
                        }
                    }
                }
            }
        };
    public static List<WorkOfDayModel> WorkOfDayList = userData.workOfDayList;

    // xuất công việc của ngày tổng
    public static WorkOfDayModel findWorkByDay(string workDate)
    {
        WorkOfDayModel workOfDayModel = new WorkOfDayModel();
        WorkOfDayList
            .Where(workOfDay => workOfDay.dateWork == workDate)
            .ToList()
            .ForEach(
                (work) =>
                {
                    workOfDayModel = work;
                }
            );
        return workOfDayModel;
    }

    public static List<WorkModel> findAllWorkOfDay(string workDate)
    {
        List<WorkModel> workList = WorkTodoListData.findWorkByDay(workDate).workList;
        return workList;
    }

    public static List<WorkModel> findAllWorkOfDayFilter(List<WorkModel> workList)
    {
        // lọc những công việc bỏ trống tiêu đề
        workList.RemoveAll(work => work.workName == "");
        return sortListByTime(workList);
    }

    public static List<WorkModel> sortListByTime(List<WorkModel> workList)
    {
        return workList
            .OrderBy(
                work =>
                    TimeArray
                        .createTimeArray("7:00", "23:00", 10)
                        .FindIndex(item => work.startTime == item)
            )
            .ToList();
    }

    public static void createWorkOfDay(WorkModel work, string workDate)
    {
        WorkOfDayModel workOfDayModel = WorkTodoListData.findWorkByDay(workDate);
        workOfDayModel.workList.Add(work);
    }

    public static WorkModel findWorkById(string id, string workDate)
    {
        WorkModel workTemp = new();
        WorkTodoListData
            .findWorkByDay(workDate)
            .workList.ForEach(
                (work) =>
                {
                    if (work.id == id)
                    {
                        workTemp = work;
                    }
                }
            );
        return workTemp;
    }

    public static void updateWork(string workDate, WorkModel workUpdate)
    {
        List<WorkModel> workModelList = WorkTodoListData.findAllWorkOfDay(workDate);
        int Index = workModelList.FindIndex(i => i.id == workUpdate.id);
        WorkTodoListData.findAllWorkOfDay(workDate)[Index] = workUpdate;
    }

    public static void deleteWorkById(string workDate, string id)
    {
        WorkTodoListData.findAllWorkOfDay(workDate).RemoveAll(item => item.id == id);
    }

    public static int countDoneWork(string workDate)
    {
        List<WorkModel> workList = WorkTodoListData.findAllWorkOfDay(workDate);
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
