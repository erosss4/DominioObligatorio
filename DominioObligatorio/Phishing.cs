using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Phishing : Incidente
    {
        private string canal;
        private bool entregoCredenciales;
        private bool transferenciaDatos;

        public Phishing(DateTime fechaReportado, Activo activo, string descripcion,
                        EstadoIncidente estado, int impacto, int probabilidad,
                        string canal, bool entregoCredenciales, bool transferenciaDatos)
            : base(fechaReportado, activo, descripcion, estado, impacto, probabilidad)
        {
            this.canal = canal;
            this.entregoCredenciales = entregoCredenciales;
            this.transferenciaDatos = transferenciaDatos;
        }

        public void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(canal))
                throw new Exception("El canal no puede ser vacío");
        }

        public override bool EsDePersona(Persona p)
        {
            return Activo.CuentaResponsable.Titular.Equals(p);
        }

        public override string ToString()
        {
            return "Phishing - " + base.ToString();
        }
    }
}
