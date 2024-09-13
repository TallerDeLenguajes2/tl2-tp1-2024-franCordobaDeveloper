using AccesoADatos;
using Cadeterias;
using Cadetes;
using MenuCadeterias;
using Pedidos;

public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("-----[ SISTEMA DE GESTIÓN DE CADETERIAS ]-----");
        
        var (accesoDatos, archivoCadetes, archivoCadeterias) = SeleccionarTipoAcceso();

        var listaCadetes = new List<Cadete>();
        var listaCadeterias = new List<Cadeteria>();

        if (File.Exists(archivoCadetes) && File.Exists(archivoCadeterias))
        {
            listaCadetes = accesoDatos.CargarDatosCadetes(archivoCadetes);
            listaCadeterias = accesoDatos.CargarDatosCadeterias(archivoCadeterias, listaCadetes);
        }
        else
        {
            Console.WriteLine("Los archivos de datos no existen en la ubicación especificada.");
            Console.WriteLine("¿Desea elegir otro tipo de acceso? (S/N)");
            string respuesta = Console.ReadLine();

            if (respuesta.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                // Proporciona la opción de elegir otro tipo de acceso
                (accesoDatos, archivoCadetes, archivoCadeterias) = SeleccionarTipoAcceso();

                listaCadetes = accesoDatos.CargarDatosCadetes(archivoCadetes);
                listaCadeterias = accesoDatos.CargarDatosCadeterias(archivoCadeterias, listaCadetes);
            }
            else
            {
                // Si el usuario no desea elegir otro tipo de acceso, sale del programa
                Console.WriteLine("Saliendo del programa.");
                return;
            }
        }

        // Crear una instancia de MenuCadeterias y usarla para seleccionar una cadetería
        var menuCadeterias = new MenuCadeteria(listaCadeterias);
        var cadeteriaSeleccionada = menuCadeterias.SeleccionarCadeteria();

        if (cadeteriaSeleccionada != null)
        {
            var opcion = "";
            var IdPedido = 0;
            cadeteriaSeleccionada.MostrarCadeteria();

            while (opcion != "s")
            {
                Console.WriteLine(" -------------- [ Menu ] -------------- \n");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Crear Pedido");
                Console.WriteLine("2. Asignar Cadete a Pedido");
                Console.WriteLine("3. Cambiar Estado de Pedido");
                Console.WriteLine("4. Consultar Jornal de Cadete");
                Console.WriteLine("5. Informe final del jornal ");
                Console.WriteLine("6. Mostrar cadeteria ");
                Console.WriteLine("7. Mostrar pedidos pendientes ");
                Console.WriteLine("8. Quitar Pedido");
                Console.WriteLine("9. Crear Nuevo Cadete");
                Console.WriteLine("10. Crear Nueva Cadetería");

                Console.WriteLine("s. Salir");
                opcion = Console.ReadLine();

                Console.WriteLine("\n --------------------------- \n");
                switch (opcion)
                {
                    case "1":
                        var nuevoPedido = cadeteriaSeleccionada.CrearPedido(IdPedido);
                        cadeteriaSeleccionada.TomarPedido(nuevoPedido);
                        IdPedido++;
                        break;
                    case "2":
                        cadeteriaSeleccionada.AsignarCadetePedido(cadeteriaSeleccionada);
                        break;
                    case "3":
                        cadeteriaSeleccionada.CambiarEstadoPedido(cadeteriaSeleccionada);
                        break;
                    case "4":
                        cadeteriaSeleccionada.ConsultarJornal(cadeteriaSeleccionada);
                        break;
                    case "5":
                        cadeteriaSeleccionada.InformeAlFinalDelJornal();
                        break;
                    case "6":
                        cadeteriaSeleccionada.MostrarCadeteria();
                        break;
                    case "7":
                        cadeteriaSeleccionada.MostrarPedidosPendientes();
                        break;
                    case "8":
                        // Obtener el pedido que deseas eliminar (por ejemplo, seleccionando un índice o por ID)
                        Pedido pedidoAEliminar = cadeteriaSeleccionada.ObtenerPedidoParaEliminar(cadeteriaSeleccionada);
                        if (pedidoAEliminar != null)
                        {
                            cadeteriaSeleccionada.QuitarPedido(pedidoAEliminar);
                        }
                        break;
                    case "9":
                        // Crear Nuevo Cadete
                        var nuevoCadete = CrearNuevoCadete();
                        listaCadetes.Add(nuevoCadete);
                        Console.WriteLine("Nuevo cadete creado correctamente.");

                        Console.WriteLine("¿Desea guardar el nuevo cadete en este momento? (S/N)");
                        string respuesta = Console.ReadLine();
                        if (respuesta.Equals("S", StringComparison.OrdinalIgnoreCase))
                        {
                            accesoDatos.GuardarDatosCadetes("Cadetes.JSON", listaCadetes);
                            Console.WriteLine("Nuevo cadete guardado correctamente.");
                        }
                        break;
                    case "10":
                        // Crear Nueva Cadetería
                        var nuevaCadeteria = CrearNuevaCadeteria();
                        listaCadeterias.Add(nuevaCadeteria);
                        Console.WriteLine("Nueva cadetería creada correctamente.");

                        Console.WriteLine("¿Desea guardar la nueva cadetería en este momento? (S/N)");
                        string respuesta2 = Console.ReadLine();
                        if (respuesta2.Equals("S", StringComparison.OrdinalIgnoreCase))
                        {
                            accesoDatos.GuardarDatosCadeterias("Cadeterias.JSON", listaCadeterias);
                            Console.WriteLine("Nueva cadetería guardada correctamente.");
                        }
                        break;
                    case "s":
                        Console.WriteLine("Saliendo del programa.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            // Después de crear y agregar nuevos cadetes o cadeterías a las listas correspondientes
            accesoDatos.GuardarDatosCadetes("Cadetes.JSON", listaCadetes);
            accesoDatos.GuardarDatosCadeterias("Cadeterias.JSON", listaCadeterias);
        }
        else
        {
            Console.WriteLine("No se encontró la cadeteria");
        }
    }

    private static (AccesoADato, string, string) SeleccionarTipoAcceso()
    {
        Console.WriteLine("Seleccione el tipo de acceso a datos:");
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");

        while (true)
        {
            Console.Write("Elija una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                return (new AccesoCSV(), "Cadetes.csv", "Cadeterias.csv");
            }
            else if (opcion == "2")
            {
                return (new AccesoJSON(), "Cadetes.JSON", "Cadeterias.JSON");
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }

    private static Cadete CrearNuevoCadete()
    {
        Console.WriteLine("Ingrese el nombre del nuevo cadete:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el teléfono del nuevo cadete:");
        string telefono = Console.ReadLine();
        Console.WriteLine("Ingrese la dirección del nuevo cadete:");
        string direccion = Console.ReadLine();

        return new Cadete(nombre, telefono, direccion);
    }

    private static Cadeteria CrearNuevaCadeteria()
    {
        Console.WriteLine("Ingrese el nombre de la nueva cadetería:");
        string nombreCadeteria = Console.ReadLine();
        Console.WriteLine("Ingrese el teléfono de la nueva cadetería:");
        string telefonoCadeteria = Console.ReadLine();

        return new Cadeteria(nombreCadeteria, telefonoCadeteria, new List<Cadete>(), new List<Pedido>());
    }
    }

