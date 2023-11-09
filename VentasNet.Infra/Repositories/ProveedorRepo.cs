using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public static class ProveedorRepo
    {
        public static bool VerificarProveedor(Proveedor nextProveedor)
        {
            bool existe = false;

            Proveedor existeProveedor = new Proveedor();
            existeProveedor = Listados.ListadoProveedor.Find(x => x.Id == nextProveedor.Id);

            if (existeProveedor != null)
                existe = true;

            return existe;
        }

        public static void ModificarProveedor(Proveedor nextProveedor)
        {
            Proveedor antiguoProv = new Proveedor();
            antiguoProv = nextProveedor;

            var index = Listados.ListadoProveedor.FindIndex(x => x.Id == nextProveedor.Id);
            Listados.ListadoProveedor.RemoveAt(index);
            Listados.ListadoProveedor.Add(nextProveedor);
            
        }

        internal static void ModificarId(Proveedor nextProveedor)
        {
            nextProveedor.Id = Listados.ListadoProveedor.Count + 1;
            nextProveedor.Estado = true;
            Listados.ListadoProveedor.Add(nextProveedor);
        }
    }
}

/*
var index = Listados.ListadoProveedor.FindIndex(x => x.Id == nextProveedor.Id);

Listados.ListadoProveedor[index].RazonSocial= nextProveedor.RazonSocial;
Listados.ListadoProveedor[index].CUIT= nextProveedor.CUIT;
Listados.ListadoProveedor[index].Domicilio= nextProveedor.Domicilio;
Listados.ListadoProveedor[index].Provincia= nextProveedor.Provincia;
*/
