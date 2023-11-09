using VentasNet.Entity.Data;
using VentasNet.Models;

namespace VentasNet.Infra.Repositories
{
    public class ClienteRepo
    {
        VentasNetContext _context = new VentasNetContext();

        public bool AgregarCliente(Cliente objCliente) //Se trae el objeto que viene del front
        {
            var existeCliente = _context.Cliente.Where(x=> x.Cuit==objCliente.CUIT).FirstOrDefault();
            if (existeCliente == null) 
            {
                try
                {
                    _context.Add(objCliente);
                    _context.SaveChanges();
                }
                catch(Exception ex) 
                {

                }  
                
            }
            return false;
        }

        public bool UpdateCliente(Cliente objCliente) //Se trae el objeto que viene del front
        {
            var existeCliente = _context.Cliente.Where(x => x.Cuit == objCliente.CUIT).FirstOrDefault();

            try
            {
                existeCliente.Provincia = objCliente.Provincia;
                existeCliente.Domicilio = objCliente.Domicilio;
                _context.Update(existeCliente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public List<Cliente> ListaDeClientes()
        {
            //Instanciando Clase Cliente
            List<Cliente> listadoCliente = new List<Cliente>(); //Necesito hacer un Listado y no un solo Cliente, por eso uso List<>

            //Como traer una lista, en este caso de Clientes desde la base de datos con Entity
            var listaClienteEntity= _context.Cliente.ToList();//Esto es analogo a un SELECT ALL (*), o sea trae todos los campos de Cliente: select * from Cliente => A la base de datos
            var ClienteEntity = _context.Cliente.Where(x => x.IdCliente == 1).FirstOrDefault();

            listadoCliente.Add(new Cliente() { Id = 1, RazonSocial = "Simon.com", CUIT = "123123", Domicilio = "Lomas", Provincia = "Corrientes" });

            //Otra forma
            Cliente cli= new Cliente() { Id = 2, RazonSocial = "Brian.com", CUIT = "12321123", Domicilio = "Lomas", Provincia = "Buenos Aires" };
            listadoCliente.Add(cli);
            

            return listadoCliente;
        }

        public void ModificarCliente(Cliente nextCliente)
        {
            int cantClientes = Listados.ListadoClientes.Count;

            nextCliente.Id = cantClientes+1;
            nextCliente.Estado = true;
            Listados.ListadoClientes.Add(nextCliente);

        }

        public bool VerificarCliente(Cliente cli)
        {
            bool existe = false;

            Cliente existeCliente = new Cliente();
            existeCliente = Listados.ListadoClientes.Find(x => x.Id == cli.Id);
            
            if (existeCliente != null)
                existe = true;
          
            return existe;
        }

    }
}

            