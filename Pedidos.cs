using Cadetes;
using Clientes;

namespace Pedidos
{

    public enum EstadoPedidos
    {
        Aceptado,
        Pendiente,
        Rechazado,
        Entregado,

    }

    public class Pedido
    {
        private int idPedido;
        private string nombrePedido;
        private EstadoPedidos estado;
        private Cadete cadeteAsignado;

        public int IdPedido {get => idPedido; set => idPedido = value;}
        public string NombrePedido { get => nombrePedido; set => nombrePedido = value;}
        public Cliente NombreCliente{ get => NombreCliente; set => NombreCliente = value;}
        public EstadoPedidos Estado { get => estado; set => estado = value;}
        public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value;}


        public Pedido(int idPedido, string nombrePedido, Cliente nombreCliente)
        {
            this.idPedido       = idPedido;
            this.nombrePedido   = nombrePedido;
            this.NombreCliente  = nombreCliente;
            estado              = EstadoPedidos.Pendiente;
            cadeteAsignado      = null;
        }

        
        public Pedido()
        {
            IdPedido = 0;
            nombrePedido = "";
            NombreCliente = new Cliente();
            estado = EstadoPedidos.Pendiente;
            cadeteAsignado = null;
        }

        public void MostrarPedido()
        {
            Console.WriteLine("\n ----------------------- \n");
            Console.WriteLine($"Numero ID del Pedido: {IdPedido}");
            Console.WriteLine($"Nombre del Pedido: {nombrePedido}");
            Console.WriteLine($"Estado del Pedido: {estado}");
            Console.WriteLine($"Datos del Cliente");
            NombreCliente.ObtenerCliente();
            if(cadeteAsignado == null)
            {
                Console.WriteLine("No hay cadete asignado");
            }
            else
            {
                Console.WriteLine($"Cadete Asignado: {cadeteAsignado.NombreCadete}");
            }
            Console.WriteLine("\n-------------------------------\n");
        }

        public void AsignarCadete(Cadete cadete)
        {
            cadeteAsignado = cadete;
        }

        public void AceptarPedido()
        {
            if(estado == EstadoPedidos.Pendiente)
            {
                estado = EstadoPedidos.Aceptado;
                if(estado == EstadoPedidos.Rechazado)
                {
                    Console.WriteLine("El Pedido fue Rechazado.");
                }
            }
        }

        public void RechazarPedido()
        {
            estado = EstadoPedidos.Rechazado;
            CadeteAsignado = null;
        }
    }
}