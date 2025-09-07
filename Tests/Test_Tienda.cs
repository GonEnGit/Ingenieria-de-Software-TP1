namespace IngSoftTP1;

using EClases;

public class PruebasTienda
{
    [Fact]
    public void ProbarAgregarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        Assert.Single(tienda.Inventario);                      // verifica que hay 1 solo producto en el inventario
        Assert.Equal("Mouse", tienda.Inventario[0].Nombre);
    }

    [Fact]
    public void ProbarBuscarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        Producto resultado = tienda.buscarProducto("Mouse");

        Assert.NotNull(resultado);                              // controla si existe el producto
        Assert.Equal("Mouse", resultado.Nombre);                // controla el nombre
        Assert.Equal(15000, resultado.Precio);                  // controla el precio
    }

    [Fact]
    public void ProbarProductoInexistente()
    {
        Tienda tienda = new Tienda();

        Producto resultado = tienda.buscarProducto("Teclado");

        Assert.NotNull(resultado);                             // porque igual devuelve un objeto
        Assert.Equal("Producto no encontrado", resultado.Nombre);
        Assert.Equal(0, resultado.Precio);
        Assert.Equal("Sin descripción", resultado.Descripcion);
    }

    [Fact]
    public void ProbarEliminarProducto()
    {
        Tienda tienda = new Tienda();
        tienda.agregarProducto("Mouse", 15000, "Mouse marca RedDragon");

        tienda.borrarProducto("Mouse");
        Assert.Empty(tienda.Inventario);
    }

    [Fact]
    public void ProbarEliminarProductoInexistente()
    {
        Tienda tienda = new Tienda();

        bool resultado = tienda.borrarProducto("Teclado");

        Assert.False(resultado);
    }

}
