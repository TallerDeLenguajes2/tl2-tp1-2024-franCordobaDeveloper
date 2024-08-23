using Cadete;

namespace Pedidos
{

    public enum EstadoPedidos
    {
        Aceptado,
        Pendiente,
        Rechazado,
        Entregado,

    }

    class Pedidos
    {
        private int idPedido;
        
        private string nombrePedido;

        private EstadoPedidos estado;
        private Cadetes cadeteAsignado;

        public Pedidos(int idPedido, string nombrePedido, EstadoPedidos estado ,Cadetes cadeteAsignado)
        {
            this.idPedido       = idPedido;
            this.nombrePedido   = nombrePedido;
            this.estado         = estado;
            this.cadeteAsignado = cadeteAsignado;
        }

        public int IdPedido {get => idPedido; set => idPedido = value;}
    }

}