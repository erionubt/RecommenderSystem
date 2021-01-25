using Microsoft.EntityFrameworkCore;
using ReccomenderSystem.Data;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Repositories
{
    public class TopicsRepository : ITopicsRepository
    {
        private readonly ApplicationDbContext _context;

        public TopicsRepository(
            ApplicationDbContext context
        )
        {
            _context = context;
        }
        public async Task<List<Topics>> GetTopics()
        {
            return await _context.Topics.ToListAsync();
        }

        public bool SaveTopics(string emri)
        {
            var tema = new Topics
            {
                TopicName = emri
            };

            _context.Topics.Add(tema);
            return _context.SaveChanges() > 0;


        }
    }
}
