using FinalProjApi.Data;
using FinalProjApi.Models;
using FinalProjApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjApi.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly FinalProjectDBContext _context;

        public void AddNewUser(User user)
        {
            if (_context.Users == null)
            {
                //return Problem("Entity set 'FinalProjectDBContext.Users'  is null.");
            }
            _context.Users.Add(user);

            _context.SaveChangesAsync();

            //return ("GetUserById", new { id = user.UserId }, user);
        }

        public User GetUserById(int id)
        {
            if (_context.Users == null)
            {
                //return NotFound();
            }

            var user = _context.Users.Find(id);

            if (user == null)
            {
                //return NotFound();
            }

            return user;
        }
    }
}