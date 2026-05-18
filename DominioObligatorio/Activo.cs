using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Activo : IValidable
    {
        private string _codigo;
        private string _nombre;
        private TipoActivo _tipoActivo;
        private int _criticidad;
        private bool _tieneBackup;

        private static int _contadorPC = 1;
        private static int _contadorSERVER = 1;
        private static int _contadorMOVIL = 1;

        public Activo(string nombre, TipoActivo tipoActivo, int criticidad, bool tieneBackup)
        {
            _nombre = nombre;
            _tipoActivo = tipoActivo;
            _criticidad = criticidad;
            _tieneBackup = tieneBackup;
            _codigo = GenerarCodigo();
        }

        public string Codigo
        {
            get { return _codigo; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public TipoActivo TipoActivo
        {
            get { return _tipoActivo; }
        }

        public int Criticidad
        {
            get { return _criticidad; }
        }

        public bool TieneBackup
        {
            get { return _tieneBackup; }
        }
        
        // Se genera un codigo autoincremental unico por cada tipo de Activo.
        private string GenerarCodigo()
        {
            int numero = 0;

            if (_tipoActivo == TipoActivo.PC)
                numero = _contadorPC++;
            else if (_tipoActivo == TipoActivo.SERVER)
                numero = _contadorSERVER++;
            else
                numero = _contadorMOVIL++;

            return _tipoActivo + numero.ToString("D4");
        }
        
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre))
                throw new Exception("Nombre inválido");
            if (_criticidad < 1 || _criticidad > 5)
                throw new Exception("Criticidad inválida");
        }
        public override string ToString()
        {
            return _codigo + " - " + _nombre;
        }
    }
}
