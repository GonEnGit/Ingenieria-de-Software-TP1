
using EClases;
using EInterfaces;
using Moq;

// una Nota: intentaste incluir el fixture en esta prueba tambien
// pero si tratas de incluir el fixture, la funcion .Aplicardescuento()
// no actua sobre el inventario que traes del fixture si no sobre el inventario
// que tiene el Mock... dicho de otra forma es al vicio incluir el fixture aquí

public class TestConMock
{
    [Fact]
    public void TestDescuentoCorrecto()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();
        mockBuscadorProductos.Setup(b => b.BuscarProductoInterface("Laptop"))
                                .Returns(new Producto { Nombre = "Laptop", Precio = 1000.0, Descripcion = "Una Laptop" });

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = 10.0;
        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(900.0, resultado);
    }

    [Fact]
    public void TestDescuentoProdInexistente()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();

        mockBuscadorProductos.Setup(b => b.BuscarProductoInterface("Laptop")).Returns((Producto)null);

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = 10.0;

        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(0, resultado);
    }

    [Fact]
    public void TestDescuentoPorcentajeNegativo()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();
        mockBuscadorProductos.Setup(b => b.BuscarProductoInterface("Laptop"))
                                .Returns(new Producto { Nombre = "Laptop", Precio = 1000.0, Descripcion = "Una Laptop" });

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = -0.10;

        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(0, resultado);
    }

    [Fact]
    public void TestDescuentoPorcentajeEntero()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();
        mockBuscadorProductos.Setup(finder => finder.BuscarProductoInterface("Laptop"))
                                .Returns(new Producto { Nombre = "Laptop", Precio = 1000.0, Descripcion = "Una Laptop" });

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = 20.0;

        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(800.0, resultado);
    }

    [Fact]
    public void TestDescuentoPorcentajeDecimal()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();

        mockBuscadorProductos.Setup(finder => finder.BuscarProductoInterface("Laptop"))
                                .Returns(new Producto { Nombre = "Laptop", Precio = 1000.0, Descripcion = "Una Laptop" });

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = 0.1;

        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(900.0, resultado);
    }

    [Fact]
    public void AplicarDescuento_VerificaLlamadaABuscarProductoInterface()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();

        mockBuscadorProductos.Setup(finder => finder.BuscarProductoInterface("Laptop"))
                                .Returns(new Producto { Nombre = "Laptop", Precio = 1000.0, Descripcion = "Una Laptop" });

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = 10.0;

        tienda.AplicarDescuento("Laptop", porcentaje);

        mockBuscadorProductos.Verify(finder => finder.BuscarProductoInterface("Laptop"), Times.Once());
    }
}