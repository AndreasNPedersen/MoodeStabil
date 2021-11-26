using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt.Dtos
{
    public record UpdateSubjectsDto
    {
        [Required]
        public DateTime? SubjectMeetTime { get; set; }
    }
}
