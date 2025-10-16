
using EClases;
using EFixtures;
using EInterfaces;

using Moq;
using Xunit;

public class PruebaCalcularTotalCarrito : IClassFixture<TiendaFixture>
{
    private readonly TiendaFixture _tiendaFixture;

    public PruebaCalcularTotalCarrito(TiendaFixture tiendaFixture)
    {
        _tiendaFixture = tiendaFixture;
    }

// ciudado te estabas confundiendo:
//      tu tienda tiene un inventario y lo que se crea en el fixture es eso
//      ahora tenes que probar el carrito, es una lista distinta al inventario
    [Fact]
    public void ProbarCalcularTotalCarrito_ProductosExistentes()
    {
        double total;
    // esto no lo usaste mucho en taller pero podes armar listas
    // como si estuvieras definiendo funciones, mas facil y rapido
    // y de paso no hace falta usar carrito.add()
        List<Producto> carrito = new List<Producto>()
        {
            _tiendaFixture.tiendaDePrueba.buscarProducto("Teclado"),
            _tiendaFixture.tiendaDePrueba.buscarProducto("Procesador"),
            _tiendaFixture.tiendaDePrueba.buscarProducto("Monitor")
        };  // aquí integras la funcion buscarProducto

        total = _tiendaFixture.tiendaDePrueba.CalcularTotalCarrito(carrito);

    // el fixture aparentemente no tiene que ser igual que la clase que usa
    // sabiendo eso, podes agregar al fixture una variable con el total del carrito
        Assert.Equal(_tiendaFixture.TotalDePruebaDelCarrito, total);
    }

    [Fact]
    public void ProbarCalcularTotalCarrito_CarritoVacio()
    {
        double total;
        List<Producto> carritoVacio = new List<Producto>();

        total = _tiendaFixture.tiendaDePrueba.CalcularTotalCarrito(carritoVacio);

        Assert.Equal(0, total);
    }

    [Fact]
    public void ProbarCalcularTotalCarrito_ProductoInexistente()
    {
        double total;

        var mockBuscadorProductos = new Mock<IBuscadorProductos>();
        mockBuscadorProductos.Setup(p => p.BuscarProductoInterface("Inexistente")).Returns((Producto)null);

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        List<Producto> carrito = new List<Producto>()
        {
            new Producto("Inexistente", 0, "No existe")
        };

        total = tienda.CalcularTotalCarrito(carrito);
        Assert.Equal(0, total);
    }
    // esta dio problemas... parece que usar la funcion buscarProdcuto no va a funcionar
    // la idea es que la funcion devuelve un objeto Producto que está diseñado para "No existir"
    // pero eso haria que la funcion CalcularTotalCarrito intente buscar un producto con el nombre 
    // "Producto no escontrado" y te termina dando un error
    // la solucion que encontraste fue usar un mock para saltear el uso de la funcion
}