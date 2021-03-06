using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Repository;
using System.Net;

namespace Clinica_Viva_Bem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patient)
        {
            this._patientService = patient;
        }
        public IActionResult Index()
        {
             ViewBag.Title = "Patient";
            return View();
        }

        [HttpPost]
        public IActionResult GetRegisterModal(string ModalChose = "")
        {
            if (ModalChose == "Patient")
                return PartialView("_PatientEdit");

            return NotFound(HttpStatusCode.NotFound);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromForm] Patient patient)
        {
          
                if (await this._patientService.Save(patient) == true)
                    return RedirectToAction(nameof(Index));
        
            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePatient(int id){
           var entity =  await this._patientService.GetById(id);
           return PartialView("_PatientEdit",entity);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePatient(int id)
        {
            if (ModelState.IsValid)
            {
                await this._patientService.Delete(id);
                return Ok();
            }

            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

            return Json(new { aaData = await this._patientService.List() });
        }

    }
}
