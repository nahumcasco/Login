using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Usuario user = new Usuario();

        

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Ingrese usuario");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Ingrese contraseña");
                textBox2.Focus();
                return;
            }

            user.CodigoUsuario = textBox1.Text;
            user.Clave = textBox2.Text;

            bool valido = conexion.ValidarUsuario(user);

            if (valido)
            {
                ProductosForm formulario = new ProductosForm();
                this.Hide();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Datos de Usuario Incorrectos");
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {

        }
    }
}
