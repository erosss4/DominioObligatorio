using DominioObligatorio;

namespace ConsoleAppObligatorio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sis = new Sistema();
            sis.Precargar();

            Console.WriteLine("=== PERSONAS Y SUS ACTIVOS ===");

            foreach (Persona p in sis.ObtenerPersonas())
            {
                Console.WriteLine(p);

                foreach (Activo a in sis.ObtenerActivosDePersona(p))
                {
                    Console.WriteLine("  -> " + a);
                }

                Console.WriteLine("====================");
            }

            Console.WriteLine("=== ACTIVOS SIN BACKUP ===");
            foreach (Activo a in sis.ActivosSinBackup())
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}
