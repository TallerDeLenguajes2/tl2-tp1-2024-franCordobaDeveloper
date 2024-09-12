using Cadetes;
using Clientes;
using Pedidos;

namespace Cadeterias
{
    class Cadeteria
    {
        private string nombreCadeteria;
        private string telefonoCadeteria;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;

        public Cadeteria(string nombreCadeteria, string telefonoCadeteria, List<Cadete> listadoCadetes, List<Pedido> listadoPedido)
        {
            this.nombreCadeteria   = nombreCadeteria;
            this.telefonoCadeteria = telefonoCadeteria;
            this.listadoCadetes    = listadoCadetes;
            this.listadoPedidos    = listadoPedido;
        }

        public string NombreCadeteria {get => nombreCadeteria; set => nombreCadeteria = value;}
        public string TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value;}
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value;}
        public Cadeteria()
        {
            nombreCadeteria   = "";
            telefonoCadeteria = "";
            listadoCadetes    = new List<Cadete>();
            listadoPedidos    = new List<Pedido>();
        }


        public void MostrarCadeteria()
        {
            int cont = 1;
            Console.WriteLine("\n-----------------------------------\n");
            Console.WriteLine();

            Console.WriteLine("Nombre Cadeteria: {0}", nombreCadeteria);
            Console.WriteLine("Telefono Cadeteria: {0}", telefonoCadeteria);
            Console.WriteLine("/n----- DATOS DEL CADETE -----\n");
            foreach (var cadete in listadoCadetes)
            {
                cadete.ObtenerCadete();
                cont++;
            }

            Console.WriteLine();
            Console.WriteLine("\n-----------------------------------\n");
        }

        public Pedido CrearPedido(int idPedido)
        {
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("\n------------- PEDIDOS --------------\n");
            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine();

            Console.WriteLine("Ingrese el Nombre del Cliente: ");
            var nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese la Direccion del Cliente: ");
            var direccionCliente = Console.ReadLine();
            Console.WriteLine("Ingrese el Telefono del Cliente: ");
            var telefonoCliente = Console.ReadLine();
            Console.WriteLine("Ingrese los datos de referencia: ");
            var referenciaCliente = Console.ReadLine();
            
            var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, referenciaCliente);

            Console.WriteLine("Ingrese las observaciones que tenga sobre el pedido: ");
            var observaciones = Console.ReadLine();

            var pedidoTomado = new Pedido(idPedido, observaciones, datosCliente);
            Console.WriteLine("\n---------------------------------------\n");

            return pedidoTomado;
        }

        public void TomarPedido(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
        }

        public void AceptarPedido(int idPedido)
        {
            var pedido = listadoPedidos.FirstOrDefault(l => l.IdPedido == idPedido);
            if(pedido == null) return;
            pedido.AceptarPedido();
        }

        public void MostrarPedidosPendientes()
        {
            foreach (var pedido in listadoPedidos)
            {
                if(pedido.Estado == EstadoPedidos.Pendiente)
                {
                    pedido.MostrarPedido();
                }
            }
        }
    }
}