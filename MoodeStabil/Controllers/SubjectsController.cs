using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;
using MoodeStabil.Manager;
using MoodeStabilProjekt.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodeStabilProjekt.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IManageSubjects mgr;

        public SubjectsController(AndreasDatabaseContext andreasDatabaseContext)
        {
            mgr = new ManageSubjects(andreasDatabaseContext);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SubjectsDto>> GetAll()
        {
            try
            {
                return Ok(mgr.GetAll());
            }
            catch(KeyNotFoundException knfe)
            {
                return NotFound(knfe);
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SubjectsDto> GetSubject(int id)
        {
            var subject = mgr.GetById(id);
            if(subject is null)
            {
                return NotFound();
            }
            return subject.AsDto();
        }
       
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<SubjectsDto> AddItem(AddSubjectsDto subjectsDto)
        {
            Subjects subjects = new()
            {
                SubjectMeetTime = subjectsDto.SubjectMeetTime,
                SubjectName = subjectsDto.SubjectName

            };

            mgr.AddSubject(subjects);

            return CreatedAtAction(nameof(GetSubject), new { id = subjects.Id }, subjects.AsDto());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateSubject(int id, [FromBody] UpdateSubjectsDto updateSubjectsDto)
        {
            var existingSubject = mgr.GetById(id);

            if(existingSubject is null)
            {
                return NotFound();
            }
            Subjects updatedSubject = existingSubject with
            {
                SubjectName = updateSubjectsDto.SubjectName,
                SubjectMeetTime = updateSubjectsDto.SubjectMeetTime
            };

            mgr.Update(updatedSubject);

            return NoContent();
           
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult DeleteItem(int id)
        {
            var existingItem = mgr.GetById(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            mgr.DeleteItem(id);

            return NoContent();
        }

    }
}
