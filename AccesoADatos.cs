using Cadeterias;
using Cadetes;
using Pedidos;
using System.Text.Json;

namespace AccesoADatos
{
    public abstract class AccesoADato
    {
        public abstract List<Cadete> CargarDatosCadetes(string ruta);
        public abstract List<Cadeteria> CargarDatosCadeterias(string ruta, List<Cadete> cadetes);
        public abstract void GuardarDatosCadetes(string ruta, List<Cadete> cadetes);
        public abstract void GuardarDatosCadeterias(string ruta, List<Cadeteria> cadeterias);
    }
    
    public class AccesoCSV : AccesoADato
    {
        public override List<Cadete> CargarDatosCadetes(string ruta)
        {
            List<Cadete> cadetes = new List<Cadete>();

            try
            {
                if (File.Exists(ruta))
                {
                    using (var reader = new StreamReader(ruta))
                    {
                        while (!reader.EndOfStream)
                        {
                            var linea = reader.ReadLine();
                            var campos = linea.Split(',');
                            if (campos.Length >= 3)
                            {
                                string nombre = campos[0];
                                string telefono = campos[1];
                                string direccion = campos[2];
                                cadetes.Add(new Cadete(nombre, telefono, direccion));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde archivo CSV: {ex.Message}");
            }

            return cadetes;
        }

        public override List<Cadeteria> CargarDatosCadeterias(string ruta, List<Cadete> cadetes)
        {
            List<Cadeteria> cadeterias = new List<Cadeteria>();

            try
            {
                if (File.Exists(ruta))
                {
                    using (var reader = new StreamReader(ruta))
                    {
                        while (!reader.EndOfStream)
                        {
                            var linea = reader.ReadLine();
                            var campos = linea.Split(';');
                            if (campos.Length >= 2)
                            {
                                string nombre = campos[0];
                                string telefono = campos[1];
                                cadeterias.Add(new Cadeteria(nombre, telefono, new List<Cadete>(), new List<Pedido>()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde archivo CSV: {ex.Message}");
            }

            return cadeterias;
        }

        public override void GuardarDatosCadetes(string ruta, List<Cadete> cadetes)
        {
            try
            {
                using (var writer = new StreamWriter(ruta))
                {
                    foreach (var cadete in cadetes)
                    {
                        var linea = $"{cadete.NombreCadete},{cadete.TelefonoCadete},{cadete.DireccionCadete}";
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en archivo CSV: {ex.Message}");
            }
        }

        public override void GuardarDatosCadeterias(string ruta, List<Cadeteria> cadeterias)
        {
            try
            {
                var json = JsonSerializer.Serialize(cadeterias);
                File.WriteAllText(ruta, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en archivo JSON: {ex.Message}");
            }
        }
    }

    public class AccesoJSON : AccesoADato
    {
        public override List<Cadete> CargarDatosCadetes(string ruta)
        {
            List<Cadete> cadetes = new List<Cadete>();

            try
            {
                if (File.Exists(ruta))
                {
                    var json = File.ReadAllText(ruta);
                    cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde archivo JSON: {ex.Message}");
            }

            return cadetes;
        }

        public override List<Cadeteria> CargarDatosCadeterias(string ruta, List<Cadete> cadetes)
        {
            List<Cadeteria> cadeterias = new List<Cadeteria>();

            try
            {
                if (File.Exists(ruta))
                {
                    var json = File.ReadAllText(ruta);
                    cadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar datos desde archivo JSON: {ex.Message}");
            }

            return cadeterias;
        }

        public override void GuardarDatosCadetes(string ruta, List<Cadete> cadetes)
        {
            try
            {
                var json = JsonSerializer.Serialize(cadetes);
                File.WriteAllText(ruta, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en archivo JSON: {ex.Message}");
            }
        }

        public override void GuardarDatosCadeterias(string ruta, List<Cadeteria> cadeterias)
        {
            try
            {
                var json = JsonSerializer.Serialize(cadeterias);
                File.WriteAllText(ruta, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en archivo JSON: {ex.Message}");
            }
        }
    }
}