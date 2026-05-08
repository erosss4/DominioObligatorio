using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public abstract class Incidente : IValidable
    {
        private int id;
        private DateTime fechaReportado;
        private string descripcion;
        private EstadoIncidente estado;
        private int impacto;
        private int probabilidad;
        private Activo activo;

        private static int ultId = 1;

        public Incidente(DateTime fechaReportado,
                         string descripcion,
                         EstadoIncidente estado,
                         int impacto,
                         int probabilidad,
                         Activo activo)
        {
            id = ultId;
            ultId++;

            this.fechaReportado = fechaReportado;
            this.descripcion = descripcion;
            this.estado = estado;
            this.impacto = impacto;
            this.probabilidad = probabilidad;
            this.activo = activo;
        }

        public int Id
        {
            get { return id; }
        }

        public DateTime FechaReportado
        {
            get { return fechaReportado; }
        }

        public string Descripcion
        {
            get { return descripcion; }
        }

        public EstadoIncidente Estado
        {
            get { return estado; }
        }

        public int Impacto
        {
            get { return impacto; }
        }

        public int Probabilidad
        {
            get { return probabilidad; }
        }

        public Activo Activo
        {
            get { return activo; }
        }

        public virtual void Validar()
        {
            if (string.IsNullOrEmpty(descripcion))
                throw new Exception("La descripción no puede ser vacía");

            if (impacto < 1 || impacto > 5)
                throw new Exception("Impacto inválido");

            if (probabilidad < 1 || probabilidad > 5)
                throw new Exception("Probabilidad inválida");

            if (activo == null)
                throw new Exception("El activo no puede ser nulo");
        }

        public bool EsDePersona(Persona p)
        {
            foreach (Cuenta c in p.Cuentas)
            {
                foreach (Activo a in c.Activos)
                {
                    if (a == activo)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public override string ToString()
        {
            return $"{id} - {estado} - {descripcion}";
        }
    }
}
