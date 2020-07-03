using System;

namespace Parcial03.Modelo
{
    public class Registro
    {
        public int idRegistro { get; set; }
        public string idUsuario { get; set; }
        public DateTime fechahora { get; set; }
        public int temperatura { get; set; }

        public bool entrada { get; set; }

        public Registro(int idRegistro, string idUsuario, DateTime fechahora,int temperatura,bool entrada)
        {
            this.idRegistro = idRegistro;
            this.idUsuario = idUsuario;
            this.fechahora = fechahora;
            this.temperatura = temperatura;
            this.entrada = entrada;
        }

        public Registro()
        {
        }
    }
}