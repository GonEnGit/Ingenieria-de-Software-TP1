
namespace EClases;

public class Producto
{
    private string nombre;
    private double precio;
    private string descripcion;

    public string Nombre { get => nombre; set => nombre = value; }
    public double Precio { get => precio; set => precio = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }

    public Producto() { }

    public Producto(string nom, double costo, string desc)
    {
        Nombre = nom;
        Precio = costo;
        Descripcion = desc;
    }

    public bool ActualizarPrecio(double nuevoPrecio)
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
}