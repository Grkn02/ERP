using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public interface IUserService
    {
        public Task<User> GetUserByUsernameAsync(string username);
        public Task AddUserAsync(User user);

    }   
}
