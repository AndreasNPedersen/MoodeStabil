using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabil.Manager
{
    public interface IPiDataManager
    {
        List<PiData> GetAllPiData();
        bool AddPiData(DateTime date);
        List<PiData> SearchPiDatas();
        List<PiData> SortPiData(DateTime date1, DateTime data2);
        bool RequestSendingEmail(DateTime date1, DateTime data2, string toEmail);
    }
}
