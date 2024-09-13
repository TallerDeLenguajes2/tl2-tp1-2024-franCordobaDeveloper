using Cadeterias;
using Cadetes;
using Pedidos;

namespace AccesoAAchivos
{
    
    public class AccesoAAchivo
    {
        public static List<string[]> LeerArchivoCSV(string nombreArchivo)
        {
            var lectura = new List<string[]>();

            if(!File.Exists(nombreArchivo))
            {
                Console.WriteLine($"El archivo {nombreArchivo} no fue encontrado.");
                return null;
            }

            try
            {
                foreach (var linea in File.ReadLines(nombreArchivo))
                {
                    if(!string.IsNullOrWhiteSpace(linea))
                    {
                        string[] arrLinea = linea.Split(';'); // separamos con split 
                        lectura.Add(arrLinea);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return null;
            }

            return lectura;
        }

        public static List<Cadeteria> CargarDatosCadeterias(string nombreArchivo, List<Cadete> listadoCadete)
        {
            var listaCadeterias = new List<Cadeteria>();
            var data = LeerArchivoCSV(nombreArchivo);

            if( data != null && data.Any())
            {
                foreach (var infoCadeteria in data)
                {
                    if(infoCadeteria == null || infoCadeteria.Length < 2) continue;

                    string nombreCadeteria   = infoCadeteria[0];
                    string telefonoCadeteria = infoCadeteria[1];

                    var cadeteriaNueva = new Cadeteria(nombreCadeteria, telefonoCadeteria, listadoCadete, new List<Pedido>());
                    listaCadeterias.Add(cadeteriaNueva);
                }
            }

            return listaCadeterias;
        }

        public List<Cadete> CargarDatosCadetes(string nombreArchivo)
        {
            Cadete nuevoCadete;
            var listaNueva = new List<Cadete>();
            var listaCSV = LeerArchivoCSV(nombreArchivo);

            if(listaCSV != null && listaCSV.Any())
            {
                int id = 0;
                foreach (var infoCadete in listaCSV)
                {
                    if(infoCadete == null || infoCadete.Length < 3) continue;

                    string nombre = infoCadete[0];
                    string telefono = infoCadete[1];
                    string direccion = infoCadete[2];

                    nuevoCadete = new Cadete(nombre,telefono,direccion);
                    listaNueva.Add(nuevoCadete);
                    id++;
                }
            } else {
                Console.WriteLine("No hay cadetes para cargar en lista");
            }

            return listaNueva;
        }


        public void GuardarDatosCadete(string nombreArchivo, List<Cadete> cadetes)
        {
            List<string[]> datosCadetes = new List<string[]>();
            foreach (var cadete in cadetes)
            {
                string[] lineaCadete = { cadete.NombreCadete, cadete.TelefonoCadete, cadete.DireccionCadete};
                datosCadetes.Add(lineaCadete);
            }

            GuardarDatos(nombreArchivo, datosCadetes);
            
        }

        public void GuardarDatos(string ruta, List<string[]> datos)
        {
            try
            {
                using (var writer = new StreamWriter(ruta))
                {
                    foreach (var fila in datos)
                    {
                        var linea = string.Join(",", fila);
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en archivo CSV: {ex.Message}");
            }
        }

        public void GuardarDatosCadeterias(string nombreArchivo, List<Cadeteria> cadeterias)
        {
            // Convierte la lista de cadeterías a un formato adecuado para guardar en el archivo
            List<string[]> datosCadeterias = new List<string[]>();
            foreach (var cadeteria in cadeterias)
            {
                string[] lineaCadeteria = { cadeteria.NombreCadeteria, cadeteria.TelefonoCadeteria };
                datosCadeterias.Add(lineaCadeteria);
            }

            // Llama al método GuardarDatos para guardar los datos de las cadeterías en el archivo
            GuardarDatos(nombreArchivo, datosCadeterias);
        }
    }

}