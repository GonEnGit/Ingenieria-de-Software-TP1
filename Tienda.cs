
namespace EClases;

public class Tienda
{
    private List<Producto> inventario;

    public List<Producto> Inventario { get => inventario; set => inventario = value; }

    public Tienda()
    {
        inventario = new List<Producto>();
    }

    public void agregarProducto(string nom, double costo, string desc)
    {
        Producto prod = new Producto();

        prod.Nombre = nom;
        prod.Precio = costo;
        prod.Descripcion = desc;

        inventario.Add(prod);
    }

    public Producto buscarProducto(string nom)
    {
        return inventario.FirstOrDefault(prod => prod.Nombre == nom);
    }

    public void borrarProducto(string nom)
    {
        Producto prod = inventario.FirstOrDefault(prod => prod.Nombre == nom);
        if (prod != null)
        {
            inventario.Remove(prod);
        }
    }
}