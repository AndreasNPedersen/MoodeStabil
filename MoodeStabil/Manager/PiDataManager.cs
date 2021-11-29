using Microsoft.EntityFrameworkCore;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public class PiDataManager : IPiDataManager
    {
       private readonly AndreasDatabaseContext _database;
        public PiDataManager (AndreasDatabaseContext _newDatabase)
        {
            _database = _newDatabase;
        }
        public bool AddPiData(DateTime date)
        {
            List<Subjects> subjects = _database.Subjects.ToList<Subjects>();
            foreach (Subjects sub in subjects)
            {
                if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Monday && date.DayOfWeek == DayOfWeek.Monday
                    && sub.SubjectMeetTime.Value.Hour <= date.Hour && date.Hour <= sub.SubjectMeetTime.Value.Hour+1)
                {
                    try
                    {
                        PiData data = new PiData() {Date=date,DateFromSubject=sub.SubjectMeetTime,SubjectId=sub.Id,Subject=sub };
                        _database.Add(data);
                        _database.SaveChanges();
                        return true;
                    }catch(Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Tuesday && date.DayOfWeek == DayOfWeek.Tuesday
                    && sub.SubjectMeetTime <= date && sub.SubjectMeetTime.Value.Hour <= sub.SubjectMeetTime.Value.Hour + 1)
                {
                    try
                    {
                        PiData data = new PiData() { Date = date, DateFromSubject = sub.SubjectMeetTime, SubjectId = sub.Id, Subject = sub };
                        _database.Add(data);
                        _database.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Wednesday && date.DayOfWeek == DayOfWeek.Wednesday
                    && sub.SubjectMeetTime <= date && sub.SubjectMeetTime.Value.Hour <= sub.SubjectMeetTime.Value.Hour + 1)
                {
                    try
                    {
                        PiData data = new PiData() { Date = date, DateFromSubject = sub.SubjectMeetTime, SubjectId = sub.Id, Subject = sub };
                        _database.Add(data);
                        _database.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Thursday && date.DayOfWeek == DayOfWeek.Thursday
                    && sub.SubjectMeetTime <= date && sub.SubjectMeetTime.Value.Hour <= sub.SubjectMeetTime.Value.Hour + 1)
                {
                    try
                    {
                        PiData data = new PiData() { Date = date, DateFromSubject = sub.SubjectMeetTime, SubjectId = sub.Id, Subject = sub };
                        _database.Add(data);
                        _database.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Friday && date.DayOfWeek == DayOfWeek.Friday
                    && sub.SubjectMeetTime <= date && sub.SubjectMeetTime.Value.Hour <= sub.SubjectMeetTime.Value.Hour + 1)
                {
                    try
                    {
                        PiData data = new PiData() { Date = date, DateFromSubject = sub.SubjectMeetTime, SubjectId = sub.Id, Subject = sub };
                        _database.Add(data);
                        _database.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        public List<PiData> GetAllPiData()
        {
            List<Subjects> subjects = _database.Subjects.ToList();
            List<PiData> piDatas = _database.PiData.ToList();

            
            return piDatas;
        }

        public List<PiData> SearchPiDatas()
        {
            DateTime time = DateTime.Now;
            List<PiData> piDatas = GetAllPiData();

            IEnumerable<PiData> result = piDatas.Where(c => c.Date.Value.Day == time.Day || c.Date.Value.Day == time.Day - 1 ||
          c.Date.Value.Day == time.Day - 2 || c.Date.Value.Day == time.Day - 3 || c.Date.Value.Day == time.Day - 4 ||
          c.Date.Value.Day == time.Day - 5
                );
            return result.ToList();
        }
    }
}
