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
        
        // 4B
        public List<Incidente> ObtenerIncidentesDePersona(Persona p)
        {
            if (p == null) throw new Exception("La persona no puede ser nula");

            List<Incidente> resultado = new List<Incidente>();
            foreach (Incidente i in _incidentes)
            {
                if (i.EsDePersona(p))
                    resultado.Add(i);
            }
            return resultado;
        }
        
        // 4C
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

        //4D
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
            // =========================
            // PERSONAS
            // =========================

            Persona p1 = new Persona("12345678", "Ana García", "ana@empresa.com", "099111111");
            Persona p2 = new Persona("22345678", "Carlos López", "carlos@empresa.com", "099222222");
            Persona p3 = new Persona("32345678", "María Fernández", "maria@empresa.com", "099333333");
            Persona p4 = new Persona("42345678", "Lucía Pérez", "lucia@empresa.com", "099444444");
            Persona p5 = new Persona("52345678", "Javier Silva", "javier@empresa.com", "099555555");
            Persona p6 = new Persona("62345678", "Sofía Rodríguez", "sofia@empresa.com", "099666666");
            Persona p7 = new Persona("72345678", "Martín Gómez", "martin@empresa.com", "099777777");
            Persona p8 = new Persona("82345678", "Valentina Castro", "valentina@empresa.com", "099888888");
            Persona p9 = new Persona("92345678", "Diego Torres", "diego@empresa.com", "099999999");
            Persona p10 = new Persona("10345678", "Camila Díaz", "camila@empresa.com", "098111111");

            CrearPersona(p1);
            CrearPersona(p2);
            CrearPersona(p3);
            CrearPersona(p4);
            CrearPersona(p5);
            CrearPersona(p6);
            CrearPersona(p7);
            CrearPersona(p8);
            CrearPersona(p9);
            CrearPersona(p10);

            // =========================
            // CUENTAS
            // =========================

            Cuenta c1 = new Cuenta(true, new DateTime(2025, 1, 10));
            Cuenta c2 = new Cuenta(false, new DateTime(2025, 2, 5));
            Cuenta c3 = new Cuenta(true, new DateTime(2024, 11, 15));
            Cuenta c4 = new Cuenta(false, new DateTime(2025, 3, 1));
            Cuenta c5 = new Cuenta(true, new DateTime(2025, 1, 20));
            Cuenta c6 = new Cuenta(false, new DateTime(2024, 12, 30));
            Cuenta c7 = new Cuenta(true, new DateTime(2025, 4, 8));
            Cuenta c8 = new Cuenta(true, new DateTime(2025, 5, 2));
            Cuenta c9 = new Cuenta(false, new DateTime(2025, 2, 18));
            Cuenta c10 = new Cuenta(true, new DateTime(2025, 3, 12));
            Cuenta c11 = new Cuenta(false, new DateTime(2024, 10, 22));
            Cuenta c12 = new Cuenta(true, new DateTime(2025, 1, 28));

            p1.AgregarCuenta(c1);
            p1.AgregarCuenta(c2);

            p2.AgregarCuenta(c3);
            p2.AgregarCuenta(c4);

            p3.AgregarCuenta(c5);
            p4.AgregarCuenta(c6);
            p5.AgregarCuenta(c7);
            p6.AgregarCuenta(c8);
            p7.AgregarCuenta(c9);
            p8.AgregarCuenta(c10);
            p9.AgregarCuenta(c11);
            p10.AgregarCuenta(c12);

            // =========================
            // ACTIVOS
            // =========================

            Activo a1 = new Activo("Laptop Ana", TipoActivo.PC, 3, true);
            Activo a2 = new Activo("Servidor Finanzas", TipoActivo.SERVER, 5, false);
            Activo a3 = new Activo("Celular Carlos", TipoActivo.MOVIL, 2, false);
            Activo a4 = new Activo("PC Recepción", TipoActivo.PC, 1, true);
            Activo a5 = new Activo("Servidor Backup", TipoActivo.SERVER, 4, false);
            Activo a6 = new Activo("Notebook Ventas", TipoActivo.PC, 2, true);
            Activo a7 = new Activo("Servidor RRHH", TipoActivo.SERVER, 5, true);
            Activo a8 = new Activo("Tablet Gerencia", TipoActivo.MOVIL, 3, false);
            Activo a9 = new Activo("PC Administración", TipoActivo.PC, 4, true);
            Activo a10 = new Activo("Servidor Web", TipoActivo.SERVER, 5, false);
            Activo a11 = new Activo("Celular Soporte", TipoActivo.MOVIL, 2, true);
            Activo a12 = new Activo("PC Diseño", TipoActivo.PC, 3, false);
            Activo a13 = new Activo("Servidor QA", TipoActivo.SERVER, 4, true);
            Activo a14 = new Activo("Celular Marketing", TipoActivo.MOVIL, 1, false);
            Activo a15 = new Activo("PC Laboratorio", TipoActivo.PC, 5, false);

            c1.AgregarActivo(a1);
            c1.AgregarActivo(a2);

            c2.AgregarActivo(a3);

            c3.AgregarActivo(a4);
            c3.AgregarActivo(a5);

            c4.AgregarActivo(a6);

            c5.AgregarActivo(a7);
            c6.AgregarActivo(a8);
            c7.AgregarActivo(a9);
            c8.AgregarActivo(a10);
            c9.AgregarActivo(a11);
            c10.AgregarActivo(a12);
            c11.AgregarActivo(a13);
            c12.AgregarActivo(a14);
            c12.AgregarActivo(a15);

            CrearActivo(a1);
            CrearActivo(a2);
            CrearActivo(a3);
            CrearActivo(a4);
            CrearActivo(a5);
            CrearActivo(a6);
            CrearActivo(a7);
            CrearActivo(a8);
            CrearActivo(a9);
            CrearActivo(a10);
            CrearActivo(a11);
            CrearActivo(a12);
            CrearActivo(a13);
            CrearActivo(a14);
            CrearActivo(a15);

            // =========================
            // INCIDENTES
            // =========================

            CrearIncidente(new Phishing(new DateTime(2025, 1, 5), "Correo falso banco", EstadoIncidente.CERRADO, 3, 2, a1, "email", true, false));
            CrearIncidente(new Phishing(new DateTime(2025, 1, 10), "Mensaje sospechoso", EstadoIncidente.ABIERTO, 2, 3, a1, "whatsapp", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 1, 12), "Servidor cifrado", EstadoIncidente.EN_ANALISIS, 5, 5, a2, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 1, 20), "Llamada fraudulenta", EstadoIncidente.CONTENIDO, 2, 2, a3, "llamada", true, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 1, 22), "Ataque ransomware", EstadoIncidente.ABIERTO, 4, 5, a5, true, false));

            CrearIncidente(new Phishing(new DateTime(2025, 2, 1), "Email falso soporte", EstadoIncidente.CERRADO, 3, 3, a4, "email", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 2, 5), "Encriptación parcial", EstadoIncidente.EN_ANALISIS, 5, 4, a7, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 2, 8), "WhatsApp corporativo falso", EstadoIncidente.ABIERTO, 1, 2, a8, "whatsapp", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 2, 12), "Publicación de datos", EstadoIncidente.CONTENIDO, 5, 5, a10, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 2, 15), "SMS fraudulento", EstadoIncidente.CERRADO, 2, 3, a11, "sms", true, false));

            CrearIncidente(new Phishing(new DateTime(2025, 2, 20), "Red social falsa", EstadoIncidente.ABIERTO, 3, 4, a12, "redes sociales", false, true));
            CrearIncidente(new Ransomware(new DateTime(2025, 2, 22), "Servidor comprometido", EstadoIncidente.EN_ANALISIS, 5, 5, a13, true, false));
            CrearIncidente(new Phishing(new DateTime(2025, 3, 1), "Correo RRHH falso", EstadoIncidente.CONTENIDO, 2, 2, a14, "email", true, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 3, 3), "Datos cifrados", EstadoIncidente.CERRADO, 4, 4, a15, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 3, 5), "Intento phishing Teams", EstadoIncidente.ABIERTO, 2, 4, a2, "teams", false, false));

            CrearIncidente(new Ransomware(new DateTime(2025, 3, 8), "Ataque servidor web", EstadoIncidente.EN_ANALISIS, 5, 5, a10, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 3, 10), "Llamada soporte falsa", EstadoIncidente.CONTENIDO, 1, 2, a3, "llamada", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 3, 12), "Exfiltración confirmada", EstadoIncidente.ABIERTO, 5, 5, a5, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 3, 15), "Correo falso IT", EstadoIncidente.CERRADO, 3, 2, a6, "email", true, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 3, 18), "Ransomware notebook", EstadoIncidente.EN_ANALISIS, 4, 3, a9, true, false));

            CrearIncidente(new Phishing(new DateTime(2025, 3, 20), "SMS banco", EstadoIncidente.ABIERTO, 2, 2, a8, "sms", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 3, 22), "Servidor bloqueado", EstadoIncidente.CONTENIDO, 5, 4, a13, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 3, 25), "WhatsApp falso gerente", EstadoIncidente.CERRADO, 1, 3, a11, "whatsapp", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 3, 27), "Cifrado masivo", EstadoIncidente.ABIERTO, 5, 5, a2, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 4, 1), "Red social falsa", EstadoIncidente.EN_ANALISIS, 2, 3, a4, "redes sociales", true, false));

            CrearIncidente(new Ransomware(new DateTime(2025, 4, 3), "Exfiltración datos clientes", EstadoIncidente.CONTENIDO, 5, 5, a7, true, true));
            CrearIncidente(new Phishing(new DateTime(2025, 4, 5), "Correo phishing interno", EstadoIncidente.CERRADO, 3, 3, a1, "email", false, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 4, 8), "Servidor QA afectado", EstadoIncidente.ABIERTO, 4, 5, a13, true, false));
            CrearIncidente(new Phishing(new DateTime(2025, 4, 10), "Intento robo credenciales", EstadoIncidente.EN_ANALISIS, 2, 4, a14, "email", true, false));
            CrearIncidente(new Ransomware(new DateTime(2025, 4, 12), "Ataque final", EstadoIncidente.CERRADO, 5, 5, a15, true, true));
        }

        
    }

}