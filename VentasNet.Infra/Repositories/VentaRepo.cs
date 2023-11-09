using VentasNet.Models;

namespace VentasNet.Infra.Repositories
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
