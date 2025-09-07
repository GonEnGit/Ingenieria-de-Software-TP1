namespace IngSoftTP1;

using EClases;

public class PruebasProducto
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

// esta funcion tiene varias posibilidades.
// encontraste que tambien seria buena idea controlar que el valor sea el correcto
// no solo controlar si lo que devuelve es lo esperado
    [Fact]
    public void ProbaraActualizarPrecio()
    {
        Producto prod = new Producto("Teclado", 15000, "Es un teclado");

        bool confirmacion = prod.ActualizarPrecio(15);
        Assert.True(confirmacion);
        Assert.Equal(17250, prod.Precio);

        confirmacion = prod.ActualizarPrecio(0.15);
        Assert.True(confirmacion);
        Assert.Equal(17250, prod.Precio);

        confirmacion = prod.ActualizarPrecio(-15);
        Assert.False(confirmacion);
        Assert.Equal(15000, prod.Precio);

        confirmacion = prod.ActualizarPrecio(0);
        Assert.False(confirmacion);
        Assert.Equal(15000, prod.Precio);
    }
}
