using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Operador : Persona
    {
        public Operador(string cedula, string nombre, string email, string telefono, string password)
            : base(cedula, nombre, email, telefono, password)
        {
        }

        public override string ObtenerRol()
        {
            return "OPERADOR";
        }
    }
}
