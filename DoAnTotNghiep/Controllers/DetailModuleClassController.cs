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
    public class DetailModuleClassController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DetailModuleClassController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listDetailModuleClass = (from item in _context.DetailModuleClasss.AsNoTracking()
                                      join student in _context.Students.AsNoTracking() on item.StudentID equals student.StudentID into gj1
                                      from student in gj1.DefaultIfEmpty()
                                      join moduleClass in _context.ModuleClasss.AsNoTracking() on item.ModuleClassID equals moduleClass.ModuleClassID into gj2
                                      from moduleClass in gj2.DefaultIfEmpty()
                                      join Class1 in _context.Classs.AsNoTracking() on item.ClassID equals Class1.ClassID into gj3
                                      from Class1 in gj3.DefaultIfEmpty()

                                             select new DetailModuleClassModel
                                      {
                                              FrequentPoints1 = item.FrequentPoints1,
                                              FrequentPoints2 = item.FrequentPoints2,
                                              MediumScore = item.MediumScore,
                                              DetailModuleClassID = item.DetailModuleClassID,
                                              DetailModuleClassName = Class1.ClassName,
                                              StudentID = item.StudentID,
                                              DetailModuleClassStudentName = student.FullName,
                                              DetailModuleClassStudentCode = student.StudentCode,
                                              ClassID = item.ClassID,
                                              DetailModuleClassClass = Class1.ClassName
                                      });



                
                                                                        

                return Ok(listDetailModuleClass);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("get-moduleclass")]
        public IActionResult Getbymoduleclass(Guid detaimId)
        {
            try
            {
                var listDetailModuleClass = (
                from item in _context.DetailModuleClasss.AsNoTracking()
                                             join student in _context.Students.AsNoTracking() on item.StudentID equals student.StudentID into gj1
                                             from student in gj1.DefaultIfEmpty()
                                             join moduleClass in _context.ModuleClasss.AsNoTracking() on item.ModuleClassID equals moduleClass.ModuleClassID into gj2
                                             from moduleClass in gj2.DefaultIfEmpty()
                                             join class1 in _context.Classs.AsNoTracking() on item.ClassID equals class1.ClassID into gj3
                                             from class1 in gj3.DefaultIfEmpty()
                                                where item.ModuleClassID == detaimId
                                                select new DetailModuleClassModel
                                             {
                                                 FrequentPoints1 = item.FrequentPoints1,
                                                 FrequentPoints2 = item.FrequentPoints2,
                                                 MediumScore = item.MediumScore,
                                                 DetailModuleClassID = item.DetailModuleClassID,
                                                 ClassID = item.ClassID,
                                                 DetailModuleClassName = class1.ClassName,
                                                 StudentID = item.StudentID,
                                                 DetailModuleClassStudentName = student.FullName,
                                                 DetailModuleClassStudentCode = student.StudentCode,
                                             });
                return Ok(listDetailModuleClass);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var DetailModuleClass = _context.DetailModuleClasss.SingleOrDefault(lo => lo.DetailModuleClassID == id);
            if (DetailModuleClass != null)
            {
                return Ok(DetailModuleClass);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewDetailModuleClass([FromBody] DetailModuleClassModel model)
        {
            try
            {
                var DetailModuleClass = new DetailModuleClassDB
                {
                    ModuleClassID = model.ModuleClassID,
                    StudentID = model.StudentID,
                    FrequentPoints1 = model.FrequentPoints1,
                    FrequentPoints2 = model.FrequentPoints2,
                    MediumScore = model.MediumScore,
                    ClassID = model.ClassID,
                };
                _context.Add(DetailModuleClass);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDetailModuleClassById(Guid id, DetailModuleClassModel model)
        {
            var detailModuleClass = _context.DetailModuleClasss.SingleOrDefault(lo => lo.DetailModuleClassID == id);
            if (detailModuleClass != null)
            {
                detailModuleClass.ModuleClassID = model.ModuleClassID;
                detailModuleClass.StudentID = model.StudentID;
                detailModuleClass.FrequentPoints1 = model.FrequentPoints1;
                detailModuleClass.FrequentPoints2 = model.FrequentPoints2;
                detailModuleClass.MediumScore = model.MediumScore;
                detailModuleClass.ClassID = model.ClassID;
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
        public IActionResult DeleteDetailModuleClassById(Guid id)
        {
            var loai = _context.DetailModuleClasss.SingleOrDefault(lo => lo.DetailModuleClassID == id);
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
