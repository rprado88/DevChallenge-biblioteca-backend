using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Biblioteca_Core.Contracts
{
    [Serializable]
    [DataContract]
    public class ObraRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("titulo")]
        public string Titulo { get; set; }

        [JsonProperty("editora")]
        public string Editora { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("autores")]
        public List<string> Autores { get; set; }
    }
}
