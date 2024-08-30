namespace Cadetes
{
    class Cadete
    {    
        private int idCadete;
        
        private string  nombreCadete;

        private string direccionCadete;

        private string telefonoCadete;
    
        public Cadete(int idCadete, string nombreCadete, string direccionCadete, string telefonoCadete)
        {
            this.idCadete        = idCadete;
            this.nombreCadete    = nombreCadete;
            this.direccionCadete = direccionCadete;
            this.telefonoCadete  = telefonoCadete;
        }

        public int IdCadete { get => idCadete; set => idCadete = value;}
        
        public string NombreCadete {get => nombreCadete; set => nombreCadete = value;}
        
        public string DireccionCadete { get => direccionCadete; set => direccionCadete = value;}

        public string TelefonoCadete { get => telefonoCadete; set => telefonoCadete = value;}
    
        public void ObtenerCadete()
        {
            Console.WriteLine("\n----------- Datos del Cadete ----------\n");
            Console.WriteLine();

            Console.WriteLine("ID Cadete: {0}", idCadete);
            Console.WriteLine("Nombre Cadete: {0}", nombreCadete);
            Console.WriteLine("Direccion del Pedido: {0}", direccionCadete);
            Console.WriteLine("Telefono Cadete: {0}", telefonoCadete);

            Console.WriteLine();
            Console.WriteLine("\n------------------------------------------");
        }
    }

}