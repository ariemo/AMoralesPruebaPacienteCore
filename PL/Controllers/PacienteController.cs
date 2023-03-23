using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class PacienteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll(ML.Paciente paciente)
        {
           ML.Result result = BL.Paciente.GetAll();
            
            if (result.Correct)
            {
                paciente.Pacientes = result.Objects;
                
            }
            return View(paciente);
        }
    }
}
