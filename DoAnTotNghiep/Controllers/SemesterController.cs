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
    public class SemesterController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SemesterController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listSemester = _context.Semesters.ToList();
                return Ok(listSemester);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Semester = _context.Semesters.SingleOrDefault(lo => lo.SemesterID == id);
            if (Semester != null)
            {
                return Ok(Semester);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewSemester([FromBody] SemesterModel model)
        {
            try
            {
                var Semester = new SemesterDB
                {
                    SemesterName = model.SemesterName,
                };
                _context.Add(Semester);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSemesterById(Guid id, SemesterModel model)
        {
            var semester = _context.Semesters.SingleOrDefault(lo => lo.SemesterID == id);
            if (semester != null)
            {
                semester.SemesterName = model.SemesterName;
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
        public IActionResult DeleteSemesterById(Guid id)
        {
            var loai = _context.Semesters.SingleOrDefault(lo => lo.SemesterID == id);
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
