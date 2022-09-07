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
    public class PracticalLaboratoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PracticalLaboratoryController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listPracticalLaboratory = (from item in _context.PracticalLaboratorys.AsNoTracking()
                                  join building in _context.Buildings.AsNoTracking() on item.BuildingID equals building.BuildingID into gj1
                                  from building in gj1.DefaultIfEmpty()
                                               select new PracticalLaboratoryModel
                                  {
                                               PracticalLaboratoryCode = item.PracticalLaboratoryCode,
                                               NumberOfSeats = item.NumberOfSeats,
                                               Description = item.Description,
                                               PracticalLaboratoryID = item.PracticalLaboratoryID,
                                               PracticalLaboratoryName = item.PracticalLaboratoryName,
                                               BuildingID = item.BuildingID,
                                               PracticalLaboratoryBuilding = building.BuildingName,
                                               });
                return Ok(listPracticalLaboratory);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var PracticalLaboratory = _context.PracticalLaboratorys.SingleOrDefault(lo => lo.PracticalLaboratoryID == id);
            if (PracticalLaboratory != null)
            {
                return Ok(PracticalLaboratory);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewPracticalLaboratory([FromBody] PracticalLaboratoryModel model)
        {
            try
            {
                var PracticalLaboratory = new PracticalLaboratoryDB
                {
                    PracticalLaboratoryCode = model.PracticalLaboratoryCode,
                    PracticalLaboratoryName = model.PracticalLaboratoryName,
                    NumberOfSeats = model.NumberOfSeats,
                    Description = model.Description,
                    BuildingID = model.BuildingID,

                };
                _context.Add(PracticalLaboratory);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePracticalLaboratoryById(Guid id, PracticalLaboratoryModel model)
        {
            var practicalLaboratory = _context.PracticalLaboratorys.SingleOrDefault(lo => lo.PracticalLaboratoryID == id);
            if (practicalLaboratory != null)
            {
                practicalLaboratory.PracticalLaboratoryCode = model.PracticalLaboratoryCode;
                practicalLaboratory.PracticalLaboratoryName = model.PracticalLaboratoryName;
                practicalLaboratory.NumberOfSeats = model.NumberOfSeats;
                practicalLaboratory.Description = model.Description;
                practicalLaboratory.BuildingID = model.BuildingID;
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
        public IActionResult DeletePracticalLaboratoryById(Guid id)
        {
            var loai = _context.PracticalLaboratorys.SingleOrDefault(lo => lo.PracticalLaboratoryID == id);
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
