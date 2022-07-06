
using Application.Commands.LectureGroups;
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

            return HandleResult(lectureGroups);
        }

        [HttpGet("schedule/{id}")]
        public async Task<ActionResult<List<ScheduleForStudentDto>>> GetScheduleForGroup(int id)
        {
            var schedule = await Mediator.Send(new GetScheduleForGroup.Query { LectureGroupId = id});

            return HandleResult(schedule);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureGroupDto>> GetLectureGroupById(int id)
        {
            var lectureGroup = await Mediator.Send(new GetLectureGroupById.Query { LectureGroupId = id});

            return HandleResult(lectureGroup); ;
        }


        [HttpGet("getLectureGroupsForSeason/{facultyId}")]
        public async Task<ActionResult<LectureGroupDto>> GetLectureGroupsForSeason(int facultyId)
        {
            var lectureGroup = await Mediator.Send(new GetLectureGroupsForSeason.Query { FacultyId = facultyId });

            return HandleResult(lectureGroup); 
        }



        [HttpPost]
        public async Task<IActionResult> AddLectureGroup(RequestLectureGroupDto lectureGroupDto)
        {
            return HandleResult(await Mediator.Send(new AddLectureGroup.Command { LectureGroup = lectureGroupDto }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLectureGroup(RequestLectureGroupDto lectureGroupDto, int id)
        {

            return HandleResult(await Mediator.Send(new EditLectureGroup.Command { LectureGroupDto = lectureGroupDto, LectureGroupId = id }));
        }

        [HttpDelete("{lectureGroupId}")]
        public async Task<IActionResult> DeleteLectureGroup(int lectureGroupId)
        {
            return HandleResult(await Mediator.Send(new DeleteLectureGroup.Command { LectureGroupId = lectureGroupId }));
        }

    }
}

