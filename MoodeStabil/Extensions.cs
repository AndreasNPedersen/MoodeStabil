using ModelLib;
using MoodeStabilProjekt.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt
{
    public static class Extensions
    {
        public static SubjectsDto AsDto(this Subjects aSubject)
        {
            return new SubjectsDto
            {
                Id = aSubject.Id,
                SubjectName = aSubject.SubjectName,
                SubjectMeetTime = aSubject.SubjectMeetTime,
                

            };
        }
    }
}
