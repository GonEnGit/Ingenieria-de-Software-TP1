
namespace IngSoftTP1;

using EClases;

public class UnitTest1
{
    [Fact]
    public void ProbarProduct()
    {
        Producto prueba = new Producto("Mouse",15000, "Mouse marca RedDragon");

        Assert.NotNull(prueba);                         // Controla que el objeto no sea nulo
        Assert.Equal("Mouse", prueba.Nombre);           // Si cambias alguno de estos valores te daria un error
        Assert.Equal(15000, prueba.Precio);
        Assert.Equal("Mouse marca RedDragon", prueba.Descripcion);
    }

    [Fact]
    public void ProbarAgregarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        Assert.Single(tienda.Inventario);                                   // verifica que hay 1 solo producto en el inventario
        Assert.Contains(tienda.Inventario, p => p.Nombre == "Mouse" 
                                                    && p.Precio == 15000    // verifica que sea el objeto agregado
                                                        && p.Descripcion == "Mouse marca RedDragon");
    }

    [Fact]
    public void ProbarBuscarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        Producto resultado = tienda.buscarProducto("Mouse");

        Assert.NotNull(resultado);                   // controla si existe el producto
        Assert.Equal("Mouse", resultado.Nombre);     // controla el nombre
        Assert.Equal(15000, resultado.Precio);       // controla el precio
    }

    [Fact]
    public void ProbarEliminarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Es un Mouse");
        tienda.agregarProducto("Teclado", 25000, "Es un teclado");

        tienda.borrarProducto("Mouse");
        Assert.DoesNotContain(tienda.Inventario, p => p.Nombre == "Mouse"); 
        Assert.NotEmpty(tienda.Inventario); // Verifica que el inventario no este vacio
    }
}
