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
    public class BuildingController : ControllerBase
    {
        private readonly MyDbContext _context;

        public BuildingController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listBuilding = _context.Buildings.ToList();
                return Ok(listBuilding);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var Building = _context.Buildings.SingleOrDefault(lo => lo.BuildingID == id);
            if (Building != null)
            {
                return Ok(Building);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewBuilding([FromBody] BuildingModel model)
        {
            try
            {
                var Building = new BuildingDB
                {
                    BuildingName = model.BuildingName,
                    BaseBuilding = model.BaseBuilding,
                };
                _context.Add(Building);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBuildingById(Guid id, BuildingModel model)
        {
            var building = _context.Buildings.SingleOrDefault(lo => lo.BuildingID == id);
            if (building != null)
            {
                building.BuildingName = model.BuildingName;
                building.BaseBuilding = model.BaseBuilding;
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
        public IActionResult DeleteBuildingById(Guid id)
        {
            var loai = _context.Buildings.SingleOrDefault(lo => lo.BuildingID == id);
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