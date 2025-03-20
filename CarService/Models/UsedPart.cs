using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Models
{
    internal class UsedPart
    {
        
        public int RequestId { get; set; }
        public Request? Request { get; set; }
        
        public int PartId { get; set; }
        public Part? Part { get; set; }
        public int Count { get; set; }
    }
}
