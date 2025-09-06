
namespace IngSoftTP1;

using EClases;

public class UnitTest1
{
    [Fact]
    public void ProbarProduct()
    {
        Producto prueba = new Producto();

        prueba.Nombre = "Mouse";
        prueba.Precio = 15000;
        prueba.Descripcion = "Mouse marca RedDragon";

        Assert.Equal("Mouse", prueba.Nombre);           // Si cambias alguno de estos valores te daria un error
        Assert.Equal(15000, prueba.Precio);
        Assert.Equal("Mouse marca RedDragon", prueba.Descripcion);
    }

    [Fact]
    public void ProbarAgregarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        Assert.Single(tienda.Inventario);               // verifica que hay 1 solo producto en el inventario
        Assert.Equal("Mouse", tienda.Inventario[0].Nombre);
    }

    [Fact]
    public void ProbarBuscarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        Producto resultado = tienda.buscarProducto("Mouse");

        Assert.NotNull(resultado);                  // controla si existe el producto
        Assert.Equal("Mouse", resultado.Nombre);      // controla el nombre
        Assert.Equal(15000, resultado.Precio);       // controla el precio
    }

    [Fact]
    public void ProbarEliminarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        tienda.borrarProducto("Mouse");
        Assert.Empty(tienda.Inventario);
    }
}
