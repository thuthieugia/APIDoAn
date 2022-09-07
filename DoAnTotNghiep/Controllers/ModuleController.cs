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
    public class ModuleController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ModuleController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listModule = (from item in _context.Modules.AsNoTracking()
                                  join subject in _context.Subjects.AsNoTracking() on item.SubjectID equals subject.SubjectID into gj1
                                  from subject in gj1.DefaultIfEmpty()
                                  select new ModuleModel
                                  {
                                      ModuleCode = item.ModuleCode,
                                      NumberOfModule = item.NumberOfModule,
                                      ModuleID = item.ModuleID,
                                      ModuleName = item.ModuleName,
                                      SubjectID = item.SubjectID,
                                      ModuleSubject = subject.SubjectName
                                  });
                return Ok(listModule);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Module = _context.Modules.SingleOrDefault(lo => lo.ModuleID == id);
            if (Module != null)
            {
                return Ok(Module);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewModule([FromBody] ModuleModel model)
        {
            try
            {
                var Module = new ModuleDB
                {
                    ModuleCode = model.ModuleCode,
                    ModuleName = model.ModuleName,
                    NumberOfModule = model.NumberOfModule,
                    SubjectID = model.SubjectID,

                };
                _context.Add(Module);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateModuleById(Guid id, ModuleModel model)
        {
            var module = _context.Modules.SingleOrDefault(lo => lo.ModuleID == id);
            if (module != null)
            {
                module.ModuleCode = model.ModuleCode;
                module.ModuleName = model.ModuleName;
                module.NumberOfModule = model.NumberOfModule;
                module.SubjectID = model.SubjectID;
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
        public IActionResult DeleteModuleById(Guid id)
        {
            var loai = _context.Modules.SingleOrDefault(lo => lo.ModuleID == id);
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