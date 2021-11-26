using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt.Dtos
{
    public record AddSubjectsDto
    {
        [Required]
        [Range(1,1000)]
        public string SubjectName { get; set; }
        [Required]
        public DateTime? SubjectMeetTime { get; set; }
    }
}
