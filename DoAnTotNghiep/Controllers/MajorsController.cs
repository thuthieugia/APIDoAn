using DoAnTotNghiep.Data;
using DoAnTotNghiep.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MajorsController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                //var listMajors = _context.Majorss.ToList();
                var listMajors = (from item in _context.Majorss.AsNoTracking()
                                  join ology in _context.Ologys.AsNoTracking() on item.OlogyID equals ology.OlogyID into gj1
                                  from ology in gj1.DefaultIfEmpty()
                                  select new MajorsModel
                                  {
                                      MajorsCode = item.MajorsCode,
                                      MajorsID = item.MajorsID,
                                      MajorsName = item.MajorsName,
                                      OlogyID = item.OlogyID,
                                      MajorsOlogy = ology.OlogyName
                                  });
                return Ok(listMajors);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Majors = _context.Majorss.SingleOrDefault(lo => lo.MajorsID == id);
            if (Majors != null)
            {
                return Ok(Majors);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewMajors([FromBody] MajorsModel model)
        {
            try
            {
                var Majors = new MajorsDB
                {
                    MajorsCode = model.MajorsCode,
                    MajorsName = model.MajorsName,
                    OlogyID = model.OlogyID,
                };
                _context.Add(Majors);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMajorsById(Guid id, MajorsModel model)
        {
            var majors = _context.Majorss.SingleOrDefault(lo => lo.MajorsID == id);
            if (majors != null)
            {
                majors.MajorsCode = model.MajorsCode;
                majors.MajorsName = model.MajorsName;
                majors.OlogyID = model.OlogyID;
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
        public IActionResult DeleteMajorsById(Guid id)
        {
            var loai = _context.Majorss.SingleOrDefault(lo => lo.MajorsID == id);
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