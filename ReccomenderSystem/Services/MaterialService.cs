using ReccomenderSystem.Data;
using ReccomenderSystem.DTOs;
using ReccomenderSystem.Interfaces;
using ReccomenderSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly ApplicationDbContext _context;

        public MaterialService(
            IMaterialRepository materialRepository,
            ApplicationDbContext context
        )
        {
            _materialRepository = materialRepository;
            _context = context;
        }
        public List<MaterialDTO> GetSearchedMaterials(string materiali)
        {
            var result = _materialRepository.GetSearchedMaterials(materiali);
            List<MaterialDTO> listToReturn = new List<MaterialDTO>();

            foreach (var item in result)
            {
                var material = new MaterialDTO();
                material.Title = item.Title;
                material.Author = item.Author;
                material.DatePublished = item.DatePublished;
                material.MaterialPhoto = item.MaterialPhoto;
                material.Price = item.Price;
                material.Topic = GetTopicById(item.TopicId);

                listToReturn.Add(material);
            }

            return (listToReturn);

        }

        private string GetTopicById(int id)
        {
            var topic = _context.Topics.Where(x => x.TopicId == id).FirstOrDefault();
            return topic.TopicName;
        }
    }
}
