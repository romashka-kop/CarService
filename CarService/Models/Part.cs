using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    internal class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int ManufacturerId { get; set; } 
        public Manufacturer Manufacturer { get; set; }
        public List<Request> Requests { get; set; }
        public List<UsedPart> UsedParts { get; set; }
        public List<PartRequest> PartRequests { get; set; }
    }
}
