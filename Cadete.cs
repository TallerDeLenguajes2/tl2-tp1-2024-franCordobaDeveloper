namespace Cadetes
{
    public class Cadete
    {    
        private int idCadete;
        
        private string  nombreCadete;

        private string direccionCadete;

        private string telefonoCadete;
    
        public Cadete( string nombreCadete, string telefonoCadete,string direccionCadete)
        {
            this.IdCadete        = idCadete;
            this.nombreCadete    = nombreCadete;
            this.telefonoCadete  = telefonoCadete;
            this.direccionCadete = direccionCadete;
            
        }

        public int IdCadete { get => idCadete; set => idCadete = value;}
        
        public string NombreCadete {get => nombreCadete; set => nombreCadete = value;}
        
        public string DireccionCadete { get => direccionCadete; set => direccionCadete = value;}

        public string TelefonoCadete { get => telefonoCadete; set => telefonoCadete = value;}
    
        public void ObtenerCadete()
        {
            Console.WriteLine("\n----------- Datos del Cadete ----------\n");
            Console.WriteLine();

            Console.WriteLine("ID CADETE: {0}", idCadete);
            Console.WriteLine("Nombre Cadete: {0}", nombreCadete);
            Console.WriteLine("Direccion del Pedido: {0}", direccionCadete);
            Console.WriteLine("Telefono Cadete: {0}", telefonoCadete);

            Console.WriteLine();
            Console.WriteLine("\n------------------------------------------");
        }
    }

}