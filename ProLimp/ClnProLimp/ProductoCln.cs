using CadProLimp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnProLimp
{
    public class ProductoCln
    {
        public static bool ExisteCodigo(string codigo, int? excluirId = null)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return false;
            using (var context = new LabProLimpEntities())
            {
                return context.Producto.Any(p =>
                    p.estado > -1 &&
                    p.codigo == codigo &&
                    (!excluirId.HasValue || p.id != excluirId.Value));
            }
        }

        public static int insertar(Producto producto)
        {
            using (var context = new LabProLimpEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.id;
            }
        }

        public static int actualizar(Producto producto)
        {
            using (var context = new LabProLimpEntities())
            {
                var existe = context.Producto.Find(producto.id);
                existe.id_unidad_medida = producto.id_unidad_medida;
                existe.id_categoria = producto.id_categoria;
                existe.id_marca = producto.id_marca;
                existe.id_proveedor = producto.id_proveedor;
                existe.codigo = producto.codigo;
                existe.nombre = producto.nombre;
                existe.precio_unitario = producto.precio_unitario;
                existe.stock = producto.stock;
                existe.fecha_vencimiento = producto.fecha_vencimiento;
                existe.precio_compra = producto.precio_compra;
                existe.cantidad_minima_stock = producto.cantidad_minima_stock;
                return context.SaveChanges();

            }
        }

        public static int actualizarStock(int idProducto, decimal cantidadVendida)
        {
            using (var context = new LabProLimpEntities())
            {
                var producto = context.Producto.Find(idProducto);
                if (producto != null)
                {
                    producto.stock = producto.stock - (int)cantidadVendida;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabProLimpEntities())
            {
                var existe = context.Producto.Find(id);
                existe.estado = -1;
                existe.usuario_registro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Producto obtenerUno(int id)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.Producto.Find(id);
            }
        }

        public static List<Producto> listar()
        {
            using (var context = new LabProLimpEntities())
            {
                return context.Producto.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paProductoListar_Result> listarPa(string parametro)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.paProductoListar(parametro).ToList();
            }
        }
    }
}
