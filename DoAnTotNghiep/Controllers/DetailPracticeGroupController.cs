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
    public class DetailPracticeGroupController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DetailPracticeGroupController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var listDetailPracticeGroup = _context.DetailPracticeGroups.ToList();
                return Ok(listDetailPracticeGroup);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var DetailPracticeGroup = _context.DetailPracticeGroups.SingleOrDefault(lo => lo.DetailPracticeGroupID == id);
            if (DetailPracticeGroup != null)
            {
                return Ok(DetailPracticeGroup);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreateNewDetailPracticeGroup([FromBody] DetailPracticeGroupModel model)
        {
            try
            {
                var DetailPracticeGroup = new DetailPracticeGroupDB
                {
                    PracticeGroupID = model.PracticeGroupID,
                    StudentID = model.StudentID,
                    Note = model.Note,

    };
                _context.Add(DetailPracticeGroup);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDetailPracticeGroupById(Guid id, DetailPracticeGroupModel model)
        {
            var detailPracticeGroup = _context.DetailPracticeGroups.SingleOrDefault(lo => lo.DetailPracticeGroupID == id);
            if (detailPracticeGroup != null)
            {
                detailPracticeGroup.PracticeGroupID = model.PracticeGroupID;
                detailPracticeGroup.StudentID = model.StudentID;
                detailPracticeGroup.Note = model.Note;

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
        public IActionResult DeleteDetailPracticeGroupById(Guid id)
        {
            var loai = _context.DetailPracticeGroups.SingleOrDefault(lo => lo.DetailPracticeGroupID == id);
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
