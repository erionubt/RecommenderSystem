using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.DTOs
{
    public class MaterialDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string DatePublished { get; set; }
        public decimal? Price { get; set; }
        public string Topic { get; set; }
        public string MaterialPhoto { get; set; }
    }
}
