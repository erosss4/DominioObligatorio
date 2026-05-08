using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Phishing : Incidente
    {
        private string canal;
        private bool entregoCredenciales;
        private bool huboTransferenciaDatos;

        public Phishing(DateTime fechaReportado,
                         string descripcion,
                         EstadoIncidente estado,
                         int impacto,
                         int probabilidad,
                         Activo activo,
                         string canal,
                         bool entregoCredenciales,
                         bool huboTransferenciaDatos)
            : base(fechaReportado, descripcion, estado, impacto, probabilidad, activo)
        {
            this.canal = canal;
            this.entregoCredenciales = entregoCredenciales;
            this.huboTransferenciaDatos = huboTransferenciaDatos;
        }

        public override void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(canal))
                throw new Exception("El canal no puede ser vacío");
        }

        public override string ToString()
        {
            return $"PHISHING - {Descripcion}";
        }
    }
}
