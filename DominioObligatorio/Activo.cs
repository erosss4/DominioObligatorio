using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Activo : IValidable
    {
        private string codigo;
        private string nombre;
        private TipoActivo tipoActivo;
        private int criticidad;
        private bool tieneBackup;

        private static int contadorPC = 1;
        private static int contadorSERVER = 1;
        private static int contadorMOVIL = 1;

        public Activo(string nombre, TipoActivo tipoActivo, int criticidad, bool tieneBackup)
        {
            this.nombre = nombre;
            this.tipoActivo = tipoActivo;
            this.criticidad = criticidad;
            this.tieneBackup = tieneBackup;
            codigo = GenerarCodigo();
            Validar();
        }

        public string Codigo
        {
            get { return codigo; }
        }

        public string Nombre
        {
            get { return nombre; }
        }

        public TipoActivo TipoActivo
        {
            get { return tipoActivo; }
        }

        public int Criticidad
        {
            get { return criticidad; }
        }

        public bool TieneBackup
        {
            get { return tieneBackup; }
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
        
        public void Validar()
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("Nombre inválido");
            if (criticidad < 1 || criticidad > 5)
                throw new Exception("Criticidad inválida");
        }
        public override string ToString()
        {
            return codigo + " - " + nombre;
        }
    }
}
