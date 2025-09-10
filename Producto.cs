
namespace EClases;

public class Producto
{
    private string nombre;
    private double precio;
    private string descripcion;

    public global::System.String Nombre { get => nombre; set => nombre = value; }
    public global::System.Double Precio { get => precio; set => precio = value; }
    public global::System.String Descripcion { get => descripcion; set => descripcion = value; }

    public Producto() { }

    public Producto(string nom, double costo, string desc)
    {
        Nombre = nom;
        Precio = costo;
        Descripcion = desc;
    }

    public bool ActualizarPrecio(double nuevoPrecio)
    {
        try
        {
            if (nuevoPrecio <= 0)
            {
                throw new Exception(" ");
            }
            else
            {
                precio = nuevoPrecio;
            }
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }
}