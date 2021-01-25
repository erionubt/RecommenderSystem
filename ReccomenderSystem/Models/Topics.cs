using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReccomenderSystem.Models
{
    public class Topics
    {
        [Key]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
    }
}
