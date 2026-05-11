using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Phishing : Incidente
    {
        private string _canal;
        private bool _entregoCredenciales;
        private bool _huboTransferenciaDatos;

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
            _canal = canal;
            _entregoCredenciales = entregoCredenciales;
            _huboTransferenciaDatos = huboTransferenciaDatos;
        }

        public override void Validar()
        {
            base.Validar();

            if (string.IsNullOrEmpty(_canal))
                throw new Exception("El canal no puede ser vacío");
        }

        public override string ToString()
        {
            return $"PHISHING - {Descripcion}";
        }
    }
}
