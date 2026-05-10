using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public abstract class Incidente : IValidable
    {
        private int _id;
        private DateTime _fechaReportado;
        private string _descripcion;
        private EstadoIncidente _estado;
        private int _impacto;
        private int _probabilidad;
        private Activo _activo;

        private static int s_ultId = 1;

        public Incidente(DateTime fechaReportado, string descripcion, EstadoIncidente estado, int impacto, int probabilidad, Activo activo)
        {
            _id = s_ultId;
            s_ultId++;

            _fechaReportado = fechaReportado;
            _descripcion = descripcion;
            _estado = estado;
            _impacto = impacto;
            _probabilidad = probabilidad;
            _activo = activo;
            Validar();
        }

        public int Id
        {
            get { return _id; }
        }

        public DateTime FechaReportado
        {
            get { return _fechaReportado; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
        }

        public EstadoIncidente Estado
        {
            get { return _estado; }
        }

        public int Impacto
        {
            get { return _impacto; }
        }

        public int Probabilidad
        {
            get { return _probabilidad; }
        }

        public Activo Activo
        {
            get { return _activo; }
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(_descripcion))
                throw new Exception("Descripción inválida");

            if (_impacto < 1 || _impacto > 5)
                throw new Exception("Impacto inválido");

            if (_probabilidad < 1 || _probabilidad > 5)
                throw new Exception("Probabilidad inválida");

            if (_activo == null)
                throw new Exception("Activo inválido");
        }

        public override string ToString()
        {
            return $"{_id} - {_descripcion}";
        }
    }
}