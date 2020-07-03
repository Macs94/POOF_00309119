using System;
using System.Collections.Generic;
using System.Data;
using Parcial03.Modelo;

namespace Parcial03.Controlador
{
    public class RegistroDAO
    {
        public static List<Registro> getLista()
        {
            string sql = "select * from registro";


            DataTable dt = ConneccionDB.realizarConsulta(sql);

            List<Registro> lista = new List<Registro>();

            foreach (DataRow fila in dt.Rows)
            {
                Registro r = new Registro();
                r.idRegistro = Int32.Parse(fila[0].ToString());
                r.idUsuario = fila[1].ToString();
                r.fechahora = DateTime.Parse(fila[2].ToString());
                r.temperatura = Int32.Parse(fila[3].ToString());
                r.entrada = Convert.ToBoolean(fila[4].ToString());
                lista.Add(r);
            }


            return lista;
        }

        public static void agregarRegistro(Registro r)
        {
            string sql = String.Format(
                "insert into registro (\"idUsuario\", \"fechayhora\", \"temperatura\", \"entrada\") "
                + " values ('{0}', '{1}', '{2}', '{3}');"
                , r.idUsuario, r.fechahora, r.temperatura, r.entrada);
            ConneccionDB.realizarAccion(sql);
        }

        public static List<Registro> getListaUsuario(string idUsuario)
        {
            string sql = String.Format(
                "select * from registro where \"idUsuario\"='{0}';",
                idUsuario);

            DataTable dt = ConneccionDB.realizarConsulta(sql);

            List<Registro> lista = new List<Registro>();
            foreach (DataRow fila in dt.Rows)
            {
                Registro r = new Registro();
                r.idRegistro = Int32.Parse(fila[0].ToString());
                r.idUsuario = fila[1].ToString();
                r.fechahora = DateTime.Parse(fila[2].ToString());
                r.temperatura = Int32.Parse(fila[3].ToString());
                r.entrada = Convert.ToBoolean(fila[4].ToString());
                lista.Add(r);

            }

            return lista;
        }

        public static List<Registro> getListaEntrada()
        {
            string sql = "select * from registro where \"entrada\" = 'true'";


            DataTable dt = ConneccionDB.realizarConsulta(sql);

            List<Registro> lista = new List<Registro>();

            foreach (DataRow fila in dt.Rows)
            {
                Registro r = new Registro();
                r.idRegistro = Int32.Parse(fila[0].ToString());
                r.idUsuario = fila[1].ToString();
                r.fechahora = DateTime.Parse(fila[2].ToString());
                r.temperatura = Int32.Parse(fila[3].ToString());
                r.entrada = Convert.ToBoolean(fila[4].ToString());
                lista.Add(r);
            }


            return lista;
        }

        public static List<Registro> GetTop5Temperaturas()
        {
            string sql = "SELECT * FROM registro ORDER BY temperatura DESC LIMIT 5;";

            DataTable dt = ConneccionDB.realizarConsulta(sql);

            List<Registro> lista = new List<Registro>();
            foreach (DataRow fila in dt.Rows)
            {
                Registro r = new Registro();
                r.idRegistro = Convert.ToInt32(fila[0].ToString());
                r.idUsuario = fila[1].ToString();
                r.fechahora = DateTime.Parse(fila[2].ToString());
                r.temperatura = Int32.Parse(fila[3].ToString());
                r.entrada = Convert.ToBoolean(fila[4].ToString());

                lista.Add(r);
            }

            return lista;



        }
    }
}