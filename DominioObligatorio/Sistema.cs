using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Sistema
    {
        private List<Persona> _personas = new List<Persona>();
        private List<Activo> _activos = new List<Activo>();
        private List<Incidente> _incidentes = new List<Incidente>();


        public void CrearActivo(Activo a)
        {
            if (a == null) throw new Exception("El activo no puede ser nulo");
            a.Validar();
            _activos.Add(a);
        }

        public void CrearIncidente(Incidente i)
        {
            if (i == null) throw new Exception("El incidente no puede ser nulo");
            i.Validar();
            _incidentes.Add(i);

        }
        
        public void CrearPersona(Persona p)
        {
            if (p == null) throw new Exception("La persona no puede ser nula");
            if (_personas.Contains(p)) throw new Exception("La cedula ya existe");
            p.Validar();
            _personas.Add(p);
        }
        
        public List<Persona> ObtenerPersonasConActivos()
        {
            return _personas;
        }
        
        public List<Activo> ObtenerActivosDePersona(Persona p)
        {
            if (p == null) throw new Exception("La persona no puede ser nula");

            List<Activo> resultado = new List<Activo>();
            foreach (Activo a in _activos)
            {
                foreach (Cuenta c in p.Cuentas)
                {
                    if (c.Activos.Contains(a))
                    {
                        resultado.Add(a);
                        break;
                    }
                }
            }
            return resultado;
        }

        public List<Activo> ActivosSinBackup()
        {
            List<Activo> resultado = new List<Activo>();
            foreach (Activo a in _activos)
            {
                if (!a.TieneBackup)
                    resultado.Add(a);
            }
            return resultado;
        }
      
        public void Precargar()
        {
            // --- PERSONAS ---
            Persona p1 = new Persona("12345678", "Ana García", "ana@empresa.com", "099111222");
            Persona p2 = new Persona("23456789", "Carlos López", "carlos@empresa.com", "099333444");
            Persona p3 = new Persona("34567890", "María Fernández", "maria@empresa.com", "099555666");

            CrearPersona(p1);
            CrearPersona(p2);
            CrearPersona(p3);

            // --- CUENTAS ---
            Cuenta c1 = new Cuenta(true, new DateTime(2025, 1, 15));
            Cuenta c2 = new Cuenta(false, new DateTime(2024, 6, 10));
            Cuenta c3 = new Cuenta(true, new DateTime(2025, 3, 20));

            p1.AgregarCuenta(c1);
            p2.AgregarCuenta(c2);
            p3.AgregarCuenta(c3);

            // --- ACTIVOS ---
            Activo a1 = new Activo("Laptop Ana", TipoActivo.PC, 3, true);
            Activo a2 = new Activo("Servidor Central", TipoActivo.SERVER, 5, false);
            Activo a3 = new Activo("Celular Carlos", TipoActivo.MOVIL, 2, false);
            Activo a4 = new Activo("PC Recepción", TipoActivo.PC, 1, true);
            Activo a5 = new Activo("Servidor Backup", TipoActivo.SERVER, 4, false);

            c1.AgregarActivo(a1);
            c2.AgregarActivo(a2);
            c2.AgregarActivo(a3);
            c3.AgregarActivo(a4);
            c3.AgregarActivo(a5);

            CrearActivo(a1);
            CrearActivo(a2);
            CrearActivo(a3);
            CrearActivo(a4);
            CrearActivo(a5);

            // --- INCIDENTES ---
            Incidente i1 = new Phishing(
                new DateTime(2025, 2, 10),
                "Correo falso de banco",
                EstadoIncidente.CERRADO,
                3, 2, a1,
                "email", true, false);

            Incidente i2 = new Ransomware(
                new DateTime(2025, 4, 5),
                "Cifrado de servidor central",
                EstadoIncidente.EN_ANALISIS,
                5, 5, a2,
                true, true);

            Incidente i3 = new Phishing(
                new DateTime(2025, 5, 1),
                "SMS fraudulento",
                EstadoIncidente.ABIERTO,
                2, 3, a3,
                "whatsapp", false, false);

            CrearIncidente(i1);
            CrearIncidente(i2);
            CrearIncidente(i3);
        }
       
    }

}