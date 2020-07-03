using System;
using System.Drawing;
using System.Windows.Forms;
using Parcial03.Controlador;
using Parcial03.Modelo;

namespace Parcial03
{
    public partial class FormAdmin : Form
    {
        private Usuario usuario;

        private delegate void MyDelegate();

        private static MyDelegate Actualizar;
        public FormAdmin(Usuario pUsuario)
        {
            InitializeComponent();
            usuario = pUsuario;
            DoubleBuffered = true;

        }
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = "Bienvenido " + usuario.nombre;
            lblAdmin.TextAlign = ContentAlignment.MiddleLeft;
            lblAdmin.Font = new Font("Microsoft Sans Serif", 12);
            Actualizar=poblarControles;
            Actualizar += actualizartablas;
            Actualizar.Invoke();

        }

        private void poblarControles()
        {
            //Actualizar Comboboxes
            cmbDepa.DataSource = null;
            cmbDepa.ValueMember = "idDepartamento";
            cmbDepa.DisplayMember = "nombre";
            cmbDepa.DataSource = DepartamentoDAO.getLista();
            
            cmbCarnet.DataSource = null;
            cmbCarnet.ValueMember = "idUsuario";
            cmbCarnet.DisplayMember = "idUsuario";
            cmbCarnet.DataSource = UsuarioDAO.getLista();
        }

        private void actualizartablas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RegistroDAO.getLista();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = RegistroDAO.getListaEntrada();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            u.idUsuario = txtCarnet.Text;
            u.idDepartamento =  (int)cmbDepa.SelectedValue;
            u.nombre = txtNombre.Text;
            u.apellido = txtApellido.Text;
            u.dui = txtDui.Text;
            u.fechaNacimiento = Convert.ToDateTime(txtFN.Text);
            

            try
            {
                UsuarioDAO.agregarUsuario(u);
                MessageBox.Show("Usuario agregado exitosamente al departamento de "+ cmbDepa.Text+ " (la contraseña es su nombre)",
                    "Departamento de Administración-Edificio Central",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar.Invoke();

            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElim_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDAO.eliminar(cmbCarnet.Text);
                MessageBox.Show("Usuario eliminado exitosamente", "JUMBO - Bottled coffee",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualizar.Invoke();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message, "Error dialog",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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