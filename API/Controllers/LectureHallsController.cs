
using Application.Commands.LectureHalls;
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

            return HandleResult(lectureHalls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureHallDto>> GetLectureHallById(int id)
        {
            var lectureHall = await Mediator.Send(new GetLectureHallById.Query { LectureHallId = id});

            return HandleResult(lectureHall);
        }


        [HttpPost]
        public async Task<IActionResult> AddLectureHall(RequestLectureHallDto lectureHallDto)
        {
          return HandleResult(await Mediator.Send(new AddLectureHall.Command { LectureHallDto = lectureHallDto }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLectureHall(RequestLectureHallDto lectureHallDto, int id)
        {

          return HandleResult(await Mediator.Send(new EditLectureHall.Command { LectureHallDto = lectureHallDto, LectureHallId = id }));
        }

        [HttpDelete("{lectureHallId}")]
        public async Task<IActionResult> DeleteLectureHall(int lectureHallId)
        {
          return  HandleResult(await Mediator.Send(new DeleteLectureHall.Command { LectureHallId = lectureHallId }));
        }


    }
}

