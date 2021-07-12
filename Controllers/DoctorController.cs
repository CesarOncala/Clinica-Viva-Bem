using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Repository;
using System.Net;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinica_Viva_Bem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctor)
        {
            this._doctorService = doctor;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Doctor";
   
            return View();
        }

        [HttpPost]
        public IActionResult GetRegisterModal(string ModalName = "")
        {
            if (ModalName == "Doctor"){
                
            ViewBag.Especialidades = (from o in Enum.GetValues<Enums.Especialidade>()
                                      select new SelectListItem()
                                      {
                                          Text = o.ToString(),
                                          Value = ((int)o).ToString()
                                      }
                                ).ToList();
                return PartialView("_DoctorEdit");
            }

            return NotFound(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor([FromForm] Doctor doctor)
        {
            if (await this._doctorService.Save(doctor) == true)
                return Json(new { success = true });

            return Json(new { success = false });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(int id)
        {
            var entity = await this._doctorService.GetById(id);
            ViewBag.Especialidades = (from o in Enum.GetValues<Enums.Especialidade>()
                                      select new SelectListItem()
                                      {
                                          Text = o.ToString(),
                                          Value = ((int)o).ToString(),
                                          Selected = (int) entity.Especialidade == (int) o ? true : false
                                          
                                      }
                                     ).ToList();


            return PartialView("_DoctorEdit", entity);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveDoctor(int id)
        {
            if (ModelState.IsValid)
            {
                await this._doctorService.Delete(id);
                return Ok();
            }

            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Json(new { aaData = await this._doctorService.List() });
        }

    }
}
