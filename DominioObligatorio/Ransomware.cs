using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Ransomware : Incidente
    {
        private bool datosEncriptados;
        private bool huboExfiltracion;

        public Ransomware(DateTime fechaReportado,
                          string descripcion,
                          EstadoIncidente estado,
                          int impacto,
                          int probabilidad,
                          Activo activo,
                          bool datosEncriptados,
                          bool huboExfiltracion)
            : base(fechaReportado, descripcion, estado, impacto, probabilidad, activo)
        {
            this.datosEncriptados = datosEncriptados;
            this.huboExfiltracion = huboExfiltracion;
        }

        public override string ToString()
        {
            return $"RANSOMWARE - {Descripcion}";
        }
    }
}
