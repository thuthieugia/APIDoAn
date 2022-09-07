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
    public class ClassController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClassController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                /*var listClass = _context.Classs.ToList();*/
                var listClass = (from item in _context.Classs.AsNoTracking()
                                 join course in _context.Courses.AsNoTracking() on item.CourseID equals course.CourseID into gj1
                                 from course in gj1.DefaultIfEmpty()
                                 join majors in _context.Majorss.AsNoTracking() on item.MajorsID equals majors.MajorsID into gj2
                                  from majors in gj2.DefaultIfEmpty()
                                  select new ClassModel
                                  {
                                      ClassCode = item.ClassCode,
                                      ClassID = item.ClassID,
                                      ClassName = item.ClassName,
                                      MajorsID = item.MajorsID,
                                      ClassMajors = majors.MajorsName,
                                      CourseID = item.CourseID,
                                      ClassCourse = course.CourseName

                                  });
                return Ok(listClass);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Class = _context.Classs.SingleOrDefault(lo => lo.ClassID == id);
            if (Class != null)
            {
                return Ok(Class);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewClass([FromBody] ClassModel model)
        {
            try
            {
                var Class = new ClassDB
                {
                    ClassCode = model.ClassCode,
                    ClassName = model.ClassName,
                    CourseID = model.CourseID,
                    MajorsID = model.MajorsID,
                    

                };
                _context.Add(Class);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassById(Guid id, ClassModel model)
        {
            var class1 = _context.Classs.SingleOrDefault(lo => lo.ClassID == id);
            if (class1 != null)
            {
                class1.ClassCode = model.ClassCode;
                class1.ClassName = model.ClassName;
                class1.CourseID = model.CourseID;
                class1.MajorsID = model.MajorsID;
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
        public IActionResult DeleteClassById(Guid id)
        {
            var loai = _context.Classs.SingleOrDefault(lo => lo.ClassID == id);
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
