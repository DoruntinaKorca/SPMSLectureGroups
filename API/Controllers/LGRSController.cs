
using Application.DTOs.LGRSDtos;
using Application.Queries.LGRS;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class LGRSController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<LGRSDto>>> GetAllLGRS()
        {
            var lgrs = await Mediator.Send(new GetAllLGRS.Query());

            return lgrs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LGRSDto>> GetLGRSById(int id)
        {
            var lgrs = await Mediator.Send(new GetLGRSById.Query { LGRSId = id});

            return lgrs;
        }
    }
}


