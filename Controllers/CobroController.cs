using Microsoft.AspNetCore.Mvc;
using PracticaCalificada1.Models;

namespace PracticaCalificada1.Controllers
{
    public class CobroController : Controller
    {
        public IActionResult Index()
        {

            return View(new Cobro());
        }
        [HttpPost]
        public IActionResult Calcular(Cobro obj)
        {
            DateTime hoy = DateTime.Now;
            int diferencia = (hoy - obj.fechaVenc).Days;
            double mora = 0 , montoFinal;

            if (diferencia > 0)
            {
                mora = diferencia * 0.0005 * obj.montoPagar;
            }
            montoFinal = obj.montoPagar + mora;

            ViewData["Message"] = "El Pago final es de " + montoFinal;

            return View("Index");
        }
    }
}
