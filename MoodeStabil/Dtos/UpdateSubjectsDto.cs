using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt.Dtos
{
    public record UpdateSubjectsDto
    {
        
        public DateTime? SubjectMeetTime { get; set; }
        
        public string SubjectName { get; set; }
    }
}
