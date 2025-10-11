
using EInterfaces;

namespace EClases;

public class Tienda
{
    // variables
    private List<Producto> inventario;
    private readonly IBuscadorProductos _buscadorProductos;

    public List<Producto> Inventario { get => inventario; set => inventario = value; }

    // constructores
    public Tienda()
    {
        inventario = new List<Producto>();
    }

    public Tienda(IBuscadorProductos buscadorProductos)
    {
        inventario = new List<Producto>();
        _buscadorProductos = buscadorProductos;
    }

    // funciones
    public void agregarProducto(string nom, double costo, string desc)
    {
        Producto prod = new Producto(nom, costo, desc);
        inventario.Add(prod);
    }

    public Producto buscarProducto(string nom)
    {
        try
        {
            Producto prod = inventario.FirstOrDefault(prod => prod.Nombre == nom);
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

    // y como tenes que usar interface para los mocks no te queda otra que usarla en el metodo tambien
    public double AplicarDescuento(string nom, double porcentaje)
    {
        try
        {
            if (porcentaje <= 0)
            {
                throw new Exception("Porcentaje inválido");
            }
            Producto producto = _buscadorProductos.BuscarProductoInterface(nom);
            if (producto == null)
            {
                throw new Exception("Producto no encontrado");
            }
            double precioDescontado = producto.Precio;
            if (porcentaje >= 1)
            {
                precioDescontado = precioDescontado - (precioDescontado * (porcentaje / 100));
            }
            else
            {
                precioDescontado = precioDescontado - (precioDescontado * porcentaje);
            }
            return precioDescontado;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en AplicarDescuento: {ex.Message}");
            return 0;
        }
    }

    public double CalcularTotalCarrito(List<Producto> carrito)
    {
    // hacer los descuentos aleatorios complica las pruebas de este metodo
    // decidiste fijar los descuentos, de todas formas, el metodo ya se testea en otro lado
        int contador = 0;
        double total = 0;

        foreach (Producto prod in carrito)
        {
            if ((contador % 2) == 0)
            {
                total += prod.Precio;
            }
            else
            {
                total += AplicarDescuento(prod.Nombre, 15);
            }
            contador++;
        }

        return total;
    }
}