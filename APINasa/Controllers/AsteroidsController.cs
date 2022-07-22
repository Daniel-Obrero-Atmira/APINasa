using APINasa.DataAccess;
using APINasa.Models;
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
    public class AsteroidsController : ControllerBase
    {
        private readonly IMeteoritoService _model;

        public AsteroidsController(IMeteoritoService modelItemRepository)
        {
            _model = modelItemRepository;
        }

        // GET api/values/5
        [HttpGet]
        public async Task<IActionResult> GetTop3(int days)
        {
            if (days <= 0 || days > 7)
            {
                //Response.Headers.Add("Error", "El valor days debe de estar comprendido entre 1 y 7");
                return BadRequest();
            }
            else
            {
                var entity = _model.Obtenertop3(days);

                if (entity.Count == 0)
                {
                    //Response.Headers.Add("Error", "La respuesta devuelta esta vacía");
                    return Ok(entity);
                }
                else
                {
                    return Ok(entity);
                }
                    
                

            }


        }
        [HttpPost]
        [Route("SaveAsteroids")]
        public async Task<IActionResult> GuardarTop3(int days)
        {
            if (days <= 0 || days > 7)
            {
                //Response.Headers.Add("Error", "El valor days debe de estar comprendido entre 1 y 7");
                return BadRequest();
            }
            else
            {
                var entity = _model.Insertar3Meteoritos(days);

                if (entity.Count == 0)
                {
                    //Response.Headers.Add("Error", "La respuesta devuelta esta vacía");
                    return Ok(entity);
                }
                else
                {
                    
                    return Ok(entity);
                }



            }
        }
    }
}
