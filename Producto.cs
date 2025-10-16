
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
    
    public Producto(string nombre, double precio, string descripcion)
    {
        this.nombre = nombre;
        this.precio = precio;
        this.descripcion = descripcion;
    }
}