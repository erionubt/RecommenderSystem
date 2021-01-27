using ReccomenderSystem.Data;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public MaterialRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
        public List<Materials> GetSearchedMaterials(string materiali)
        {
            var lista = _context.Materials.ToList();

            if (!string.IsNullOrEmpty(materiali))
                lista = lista.Where(x => x.Title.ToLower().Contains(materiali.Trim().ToLower()) 
                || x.Author.ToLower().Contains(materiali.Trim().ToLower())).ToList();

            return lista;
        
        }
    }
}
