using APINasa.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APINasa.Controllers
{
    [Route("asteroids")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IAPI _model;

        public ModelController(IAPI modelItemRepository)
        {
            _model = modelItemRepository;
        }

        // GET api/values/5
        [HttpGet]
        public async Task<IActionResult> GetWhere(int days)
        {
            if (days <= 0 || days > 7)
            {
                return BadRequest();
            }
            else
            {
                var entity = _model.Obtenertop3(days);
                if (entity.Result.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(entity);
                }

            }


        }
    }
}
