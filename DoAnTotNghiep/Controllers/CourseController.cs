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
    public class CourseController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CourseController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listCourse = _context.Courses.ToList();
                return Ok(listCourse);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Course = _context.Courses.SingleOrDefault(lo => lo.CourseID == id);
            if (Course != null)
            {
                return Ok(Course);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewCourse([FromBody] CourseModel model)
        {
            try
            {
                var Course = new CourseDB
                {
                    CourseName = model.CourseName,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,

                };
                _context.Add(Course);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourseById(Guid id, CourseModel model)
        {
            var course = _context.Courses.SingleOrDefault(lo => lo.CourseID == id);
            if (course != null)
            {
                course.CourseName = model.CourseName;
                course.StartTime = model.StartTime;
                course.EndTime = model.EndTime;
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
        public IActionResult DeleteCourseById(Guid id)
        {
            var loai = _context.Courses.SingleOrDefault(lo => lo.CourseID == id);
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
