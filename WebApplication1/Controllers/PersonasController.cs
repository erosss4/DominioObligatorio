using DominioObligatorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class PersonasController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new Exception("Debe ingresar email");

                if (string.IsNullOrEmpty(pass))
                    throw new Exception("Debe ingresar contraseña");

                Persona p = Sistema.Instancia.Login(email, pass);

                HttpContext.Session.SetString("Email", p.Email);
                HttpContext.Session.SetString("Rol", p.MiRol.ToString());
                HttpContext.Session.SetString("Nombre", p.Nombre);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Perfil()
        {
            if (HttpContext.Session.GetString("Email") == null)
                return View("Noautorizado");

            ViewBag.Persona =
                Sistema.Instancia.BuscarPersonaPorEmail(
                    HttpContext.Session.GetString("Email"));

            return View();
        }

        [HttpPost]
        public IActionResult Registro(string cedula, string nombre, string email, string telefono, string contrasenia)
        {
            try
            {
                Persona p = new Persona(cedula, nombre, email, telefono,  contrasenia, Rol.OPERADOR);
                Sistema.Instancia.CrearPersona(p);
                
                //Dejamos logueada a la persona
                HttpContext.Session.SetString("Email", p.Email);
                HttpContext.Session.SetString("Rol", p.MiRol.ToString());
                HttpContext.Session.SetString("Nombre", p.Nombre);
                
                return  RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                //Mantenemos los valores del form en caso de error
                ViewBag.Cedula = cedula;
                ViewBag.Nombre = nombre;
                ViewBag.Email = email;
                ViewBag.Telefono = telefono;
                
                return View();
            }
        }
        
    }
}
