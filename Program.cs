
using EClases;

/* Variables */
Producto prodBuscado;
string nombreBorrado;
double porcentaje;
bool confirmacion = false;


Console.WriteLine("\ninicio del programa\n");

Tienda tienda = new Tienda();

/* crear productos */
tienda.agregarProducto("Pan", 1500, "Es Pan");
tienda.agregarProducto("Leche", 1200, "Leche entera 1L");
tienda.agregarProducto("Huevos", 800, "Docena de huevos frescos");
tienda.agregarProducto("Queso", 2500, "Queso mozzarella 500g");
tienda.agregarProducto("Manteca", 1500, "Manteca 200g");
tienda.agregarProducto("Pan dulce", 3500, "Pan dulce tradicional");
tienda.agregarProducto("Yogur", 900, "Yogur natural 1L");

foreach (Producto p in tienda.Inventario)
{
    Console.WriteLine($"{p.Nombre} - {p.Precio} - {p.Descripcion}");
}

/* actualizar precio */
Console.Write("Ingrese el nombre del producto: ");
prodBuscado = tienda.buscarProducto(Console.ReadLine());
while (prodBuscado.Nombre == "Producto no encontrado")
{
    Console.Write("\nDebe ingresar un nombre valido: ");
    prodBuscado = tienda.buscarProducto(Console.ReadLine());
}

while (!confirmacion)
{
    Console.Write("\nIngrese el porcentaje de cambio: ");
    double.TryParse(Console.ReadLine(), out porcentaje);

    confirmacion = prodBuscado.ActualizarPrecio(porcentaje);
    if (!confirmacion)
    {
        Console.WriteLine("\nEl porcentaje debe ser positivo.");
    }
}


/* buscar productos */
Console.Write("\nIngrese el nombre de un producto: ");
string nombreBuscado = Console.ReadLine();

prodBuscado = tienda.buscarProducto(nombreBuscado);
Console.WriteLine($"Producto: {prodBuscado.Nombre} - {prodBuscado.Precio} - {prodBuscado.Descripcion}");

/* eliminar producto */
Console.Write("\nIngrese el nombre de un producto a borrar: ");
nombreBorrado = Console.ReadLine();

confirmacion = tienda.borrarProducto(nombreBorrado);
if (confirmacion)
{
    Console.WriteLine("\nProducto borrado con exito.\n");
}
else
{
    Console.WriteLine("\nNo se pudo borrar el producto.\n");
}

Console.WriteLine(" ");