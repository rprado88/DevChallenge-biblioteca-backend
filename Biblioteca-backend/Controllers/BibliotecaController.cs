﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca_Core.Contracts;
using Biblioteca_Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca_backend.Controllers
{
    [ApiController]
    [Route("api")]
    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaService iBibliotecaService;

        public BibliotecaController(IBibliotecaService _iBibliotecaService)
        {
            iBibliotecaService = _iBibliotecaService;
        }

        [HttpGet("obras")]
        [ProducesResponseType(typeof(List<ObraResponse>), 200)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<ObraResponse>>> GetObras()
        {
            var response = await iBibliotecaService.GetObras();

            if (response == null || response.Count <= 0)
            {
                return NoContent();
            }

            return Ok(response);
        }

        [HttpGet("obra/{id}")]
        [ProducesResponseType(typeof(ObraResponse), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ObraResult>> GetObraById(int id)
        {
            var response = await iBibliotecaService.GetObraById(id);

            if (!response.IsSuccess)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("obra")]
        [ProducesResponseType(typeof(ObraResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ObraResult>> Create(ObraRequest request)
        {
            var response = await iBibliotecaService.CreateObra(request);

            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPut("obra/{id}")]
        [ProducesResponseType(typeof(ObraResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ObraResult>> Update(int id,ObraRequest request)
        {
            if (id != 0)
            {
                request.Id = id;
            }
            else
            {
                return BadRequest();
            }

            var response = await iBibliotecaService.UpdateObra(request);

            if (!response.IsSuccess)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpDelete("obra/{id}")]
        public async Task<ObraResult> Delete(int id)
        {
            if (id != 0)
            {
                var response = await iBibliotecaService.DeleteObra(id);
                return response;
            }

            return null;
        }
    }
}
