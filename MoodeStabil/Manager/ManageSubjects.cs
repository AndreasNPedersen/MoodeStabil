using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public class ManageSubjects : IManageSubjects
    {
        private readonly AndreasDatabaseContext _database;
        public ManageSubjects(AndreasDatabaseContext _newDatabase)
        {
            _database = _newDatabase;
        }



        public void AddSubject(Subjects aSubjects)
        {
            aSubjects.Id = 0;
            _database.Subjects.Add(aSubjects);
            _database.SaveChanges();
        }

        public IEnumerable<Subjects> GetAll()
        {
            return _database.Subjects.ToList();
        }

        public Subjects GetById(int id)
        {
             if(_database.Subjects.ToList().Exists(i=>i.Id == id))
            {
                Subjects subjects = _database.Subjects.Find(id);
                return subjects;
            }
            throw new KeyNotFoundException();
        }

        public void Update(Subjects aSubject)
        {
            Subjects i = GetById(aSubject.Id);
            _database.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            _database.Subjects.Update(aSubject);
            _database.SaveChanges();
        }
        public void DeleteItem(int id)
        {
            var item = _database.Subjects.ToList().Find(existingItem => existingItem.Id == id);
            _database.Subjects.Remove(item);
            _database.SaveChanges();

        }
        // Mainly for testing
        public void ReplaceList()
        {
          
        }
    }
}
