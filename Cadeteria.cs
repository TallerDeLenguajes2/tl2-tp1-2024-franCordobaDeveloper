using Cadetes;

namespace Cadeterias
{
    class Cadeteria
    {
        private string nombreCadeteria;
        private string telefonoCadeteria;
        private List<Cadete> listadoCadetes;

        public Cadeteria(string nombreCadeteria, string telefonoCadeteria, List<Cadete> listadoCadetes)
        {
            this.nombreCadeteria   = nombreCadeteria;
            this.telefonoCadeteria = telefonoCadeteria;
            this.listadoCadetes    = listadoCadetes;
        }

        public string NombreCadeteria {get => nombreCadeteria; set => nombreCadeteria = value;}
        public string TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value;}
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria()
        {
            nombreCadeteria   = "";
            telefonoCadeteria = "";
            listadoCadetes    = new List<Cadete>();
        }




    }
}