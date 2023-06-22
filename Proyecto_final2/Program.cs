
using Final_Entrega1;
using Proyecto_final2;

producto Producto = new producto();
List<producto> lista = new List<producto>();
lista = Producto.ListarProductos();

usuario Usuario = new usuario();
List<usuario> listau = new List<usuario>();
listau = Usuario.ListarUsuarios();

productovendido ProductoVendido = new productovendido();
List<productovendido> listapv = new List<productovendido>();
listapv = ProductoVendido.ListarProductosVendidos();

venta Venta = new venta();
List<venta> listav = new List<venta>();
listav = Venta.ListarVentas();

foreach (var item in lista)
{

    Console.WriteLine("Id " + item.Id);
    Console.WriteLine("Descripciones " + item.Descripciones);
    Console.WriteLine("Costo " + item.Costo);
    Console.WriteLine("PrecioVenta " + item.PrecioVenta);
    Console.WriteLine("Stock " + item.Stock);
    Console.WriteLine("Id " + item.IdUsuario);
    Console.WriteLine("----------------------" );


}

foreach (var item2 in listau)
{

    Console.WriteLine("Id " + item2.Id);
    Console.WriteLine("Nombre " + item2.Nombre);
    Console.WriteLine("Apellido " + item2.Apellido);
    Console.WriteLine("NombreUsuario " + item2.NombreUsuario);
    Console.WriteLine("Contraseña " + item2.Contraseña);
    Console.WriteLine("Mail " + item2.Mail);
    Console.WriteLine("----------------------");

}

foreach (var item3 in listapv)
{

    Console.WriteLine("Id " + item3.Id);
    Console.WriteLine("Stock " + item3.Stock);
    Console.WriteLine("IdProducto " + item3.IdProducto);
    Console.WriteLine("IdVenta " + item3.IdVenta);
    Console.WriteLine("----------------------");

}

foreach (var item4 in listav)
{

    Console.WriteLine("Id " + item4.Id);
    Console.WriteLine("Descripcion " + item4.Descripcion);
    Console.WriteLine("Cantidad " + item4.Cantidad);
    Console.WriteLine("PrecioVenta " + item4.PrecioVenta);
    Console.WriteLine("PrecioCompra " + item4.PrecioCompra);
    Console.WriteLine("PrecioTotalVenta " + item4.PrecioTotalVenta);
    Console.WriteLine("----------------------");

}

Console.WriteLine("Inicio de sesión");

Console.Write("Nombre de usuario: ");
string nombreUsuario = Console.ReadLine();

Console.Write("Contraseña: ");
string contraseña = Console.ReadLine();

bool inicioSesionExitoso = false;

foreach (usuario usuariob in listau)
{
    if (usuariob.Nombre == nombreUsuario && usuariob.Contraseña == contraseña)
    {
        inicioSesionExitoso = true;
        break;
    }
}

if (inicioSesionExitoso)
{
    Console.WriteLine("Inicio de sesión exitoso.");
}
else
{
    Console.WriteLine("Credenciales inválidas. Inicio de sesión fallido.");
}

Console.ReadLine();

internal class UsuarioL
{
    public string NombreUsuario { get; set; }
    public string Contraseña { get; set; }
}

