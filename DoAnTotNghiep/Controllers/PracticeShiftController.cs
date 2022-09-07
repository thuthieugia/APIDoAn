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
    public class PracticeShiftController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PracticeShiftController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listPracticeShift = _context.PracticeShifts.ToList();
                return Ok(listPracticeShift);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var PracticeShift = _context.PracticeShifts.SingleOrDefault(lo => lo.PracticeShiftID == id);
            if (PracticeShift != null)
            {
                return Ok(PracticeShift);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewPracticeShift([FromBody] PracticeShiftModel model)
        {
            try
            {
                var PracticeShift = new PracticeShiftDB
                {
                    PracticeShiftName = model.PracticeShiftName,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                };
                _context.Add(PracticeShift);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePracticeShiftById(Guid id, PracticeShiftModel model)
        {
            var practiceShift = _context.PracticeShifts.SingleOrDefault(lo => lo.PracticeShiftID == id);
            if (practiceShift != null)
            {

                practiceShift.PracticeShiftName = model.PracticeShiftName;
                practiceShift.StartTime = model.StartTime;
                practiceShift.EndTime = model.EndTime;
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
        public IActionResult DeletePracticeShiftById(Guid id)
        {
            var loai = _context.PracticeShifts.SingleOrDefault(lo => lo.PracticeShiftID == id);
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
