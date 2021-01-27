using ReccomenderSystem.DTOs;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Interfaces
{
    public interface IMaterialService
    {
        List<MaterialDTO> GetSearchedMaterials(string materiali);
    }
}
