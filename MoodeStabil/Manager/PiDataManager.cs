using Microsoft.EntityFrameworkCore;
using ModelLib;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public class PiDataManager : IPiDataManager
    {
        private readonly AndreasDatabaseContext _database;
        public PiDataManager(AndreasDatabaseContext _newDatabase)
        {
            _database = _newDatabase;
        }
        public bool AddPiData(DateTime date)
        {
            date = date.AddHours(1);
            List<Subjects> subjects = _database.Subjects.ToList<Subjects>();
            foreach (Subjects sub in subjects)
            {
                if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Monday && date.DayOfWeek == DayOfWeek.Monday
                    && sub.SubjectMeetTime.Value.Hour == date.Hour && sub.SubjectMeetTime.Value.Minute <= date.Minute)
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
                else if (sub.SubjectMeetTime.Value.Date.DayOfWeek == DayOfWeek.Tuesday && date.DayOfWeek == DayOfWeek.Tuesday
                    && sub.SubjectMeetTime.Value.Hour == date.Hour && sub.SubjectMeetTime.Value.Minute <= date.Minute)
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
                    && sub.SubjectMeetTime.Value.Hour == date.Hour && sub.SubjectMeetTime.Value.Minute <= date.Minute)
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
                   && sub.SubjectMeetTime.Value.Hour == date.Hour && sub.SubjectMeetTime.Value.Minute <= date.Minute)
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
                    && sub.SubjectMeetTime.Value.Hour == date.Hour && sub.SubjectMeetTime.Value.Minute <= date.Minute)
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

        public bool RequestSendingEmail(DateTime date1, DateTime data2, string toEmail)
        {
            List<PiData> piDatas = GetAllPiData();
            IEnumerable<PiData> result = piDatas.Where(c => c.Date.Value >= date1 && c.Date.Value <= data2
                );
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/sandboxd77fb32c189946a18b4bc682a0c877a7.mailgun.org");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "cdae16978eebf628d682c6e05da75c75-7b8c9ba8-896c2f54");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxd77fb32c189946a18b4bc682a0c877a7", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandboxd77fb32c189946a18b4bc682a0c877a7>");
            request.AddParameter("to", toEmail);
            request.AddParameter("subject", "Repport af mødetider");
            request.AddParameter("text", result.ToString());
            request.Method = Method.POST;
            client.Execute(request);
            return result.Count() > 0;
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

            public List<PiData> SortPiData(DateTime date1, DateTime data2)
            {
                List<PiData> piDatas = GetAllPiData();
                IEnumerable<PiData> result = piDatas.Where(c => c.Date.Value >= date1 && c.Date.Value <= data2
                    );
                return result.ToList();
            }
        }
    }
