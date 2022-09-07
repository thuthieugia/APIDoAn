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
    public class SubjectController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SubjectController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listSubject = _context.Subjects.ToList();
                return Ok(listSubject);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Subject = _context.Subjects.SingleOrDefault(lo => lo.SubjectID == id);
            if (Subject != null)
            {
                return Ok(Subject);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewSubject([FromBody] SubjectModel model)
        {
            try
            {
                var Subject = new SubjectDB
                {
                    SubjectName = model.SubjectName,
                };
                _context.Add(Subject);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubjectById(Guid id, SubjectModel model)
        {
            var Subject = _context.Subjects.SingleOrDefault(lo => lo.SubjectID == id);
            if (Subject != null)
            {

                Subject.SubjectName = model.SubjectName;

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
        public IActionResult DeleteSubjectById(Guid id)
        {
            var loai = _context.Subjects.SingleOrDefault(lo => lo.SubjectID == id);
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
