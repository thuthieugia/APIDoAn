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
    public class PracticeGroupController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PracticeGroupController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listPracticeGroup = (from item in _context.PracticeGroups.AsNoTracking()
                                  join teacher in _context.Teachers.AsNoTracking() on item.TeacherID equals teacher.TeacherID into gj1
                                  from teacher in gj1.DefaultIfEmpty()
                                  join moduleClass in _context.ModuleClasss.AsNoTracking() on item.ModuleClassID equals moduleClass.ModuleClassID into gj2
                                  from moduleClass in gj2.DefaultIfEmpty()
                                         select new PracticeGroupModel
                                  {
                                      PracticeGroupCode = item.PracticeGroupCode,
                                      PracticeGroupID = item.PracticeGroupID,
                                      PracticeGroupName = item.PracticeGroupName,

                                      TeacherID = item.TeacherID,
                                      PracticeGroupTeacher = teacher.FullName,
                                      ModuleClassID = item.ModuleClassID,
                                      PracticeGroupModuleClass = moduleClass.ModuleClassCode
                                         });
                return Ok(listPracticeGroup);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var PracticeGroup = _context.PracticeGroups.SingleOrDefault(lo => lo.PracticeGroupID == id);
            if (PracticeGroup != null)
            {
                return Ok(PracticeGroup);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewPracticeGroup([FromBody] PracticeGroupModel model)
        {
            try
            {
                var PracticeGroup = new PracticeGroupDB
                {
                    ModuleClassID = model.ModuleClassID,
                    PracticeGroupCode = model.PracticeGroupCode,
                    PracticeGroupName = model.PracticeGroupName,
                    TeacherID = model.TeacherID,
                    Note = model.Note,

                };
                _context.Add(PracticeGroup);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePracticeGroupById(Guid id, PracticeGroupModel model)
        {
            var practiceGroup = _context.PracticeGroups.SingleOrDefault(lo => lo.PracticeGroupID == id);
            if (practiceGroup != null)
            {
                practiceGroup.ModuleClassID = model.ModuleClassID;
                practiceGroup.PracticeGroupCode = model.PracticeGroupCode;
                practiceGroup.PracticeGroupName = model.PracticeGroupName;
                practiceGroup.TeacherID = model.TeacherID;
                practiceGroup.Note = model.Note;

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
        public IActionResult DeletePracticeGroupById(Guid id)
        {
            var loai = _context.PracticeGroups.SingleOrDefault(lo => lo.PracticeGroupID == id);
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
