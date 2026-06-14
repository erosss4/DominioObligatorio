using DominioObligatorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class ActivosController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewBag.Activos = Sistema.Instancia.ObtenerActivos();
        return View();
    }
}