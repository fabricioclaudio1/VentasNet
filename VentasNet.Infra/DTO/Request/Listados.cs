using Microsoft.AspNetCore.Identity;

namespace VentasNet.Models
{
    public static class Listados
    {
        public static List<ClienteReq> ListadoClientes { get; set; } = new List<ClienteReq>() {
            new ClienteReq {Id=1, RazonSocial="qqq", CUIT= "123", Domicilio= "aaa", Estado=true, Provincia="salta"}, 
            new ClienteReq {Id=2, RazonSocial="www", CUIT= "456", Domicilio= "sss", Estado=true, Provincia="tucuman"},
            new ClienteReq {Id=3, RazonSocial="eee", CUIT= "789", Domicilio= "ddd", Estado=true, Provincia="jujuy"} };
        public static List<ProveedorReq> ListadoProveedor { get; set; } = new List<ProveedorReq>() {
            new ProveedorReq {Id=1, RazonSocial="prov123", CUIT="p123", Domicilio="rrr", Estado=true, Provincia="salta"},
            new ProveedorReq {Id=2, RazonSocial="prov456", CUIT="p456", Domicilio="ttt", Estado=true, Provincia="tucuman"},
            new ProveedorReq {Id=3, RazonSocial="prov789", CUIT="p789", Domicilio="yyy", Estado=true, Provincia="jujuy"}};

        //Listado de Productos disponibles en el negocio
        public static List<Producto> ListadoProducto { get; set; } = new List<Producto>() { 
            new Producto {Id=1, IdProveedor=1, NombreProducto="Aceite", Descripcion="bla bla bla", ImporteProducto=5 },
            new Producto {Id=2, IdProveedor=2, NombreProducto="Queso", Descripcion="bla bla bla", ImporteProducto=8 },
            new Producto {Id=3, IdProveedor=3, NombreProducto="Salame", Descripcion="bla bla bla", ImporteProducto=10 },
            new Producto {Id=4, IdProveedor=1, NombreProducto="Mayonesa", Descripcion="bla bla bla", ImporteProducto=3 },
            new Producto {Id=5, IdProveedor=2, NombreProducto="Cebolla", Descripcion="bla bla bla", ImporteProducto=2 },
            new Producto {Id=6, IdProveedor=3, NombreProducto="Jamon", Descripcion="bla bla bla", ImporteProducto=12 }};

        //Productos que estan en los tickets
        public static List<ProductoVendido> ListadoProductoVendido { get; set; } = new List<ProductoVendido>() { 
            new ProductoVendido {Id=1, IdVenta=1, IdProducto=1, Cantidad=2 },
            new ProductoVendido {Id=2, IdVenta=1, IdProducto=3, Cantidad=3 },
            new ProductoVendido {Id=3, IdVenta=1, IdProducto=4, Cantidad=5 },
            new ProductoVendido {Id=4, IdVenta=1, IdProducto=6, Cantidad=3 }};

        //Tickets
        public static List<Venta> ListadoVenta { get; set; } = new List<Venta>() { 
            new Venta {Id=1, IdCliente=1, Total=91 } };

        //Administrador
        public static List<Usuario> ListadoUsuarios { get; set; } = new List<Usuario>() { 
            new Usuario { Id = 1, Login = "nombre", Password = "123" } };
    }
}
