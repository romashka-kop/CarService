using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Models;

namespace CarService.Data
{
    internal class Authorization
    {
        private static Authorization? _instanse;
        private Authorization() {
        
        
        }

        public static Authorization GetInstance()
        {
            if (_instanse == null) { 
                _instanse = new Authorization();
            }
            return _instanse;
        }
        public bool isAuthorized = false;
        public User? CurrentUser { get; set; }
        public bool Login(string username, string password) {
            using var context = new CarServiceContext();

            var user = context
                .Users
                .Where(u => (u.Login == username || u.Phone == username) && u.Pass == password)
                .FirstOrDefault();
            if (user != null) {
                CurrentUser = user;
                isAuthorized = true;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            isAuthorized = false;
        }
    }
}
