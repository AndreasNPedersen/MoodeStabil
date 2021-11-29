using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt.Dtos
{
    public record AddSubjectsDto
    {
        
        public string SubjectName { get; set; }
        
        public DateTime? SubjectMeetTime { get; set; }
    }
}
