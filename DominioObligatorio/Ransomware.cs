using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Ransomware : Incidente
    {
        private bool datosEncriptados;
        private bool exfiltracion;

        public Ransomware(DateTime fechaReportado, Activo activo, string descripcion,
                          EstadoIncidente estado, int impacto, int probabilidad,
                          bool datosEncriptados, bool exfiltracion)
            : base(fechaReportado, activo, descripcion, estado, impacto, probabilidad)
        {
            this.datosEncriptados = datosEncriptados;
            this.exfiltracion = exfiltracion;
        }

        public void Validar()
        {
            base.Validar();
        }

        public override bool EsDePersona(Persona p)
        {
            return Activo.CuentaResponsable.Titular.Equals(p);
        }

        public override string ToString()
        {
            return "Ransomware - " + base.ToString();
        }
    }
}
