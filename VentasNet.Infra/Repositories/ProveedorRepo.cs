using VentasNet.Entity.Data;
using VentasNet.Entity.Models; //
using VentasNet.Infra.DTO.Request; // 
using VentasNet.Infra.DTO.Response;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class ProveedorRepo
    {
        private readonly VentasNetContext _context;

        public ProveedorRepo() //Conexion
        {
            _context = new VentasNetContext();
        }

        public ProveedorResponse AddProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);
            if (existeProveedor == null)
            {
                try
                {
                    _context.Add(objProveedor);
                    _context.SaveChanges();  //Agrego Proveedor del formulario del front a la DB
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = objProveedor.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Ocurrio un error al Agregar Proveedor";
                    proveedorResponse.Guardar = false; //Solo para asegurarme
                }

            }
            return proveedorResponse;
        }

        public ProveedorResponse UpdateProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor.Telefono = objProveedor.Telefono;
                    existeProveedor.Provincia = objProveedor.Provincia;
                    _context.Update(objProveedor);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = existeProveedor.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Error al Modificar Proveedor";
                    proveedorResponse.Guardar= false;
                }
            }

            return proveedorResponse;
        }

        public ProveedorResponse DeleteProveedor(ProveedorReq objProveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(objProveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor.Estado = false;

                    _context.Update(objProveedor);
                    _context.SaveChanges();

                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = existeProveedor.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Error al Eliminar Proveedor";
                    proveedorResponse.Guardar = false;
                }
            }

            return proveedorResponse;
        }

        public Proveedor GetProveedorCuit(string cuit)
        {

            var proveedor = _context.Proveedor.Where(x => x.Cuit == cuit).FirstOrDefault();

            return proveedor;
        }

        public List<ProveedorReq> GetProveedores()
        {
            List<ProveedorReq> listaProveedores = new List<ProveedorReq>();

            var lista = _context.Proveedor.Where(x => x.Estado != false).ToList();

            foreach (var item in lista)
            {
                ProveedorReq proveedorReq = new ProveedorReq(); //LLeno proveedorReq con datos de la DB, en cada pasada los campos de proveedorReq tendra distintos valores

                proveedorReq.IdProveedor = item.IdProveedor;
                proveedorReq.RazonSocial = item.RazonSocial;
                proveedorReq.Cuit = item.Cuit;
                proveedorReq.Nombre = item.Nombre;
                proveedorReq.Apellido = item.Apellido;
                proveedorReq.Domicilio = item.Domicilio;
                proveedorReq.Localidad = item.Localidad;
                proveedorReq.Provincia = item.Provincia;
                proveedorReq.Telefono = item.Telefono;
                proveedorReq.Estado = item.Estado;
                proveedorReq.FechaAlta = item.FechaAlta;
                proveedorReq.FechaBaja = item.FechaBaja;
                proveedorReq.IdUsuario = item.IdUsuario;

                listaProveedores.Add(proveedorReq); //Agrego a la lista el objeto proveedorReq
            }

            return listaProveedores;
        }
    }
}
