using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users : BaseEntity
    {
        public string UsersId { get; set; } = string.Empty;
        public string First_Name { get; set; }= string.Empty;
        public string Last_Name { get; set; }= string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_No { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
