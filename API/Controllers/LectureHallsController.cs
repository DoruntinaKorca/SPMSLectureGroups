
using Application.DTOs.LectureHallDtos;
using Application.Queries.LectureHalls;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LectureHallsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LectureHallDto>>> GetAllLectureHall()
        {
            var lectureHalls = await Mediator.Send(new GetAllLectureHalls.Query());

            return lectureHalls;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureHallDto>> GetLectureHallById(int id)
        {
            var lectureHall = await Mediator.Send(new GetLectureHallById.Query { LectureHallId = id});

            return lectureHall;
        }

    }
}

