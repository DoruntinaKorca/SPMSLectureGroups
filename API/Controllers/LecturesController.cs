
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

            return lectures;

        }

        [HttpGet("schedule/{id}")]
        public async Task<ActionResult<List<ScheduleForAcademicStaffDto>>> GetScheduleForAcademicStaff(Guid id)
        {
            var schedule = await Mediator.Send(new GetScheduleForAcademicStaff.Query { AcademicStaffId = id });

            return schedule;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureDto>> GetLectureById(int id)
        {
            var lecture = await Mediator.Send(new GetLectureById.Query { LectureId = id});

            return lecture;

        }
    }
}

