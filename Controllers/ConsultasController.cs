using System.Net;
using System.Threading.Tasks;
using Clinica_Viva_Bem.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Repository;

namespace Clinica_Viva_Bem.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IConsultaService _consulta;
        public ConsultasController(IConsultaService consulta)
        {
            this._consulta = consulta;
        }

        [HttpGet]
        public IActionResult GetModals(string ModalChose = "")
        {
            return PartialView("_EditConsulta");
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Consulta";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditConsulta(Consulta consulta)
        {
            await this._consulta.Save(consulta);

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveConsulta(int id)
        {
            await this._consulta.Delete(id);
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var p = await this._consulta.List();

            return Json(new { aaData = p });
        }
    }
}