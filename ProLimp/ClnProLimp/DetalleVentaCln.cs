using CadProLimp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnProLimp
{
    public class DetalleVentaCln
    {
        public static int insertar(DetalleVenta detalleVenta)
        {
            using (var context = new LabProLimpEntities())
            {
                context.DetalleVenta.Add(detalleVenta);
                context.SaveChanges();
                return detalleVenta.id;
            }
        }

        public static int actualizar(DetalleVenta detalleVenta)
        {
            using (var context = new LabProLimpEntities())
            {
                var existe = context.DetalleVenta.Find(detalleVenta.id);
                existe.id_venta = detalleVenta.id_venta;
                existe.id_producto = detalleVenta.id_producto;
                existe.cantidad = detalleVenta.cantidad;
                existe.precio_unitario = detalleVenta.precio_unitario;
                existe.subtotal = detalleVenta.subtotal;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabProLimpEntities())
            {
                var existe = context.DetalleVenta.Find(id);
                existe.estado = -1;
                existe.usuario_registro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static DetalleVenta obtenerUno(int id)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.DetalleVenta.Find(id);
            }
        }


        public static List<DetalleVenta> listar()
        {
            using (var context = new LabProLimpEntities())
            {
                return context.DetalleVenta.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paDetalleVentaListar_Result> listarPa(string parametro)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.paDetalleVentaListar(parametro).ToList();
            }
        }
    }
}