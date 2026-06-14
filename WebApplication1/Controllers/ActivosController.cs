using DominioObligatorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class ActivosController : Controller
{
    // GET
    public IActionResult Index()
    {
        //Control de Sesion para solo Operador
        if (HttpContext.Session.GetString("Rol") == null ||
            HttpContext.Session.GetString("Rol") != Rol.OPERADOR.ToString())
        {
            return View("NoAutorizado");
        }
        
        //Mostrar solo activos de persona logueada
        string email = HttpContext.Session.GetString("Email");
        Persona personaLogueada = Sistema.Instancia.BuscarPersonaPorEmail(email);
        
        ViewBag.Activos = Sistema.Instancia.ObtenerActivosDePersona(personaLogueada);
        
        return View();
    }
}