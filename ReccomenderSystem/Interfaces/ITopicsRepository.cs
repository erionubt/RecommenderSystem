using ReccomenderSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Interfaces
{
    public interface ITopicsRepository
    {
        Task<List<Topics>> GetTopics();
        bool SaveTopics(string emri);
    }
}
