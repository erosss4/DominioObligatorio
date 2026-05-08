using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public abstract class Incidente : IValidable
    {
        private int id;
        private static int ultId = 1;

        private DateTime fechaReportado;
        private Activo activo;
        private string descripcion;
        private EstadoIncidente estado;
        private int impacto;
        private int probabilidad;

        public Incidente(DateTime fechaReportado, Activo activo, string descripcion,
                         EstadoIncidente estado, int impacto, int probabilidad)
        {
            id = ultId++;
            this.fechaReportado = fechaReportado;
            this.activo = activo;
            this.descripcion = descripcion;
            this.estado = estado;
            this.impacto = impacto;
            this.probabilidad = probabilidad;
        }

        public int Id
        {
            get { return id; }
        }

        public Activo Activo
        {
            get { return activo; }
        }

        public EstadoIncidente Estado
        {
            get { return estado; }
        }

        public void Validar()
        {
            if (activo == null)
                throw new Exception("El activo no puede ser nulo");

            if (string.IsNullOrEmpty(descripcion))
                throw new Exception("La descripción no puede ser vacía");

            if (impacto < 1 || impacto > 5)
                throw new Exception("Impacto inválido");

            if (probabilidad < 1 || probabilidad > 5)
                throw new Exception("Probabilidad inválida");
        }

        public abstract bool EsDePersona(Persona p);

        public override string ToString()
        {
            return "Incidente " + id + " - " + estado;
        }
    }
}
