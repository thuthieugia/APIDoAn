using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoAnTotNghiep.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnTotNghiep.Model;
using Microsoft.EntityFrameworkCore;

namespace DoAnTotNghiep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AttendanceController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listAttendance = (from item in _context.Attendances.AsNoTracking()
                                join student in _context.Students.AsNoTracking() on item.StudentID equals student.StudentID into gj1
                                from student in gj1.DefaultIfEmpty()
                                join practiceSchedule in _context.PracticeSchedules.AsNoTracking() on item.PracticeScheduleID equals practiceSchedule.PracticeScheduleID into gj2
                                from practiceSchedule in gj2.DefaultIfEmpty()
                                      select new AttendanceModel
                                {
                                    StartTime = item.StartTime,
                                    EndTime = item.EndTime,
                                    Description = item.Description,
                                    AttendanceStatus = item.AttendanceStatus,
                                    AttendanceID = item.AttendanceID,
                                    StudentID = item.StudentID,
                                    AttendanceStudentName = student.FullName,
                                    AttendanceStudentCode = student.StudentCode,
                                    AttendancePracticeSchedule = practiceSchedule.Description,
                                });
                return Ok(listAttendance);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("get-practiceschedule")]
        public IActionResult Getbypracticeschedule(Guid pracId)
        {
            try
            {
                var listAttendance = (
                    from item in _context.Attendances.AsNoTracking()
                                      join student in _context.Students.AsNoTracking() on item.StudentID equals student.StudentID into gj1
                                      from student in gj1.DefaultIfEmpty()
                                      join practiceSchedule in _context.PracticeSchedules.AsNoTracking() on item.PracticeScheduleID equals practiceSchedule.PracticeScheduleID into gj2
                                      from practiceSchedule in gj2.DefaultIfEmpty()
                                      where item.PracticeScheduleID == pracId
                                      select new AttendanceModel
                                      {
                                          StartTime = item.StartTime,
                                          EndTime = item.EndTime,
                                          Description = item.Description,
                                          AttendanceStatus = item.AttendanceStatus,
                                          AttendanceID = item.AttendanceID,
                                          StudentID = item.StudentID,
                                          AttendanceStudentName = student.FullName,
                                          AttendanceStudentCode = student.StudentCode,
                                          AttendancePracticeSchedule = practiceSchedule.Description,
                                      });
                return Ok(listAttendance);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Attendance = _context.Attendances.FirstOrDefaultAsync(lo => lo.AttendanceID == id);
            if (Attendance != null)
                {
                    return Ok(Attendance);
                }
            else
                {
                    return NotFound();
                }
        }
        [HttpPost]
        public IActionResult CreateNewAttendance([FromBody]AttendanceModel model)
        {
            try
            {
                var Attendance = new AttendanceDB
                {
                    StudentID = model.StudentID,
                    PracticeScheduleID = model.PracticeScheduleID,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    Description = model.Description,
                    AttendanceStatus = model.AttendanceStatus,
                };
                _context.Add(Attendance);
                _context.SaveChanges();
                return Ok();
                
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAttendanceById(Guid id, AttendanceModel model)
        {
            var attendance = _context.Attendances.SingleOrDefault(lo => lo.AttendanceID == id);
            if (attendance != null)
            {
                attendance.StudentID = model.StudentID;
                attendance.PracticeScheduleID = model.PracticeScheduleID;
                attendance.StartTime = model.StartTime;
                attendance.EndTime = model.EndTime;
                attendance.Description = model.Description;
                attendance.AttendanceStatus = model.AttendanceStatus;
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
        public IActionResult DeleteAttendanceById(Guid id)
        {
            var loai = _context.Attendances.SingleOrDefault(lo => lo.AttendanceID == id);
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
