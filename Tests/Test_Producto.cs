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
}
