using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class UsersModel
    {
        public string UsersId { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_No { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

    }
    public class UsrerLoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
    public class UserRegisterModel
    {
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_No { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
    public class GetUserByIdModel
    {

        public string UsersId { get; set; } = string.Empty;
    }
    public class UserUpdateModel
    {
        public string UsersId { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_No { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
    public class UserDeleteModel
    {
        public string UsersId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;

    }
    public class UserActiveModel
    {
        public string UsersId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }

}
