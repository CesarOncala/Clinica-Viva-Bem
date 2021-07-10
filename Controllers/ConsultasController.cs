using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Repository;

namespace Clinica_Viva_Bem.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IConsultaService _consulta;
        private readonly IDoctorService _doctor;
        private readonly IPatientService _patient;
        public ConsultasController(IConsultaService consulta, IDoctorService doctor, IPatientService patient)
        {
            this._doctor = doctor;
            this._patient = patient;
            this._consulta = consulta;
        }

        [HttpPost]
        public async Task<IActionResult> GetModalEdit(int id = 0)
        {
            ViewBag.isEdit = false;
            if (id == 0)
                return PartialView("_EditConsulta");

            ViewBag.isEdit = true;
            var entity = await this._consulta.GetById(id, new[] { "Doctor", "Patient" });
            return PartialView("_EditConsulta", entity);
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Consulta";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditConsulta(Consulta consulta)
        {   
            if(this._consulta.GetByFilter(o=> 
             o.DoctorId == consulta.DoctorId
             && consulta.Date.Day == o.Date.Day
             ).Count()==2)
                return Json(new{success = false, message = "This Doctor have two consultations in this day!"});

            return Json(new { success = await this._consulta.Save(consulta) });
        }

        [HttpGet]
        public IActionResult GetSelectOptions(string typeSearch, int page, string search = "")
        {
            if (typeSearch == "doctor")
                return Json(new
                {
                    results = this._doctor.
                GetByFilter(o => o.Name.ToLower().Trim().Contains(search.ToLower().Trim()))
                .Select(o => new { id = o.Id, text = o.Name })
                });
            else if (typeSearch == "patient")
                return Json(new
                {
                    results = this._patient.
                GetByFilter(o => o.Name.Trim().ToLower().Contains(search.ToLower().Trim()))
                .Select(o => new { id = o.Id, text = o.Name })
                });

            return NotFound("Not found");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveConsulta(int id)
        {
            try
            {
                await this._consulta.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }

        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var p = await this._consulta.List();

            return Json(new { aaData = p });
        }
    }
}