﻿using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Interfaces
{
    public interface IMaterialRepository
    {
        List<Materials> GetSearchedMaterials(string materiali);
    }
}
