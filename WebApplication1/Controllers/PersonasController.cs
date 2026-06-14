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

        //Para Ver Personas
        public IActionResult Index()
        {
            //Solo Admin
            if (HttpContext.Session.GetString("Rol") != Rol.ADMIN.ToString())
            {
                return View("NoAutorizado");
            }
            ViewBag.Personas = Sistema.Instancia.ObtenerPersonas();
            return View();
        }
        
        //Para Ver Cuentas solo Admin
        public IActionResult Cuentas(string cedula)
        {
            if (HttpContext.Session.GetString("Rol") != Rol.ADMIN.ToString())
            {
                return View("NoAutorizado");
            }
            Persona persona = Sistema.Instancia.BuscarPersonaPorCedula(cedula);
            ViewBag.Persona = persona;
            ViewBag.Cuentas = persona.Cuentas;
            return View();
        }
        
        //Para Ver Activos de una Cuenta solo Admin
        public IActionResult Activos(int codigoCuenta)
        {
            if (HttpContext.Session.GetString("Rol") != Rol.ADMIN.ToString())
            {
                return View("NoAutorizado");
            }
            
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];
            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];

            Cuenta cuenta = Sistema.Instancia.BuscarCuentaPorCodigo(codigoCuenta);
            ViewBag.Cuenta = cuenta;
            ViewBag.Activos = cuenta.Activos;
            return View();
        }
        
        
        [HttpPost]
        public IActionResult Desasociar(int codigoCuenta, string codigoActivo)
        {
            if (HttpContext.Session.GetString("Rol") != Rol.ADMIN.ToString())
            {
                return View("NoAutorizado");
            }

            try
            {
                Cuenta cuenta = Sistema.Instancia.BuscarCuentaPorCodigo(codigoCuenta);
                cuenta.DesasociarActivo(codigoActivo);
                TempData["Exito"] = "Activo eliminado correctamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            // Redirijo a Activos
            return RedirectToAction("Activos", new { codigoCuenta = codigoCuenta });
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
                return View("NoAutorizado");

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
