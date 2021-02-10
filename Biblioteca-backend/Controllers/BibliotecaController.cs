using System.Collections.Generic;
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
        public async Task<List<ObraResponse>> GetObras()
        {
            var response = await iBibliotecaService.GetObras();

            return response;
        }

        [HttpGet("obra/{id}")]
        public async Task<ObraResult> GetObrasById(int id)
        {
            var response = await iBibliotecaService.GetObraById(id);

            return response;
        }

        [HttpPost("obra")]
        public async Task<ObraResult> Create(ObraRequest request)
        {
            var response = await iBibliotecaService.CreateObra(request);

            return response;
        }

        [HttpPut("obra/{id}")]
        public async Task<ObraResult> Update(int id,ObraRequest request)
        {
            if (id != 0)
            {
                request.Id = id;
            }

            var response = await iBibliotecaService.UpdateObra(request);

            return response;
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
