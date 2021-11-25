using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public class PiDataManager : IPiDataManager
    {
        AndreasDatabaseContext _database;
        public PiDataManager (AndreasDatabaseContext _newDatabase)
        {
            _database = _newDatabase;
        }
        public bool AddPiData(DateTime date)
        {
            List<Subjects> subjects = _database.Subjects.ToList<Subjects>();
            foreach (Subjects sub in subjects)
            {
                if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Monday && date.DayOfWeek == DayOfWeek.Monday)
                {
                    try
                    {
                    _database.Add(new PiData(date,sub.SubjectMeetTime,sub));
                        return true;
                    }catch(Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Tuesday && date.DayOfWeek == DayOfWeek.Tuesday)
                {
                    try
                    {
                        _database.Add(new PiData(date, sub.SubjectMeetTime, sub));
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Wednesday && date.DayOfWeek == DayOfWeek.Wednesday)
                {
                    try
                    {
                        _database.Add(new PiData(date, sub.SubjectMeetTime, sub));
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Thursday && date.DayOfWeek == DayOfWeek.Thursday)
                {
                    try
                    {
                        _database.Add(new PiData(date, sub.SubjectMeetTime, sub));
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("fejl " + ex.Message);
                        return false;
                    }
                }
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Friday && date.DayOfWeek == DayOfWeek.Friday)
                {
                    try
                    {
                        _database.Add(new PiData(date, sub.SubjectMeetTime, sub));
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

        public IEnumerable<PiData> GetAllPiData()
        {
            return _database.PiData.ToList();
        }
    }
}
