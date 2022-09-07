using DoAnTotNghiep.Data;
using DoAnTotNghiep.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PermissionController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listPermission = _context.Permissions.ToList();
                return Ok(listPermission);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Permission = _context.Permissions.SingleOrDefault(lo => lo.PermissionID == id);
            if (Permission != null)
            {
                return Ok(Permission);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewPermission([FromBody] PermissionModel model)
        {
            try
            {
                var Permission = new PermissionDB
                {
                    PermissionName = model.PermissionName,
                };
                _context.Add(Permission);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePermissionById(Guid id, PermissionModel model)
        {
            var Permission = _context.Permissions.SingleOrDefault(lo => lo.PermissionID == id);
            if (Permission != null)
            {

                Permission.PermissionName = model.PermissionName;
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
        public IActionResult DeletePermissionById(Guid id)
        {
            var loai = _context.Permissions.SingleOrDefault(lo => lo.PermissionID == id);
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
