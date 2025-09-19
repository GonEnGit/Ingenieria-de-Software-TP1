
using EInterfaces;

namespace EClases;

public class buscadorProductos : IBuscadorProductos
{
    private readonly List<Producto> _inventarioInterfaz;

    public buscadorProductos(List<Producto> inventarioInterfaz)
    {
        _inventarioInterfaz = inventarioInterfaz;
    }

    public Producto BuscarProductoInterface(string nom)
    {
        return _inventarioInterfaz.FirstOrDefault(p => p.Nombre == nom);
    }
}