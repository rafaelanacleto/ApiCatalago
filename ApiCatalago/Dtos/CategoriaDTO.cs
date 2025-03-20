using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalago.Dtos
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? ImagemPath { get; set; }
        
    }
}