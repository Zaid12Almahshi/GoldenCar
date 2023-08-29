using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.IRental
{
    public interface IUsersService<Users>:IGlobalService<Users>
    {
        Task<Users> GetUserNameAndPassword(Users entity);
    }
}
