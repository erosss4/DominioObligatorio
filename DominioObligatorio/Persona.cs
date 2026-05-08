using DominioObligatorio.Interfaces;
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

        private List<Cuenta> cuentas = new List<Cuenta>();

        public Persona(string cedula, string nombre, string email, string telefono)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.email = email;
            this.telefono = telefono;
            Validar();
        }

        public string Cedula
        {
            get { return cedula; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Telefono
        {
            get { return telefono; }
        }

        public List<Cuenta> Cuentas
        {
            get { return cuentas; }
        }

        public void AgregarCuenta(Cuenta c)
        {
            if (c == null)
                throw new Exception("La cuenta no puede ser nula");

            cuentas.Add(c);
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
                throw new Exception("El teléfono no puede ser vacío");
        }

        public override bool Equals(object? obj)
        {
            Persona p = obj as Persona;

            return p != null && cedula == p.cedula;
        }

        public override string ToString()
        {
            return $"{cedula} - {nombre}";
        }
    }
}