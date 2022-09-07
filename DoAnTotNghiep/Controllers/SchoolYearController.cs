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
    public class SchoolYearController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SchoolYearController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listSchoolYear = _context.SchoolYears.ToList();
                return Ok(listSchoolYear);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var SchoolYear = _context.SchoolYears.SingleOrDefault(lo => lo.SchoolYearID == id);
            if (SchoolYear != null)
            {
                return Ok(SchoolYear);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewSchoolYear([FromBody] SchoolYearModel model)
        {
            try
            {
                var SchoolYear = new SchoolYearDB
                {
                    SchoolYearName = model.SchoolYearName,
                };
                _context.Add(SchoolYear);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchoolYearById(Guid id, SchoolYearModel model)
        {
            var schoolYear = _context.SchoolYears.SingleOrDefault(lo => lo.SchoolYearID == id);
            if (schoolYear != null)
            {
                schoolYear.SchoolYearName = model.SchoolYearName;
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
        public IActionResult DeleteSchoolYearById(Guid id)
        {
            var loai = _context.SchoolYears.SingleOrDefault(lo => lo.SchoolYearID == id);
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
