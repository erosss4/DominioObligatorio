using System.Collections.Generic;
namespace DominioObligatorio.Ordenadores;

public class IncidentesPorSeveridad : IComparer<Incidente>
    {
        public int Compare(Incidente? x, Incidente? y)
        {
            //Descendente..
            return y.CalcularSeveridad().CompareTo(x.CalcularSeveridad());
        }
    }