namespace VentasNet.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; }
        public string? CUIT { get; set; }
        public string? Domicilio { get; set; }
        public string? Provincia { get; set; }
        public bool Estado { get; set; }
    }
}

//Tengo que crear una Lista de Proveedores