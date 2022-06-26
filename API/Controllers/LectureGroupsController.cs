
using Application.DTOs.LectureDtos;
using Application.DTOs.LectureGroupDtos;
using Application.Queries.LectureGroups;
using Application.Queries.Lectures;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LectureGroupsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LectureGroupDto>>> GetAllLectureGroups()
        {
            var lectureGroups = await Mediator.Send(new GetAllLectureGroups.Query());

            return lectureGroups;
        }

        [HttpGet("schedule/{id}")]
        public async Task<ActionResult<List<ScheduleForStudentDto>>> GetScheduleForGroup(int id)
        {
            var schedule = await Mediator.Send(new GetScheduleForGroup.Query { LectureGroupId = id});

            return schedule;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureGroupDto>> GetLectureGroupById(int id)
        {
            var lectureGroup = await Mediator.Send(new GetLectureGroupById.Query { LectureGroupId = id});

            return lectureGroup;
        }
    }
}

