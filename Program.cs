
using EClases;

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

/* buscar productos */
Console.WriteLine("Ingrese el nombre de un producto:");
string nombreBuscado = Console.ReadLine();

if (tienda.Inventario.Any(prod => prod.Nombre == nombreBuscado))
{
    Producto prod = tienda.Inventario.FirstOrDefault(prod => prod.Nombre == nombreBuscado);
    Console.WriteLine($"Producto: {prod.Nombre} - {prod.Precio} - {prod.Descripcion}");
}
else
{
    Console.WriteLine("No se encontró el producto.");
}

/* eliminar producto */
Console.WriteLine("Ingrese el nombre de un producto a borrar:");
string nombreBorrado = Console.ReadLine();

if (tienda.Inventario.Any(prod => prod.Nombre == nombreBorrado))
{
    Producto prod = tienda.Inventario.FirstOrDefault(prod => prod.Nombre == nombreBorrado);
    Console.WriteLine($"Producto: {prod.Nombre} fue borrado");
    tienda.Inventario.Remove(prod);
}
else
{
    Console.WriteLine("No se encontró el producto.");
}

Console.WriteLine(" ");