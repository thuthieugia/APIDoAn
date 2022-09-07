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
    public class TeacherController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TeacherController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listTeacher = (from item in _context.Teachers.AsNoTracking()
                                   join Subject in _context.Subjects.AsNoTracking() on item.SubjectID equals Subject.SubjectID into gj1
                                   from Subject in gj1.DefaultIfEmpty()
                                   select new TeacherModel
                                   {
                                       TeacherCode = item.TeacherCode,
                                       PhoneNumber = item.PhoneNumber,
                                       Email = item.Email,

                                       TeacherID = item.TeacherID,
                                       FullName = item.FullName,
                                       SubjectID = item.SubjectID,
                                       TeacherSubject = Subject.SubjectName
                                   });
                return Ok(listTeacher);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Teacher = _context.Teachers.SingleOrDefault(lo => lo.TeacherID == id);
            if (Teacher != null)
            {
                return Ok(Teacher);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewTeacher([FromBody] TeacherModel model)
        {
            try
            {
                var Teacher = new TeacherDB
                {
                    TeacherCode = model.TeacherCode,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    SubjectID = model.SubjectID,
                };
                _context.Add(Teacher);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacherById(Guid id, TeacherModel model)
        {
            var teacher = _context.Teachers.SingleOrDefault(lo => lo.TeacherID == id);
            if (teacher != null)
            {

                teacher.TeacherCode = model.TeacherCode;
                teacher.FullName = model.FullName;
                teacher.PhoneNumber = model.PhoneNumber;
                teacher.Email = model.Email;
                teacher.SubjectID = model.SubjectID;
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
        public IActionResult DeleteTeacherById(Guid id)
        {
            var loai = _context.Teachers.SingleOrDefault(lo => lo.TeacherID == id);
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
