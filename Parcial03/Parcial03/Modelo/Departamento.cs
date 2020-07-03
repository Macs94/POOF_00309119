namespace Parcial03.Modelo
{
    public class Departamento
    {
        public int idDepartamento { get; set; }
        public string nombre { get; set; }
        public string ubicacion { get; set; }

        public Departamento(int idDepartamento, string nombre, string ubicacion)
        {
            this.idDepartamento = idDepartamento;
            this.nombre = nombre;
            this.ubicacion = ubicacion;
        }

        public Departamento()
        {
        }
    }
}