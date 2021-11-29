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
            
            //var ListpiDatas = from b in piDatas
            //                  from c in subjects
            //                  where b.SubjectId == c.Id
            //                  select b.Subject = c;
            
            
            return piDatas;
        }
    }
}
