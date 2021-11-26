using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt.Dtos
{
    public record SubjectsDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime? SubjectMeetTime { get; set; }

        public virtual ICollection<PiData> PiData { get; set; }
    }
}
