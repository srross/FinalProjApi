//using FinalProjApi.Data;
//using FinalProjApi.Models;
//using FinalProjApi.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalProjApi.Services
//{
//    public class UserService : ControllerBase, IUserService
//    {
//        private readonly FinalProjectDBContext _context;

//        public void AddNewUser(User user)
//        {
//            if (_context.Users == null)
//            {

//            }
//            _context.Users.Add(user);
//            _context.SaveChangesAsync();
//        }

//        public User GetUserById(int id)
//        {
//            if (_context.Users == null)
//            {

//            }

//            var user = _context.Users.Find(id);

//            if (user == null)
//            {

//            }

//            return user;
//        }
//    }
//}