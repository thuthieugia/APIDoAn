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
    public class TechnicalStaffController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TechnicalStaffController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listTechnicalStaff = _context.TechnicalStaffs.ToList();
                return Ok(listTechnicalStaff);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var TechnicalStaff = _context.TechnicalStaffs.SingleOrDefault(lo => lo.TechnicalStaffID == id);
            if (TechnicalStaff != null)
            {
                return Ok(TechnicalStaff);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewTechnicalStaff([FromBody] TechnicalStaffModel model)
        {
            try
            {
                var TechnicalStaff = new TechnicalStaffDB
                {
                    TechnicalStaffCode = model.TechnicalStaffCode,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
    };
                _context.Add(TechnicalStaff);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTechnicalStaffById(Guid id, TechnicalStaffModel model)
        {
            var technicalStaff = _context.TechnicalStaffs.SingleOrDefault(lo => lo.TechnicalStaffID == id);
            if (technicalStaff != null)
            {
                technicalStaff.FullName = model.FullName;
                technicalStaff.TechnicalStaffCode = model.TechnicalStaffCode;
                technicalStaff.FullName = model.FullName;
                technicalStaff.PhoneNumber = model.PhoneNumber;
                technicalStaff.Email = model.Email;
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
        public IActionResult DeleteTechnicalStaffById(Guid id)
        {
            var loai = _context.TechnicalStaffs.SingleOrDefault(lo => lo.TechnicalStaffID == id);
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
