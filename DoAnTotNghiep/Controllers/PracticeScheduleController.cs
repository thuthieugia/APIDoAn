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
    public class PracticeScheduleController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PracticeScheduleController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listPracticeSchedule = (from item in _context.PracticeSchedules.AsNoTracking()
                                  join practiceShift in _context.PracticeShifts.AsNoTracking() on item.PracticeShiftID equals practiceShift.PracticeShiftID into gj1
                                  from practiceShift in gj1.DefaultIfEmpty()
                                  join practiceGroup in _context.PracticeGroups.AsNoTracking() on item.PracticeGroupID equals practiceGroup.PracticeGroupID into gj2
                                  from practiceGroup in gj2.DefaultIfEmpty()
                                  join practicalLaboratory in _context.PracticalLaboratorys.AsNoTracking() on item.PracticalLaboratoryID equals practicalLaboratory.PracticalLaboratoryID into gj3
                                  from practicalLaboratory in gj3.DefaultIfEmpty()
                                  join semester in _context.Semesters.AsNoTracking() on item.SemesterID equals semester.SemesterID into gj4
                                  from semester in gj4.DefaultIfEmpty()
                                  join schoolYear in _context.SchoolYears.AsNoTracking() on item.SchoolYearID equals schoolYear.SchoolYearID into gj5
                                  from schoolYear in gj5.DefaultIfEmpty()
                                  join teacher in _context.Teachers.AsNoTracking() on item.TeacherID equals teacher.TeacherID into gj6
                                  from teacher in gj6.DefaultIfEmpty()
                                            select new PracticeScheduleModel
                                  {
                                      PracticeScheduleID = item.PracticeScheduleID,
                                      Date = item.Date,
                                      Status = item.Status,
                                      Description = item.Description,
                                      Request = item.Request,
                                      PracticeShiftID = item.PracticeShiftID,
                                      PracticeSchedulePracticeShiftname = practiceShift.PracticeShiftName,
                                      PracticeSchedulePracticeShiftstarttime = practiceShift.StartTime,
                                      PracticeSchedulePracticeShiftendtime = practiceShift.EndTime,
                                      PracticeGroupID = item.PracticeGroupID,
                                      PracticeSchedulePracticeGroup = practiceGroup.PracticeGroupName,
                                      PracticalLaboratoryID = item.PracticalLaboratoryID,
                                      PracticeSchedulePracticalLaboratory = practicalLaboratory.PracticalLaboratoryName,
                                      SemesterID = item.SemesterID,
                                      PracticeScheduleSemester = semester.SemesterName,
                                      SchoolYearID = item.SchoolYearID,
                                      PracticeScheduleSchoolYear = schoolYear.SchoolYearName,
                                      TeacherID = item.TeacherID,
                                      PracticeScheduleTeacher = teacher.FullName,


                                            });
                return Ok(listPracticeSchedule);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            /*var PracticeSchedule = _context.PracticeSchedules.SingleOrDefault(lo => lo.PracticeScheduleID == id);*/
            var PracticeSchedule = (from item in _context.PracticeSchedules.AsNoTracking()
                                        join practiceShift in _context.PracticeShifts.AsNoTracking() on item.PracticeShiftID equals practiceShift.PracticeShiftID into gj1
                                        from practiceShift in gj1.DefaultIfEmpty()
                                        join practiceGroup in _context.PracticeGroups.AsNoTracking() on item.PracticeGroupID equals practiceGroup.PracticeGroupID into gj2
                                        from practiceGroup in gj2.DefaultIfEmpty()
                                        join practicalLaboratory in _context.PracticalLaboratorys.AsNoTracking() on item.PracticalLaboratoryID equals practicalLaboratory.PracticalLaboratoryID into gj3
                                        from practicalLaboratory in gj3.DefaultIfEmpty()
                                        join semester in _context.Semesters.AsNoTracking() on item.SemesterID equals semester.SemesterID into gj4
                                        from semester in gj4.DefaultIfEmpty()
                                        join schoolYear in _context.SchoolYears.AsNoTracking() on item.SchoolYearID equals schoolYear.SchoolYearID into gj5
                                        from schoolYear in gj5.DefaultIfEmpty()
                                        join teacher in _context.Teachers.AsNoTracking() on item.TeacherID equals teacher.TeacherID into gj6
                                        from teacher in gj6.DefaultIfEmpty()
                                        where item.PracticeScheduleID == id
                                    select new PracticeScheduleModel
                                        {
                                            PracticeScheduleID = item.PracticeScheduleID,
                                            Date = item.Date,
                                            Status = item.Status,
                                            Description = item.Description,
                                            Request = item.Request,
                                            PracticeShiftID = item.PracticeShiftID,
                                            PracticeSchedulePracticeShiftname = practiceShift.PracticeShiftName,
                                            PracticeSchedulePracticeShiftstarttime = practiceShift.StartTime,
                                            PracticeSchedulePracticeShiftendtime = practiceShift.EndTime,
                                            PracticeGroupID = item.PracticeGroupID,
                                            PracticeSchedulePracticeGroup = practiceGroup.PracticeGroupName,
                                            PracticalLaboratoryID = item.PracticalLaboratoryID,
                                            PracticeSchedulePracticalLaboratory = practicalLaboratory.PracticalLaboratoryName,
                                            SemesterID = item.SemesterID,
                                            PracticeScheduleSemester = semester.SemesterName,
                                            SchoolYearID = item.SchoolYearID,
                                            PracticeScheduleSchoolYear = schoolYear.SchoolYearName,
                                            TeacherID = item.TeacherID,
                                            PracticeScheduleTeacher = teacher.FullName,
                                        });

            if (PracticeSchedule != null)
            {
                return Ok(PracticeSchedule);
                
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewPracticeSchedule([FromBody] PracticeScheduleModel model)
        {
            try
            {
                var PracticeSchedule = new PracticeScheduleDB
                {
                    Date = model.Date,
                    PracticeShiftID = model.PracticeShiftID,
                    PracticeGroupID = model.PracticeGroupID,
                    PracticalLaboratoryID = model.PracticalLaboratoryID,
                    Status = model.Status,
                    Description = model.Description,
                    SchoolYearID = model.SchoolYearID,
                    SemesterID = model.SemesterID,
                    TeacherID = model.TeacherID,
                    Request = model.Request,
                    

                };
                _context.Add(PracticeSchedule);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePracticeScheduleById(Guid id, PracticeScheduleModel model)
        {
            var practiceSchedule = _context.PracticeSchedules.SingleOrDefault(lo => lo.PracticeScheduleID == id);
            if (practiceSchedule != null)
            {
                practiceSchedule.Date = model.Date;
                practiceSchedule.PracticeShiftID = model.PracticeShiftID;
                practiceSchedule.PracticeGroupID = model.PracticeGroupID;
                practiceSchedule.PracticalLaboratoryID = model.PracticalLaboratoryID;
                practiceSchedule.Status = model.Status;
                practiceSchedule.Description = model.Description;
                practiceSchedule.SchoolYearID = model.SchoolYearID;
                practiceSchedule.SemesterID = model.SemesterID;
                practiceSchedule.Request = model.Request;
                practiceSchedule.TeacherID = model.TeacherID;

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
        public IActionResult DeletePracticeScheduleById(Guid id)
        {
            var loai = _context.PracticeSchedules.SingleOrDefault(lo => lo.PracticeScheduleID == id);
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
