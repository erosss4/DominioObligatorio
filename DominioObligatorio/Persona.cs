using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public abstract class Persona : IValidable
    {
        private string _cedula;
        private string _nombre;
        private string _email;
        private string _telefono;
        private string _contrasenia;

        private List<Cuenta> _cuentas = new List<Cuenta>();

        public Persona(string cedula, string nombre, string email, string telefono, string contrasenia)
        {
            _cedula = cedula;
            _nombre = nombre;
            _email = email;
            _telefono = telefono;
            _contrasenia = contrasenia;
        }

        public string Cedula
        {
            get { return _cedula; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Telefono
        {
            get { return _telefono; }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
        }

        public List<Cuenta> Cuentas
        {
            get { return _cuentas; }
        }

        public void AgregarCuenta(Cuenta c)
        {
            if (c == null)
                throw new Exception("La cuenta no puede ser nula");
            c.Validar();
            _cuentas.Add(c);
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_cedula))
                throw new Exception("La cédula no puede ser vacía");

            if (string.IsNullOrEmpty(_nombre))
                throw new Exception("El nombre no puede ser vacío");

            if (string.IsNullOrEmpty(_email) || !_email.Contains("@"))
                throw new Exception("Email inválido");

            if (string.IsNullOrEmpty(_telefono))
                throw new Exception("El teléfono no puede ser vacío");

            if (string.IsNullOrEmpty(_contrasenia))
                throw new Exception("La contraseña no puede ser vacía");
        }

        public override bool Equals(object? obj)
        {
            Persona p = obj as Persona;

            return p != null && _cedula == p._cedula;
        }

        public override string ToString()
        {
            return $"{_cedula} - {_nombre}";
        }
        public abstract string ObtenerRol();
        
    }
}