namespace IngSoftTP1;

using EClases;
using EFixtures;

//': IClassFixture<TiendaFixture> , IClassFixture<ProductoFixture>'
// es valido para usar varios fixtures en una misma clase de prueba
// aunque acá no tendria mucho sentido
public class PruebasTienda : IClassFixture<TiendaFixture>
{
    public readonly TiendaFixture _tiendaFixture;
    public PruebasTienda(TiendaFixture tiendaFixture)
    {
        _tiendaFixture = tiendaFixture;
    }

// NOTA: intentaste de mil maneras...
// una solucion que encontraste fue sacar el paralelismo de las pruebas
// hay varias formas, la ultima que usaste fue: 
//                                              dotnet test test.csproj -p:ParallelizeTestCollections=false
// pero al final, la unica forma de solucionarlo fue reiniciar
// el inventario del fixture... cuando ejecutas las pruebas 1 por 1
// no te da ningun error, pero cuando las haces a todas juntas AgregarProducto falla
    [Fact]
    public void ProbarAgregarProducto()
    {
        _tiendaFixture.tiendaDePrueba.Inventario.Clear();
        _tiendaFixture.tiendaDePrueba.agregarProducto("Teclado", 15000, "Es un teclado");
        _tiendaFixture.tiendaDePrueba.agregarProducto("Mouse", 10000, "es un mouse");

        Assert.Multiple(() =>
        {
            Assert.Equal(2, _tiendaFixture.tiendaDePrueba.Inventario.Count); // Más claro que Assert.True
            Assert.Equal("Teclado", _tiendaFixture.tiendaDePrueba.Inventario[0].Nombre);
            Assert.Equal("Mouse", _tiendaFixture.tiendaDePrueba.Inventario[1].Nombre);
        });
    }

    [Fact]
    public void ProbarBuscarProducto()
    {
        Producto resultado = _tiendaFixture.tiendaDePrueba.buscarProducto("Teclado");

        Assert.NotNull(resultado);                              // controla si existe el producto
        Assert.Equal("Teclado", resultado.Nombre);              // controla el nombre
        Assert.Equal(15000, resultado.Precio);                  // controla el precio
    }

    [Fact]
    public void ProbarProductoInexistente()
    {
        Producto resultado = _tiendaFixture.tiendaDePrueba.buscarProducto("Mouse");

        Assert.NotNull(resultado);                              // porque igual devuelve un objeto
        Assert.Equal("Producto no encontrado", resultado.Nombre);
        Assert.Equal(0, resultado.Precio);
        Assert.Equal("Sin descripción", resultado.Descripcion);
    }

    [Fact]
    public void ProbarEliminarProducto()
    {
        _tiendaFixture.tiendaDePrueba.borrarProducto("Teclado");
        _tiendaFixture.tiendaDePrueba.borrarProducto("Procesador");
        _tiendaFixture.tiendaDePrueba.borrarProducto("Monitor");    // tuviste que acomodarlo al nuevo fixture
        Assert.Empty(_tiendaFixture.tiendaDePrueba.Inventario);
    }

    [Fact]
    public void ProbarEliminarProductoInexistente()
    {
        bool resultado = _tiendaFixture.tiendaDePrueba.borrarProducto("Mouse");
        Assert.False(resultado);
    }
}
