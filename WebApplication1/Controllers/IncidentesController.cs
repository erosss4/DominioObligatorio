namespace WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using DominioObligatorio;

public class IncidentesController : Controller
{
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Rol") != Rol.ADMIN.ToString())
            return View("NoAutorizado");
        
        ViewBag.Incidentes = Sistema.Instancia.ObtenerIncidentes();
        return View();
    }
}