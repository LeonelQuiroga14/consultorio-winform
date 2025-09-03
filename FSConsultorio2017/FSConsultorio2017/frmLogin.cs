using BL;
using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSConsultorio2017
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        Usuarios usuario;
        
        
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        bool CambioUser = false;
        public void SetCambioUser(bool v) { CambioUser = v; }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (CambioUser == true)
            {
                Close();
              //  return;
            }
            else
            {
                Application.Exit();
            }
        }
         string user, contrasenia;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())  {
                try
                {
                    user = txtUsuario.Text;
                    contrasenia = txtPass.Text;
                    usuario = UsuariosBD.GetUsuario(user, contrasenia);
                    if (usuario != null)
                    { if (usuario.Bloqueo == true)
                        {
                            errorProvider1.SetError(txtUsuario, "Usuario bloqueado.");
                            txtUsuario.SelectAll();
                            txtUsuario.Focus();
                        }
                        else
                        {
                            Hide();
                            MenuPrincipal frmMenu = new MenuPrincipal();
                            frmMenu.Text = "Consultorio Medicos ";
                            frmMenu.IsMdiContainer = true;
                            frmMenu.SetUsuario(usuario);
                            frmMenu.Show();
                        }            
                    }
                    else { errorProvider1.SetError(txtUsuario, "Usuario no registrado o clave erronea.");
                        txtUsuario.SelectAll();
                        txtUsuario.Focus();
                    }
                }
                catch (Exception ex )
                {

                    errorProvider1.SetError(txtUsuario, "Usuario no registrado o clave erronea.");
                    txtUsuario.SelectAll();
                    txtUsuario.Focus();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else { txtPass.UseSystemPasswordChar = true; }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                valido = false;
                errorProvider1.SetError(txtUsuario, "Ingrese un nombre de usuario.");
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPass, "Ingrese una contraseña.");
            }
            else if(txtPass.Text.Length<8)
            {

                
                    valido = false;
                    errorProvider1.SetError(txtPass, "La contraseña debe contener al menos 8 caracteres.");
                

            }
            return valido;
        }
       private static frmLogin frm = null;
        internal static frmLogin Instancia()
        {
            if (frm==null)
            {
                frm = new frmLogin();
                frm.FormClosed += new FormClosedEventHandler(frm_FormlClosed);
            }
            return frm;
        }

        private static void frm_FormlClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        internal void SetUsuario(Usuarios u)
        {
            usuario = u; ;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            
            frm.ShowDialog();
        }

        internal Usuarios GetUsuario()
        {
            return usuario;
        }
    }
}
