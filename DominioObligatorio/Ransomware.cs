using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Ransomware : Incidente
    {
        private bool _datosEncriptados;
        private bool _huboExfiltracion;

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
            _datosEncriptados = datosEncriptados;
            _huboExfiltracion = huboExfiltracion;
        }

        public override string ToString()
        {
            return $"RANSOMWARE - {Descripcion}";
        }

        // Se aplica Polimorfismo
        public override int CalcularSeveridad()
        {
            int severidad = base.CalcularSeveridad();
            if (_datosEncriptados) 
                severidad += 20;
            if (_huboExfiltracion)
                severidad += 25;
            if(Activo.TieneBackup) 
                severidad -= 15;
            if (severidad > 100)
                severidad = 100;
            return severidad;
        }
    }
}
