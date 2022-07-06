
using Application.Commands.Lectures;
using Application.DTOs.LectureDtos;
using Application.Queries.Lectures;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LecturesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LectureDto>>> GetAllLectures()
        {
            var lectures = await Mediator.Send(new GetAllLectures.Query());

            return HandleResult(lectures);

        }

        [HttpGet("schedule/{id}")]
        public async Task<ActionResult<List<ScheduleForAcademicStaffDto>>> GetScheduleForAcademicStaff(Guid id)
        {
            var schedule = await Mediator.Send(new GetScheduleForAcademicStaff.Query { AcademicStaffId = id });

            return HandleResult(schedule);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureDto>> GetLectureById(int id)
        {
            var lecture = await Mediator.Send(new GetLectureById.Query { LectureId = id});

            return HandleResult(lecture);

        }

        [HttpPost("{courseId}/{academicStaffId}")]
        public async Task<IActionResult> AddLecture(RequestLectureDto lectureDto, int courseId, Guid academicStaffId)
        {
     
            return HandleResult(await Mediator.Send(new AddLecture.Command { LectureDto = lectureDto, CourseId = courseId, AcademicStaffId = academicStaffId }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLecture(RequestLectureDto lectureDto, int id)
        {

            return HandleResult(await Mediator.Send(new EditLecture.Command { LectureDto = lectureDto, LectureId = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecture(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteLecture.Command { LectureId = id }));
        }
    }
}

