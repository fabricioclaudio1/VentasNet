namespace VentasNet.Models
{
    public class ProductoVendido
    {
        public int Id { get; set; } 
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set;}

    }
}

