
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
        try
        {
            Producto prod =  inventario.FirstOrDefault(prod => prod.Nombre == nom);
            if (prod == null)
            {
                throw new Exception("excepción");
            }
            return prod;
        }
        catch (System.Exception)
        {
            return new Producto("Producto no encontrado", 0, "Sin descripción");
        }
    }

    public bool borrarProducto(string nom)
    {
        try
        {
            Producto prod = inventario.FirstOrDefault(prod => prod.Nombre == nom);
            if (prod != null)
            {
                inventario.Remove(prod);
                return true;
            }
            else
            {
                throw new Exception(" ");
            }
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}