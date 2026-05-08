using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Activo : IValidable
    {
        private static int contadorPC = 1;
        private static int contadorSERVER = 1;
        private static int contadorMOVIL = 1;
        private string codigo;
        private string nombre;
        private TipoActivo tipoActivo;
        private int criticidad;
        private bool tieneBackup;
        private Cuenta cuentaResponsable;
        public Activo(string nombre, TipoActivo tipoActivo, int criticidad, bool tieneBackup, Cuenta cuentaResponsable)
        {
            this.nombre = nombre;
            this.tipoActivo = tipoActivo;
            this.criticidad = criticidad;
            this.tieneBackup = tieneBackup;
            this.cuentaResponsable = cuentaResponsable;
            codigo = GenerarCodigo();
        }
        private string GenerarCodigo()
        {
            int numero = 0;

            if (tipoActivo == TipoActivo.PC)
                numero = contadorPC++;
            else if (tipoActivo == TipoActivo.SERVER)
                numero = contadorSERVER++;
            else
                numero = contadorMOVIL++;

            return tipoActivo + numero.ToString("D4");
        }
        public string Codigo
        {
            get { return codigo; }
        }
        public Cuenta CuentaResponsable
        {
            get { return cuentaResponsable; }
        }
        public bool TieneBackup
        {
            get { return tieneBackup; }
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("Nombre inválido");
            if (criticidad < 1 || criticidad > 5)
                throw new Exception("Criticidad inválida");
            if (cuentaResponsable == null)
                throw new Exception("Debe tener cuenta responsable");
        }
        public override string ToString()
        {
            return codigo + " - " + nombre;
        }
    }
}
