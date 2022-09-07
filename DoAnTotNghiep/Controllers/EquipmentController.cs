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
    public class EquipmentController : ControllerBase
    {
        private readonly MyDbContext _context;

        public EquipmentController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listEquipment = _context.Equipments.ToList();
                return Ok(listEquipment);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Equipment = _context.Equipments.SingleOrDefault(lo => lo.EquipmentID == id);
            if (Equipment != null)
            {
                return Ok(Equipment);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewEquipment([FromBody] EquipmentModel model)
        {
            try
            {
                var Equipment = new EquipmentDB
                {
                    EquipmentCode = model.EquipmentCode,
                    PracticalLaboratoryID = model.PracticalLaboratoryID,
                    EquipmentName = model.EquipmentName,
                    Description = model.Description,
                    EquipmentStatus = model.EquipmentStatus,
                };
                _context.Add(Equipment);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEquipmentById(Guid id, EquipmentModel model)
        {
            var equipment = _context.Equipments.SingleOrDefault(lo => lo.EquipmentID == id);
            if (equipment != null)
            {
                equipment.EquipmentCode = model.EquipmentCode;
                equipment.PracticalLaboratoryID = model.PracticalLaboratoryID;
                equipment.EquipmentName = model.EquipmentName;
                equipment.Description = model.Description;
                equipment.EquipmentStatus = model.EquipmentStatus;
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
        public IActionResult DeleteEquipmentById(Guid id)
        {
            var loai = _context.Equipments.SingleOrDefault(lo => lo.EquipmentID == id);
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