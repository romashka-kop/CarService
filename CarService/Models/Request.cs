using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    internal class Request
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public User Client { get; set; }
        public int? MasterId { get; set; }
        public User? Master { get; set; }
        public int CarId {  get; set; }
        public Car Car { get; set; }
        public string VIN { get; set; }
        [NotNull, MaxLength(100)]
        public string Description { get; set; }
        [NotNull] 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Message { get; set; }
        public byte? Rank { get; set; }
        public List<Part> Parts { get; set; }
       public List<UsedPart> UsedParts { get; set; }
    }
}
