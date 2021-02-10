using System;
namespace Biblioteca_Core.Contracts
{
    public class ObraResult
    {
        public ObraResult() { }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ObraResponse Data { get; set; }

    }
}
