namespace DominioObligatorio.Ordenadores;

public class ActivosPorCodigo : IComparer<Activo>
{
    public int Compare(Activo? x, Activo? y)
    {
        return x.Codigo.CompareTo(y.Codigo);
    }
}