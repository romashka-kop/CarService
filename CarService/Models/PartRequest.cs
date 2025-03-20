using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    internal class PartRequest
    {
        public int Id { get; set; }
        public int? requestId { get; set; }
        public Request? Request { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
