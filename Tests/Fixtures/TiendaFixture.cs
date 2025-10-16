
using EClases;

namespace EFixtures;

public class TiendaFixture : IDisposable
{
    public Tienda tiendaDePrueba { get; }
    public double TotalDePruebaDelCarrito { get; }

    public TiendaFixture()
    {
        tiendaDePrueba = new Tienda();
        tiendaDePrueba.agregarProducto("Teclado", 15000, "Es un teclado");
        tiendaDePrueba.agregarProducto("Procesador", 100000, "Es un procesador");
        tiendaDePrueba.agregarProducto("Monitor", 200000, "Es un monitor");

        TotalDePruebaDelCarrito = 15000 + (100000 * 0.85) + 200000;
    }

    public void Dispose() {}
}