using DominioObligatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DominioObligatorio
{
    public class Cuenta : IValidable
    {
        private int _codigoUsuario;
        private bool _mfaHabilitado;
        private DateTime _fechaUltimoCambioContrasenia;
        private static int s_ultCodigo = 1;

        private List<Activo> _activos = new List<Activo>();

        public Cuenta(bool mfaHabilitado, DateTime fechaUltimoCambioContrasenia)
        {
            _codigoUsuario = s_ultCodigo;
            s_ultCodigo++;

            _mfaHabilitado = mfaHabilitado;
            _fechaUltimoCambioContrasenia = fechaUltimoCambioContrasenia;
        }

        public int CodigoUsuario
        {
            get { return _codigoUsuario; }
        }

        public bool MfaHabilitado
        {
            get { return _mfaHabilitado; }
        }

        public DateTime FechaUltimoCambioContrasenia
        {
            get { return _fechaUltimoCambioContrasenia; }
        }

        public List<Activo> Activos
        {
            get { return _activos; }
        }

        public void AgregarActivo(Activo a)
        {
            if (a == null)
                throw new Exception("El activo no puede ser nulo");

            _activos.Add(a);
        }

        public void Validar()
        {
            if (_fechaUltimoCambioContrasenia == new DateTime())
                throw new Exception("Fecha inválida");
        }

        public override string ToString()
        {
            return $"Cuenta {_codigoUsuario}";
        }
    }
}
