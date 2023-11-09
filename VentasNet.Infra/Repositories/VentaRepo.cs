using VentasNet.Models;

namespace VentasNet.Repositorio
{
    public class VentaRepo
    {
        private Venta _venta = new Venta();
        public VentaRepo()
        {

        }
        public Venta VentaMostrador()
        {
            return _venta;
        }
    }
}
