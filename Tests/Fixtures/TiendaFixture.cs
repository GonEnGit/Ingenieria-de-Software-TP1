
using EClases;

namespace EFixtures;

public class TiendaFixture : IDisposable
{
    public Tienda tiendaDePrueba { get; }
    public TiendaFixture()
    {
        tiendaDePrueba = new Tienda();
        tiendaDePrueba.agregarProducto("Teclado", 15000, "Es un teclado");
    }

    public void Dispose() {}
}