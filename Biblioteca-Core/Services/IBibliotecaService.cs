using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca_Core.Contracts;

namespace Biblioteca_Core.Services
{
    public interface IBibliotecaService
    {
        Task<List<ObraResponse>> GetObras();

        Task<ObraResult> GetObraById(int id);

        Task<ObraResult> CreateObra(ObraRequest request);

        Task<ObraResult> UpdateObra(ObraRequest request);

        Task<ObraResult> DeleteObra(int id);

    }
}
