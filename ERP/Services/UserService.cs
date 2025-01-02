using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext _context)
        {
            this._context = _context;

        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Username == username); // bulunamazsa  null değer döner


        }

        public async Task AddUserAsync(string username, string hashedpassword)
        {
            User user = new User()
            {
                Username = username,
                PasswordHash = hashedpassword
            };
           
            _context.Users.Add(user);
            _context.SaveChanges();

        }


    }
}
