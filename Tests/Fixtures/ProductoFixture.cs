
using EClases;

namespace EFixtures;

public class ProductoFixture : IDisposable
{
    public Producto productoDePrueba { get; }
    public ProductoFixture()
    {
        productoDePrueba = new Producto();

        productoDePrueba.Nombre = "Teclado";
        productoDePrueba.Precio = 15000;
        productoDePrueba.Descripcion = "Es un teclado";
    }

    public void Dispose() {}
}