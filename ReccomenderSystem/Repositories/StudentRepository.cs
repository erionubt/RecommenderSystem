using ReccomenderSystem.Data;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMRS.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddStudent(ApplicationUser student)
        {
            await _context.Users.AddAsync(student);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
