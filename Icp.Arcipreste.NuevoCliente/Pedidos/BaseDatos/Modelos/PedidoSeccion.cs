namespace Icp.Arcipreste.NuevoCliente.Pedidos.BaseDatos.Modelos
{
    public class PedidoSeccion
    {
        public int id_pedido { get; set; }
        public int id_articulo { get; set; }
        public int cantidad { get; set; }
        public int id_seccion_pedido { get; set; }
    }
}
