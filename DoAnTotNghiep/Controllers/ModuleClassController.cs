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
    public class ModuleClassController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ModuleClassController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listModuleClass = (from item in _context.ModuleClasss.AsNoTracking()
                                   join teacher in _context.Teachers.AsNoTracking() on item.TeacherID equals teacher.TeacherID into gj1
                                   from teacher in gj1.DefaultIfEmpty()
                                   join module in _context.Modules.AsNoTracking() on item.ModuleID equals module.ModuleID into gj2
                                   from module in gj2.DefaultIfEmpty()
                                   join schoolYear in _context.SchoolYears.AsNoTracking() on item.SchoolYearID equals schoolYear.SchoolYearID into gj3
                                   from schoolYear in gj3.DefaultIfEmpty()
                                   join semester in _context.Semesters.AsNoTracking() on item.SemesterID equals semester.SemesterID into gj4
                                   from semester in gj4.DefaultIfEmpty()
                                       select new ModuleClassModel
                                   {
                                       ModuleClassCode = item.ModuleClassCode,
                                       ModuleClassID = item.ModuleClassID,
                                       TeacherID = item.TeacherID,
                                       ModuleClassTeacher = teacher.FullName,
                                       ModuleID = item.ModuleID,
                                       ModuleClassModule = module.ModuleName,
                                       SchoolYearID = item.SchoolYearID,
                                       ModuleClassSchoolYear = schoolYear.SchoolYearName,
                                       SemesterID = item.SemesterID,
                                       ModuleClassSemester = semester.SemesterName,
                                       Status = item.Status,
                                       StartTime = item.StartTime,
                                       EndTime = item.EndTime,
                                       });
                return Ok(listModuleClass);
            }
            catch
            {
                return BadRequest();
            }
        }




        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var ModuleClass  = (from item in _context.ModuleClasss.AsNoTracking()
                                   join teacher in _context.Teachers.AsNoTracking() on item.TeacherID equals teacher.TeacherID into gj1
                                   from teacher in gj1.DefaultIfEmpty()
                                   join module in _context.Modules.AsNoTracking() on item.ModuleID equals module.ModuleID into gj2
                                   from module in gj2.DefaultIfEmpty()
                                   join schoolYear in _context.SchoolYears.AsNoTracking() on item.SchoolYearID equals schoolYear.SchoolYearID into gj3
                                   from schoolYear in gj3.DefaultIfEmpty()
                                   join semester in _context.Semesters.AsNoTracking() on item.SemesterID equals semester.SemesterID into gj4
                                   from semester in gj4.DefaultIfEmpty()
                                   select new ModuleClassModel
                                   {
                                       ModuleClassCode = item.ModuleClassCode,
                                       ModuleClassID = item.ModuleClassID,
                                       TeacherID = item.TeacherID,
                                       ModuleClassTeacher = teacher.FullName,
                                       ModuleID = item.ModuleID,
                                       ModuleClassModule = module.ModuleName,
                                       SchoolYearID = item.SchoolYearID,
                                       ModuleClassSchoolYear = schoolYear.SchoolYearName,
                                       SemesterID = item.SemesterID,
                                       ModuleClassSemester = semester.SemesterName,
                                       Status = item.Status,
                                       StartTime = item.StartTime,
                                       EndTime = item.EndTime,
                                   });
            if (ModuleClass != null)
            {
                return Ok(ModuleClass);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewModuleClass([FromBody] ModuleClassModel model)
        {
            try
            {
                var ModuleClass = new ModuleClassDB
                {
                    ModuleClassCode = model.ModuleClassCode,
                    ModuleID = model.ModuleID,
                    SemesterID = model.SemesterID,
                    Status = model.Status,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    TeacherID = model.TeacherID,
                    SchoolYearID = model.SchoolYearID,
                };
                _context.Add(ModuleClass);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateModuleClassById(Guid id, ModuleClassModel model)
        {
            var moduleClass = _context.ModuleClasss.SingleOrDefault(lo => lo.ModuleClassID == id);
            if (moduleClass != null)
            {

                moduleClass.ModuleClassCode = model.ModuleClassCode;
                moduleClass.ModuleID = model.ModuleID;
                moduleClass.SemesterID = model.SemesterID;
                moduleClass.Status = model.Status;
                moduleClass.StartTime = model.StartTime;
                moduleClass.EndTime = model.EndTime;
                moduleClass.TeacherID = model.TeacherID;
                moduleClass.SchoolYearID = model.SchoolYearID;
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
        public IActionResult DeleteModuleClassById(Guid id)
        {
            var loai = _context.ModuleClasss.SingleOrDefault(lo => lo.ModuleClassID == id);
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
