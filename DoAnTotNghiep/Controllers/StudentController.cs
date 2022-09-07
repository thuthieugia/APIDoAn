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
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext _context;

        public StudentController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listStudent = (from item in _context.Students.AsNoTracking()
                                  join Class1 in _context.Classs.AsNoTracking() on item.ClassID equals Class1.ClassID into gj1
                                  from Class1 in gj1.DefaultIfEmpty()
                                  select new StudentModel
                                  {
                                      StudentCode = item.StudentCode,
                                      DateOfBirth = item.DateOfBirth,
                                      Gender = item.Gender,
                                      PhoneNumber = item.PhoneNumber,
                                      Email = item.Email,

                                      StudentID = item.StudentID,
                                      FullName = item.FullName,
                                      ClassID = item.ClassID,
                                      StudentClass = Class1.ClassName
                                  });
                return Ok(listStudent);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Student = _context.Students.SingleOrDefault(lo => lo.StudentID == id);
            if (Student != null)
            {
                return Ok(Student);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewStudent([FromBody] StudentModel model)
        {
            try
            {
                var Student = new StudentDB
                {
                    StudentCode = model.StudentCode,
                    FullName = model.FullName,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    ClassID = model.ClassID,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                };
                _context.Add(Student);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudentById(Guid id, StudentModel model)
        {
            var student = _context.Students.SingleOrDefault(lo => lo.StudentID == id);
            if (student != null)
            {
                student.StudentCode = model.StudentCode;
                student.FullName = model.FullName;
                student.DateOfBirth = model.DateOfBirth;
                student.Gender = model.Gender;
                student.ClassID = model.ClassID;
                student.PhoneNumber = model.PhoneNumber;
                student.Email = model.Email;
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
        public IActionResult DeleteStudentById(Guid id)
        {
            var loai = _context.Students.SingleOrDefault(lo => lo.StudentID == id);
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
