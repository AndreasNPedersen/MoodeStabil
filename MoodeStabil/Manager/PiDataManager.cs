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
                if (sub.SubjectMeetTime)
            }
            _database.Add(new PiData(date,));
        }

        public IEnumerable<PiData> GetAllPiData()
        {
            throw new NotImplementedException();
        }
    }
}
