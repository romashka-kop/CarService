using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarService.Models
{
    internal class User
    {
        public int Id { get; set; }
        public UserType Type { get; set; }
        public string Family { get; set; }  
        public string Name { get; set; }
        public string Patronymic {  get; set; }
        public string Phone { get; set; }
        public string? Login { get; set; }
        public string Pass { get; set; }
        public List<Request> MasterRequests { get; set; } = [];
        public List<Request> ClientRequests { get; set; } = [];
    }
}
