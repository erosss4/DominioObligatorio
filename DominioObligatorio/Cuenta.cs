using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Cuenta : IValidable
    {
        private int codigoUsuario;
        private static int ultCodigo = 1;
        private bool mfaHabilitado;
        private DateTime fechaUltimoCambioContrasenia;
        private Persona titular;
        public Cuenta(bool mfaHabilitado, DateTime fechaUltimoCambioContrasenia, Persona titular)
        {
            codigoUsuario = ultCodigo++;
            this.mfaHabilitado = mfaHabilitado;
            this.fechaUltimoCambioContrasenia = fechaUltimoCambioContrasenia;
            this.titular = titular;
        }
        public int CodigoUsuario
        {
            get { return codigoUsuario; }
        }
        public Persona Titular
        {
            get { return titular; }
        }
        public void Validar()
        {
            if (titular == null)
                throw new Exception("La cuenta debe tener titular");
            if (fechaUltimoCambioContrasenia == DateTime.MinValue)
                throw new Exception("Fecha inválida");
        }
    }
}
