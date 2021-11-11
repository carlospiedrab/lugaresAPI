using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Lugar :BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double GastoAproximado { get; set; }

        public string ImagenUrl { get; set; }

        public Pais Pais { get; set; }

        public int PaisId { get; set; }

        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

        
    }
}