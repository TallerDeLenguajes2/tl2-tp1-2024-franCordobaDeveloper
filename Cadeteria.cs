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

        public void CambiarEstadoPedido(Cadeteria cadeteria)
        {
            Console.WriteLine("Seleccione el pedido al que desea cambiar el estado:");
            for (int i = 0; i < cadeteria.ListadoPedidos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Pedido ID: {cadeteria.ListadoPedidos[i].IdPedido}");
            }

            if (int.TryParse(Console.ReadLine(), out int pedidoSeleccionado) && pedidoSeleccionado >= 1 && pedidoSeleccionado <= cadeteria.ListadoPedidos.Count)
            {
                var pedido = cadeteria.ListadoPedidos[pedidoSeleccionado - 1];
                Console.WriteLine("Seleccione el estado en que desea colocar el pedido:");
                Console.WriteLine("1. Pendiente");
                Console.WriteLine("2. Rechazado");
                Console.WriteLine("3. Entregado");

                if (int.TryParse(Console.ReadLine(), out int estadoSeleccionado) && estadoSeleccionado >= 1 && estadoSeleccionado <= 4)
                {
                    switch (estadoSeleccionado)
                    {
                        case 1:
                            // Cambiar estado a Pendiente
                            pedido.Estado = EstadoPedidos.Pendiente;
                            Console.WriteLine("El estado del pedido ha sido cambiado a Pendiente.");
                            break;
                        case 2:
                            // Cambiar estado a Rechazado
                            pedido.Estado = EstadoPedidos.Rechazado;
                            Console.WriteLine("El estado del pedido ha sido cambiado a Rechazado.");
                            break;
                        case 3:
                            // Cambiar estado a Entregado
                            pedido.Estado = EstadoPedidos.Entregado;
                            Console.WriteLine("El estado del pedido ha sido cambiado a Entregado.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Selección de estado inválida.");
                }
            }
            else
            {
                Console.WriteLine("Selección de pedido inválida.");
            }
        }


        // Metedo para consultar el jornal de un cadete que se encuento en una cadeteria preseleccionada
        public void ConsultarJornal(Cadeteria cadeteria)
        {
            Console.WriteLine("Seleccione el cadete para consultar el jornal:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Cadete: {cadeteria.ListadoCadetes[i].NombreCadete}");
            }

            if (int.TryParse(Console.ReadLine(), out int cadeteSeleccionado) && cadeteSeleccionado >= 1 && cadeteSeleccionado <= cadeteria.ListadoCadetes.Count)
            {
                var idCadete = cadeteria.ListadoCadetes[cadeteSeleccionado - 1].IdCadete;
                double jornal = cadeteria.JornalACobrar(idCadete);
                Console.WriteLine($"El jornal a cobrar para el cadete '{cadeteria.listadoCadetes[idCadete].NombreCadete}' seleccionado es: ${jornal}");
            }
            else
            {
                Console.WriteLine("Selección de cadete inválida.");
            }
        }

        // MEtodo para calcular el jornal de un cadete
        public double JornalACobrar(int idCadete)
        {
            int cantidadPedidosEntregados = 0;
            var cadete = listadoCadetes.FirstOrDefault(l => l.IdCadete == idCadete);
            if (cadete != null)
            {
                foreach (var pedido in listadoPedidos)
                {
                    if (pedido.CadeteAsignado == cadete && pedido.Estado == EstadoPedidos.Entregado)
                    {
                        cantidadPedidosEntregados++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Cadete no encontrado");
            }
            double tarifaPorPedido = 500.0f;
            double jornal = cantidadPedidosEntregados * tarifaPorPedido;
            return jornal;
        }

        // Metodo para calcular el informe del jornal de cada cadete
        public void InformeAlFinalDelJornal()
        {
            Console.WriteLine("\n ----------- Informe ---------------- \n");
            foreach (var cadete in listadoCadetes)
            {
                int cantidadPedidosEntregados = 0;
                double montoGanado = 0.0f;

                foreach (var pedido in listadoPedidos)
                {
                    if (pedido.CadeteAsignado == cadete && pedido.Estado == EstadoPedidos.Entregado)
                    {
                        cantidadPedidosEntregados++;
                        montoGanado += 500.0;
                    }
                }
                Console.WriteLine("Datos de Cadetes");
                Console.WriteLine($"Cadete: {cadete.NombreCadete}");
                Console.WriteLine($"Cantidad de pedidos entregados: {cantidadPedidosEntregados}");
                Console.WriteLine($"Monto Ganado: {montoGanado}");
                Console.WriteLine(" --------------------------- ");
            }
            int totalEnvios = listadoPedidos.Count(p => p.Estado == EstadoPedidos.Entregado);
            double promedioEnvios = totalEnvios / listadoCadetes.Count;
            Console.WriteLine($"Cantidad de envios promedio por cadete: {promedioEnvios}");
            Console.WriteLine("\n --------------------------- \n");
        }

        public Pedido ObtenerPedidoParaEliminar(Cadeteria cadeteria)
        {
            // Mostrar la lista de pedidos disponibles para que el usuario seleccione uno
            Console.WriteLine("Seleccione el pedido que desea eliminar:");
            for (int i = 0; i < cadeteria.ListadoPedidos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Pedido ID: {cadeteria.ListadoPedidos[i].IdPedido}");
            }

            // Obtener la selección del usuario
            if (int.TryParse(Console.ReadLine(), out int pedidoSeleccionado) && pedidoSeleccionado >= 1 && pedidoSeleccionado <= cadeteria.ListadoPedidos.Count)
            {
                // Restar 1 al índice para obtener el pedido correspondiente
                return cadeteria.ListadoPedidos[pedidoSeleccionado - 1];
            }
            else
            {
                Console.WriteLine("Selección de pedido inválida.");
                return null; // Devolver null en caso de selección inválida
            }
        }

        public void QuitarPedido(Pedido pedido)
        {
            if (listadoPedidos.Contains(pedido))
            {
                listadoPedidos.Remove(pedido);
                CalcularJornal();
                Console.WriteLine("Pedido eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado en la lista del cadete.");
            }
        }

        public void CalcularJornal()
        {
            foreach (var cadete in listadoCadetes)
            {
                int cantidadPedidosEntregados = 0;
                double montoGanado = 0.0f;

                foreach (var pedido in listadoPedidos)
                {
                    if (pedido.CadeteAsignado == cadete && pedido.Estado == EstadoPedidos.Entregado)
                    {
                        cantidadPedidosEntregados++;
                        montoGanado += 500.0;
                    }
                }
            }
        }
    }
}
