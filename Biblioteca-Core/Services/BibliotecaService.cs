using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca_Core.Contracts;
using Biblioteca_Core.Models;

namespace Biblioteca_Core.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly ObraContext obraContext;

        public BibliotecaService(ObraContext _obraContext)
        {
            obraContext = _obraContext;
        }

        public async Task<List<ObraResponse>> GetObras()
        {
            var result = new List<ObraResponse>();

            try
            {
                var responseData = obraContext.obraModel.ToList();

                if (responseData != null)
                {
                    foreach (var item in responseData)
                    {
                        result.Add(new ObraResponse()
                        {
                            Editora = item.Editora,
                            Foto = item.Foto,
                            Id = item.Id,
                            Titulo = item.Titulo,
                            Autores = item.Autores.Split(',').ToList()
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<ObraResult> GetObraById(int id)
        {
            var result = new ObraResult();

            try
            {
                var responseData = await obraContext.obraModel.FindAsync(id);

                if (responseData != null)
                {
                    result.Data = new ObraResponse()
                    {
                        Editora = responseData.Editora,
                        Foto = responseData.Foto,
                        Id = responseData.Id,
                        Titulo = responseData.Titulo,
                        Autores = responseData.Autores.Split(',').ToList()
                    };
                    result.IsSuccess = true;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Obra não encontrada!";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<ObraResult> CreateObra(ObraRequest request)
        {
            var result = new ObraResult();
            
            try
            {
                var obraModel = new ObraModel()
                {
                    Autores = string.Join(',', request.Autores),
                    Editora = request.Editora,
                    Foto = request.Foto,
                    Titulo = request.Titulo
                };

                obraContext.obraModel.Add(obraModel);
                var responseData = obraContext.SaveChangesAsync();

                if (responseData.IsCompleted)
                {
                    result.IsSuccess = true;
                    result.Message = "Obra Criada com Sucesso!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;

        }

        public async Task<ObraResult> UpdateObra(ObraRequest request)
        {
            var result = new ObraResult();

            try
            {
                var responseData = await obraContext.obraModel.FindAsync(request.Id);

                if (responseData != null)
                {
                    responseData.Id = request.Id;
                    responseData.Editora = request.Editora;
                    responseData.Foto = request.Foto;
                    responseData.Titulo = request.Titulo;
                    responseData.Autores = string.Join(',', request.Autores);

                    obraContext.obraModel.Update(responseData);
                    await obraContext.SaveChangesAsync();

                    result.IsSuccess = true;
                    result.Message = "Obra Atualizada com Sucesso!";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Obra não encontrada!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<ObraResult> DeleteObra(int id)
        {
            var result = new ObraResult();

            try
            {
                var responseData = await obraContext.obraModel.FindAsync(id);

                if (responseData != null)
                {
                    obraContext.obraModel.Remove(responseData);
                    obraContext.SaveChanges();

                    result.IsSuccess = true;
                    result.Message = "Obra excluída com sucesso!";
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Obra não encontrada!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
