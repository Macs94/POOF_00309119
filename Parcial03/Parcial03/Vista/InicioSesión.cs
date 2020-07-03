using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial03.Controlador;
using Parcial03.Modelo;

namespace Parcial03
{
    public partial class InicioSesión : Form
    {
        public InicioSesión()
        {
            InitializeComponent();
        }
        private void InicioSesión_Load(object sender, EventArgs e)
        {
            poblarControles();
        }
        private void poblarControles()
        {
            // Actualizar ComboBox
            cmbCarnet.DataSource = null;
            cmbCarnet.ValueMember = "contraseña";
            cmbCarnet.DisplayMember = "idUsuario";
            cmbCarnet.DataSource = UsuarioDAO.getLista();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtContra.Text == cmbCarnet.SelectedValue.ToString())
            {
                Usuario u = (Usuario) cmbCarnet.SelectedItem;
                if (u.idDepartamento == 1)
                {
                    FormAdmin ventanaAdmin = new FormAdmin(u);
                    ventanaAdmin.Owner = this;
                    this.Hide();
                    ventanaAdmin.ShowDialog();
                    this.Close();
                }
                else if (u.idDepartamento == 2)
                {
                    FormVigilante ventanaV = new FormVigilante(u);
                    ventanaV.Owner = this;
                    this.Hide();
                    ventanaV.ShowDialog();
                    this.Close();

                }
                else if (u.idDepartamento == 3)
                {
                    FormGeneral ventanaG = new FormGeneral(u);
                    ventanaG.Owner = this;
                    this.Hide();
                    ventanaG.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("¡Contraseña incorrecta!", "Error dialog", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       
    }
}