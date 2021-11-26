using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public class ManageSubjects : IManageSubjects
    {
        private static List<Subjects> MockSubjects = new()
        {
   
            new Subjects(1,"Programming",DateTime.Now),
            new Subjects(2,"Systemudvikling", new DateTime(2021,2,3,9,10,10)),
            new Subjects(3,"Technology", new DateTime(2021,2,4,9,10,10)),


        };
    
        public void AddSubject(Subjects aSubjects)
        {
            MockSubjects.Add(aSubjects);
        }

        public IEnumerable<Subjects> GetAll()
        {
            return MockSubjects;
        }

        public Subjects GetById(int id)
        {
             if(MockSubjects.Exists(i=>i.Id == id))
            {
                Subjects subjects = MockSubjects.Find(i => i.Id == id);
                return subjects;
            }
            throw new KeyNotFoundException();
        }

        public void Update(Subjects aSubject)
        {
            var index = MockSubjects.FindIndex(existingItem => existingItem.Id == aSubject.Id);
            MockSubjects[index] = aSubject;
        }

        // Mainly for testing
        public void ReplaceList()
        {
            MockSubjects = new()
            {

                new Subjects(1, "Programming", DateTime.Now),
                new Subjects(2, "Systemudvikling", new DateTime(2021, 2, 3, 9, 10, 10)),
                new Subjects(3, "Technology", new DateTime(2021, 2, 4, 9, 10, 10)),


            };
        }
    }
}
