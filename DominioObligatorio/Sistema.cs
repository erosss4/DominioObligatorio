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
        
       
    }

}