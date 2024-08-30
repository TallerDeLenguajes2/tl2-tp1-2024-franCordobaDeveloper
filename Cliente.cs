namespace Clientes
{
    class Cliente
    {
        private string nombreCliente;

        private string direccionCliente;

        private string telefonoCliente;

        private string referenciaDireccionCliente;

        public Cliente(string nombreCliente, string direccionCliente, string telefonoCliente, string referenciaDireccionCliente )
        {
            this.nombreCliente              = nombreCliente;
            this.direccionCliente           = direccionCliente;
            this.telefonoCliente            = telefonoCliente;
            this.referenciaDireccionCliente = referenciaDireccionCliente;
        }

        public string NombreCliente { get => nombreCliente; set => nombreCliente = value;}
        
        public string DireccionCliente { get => direccionCliente; set => direccionCliente = value;}

        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value;}

        public string ReferenciaDireccionCliente { get => referenciaDireccionCliente; set => referenciaDireccionCliente = value;}

        public Cliente()
        {
            nombreCliente              = "";
            direccionCliente           = "";
            telefonoCliente            = "";
            referenciaDireccionCliente = "";
        }

        public void ObtenerCliente()
        {
            Console.WriteLine("---------- \n Datos de los Clientes ----------\n");
            Console.WriteLine();

            Console.WriteLine("Cliente: '{0}'", nombreCliente);
            Console.WriteLine("Direccion: '{0}'", direccionCliente);
            Console.WriteLine("Telefono: '{0}'", telefonoCliente);
            Console.WriteLine("Referencia sobre la direccion: {0}", referenciaDireccionCliente);
            
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------\n");
        }
    }
}