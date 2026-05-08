using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Sistema
    {
        private List<Persona> personas = new List<Persona>();
        private List<Cuenta> cuentas = new List<Cuenta>();
        private List<Activo> activos = new List<Activo>();
        public void CrearPersona(Persona p)
        {
            if (p == null)
                throw new Exception("Persona nula");
            p.Validar();
            if (personas.Contains(p))
                throw new Exception("Ya existe persona con esa cédula");
            personas.Add(p);
        }

        public List<Persona> ObtenerPersonasConActivo()
        {
            List<Persona> resultado = new List<Persona>();
            foreach (Activo a in activos)
            {
                Persona p = a.CuentaResponsable.Titular;
                if (!resultado.Contains(p))
                {
                    resultado.Add(p);
                }
            }
            return resultado;
        }
        public List<Activo> ObtenerActivosDePersona(Persona p)
        {
            List<Activo> lista = new List<Activo>();
            foreach (Activo a in activos)
            {
                if (a.CuentaResponsable.Titular.Equals(p))
                {
                    lista.Add(a);
                }
            }
            return lista;
        }
        public List<Activo> ActivosSinBackup()
        {
            List<Activo> lista = new List<Activo>();
            foreach (Activo a in activos)
            {
                if (!a.TieneBackup)
                    lista.Add(a);
            }
            return lista;
        }
    }
}
