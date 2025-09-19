namespace IngSoftTP1;

using EFixtures;

// Esto es un lio pero bueno, esta clase que se hereda al principio
// es una clase inherente de xUnit, indica a PruebasProducto
// que las pruebas se van a hacer usando un fixture
public class PruebasProducto : IClassFixture<ProductoFixture>
{
    private readonly ProductoFixture _productoFixture;
    public PruebasProducto(ProductoFixture productoFixture)
    {
        _productoFixture = productoFixture;
    }

    [Fact]
    public void ProbarProduct()
    {
        Assert.Equal("Teclado", _productoFixture.productoDePrueba.Nombre);
        Assert.Equal(15000, _productoFixture.productoDePrueba.Precio);
        Assert.Equal("Es un teclado", _productoFixture.productoDePrueba.Descripcion);
    }

    [Fact]
    public void ProbaraActualizarPrecio()
    {
        // cuando se ingresa un valor correcto
        bool confirmacion = _productoFixture.productoDePrueba.ActualizarPrecio(20000);
        Assert.True(confirmacion);
        Assert.Equal(20000, _productoFixture.productoDePrueba.Precio);

        // cuando se ingresa 0
        confirmacion = _productoFixture.productoDePrueba.ActualizarPrecio(0);
        Assert.False(confirmacion);
        Assert.Equal(20000, _productoFixture.productoDePrueba.Precio);

        // cuando se ingresa un valor negativo
        confirmacion = _productoFixture.productoDePrueba.ActualizarPrecio(-20000);
        Assert.False(confirmacion);
        Assert.Equal(20000, _productoFixture.productoDePrueba.Precio);
    }
}
