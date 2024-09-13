using Cadetes;
using Clientes;
using Pedidos;

namespace Cadeterias
{
    public class Cadeteria
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

        // tp-02

        public void AsignarCadetePedido(int idCadete, int idPedido)
        {
            var cadete = listadoCadetes.FirstOrDefault(l => l.IdCadete == idCadete);
            var pedido = listadoPedidos.FirstOrDefault(l => l.IdPedido == idPedido);
            if (cadete != null && pedido != null)
            {
                pedido.AsignarCadete(cadete);
            }
            else
            {
                Console.WriteLine("No se encuentra el cliente");
            }

        }

        public void AsignarCadetePedido(Cadeteria cadeteria)
        {
            Console.WriteLine("----- [ seleccione el pedido que desea asignar a un cadete ] -----");
            
            for(int i = 0; i < cadeteria.ListadoPedidos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ID pedido: {cadeteria.ListadoPedidos[i].IdPedido}");
            }

            if(int.TryParse(Console.ReadLine(), out int pedidoSeleccionado) && pedidoSeleccionado >= 1 && pedidoSeleccionado <= cadeteria.ListadoPedidos.Count)
            {
                Console.WriteLine("----- Seleccione el cadete al que asiganara el pedido -----");
                for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
                {
                    Console.WriteLine($"ID Cadete: {cadeteria.ListadoCadetes[i].IdCadete}. CADETE: {cadeteria.ListadoCadetes[i].NombreCadete}");
                }

                if(int.TryParse(Console.ReadLine(), out int cadeteSeleccionado) && cadeteSeleccionado >= 1 && cadeteSeleccionado <= cadeteria.ListadoCadetes.Count)
                {
                    // Asignacion del pedido al cadetes
                    cadeteria.AsignarCadetePedido(cadeteria.ListadoCadetes[cadeteSeleccionado - 1].IdCadete, cadeteria.ListadoPedidos[pedidoSeleccionado - 1].IdPedido);
                    Console.WriteLine("----- El pedido se ha asignado correctamente -----");

                } else {
                    Console.WriteLine("Seleccion del cadete invalida!");
                }
            } else {
                Console.WriteLine("Seleccion del pedido salio mal!");
            }
        }
    }
}