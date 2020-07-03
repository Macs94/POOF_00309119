using System;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;
using Parcial03.Controlador;
using Parcial03.Modelo;

namespace Parcial03
{
    public partial class FormVigilante : Form
    {
        private Usuario usuario;
        private delegate void MyDelegate();

        private static MyDelegate Actualizar;
        public FormVigilante(Usuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            DoubleBuffered = true;
        }
        private void FormVigilante_Load(object sender, EventArgs e)
        {
            lblVigilante.Text = "Bienvenido " + usuario.nombre;
            lblVigilante.TextAlign = ContentAlignment.MiddleLeft;
            lblVigilante.Font=new Font("Microsoft Sans Serif",12); 
            Actualizar = poblarControles;
            Actualizar += actualizartablas;
            Actualizar.Invoke();
            
        }

        private void poblarControles()
        {
            cmbCarnet1.DataSource = null;
            cmbCarnet1.ValueMember = "idUsuario";
            cmbCarnet1.DisplayMember = "idUsuario";
            cmbCarnet1.DataSource = UsuarioDAO.getLista();
            
            cmbCarnet2.DataSource = null;
            cmbCarnet2.ValueMember = "idUsuario";
            cmbCarnet2.DisplayMember = "idUsuario";
            cmbCarnet2.DataSource = UsuarioDAO.getLista();
        }

        private void actualizartablas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RegistroDAO.getLista();
        }
        private void btnRegreso_Click(object sender, EventArgs e)
        {
            InicioSesión ventana = new InicioSesión();
            ventana.Owner = this;
            this.Hide();
            ventana.ShowDialog();
            this.Close();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            Registro r = new Registro();
            r.idUsuario = (string) cmbCarnet1.SelectedValue;
            r.fechahora = dateTimePicker1.Value;
            r.temperatura = Convert.ToInt32(txtTemp1.Text);
            r.entrada = true;
            try
            {
                RegistroDAO.agregarRegistro(r);
                MessageBox.Show("Registro de entrada del usuario "+r.idUsuario+" agregado exitosamente",
                    "Departamento de Vigilancia-Edificio de Seguridad",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar.Invoke();

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            Registro r = new Registro();
            r.idUsuario = (string) cmbCarnet1.SelectedValue;
            r.fechahora = dateTimePicker1.Value;
            r.temperatura = Convert.ToInt32(txtTemp1.Text);
            r.entrada = false;
            try
            {
                RegistroDAO.agregarRegistro(r);
                MessageBox.Show("Registro de salida del usuario "+r.idUsuario+" agregado exitosamente",
                    "Departamento de Vigilancia-Edificio de Seguridad",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar.Invoke();

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}