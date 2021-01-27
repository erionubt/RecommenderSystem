using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Models
{
    public class Materials
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string DatePublished { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("TopicId")]
        public Topics Topic { get; set; }
        public int TopicId { get; set; }
        [DataType("nvarchar(500)")]
        public string MaterialPhoto { get; set; }
    }
}
