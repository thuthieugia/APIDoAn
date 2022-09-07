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
    public class OlogyController : ControllerBase
    {
        private readonly MyDbContext _context;

        public OlogyController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listOlogy = _context.Ologys.ToList();
                return Ok(listOlogy);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Ology = _context.Ologys.SingleOrDefault(lo => lo.OlogyID == id);
            if (Ology != null)
            {
                return Ok(Ology);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewOlogy([FromBody] OlogyModel model)
        {
            try
            {
                var Ology = new OlogyDB
                {
                    OlogyName = model.OlogyName,
                    OlogyCode = model.OlogyCode,
            };
                _context.Add(Ology);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOlogyById(Guid id, OlogyModel model)
        {
            var ology = _context.Ologys.SingleOrDefault(lo => lo.OlogyID == id);
            if (ology != null)
            {
                ology.OlogyCode = model.OlogyCode;
                ology.OlogyName = model.OlogyName;
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
        public IActionResult DeleteOlogyById(Guid id)
        {
            var loai = _context.Ologys.SingleOrDefault(lo => lo.OlogyID == id);
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
