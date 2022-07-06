
using Application.Commands.LGRS;
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

            return HandleResult(lgrs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LGRSDto>> GetLGRSById(int id)
        {
            var lgrs = await Mediator.Send(new GetLGRSById.Query { LGRSId = id});

            return HandleResult(lgrs);
        }
        //ME NDREQ ME BO PER LGRS
        [HttpPost]
        public async Task<IActionResult> OpenLGRS(LGRSDto lgrsDto)
        {

            return HandleResult(await Mediator.Send(new OpenLGRS.Command { LGRSDto = lgrsDto }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditLGRS(RequestLGRSDto lgrsDto, int id)
        {

            return HandleResult(await Mediator.Send(new EditLGRS.Command { LGRSDto = lgrsDto, LGRSId = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLGRS(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteLGRS.Command { LGRSId = id }));
        }
    }
}


