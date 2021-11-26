using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public interface IManageSubjects
    {
        IEnumerable<Subjects> GetAll();
        void Update(Subjects aSubject);
        Subjects GetById(int id);
        void AddSubject(Subjects aSubjects);
        void ReplaceList();
    }
}
