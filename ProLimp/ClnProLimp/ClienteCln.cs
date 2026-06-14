using CadProLimp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnProLimp
{
    public class ClienteCln
    {
        public static Cliente validar(string cliente, string cedulaIdentidad)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.Cliente.Where(c => c.razon_social == cliente && c.cedula_identidad == cedulaIdentidad).FirstOrDefault();
            }
        }

        public static int insertar(Cliente cliente)
        {
            using (var context = new LabProLimpEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static int actualizar(Cliente cliente)
        {
            using (var context = new LabProLimpEntities())
            {
                var existe = context.Cliente.Find(cliente.id);
                existe.razon_social = cliente.razon_social;
                existe.cedula_identidad = cliente.cedula_identidad;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabProLimpEntities())
            {
                var existe = context.Cliente.Find(id);
                existe.estado = -1;
                existe.usuario_registro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Cliente obtenerUno(int id)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.Cliente.Find(id);
            }
        }

        public static List<Cliente> listar()
        {
            using (var context = new LabProLimpEntities())
            {
                return context.Cliente.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paClienteListar_Result> listarPa(string parametro)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.paClienteListar(parametro).ToList();
            }
        }

        public static bool ExisteCedula(string cedulaIdentidad, int? excluirId = null)
        {
            if (string.IsNullOrWhiteSpace(cedulaIdentidad)) return false;
            using (var context = new LabProLimpEntities())
            {
                return context.Cliente.Any(c =>
                    c.estado > -1 &&
                    c.cedula_identidad == cedulaIdentidad &&
                    (!excluirId.HasValue || c.id != excluirId.Value));
            }
        }

        public static Cliente obtenerPorId(int id)
        {
            using (var context = new LabProLimpEntities())
            {
                return context.Cliente
                    .FirstOrDefault(x => x.id == id && x.estado != -1);
            }
        }
    }
}
