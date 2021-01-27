using ReccomenderSystem.DTOs;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Interfaces
{
    public interface IStudentRepository
    {
        Task<bool> AddStudent(ApplicationUser student);
        List<Materials> GetMaterialsForUser(string id);

        List<ApplicationUser> GetStudents();
    }
}
