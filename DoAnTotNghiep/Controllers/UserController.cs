using DoAnTotNghiep.Models;
using DoAnTotNghiep.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;

        public object SqlMethods { get; private set; }

        public UserController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listUser = (from item in _context.Users.AsNoTracking()
                                   join permission in _context.Permissions.AsNoTracking() on item.PermissionID equals permission.PermissionID into gj1
                                   from permission in gj1.DefaultIfEmpty()
                                   select new UserModel
                                   {
                                       UserID = item.UserID,
                                       UserName = item.UserName,
                                       password = item.password,
                                       PermissionID = item.PermissionID,
                                       UserPermission = permission.PermissionName
                                   });
                return Ok(listUser);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var User = _context.Users.SingleOrDefault(lo => lo.UserID == id);
            if (User != null)
            {
                return Ok(User);
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult CreateNewUser([FromBody] UserModel model)
        {
            try
            {
                var User = new UserDB
                {
                    UserName = model.UserName,
                    PermissionID = model.PermissionID,
                    password = model.password,
                };
                _context.Add(User);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                var result = _context.Users.Where(s => s.UserName == userName && s.password == password).Join(_context.Permissions, p => p.PermissionID, e => e.PermissionID,
                    (p, e) => new
                    {
                        user = p.UserName,
                        permission = e.PermissionName
                    }).Single();
                if (result != null)
                {

                    return Ok(result);
                }
                throw new Exception("Something was wrong");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserById(Guid id, UserModel model)
        {
            var user = _context.Users.SingleOrDefault(lo => lo.UserID == id);
            if (user != null)
            {
                user.UserName = model.UserName;
                user.PermissionID = model.PermissionID;
                user.password = model.password;

                // Update
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(Guid id)
        {
            var loai = _context.Users.SingleOrDefault(lo => lo.UserID == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
