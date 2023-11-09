namespace VentasNet.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? RazonSocial { get; set; } //Con el signo de pregunta hago que acepte NULL
        public string? CUIT { get; set; }
        public string? Domicilio { get; set; }
        public string? Provincia { get; set; }
        public bool Estado { get; set; } 
    }
}
