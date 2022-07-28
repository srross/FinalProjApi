//using FinalProjApi.Data;
//using FinalProjApi.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalProjApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : BaseController
//    {
//        private readonly FinalProjectDBContext _context;

//        public UserController(FinalProjectDBContext context)
//        {
//            _context = context;
//        }

//        // POST: api/User
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost("AddNewUser")]
//        public async Task<ActionResult<User>> AddNewUser(User user)
//        {
//            if (_context.Users == null)
//            {
//                return Problem("Entity set 'FinalProjectDBContext.Users'  is null.");
//            }
//            _context.Users.Add(user);

//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
//        }

//        //GET: api/User/5
//        [HttpGet("GetUserById/{userId}")]
//        public async Task<ActionResult<User>> GetUserById(int userId)
//        {
//            if (_context.Users == null)
//            {
//                return NotFound();
//            }
//            var user = await _context.Users.FindAsync(userId);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            return user;
//        }

//        private bool UserExists(int id)
//        {
//            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
//        }
//    }
//}