using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public interface IPiDataManager
    {
        IEnumerable<PiData> GetAllPiData();
        bool AddPiData(DateTime date);
    }
}
