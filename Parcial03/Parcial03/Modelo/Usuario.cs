using System;

namespace Parcial03.Modelo
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public int idDepartamento { get; set; }
        public string contraseña { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dui { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public Usuario(string idUsuario, int idDepartamento, string contraseña, string nombre, 
            string apellido, string dui, DateTime fechaNacimiento)
        {
            this.idUsuario = idUsuario;
            this.idDepartamento = idDepartamento;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dui = dui;
            this.fechaNacimiento = fechaNacimiento;
        }

        public Usuario()
        {
        }
    }
}