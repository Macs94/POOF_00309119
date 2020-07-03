using System;
using System.Collections.Generic;
using System.Data;
using Parcial03.Modelo;

namespace Parcial03.Controlador
{
    public class UsuarioDAO
    {
        public static List<Usuario> getLista()
        {
            string sql = "select * from usuario";

            DataTable dt = ConneccionDB.realizarConsulta(sql);

            List<Usuario> lista = new List<Usuario>();
            foreach (DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();
                u.idUsuario = fila[0].ToString();
                u.idDepartamento = Int32.Parse(fila[1].ToString());
                u.contraseña = fila[2].ToString();
                u.nombre = fila[3].ToString();
                u.apellido = fila[4].ToString();
                u.dui = fila[5].ToString();
                u.fechaNacimiento = DateTime.Parse(fila[6].ToString());
                lista.Add(u);
            }
            return lista;
        }
        public static void agregarUsuario(Usuario u)
        {
            u.contraseña = u.nombre;
            
            string sql = String.Format(
                "insert into usuario" + 
                "(\"idUsuario\", \"idDepartamento\", \"contraseña\", \"nombre\", \"apellido\", \"dui\", \"fechaNacimiento\")" +
                "values ('{0}', {1}, '{2}', '{3}', '{4}', '{5}', '{6}');",
                u.idUsuario,u.idDepartamento,u.contraseña, u.nombre, u.apellido, u.dui, u.fechaNacimiento);
                
            ConneccionDB.realizarAccion(sql);
        }
        
        public static void eliminar(string idUsuario)
        {
            string sql = String.Format(
                "delete from usuario where \"idUsuario\"='{0}';",
                idUsuario);
            
            ConneccionDB.realizarAccion(sql);
        }
        
    }
}