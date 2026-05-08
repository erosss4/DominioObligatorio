using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Persona : IValidable
    {
        private string cedula;
        private string nombre;
        private string email;
        private string telefono;
        public Persona(string cedula, string nombre, string email, string telefono)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.email = email;
            this.telefono = telefono;
        }
        public string Cedula
        {
            get { return cedula; }
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(cedula))
                throw new Exception("La cédula no puede ser vacía");
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("El nombre no puede ser vacío");
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                throw new Exception("Email inválido");
            if (string.IsNullOrEmpty(telefono))
                throw new Exception("Teléfono inválido");
        }
        public override bool Equals(object? obj)
        {
            return obj is Persona p && cedula == p.cedula;
        }
        public override string ToString()
        {
            return nombre + " - " + cedula;
        }
    }
}

