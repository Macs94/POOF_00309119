using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Parcial03.Controlador;
using Parcial03.Modelo;

namespace Parcial03
{
    public partial class FormGeneral : Form
    {
        private Usuario usuario;
        private delegate void MyDelegate();

        private static MyDelegate Actualizar; 
        
        public FormGeneral(Usuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            DoubleBuffered = true;
        }
        private void FormGeneral_Load(object sender, EventArgs e)
        {
            lblGeneral.Text = "Bienvenido " + usuario.nombre;
            lblGeneral.TextAlign = ContentAlignment.MiddleLeft;
            lblGeneral.Font = new Font("Microsoft Sans Serif",12);
            Actualizar = actualizartablas;
            Actualizar.Invoke();

            

        }

        private void actualizartablas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RegistroDAO.getListaUsuario(usuario.idUsuario);
        }

        private void btnRegreso_Click(object sender, EventArgs e)
        {
            InicioSesión ventana = new InicioSesión();
            ventana.Owner = this;
            this.Hide();
            ventana.ShowDialog();
            this.Close();
        }

       
    }
}