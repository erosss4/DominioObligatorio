using DominioObligatorio;

namespace ConsoleAppObligatorio
{
    internal class Program
    {
        static Sistema miSistema =  Sistema.Instancia;

        static void Main(string[] args)
        {

            string opcion = "";

            while (opcion != "0")
            {
                MostrarMenu();

                Console.Write("Ingrese una opción -> ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        OpcionPersonasYActivos();
                        PressToContinue();
                        break;

                    case "2":
                        OpcionIncidentesPersona();
                        PressToContinue();
                        break;

                    case "3":
                        OpcionAltaPersona();
                        PressToContinue();
                        break;

                    case "4":
                        OpcionActivosSinBackup();
                        PressToContinue();
                        break;

                    case "0":
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        MostrarError("ERROR: Opción inválida");
                        PressToContinue();
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("===== MENÚ =====");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("1 - Listar personas y activos");
            Console.WriteLine("2 - Ver incidentes de una persona");
            Console.WriteLine("3 - Alta de persona");
            Console.WriteLine("4 - Activos sin backup");
            Console.WriteLine("0 - Salir");

            Console.WriteLine();
        }

        static void OpcionPersonasYActivos()
        {
            MostrarCabezal("=== PERSONAS Y SUS ACTIVOS ===");

            foreach (Persona p in miSistema.ObtenerPersonas())
            {
                Console.WriteLine(p);

                foreach (Activo a in miSistema.ObtenerActivosDePersona(p))
                {
                    Console.WriteLine("  -> " + a);
                }

                Console.WriteLine("====================");
            }
        }
        
        // Se invoca al metodo CalcularSeveridad() y se hace el WriteLine del resultado para comprobar el funcionamiento del polimorfismo.
        static void OpcionIncidentesPersona()
        {
            MostrarCabezal("=== INCIDENTES DE UNA PERSONA ===");

            try
            {
                string cedula = LeerTexto("Ingrese cédula: ");

                Persona encontrada = null;

                foreach (Persona p in miSistema.ObtenerPersonas())
                {
                    if (p.Cedula == cedula)
                    {
                        encontrada = p;
                        break;
                    }
                }

                if (encontrada == null)
                    throw new Exception("Persona no encontrada");

                List<Incidente> incidentes =
                    miSistema.ObtenerIncidentesDePersona(encontrada);

                if (incidentes.Count == 0)
                {
                    Console.WriteLine("No tiene incidentes");
                }
                else
                {
                    foreach (Incidente i in incidentes)
                    {
                        Console.WriteLine(i + " :: Severidad: " + i.CalcularSeveridad());
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void OpcionAltaPersona()
        {
            MostrarCabezal("=== ALTA PERSONA ===");

            try
            {
                string cedula = LeerTexto("Ingrese cédula: ");
                string nombre = LeerTexto("Ingrese nombre: ");
                string email = LeerTexto("Ingrese email: ");
                string telefono = LeerTexto("Ingrese teléfono: ");
                string contrasenia = LeerTexto("Ingrese contraseña: ");

                Persona p = new Persona(cedula, nombre, email, telefono, contrasenia, Rol.OPERADOR);

                miSistema.CrearPersona(p);

                MostrarExito("Persona creada correctamente");
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        static void OpcionActivosSinBackup()
        {
            MostrarCabezal("=== ACTIVOS SIN BACKUP ===");

            List<Activo> activos = miSistema.ActivosSinBackup();

            if (activos.Count == 0)
            {
                Console.WriteLine("No hay activos sin backup");
            }
            else
            {
                foreach (Activo a in activos)
                {
                    Console.WriteLine(a);
                }
            }
        }

        static void PressToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

        static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);

            return Console.ReadLine();
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(mensaje);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MostrarExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(mensaje);

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static void MostrarCabezal(string mensaje)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(mensaje);

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();
        }
    }
}
