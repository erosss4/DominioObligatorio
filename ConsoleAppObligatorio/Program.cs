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
            foreach (Persona p in sis.ObtenerPersonasConActivos())
            {
                Console.WriteLine(p.ToString());
                foreach (Activo a in sis.ObtenerActivosDePersona(p))
                {
                    Console.WriteLine("  -> " + a.ToString());
                }
                Console.WriteLine();
            }

            Console.WriteLine("=== ACTIVOS SIN BACKUP ===");
            foreach (Activo a in sis.ActivosSinBackup())
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}
