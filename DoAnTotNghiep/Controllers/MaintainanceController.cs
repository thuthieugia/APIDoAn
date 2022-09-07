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
    public class MaintainanceController : ControllerBase
    {
        
            private readonly MyDbContext _context;

            public MaintainanceController(MyDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                try
                {
                var listMaintainance = (from item in _context.Maintainances.AsNoTracking()
                                  join technicalStaff in _context.TechnicalStaffs.AsNoTracking() on item.TechnicalStaffID equals technicalStaff.TechnicalStaffID into gj1
                                  from technicalStaff in gj1.DefaultIfEmpty()
                                  join practicalLaboratory in _context.PracticalLaboratorys.AsNoTracking() on item.PracticalLaboratoryID equals practicalLaboratory.PracticalLaboratoryID into gj2
                                  from practicalLaboratory in gj2.DefaultIfEmpty()
                                        select new MaintainanceModel
                                  {
                                      StartedDate = item.StartedDate,
                                            EndedDate = item.EndedDate,
                                      MaintainanceID = item.MaintainanceID,
                                      TechnicalStaffID = item.TechnicalStaffID,
                                      MaintainanceTechnicalStaffname = technicalStaff.FullName,
                                      MaintainanceTechnicalStaffcode = technicalStaff.TechnicalStaffCode,
                                      PracticalLaboratoryID = item.PracticalLaboratoryID,
                                      MaintainancePracticalLaboratorycode = practicalLaboratory.PracticalLaboratoryCode,
                                      MaintainancePracticalLaboratoryname = practicalLaboratory.PracticalLaboratoryName,
                                      MaintainanceStatus = item.MaintainanceStatus,
                                            Description = item.Description,


                                        });
                return Ok(listMaintainance);
                }
                catch
                {
                    return BadRequest();
                }
            }
            [HttpGet("{id}")]
            public IActionResult GetById(Guid id)
            {
                var Maintainance = _context.Maintainances.SingleOrDefault(lo => lo.MaintainanceID == id);
                if (Maintainance != null)
                {
                    return Ok(Maintainance);
                }
                else
                {
                    return NotFound();
                }
            }
            [HttpPost]
            public IActionResult CreateNewMaintainance([FromBody] MaintainanceModel model)
            {
                try
                {
                    var Maintainance = new MaintainanceDB
                    {
                        PracticalLaboratoryID = model.PracticalLaboratoryID,
                        StartedDate = model.StartedDate,
                        EndedDate = model.EndedDate,
                        TechnicalStaffID = model.TechnicalStaffID,
                        MaintainanceStatus = model.MaintainanceStatus,
                        Request = model.Request,
                        Description = model.Description,
                    };
                    _context.Add(Maintainance);
                    _context.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }

            [HttpPut("{id}")]
            public IActionResult UpdateMaintainanceById(Guid id, MaintainanceModel model)
            {
                var maintainance = _context.Maintainances.SingleOrDefault(lo => lo.MaintainanceID == id);
                if (maintainance != null)
                {
                    maintainance.PracticalLaboratoryID = model.PracticalLaboratoryID;
                    maintainance.StartedDate = model.StartedDate;
                    maintainance.EndedDate = model.EndedDate;
                    maintainance.TechnicalStaffID = model.TechnicalStaffID;
                    maintainance.MaintainanceStatus = model.MaintainanceStatus;
                    maintainance.Request = model.Request;
                    maintainance.Description = model.Description;
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
            public IActionResult DeleteMaintainanceById(Guid id)
            {
                var loai = _context.Maintainances.SingleOrDefault(lo => lo.MaintainanceID == id);
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
