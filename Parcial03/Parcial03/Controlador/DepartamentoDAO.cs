using System;
using System.Collections.Generic;
using System.Data;
using Parcial03.Modelo;

namespace Parcial03.Controlador
{
    public class DepartamentoDAO
    {
        public static List<Departamento> getLista()
        {
            string sql = "select * from departamento";

            DataTable dt = ConneccionDB.realizarConsulta(sql);
            
            List<Departamento> lista = new List<Departamento>();

            foreach (DataRow fila in dt.Rows)
            {
                Departamento d = new Departamento();
                d.idDepartamento = Int32.Parse(fila[0].ToString());
                d.nombre = fila[1].ToString();
                d.ubicacion = fila[2].ToString();
                
                lista.Add(d);
            }

            return lista;
        }
    }
}