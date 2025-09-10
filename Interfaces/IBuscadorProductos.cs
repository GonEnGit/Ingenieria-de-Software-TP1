
// Parece que para poder usar mocks, necesariamente vas a tener que usar
// interfaces, para no tener que hacer todo de nuevo, lo meejor
// va a ser que crees una nueva clase que solo busque productos

namespace EInterfaces;

using EClases;

public interface IBuscadorProductos
{
    Producto BuscarProductoInterface(string nombre);
}