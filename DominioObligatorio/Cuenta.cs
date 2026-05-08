using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Cuenta : IValidable
    {
        private int codigoUsuario;
        private bool mfaHabilitado;
        private DateTime fechaUltimoCambioContrasenia;

        private static int ultCodigo = 1;

        private List<Activo> activos = new List<Activo>();

        public Cuenta(bool mfaHabilitado, DateTime fechaUltimoCambioContrasenia)
        {
            codigoUsuario = ultCodigo;
            ultCodigo++;

            this.mfaHabilitado = mfaHabilitado;
            this.fechaUltimoCambioContrasenia = fechaUltimoCambioContrasenia;
        }

        public int CodigoUsuario
        {
            get { return codigoUsuario; }
        }

        public bool MfaHabilitado
        {
            get { return mfaHabilitado; }
        }

        public DateTime FechaUltimoCambioContrasenia
        {
            get { return fechaUltimoCambioContrasenia; }
        }

        public List<Activo> Activos
        {
            get { return activos; }
        }

        public void AgregarActivo(Activo a)
        {
            if (a == null)
                throw new Exception("El activo no puede ser nulo");

            activos.Add(a);
        }

        public void Validar()
        {
            if (fechaUltimoCambioContrasenia == new DateTime())
                throw new Exception("Fecha inválida");
        }

        public override string ToString()
        {
            return $"Cuenta {codigoUsuario}";
        }
    }
}
