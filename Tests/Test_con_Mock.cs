
// Test con Mocks parecen llevar mas cosas asi que decidiste separarla

// lo primero es usar dotnet add package moq ; xunit, no puede usar mocks por si solo

using EClases;
using EInterfaces;
using Moq;          // es un paquete externo, lo tenes que incluir a mano

public class TestConMock
{
    [Fact]
    public void TestDescuentoCorrecto()
    {
    // no se que tipo exacto seria un mock... Mock, mock y moq dan erro, dejalo en var
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();

    // un Mock se arma en 3 partes:
    //      primero usas .Setup para indicar como responde 'mockBuscadorProductos'
    //      segundo, usas .Returns para forzar un objeto a devolver por el metodo 'BuscarProductoInterface'
        mockBuscadorProductos.Setup(b => b.BuscarProductoInterface("Laptop"))
                                .Returns(new Producto { Nombre = "Laptop", Precio = 1000.0, Descripcion = "Una Laptop" });

    //      tercero, usas .object para instanciar una Tienda usando la interface
        Tienda tienda = new Tienda(mockBuscadorProductos.Object);

    // esto es solo el porcentaje que vas a usar
        double porcentaje = 10.0;

    // estas lineas conllevan la prueba en si
        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(900.0, resultado);
    }

    [Fact]
    public void TestDescuentoProdInexistente()
    {
        var mockBuscadorProductos = new Mock<IBuscadorProductos>();

    // igual que arriba, seteas que se devuelve, en este caso forzas un objeto vacio
        mockBuscadorProductos.Setup(b => b.BuscarProductoInterface("Laptop")).Returns((Producto)null);

        Tienda tienda = new Tienda(mockBuscadorProductos.Object);
        double porcentaje = 10.0;

        double resultado = tienda.AplicarDescuento("Laptop", porcentaje);

        Assert.Equal(0, resultado);
    }

    [Fact]
    public void TestDescuentoPorcentajeNegativo()
    {
        // Arrange
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