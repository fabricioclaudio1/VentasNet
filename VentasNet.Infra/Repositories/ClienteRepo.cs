using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class ClienteRepo
    {
        private readonly VentasNetContext _context;

        public ClienteRepo() //Conexion
        {
            _context = new VentasNetContext();
        }

        public ClienteResponse AddCliente(ClienteReq objCliente) //Se trae el objeto que viene del front
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuit);
            if (existeCliente == null) 
            {
                try
                {
                    _context.Add(objCliente);
                    _context.SaveChanges();  //Agrego Cliente del formulario del front a la DB
                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = objCliente.RazonSocial;
                }
                catch(Exception ex) 
                {
                    clienteResponse.Mensaje = "Ocurrio un error al Agregar Cliente";
                    clienteResponse.Guardar = false; //Solo para asegurarme
                }  
                
            }
            return clienteResponse;
        }

        public ClienteResponse UpdateCliente(ClienteReq objCliente) //Se trae el objeto que viene del front
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuit);

            if (existeCliente != null)
            {
               try
               {
                   existeCliente.Provincia = objCliente.Provincia;
                   existeCliente.Domicilio = objCliente.Domicilio;
                   _context.Update(existeCliente);
                   _context.SaveChanges();
                   clienteResponse.Guardar = true;
                   clienteResponse.RazonSocial = existeCliente.RazonSocial;
               }
               catch (Exception ex)
               {
                   clienteResponse.Mensaje = "Ocurrio un error al Modificar Cliente";
                   clienteResponse.Guardar = false; //Solo para asegurarme
               } 
            }
            
            return clienteResponse;
        }

        public ClienteResponse Delete(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(objCliente.Cuit);

            if(existeCliente != null)
            {
                try
                {
                    existeCliente.Estado = false;
                    existeCliente.FechaBaja = DateTime.Now;

                    _context.Update(existeCliente); // Es update porque lo "borro" poniendo como estado = false 
                    _context.SaveChanges();

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrio un error al Eliminar Cliente";
                    clienteResponse.Guardar = false; //Solo para asegurarme
                }
            }
            
            return clienteResponse;
        }

        public Cliente GetClienteCuit(string cuit)
        {
            var cliente = _context.Cliente.Where(x => x.Cuit == cuit).FirstOrDefault();

            return cliente;
        }

        public List<ClienteReq> GetClientes() //Lista de Clientes
        {
            List<ClienteReq> listadoClientes = new List<ClienteReq>();

            var lista= _context.Cliente.Where(x => x.Estado != false).ToList();

            foreach (var item in lista) 
            {
                ClienteReq clienteReq = new ClienteReq();

                clienteReq.IdCliente = item.IdCliente;
                clienteReq.Nombre = item.Nombre;
                clienteReq.Apellido = item.Apellido;
                clienteReq.Cuit = item.Cuit;
                clienteReq.RazonSocial = item.RazonSocial;
                clienteReq.Domicilio = item.Domicilio;
                clienteReq.Localidad = item.Localidad;
                clienteReq.Estado = item.Estado;
                clienteReq.FechaBaja = item.FechaBaja;
                clienteReq.FechaAlta = item.FechaAlta;

                listadoClientes.Add(clienteReq);
            }

            return listadoClientes;
        }

        //Arriba se hicieron las operaciones CRUD


    }
}

            