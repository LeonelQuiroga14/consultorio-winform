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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private static frmUsuarios frm = null;
        public static frmUsuarios GetInstancia()
        {
            if (frm==null)
            {
                frm = new frmUsuarios();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

            }
            return frm;
        }
        
        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;
            this.cboAdministrativo.Enabled = false;
            if (rbtMedico.Checked)
            {
                cboMedicos.Enabled = true;
                cboAdministrativo.Enabled = false;
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;
            }

            try
            {
            MedicosBD.CargarCombobox(ref cboMedicos);
            AdministrativosBD.CargarCombobox(ref cboAdministrativo);
            TipoUsuariosBD.CargarCombobox(ref cboTipoUsuario);
                lista = UsuariosBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex )
            {

                throw ex;
            }


        }

        private void MostrarDatosGrilla(List<Usuarios> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var i in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(i,r);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
        
        private void SetearFila(Usuarios i, DataGridViewRow r)
        {
            r.Cells[cmnID.Index].Value = i.IdUsuario.ToString();
            r.Cells[cmnNombre.Index].Value = i.Nombre;
            if (i.Medico != null)
            {
                r.Cells[cmnSector.Index].Value = "Sector Medico";

            }
            else if (i.Administrativo != null) { r.Cells[cmnSector.Index].Value = "Sector Recepcion"; }
            else { r.Cells[cmnSector.Index].Value = "Directiva del consultorio"; }
            r.Cells[cmnTipo.Index].Value = i.TipoUsuario.TipoUsuario;
            r.Cells[cmnEstado.Index].Value = i.Bloqueo ? "Usuario bloqueado" : "Usuario habilitado";
            r.Tag = i;
        }

        private void chkBloqueo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBloqueo.Checked == true)
            {
                lblBloquoe.Text = "Usuario bloqueado";

            }
            else { lblBloquoe.Text = "Usuario Habilitado"; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void LimpiarControles()
        {
            rbtMedico.Checked = true;
            cboMedicos.SelectedIndex = 0;
            cboAdministrativo.SelectedIndex = 0;
            cboTipoUsuario.SelectedIndex = 0;
            txtNombre.Clear();
            txtContraseña.Clear();
            txtVerContraseña.Clear();
            chkBloqueo.Checked = false;
            cboMedicos.Focus();
        }

        private void rbtMedico_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMedico.Checked)
            {
                cboMedicos.Enabled = true;
                cboAdministrativo.Enabled = false;
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;
            }
            else { cboMedicos.Enabled = false;
                cboAdministrativo.Enabled = true;
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;
            }

          
        }

        private void rbtAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAdmin.Checked)
            {
                cboMedicos.Enabled = false;
                cboAdministrativo.Enabled = true;
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;

            }
            else
            {
                cboMedicos.Enabled = true;
                cboAdministrativo.Enabled = false;
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;
            }
        }

        private void cboAdministrativo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtAdmin.Checked && cboAdministrativo.SelectedIndex == 0)
            {
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;
            }
            else {
                cboTipoUsuario.Enabled = true;
                txtNombre.Enabled = true;
                txtContraseña.Enabled = true;
                txtVerContraseña.Enabled = true;
                medico = null;
                admin = (Administrativos)cboAdministrativo.SelectedItem;
            }
          
        }

        private void cboMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtMedico.Checked && cboMedicos.SelectedIndex == 0)
            {
                cboTipoUsuario.Enabled = false;
                txtNombre.Enabled = false;
                txtContraseña.Enabled = false;
                txtVerContraseña.Enabled = false;
            }
            else
            {
                cboTipoUsuario.Enabled = true;
                txtNombre.Enabled = true;
                txtContraseña.Enabled = true;
                txtVerContraseña.Enabled = true;
                medico = (Medicos)cboMedicos.SelectedItem;
                admin = null;
            } 
        }
        private Usuarios usuario,usuarioclon;
        private List<Usuarios> lista;
        private Medicos medico;
        private Administrativos admin;

        private Usuarios GetUsuario() { return usuario; }
        private void SetUsuario(Usuarios u) { usuario = u; }
        private DataGridViewRow row;
        private DataGridViewRow GetRow() { return row; }
        private void SetRow(DataGridViewRow r) { row = r; }
        private void SetEditar(bool v) { Editar = v; }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (usuario == null)
                {
                    usuario = new Usuarios();
                    usuario.Medico = medico;
                    usuario.Administrativo = admin;
                    usuario.TipoUsuario = (TipoUsuarios)cboTipoUsuario.SelectedItem;
                    usuario.Nombre = txtNombre.Text;
                    usuario.Contrasenia = txtContraseña.Text;
                    usuario.Bloqueo = chkBloqueo.Checked;
                }
                else { usuario = GetUsuario();
                }
               

                if (Editar==false)
                {
                    try
                    {
                        UsuariosBD.Agregar(usuario);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lista = UsuariosBD.GetLista();
                        MostrarDatosGrilla(lista);
                        LimpiarControles();
                    }
                    catch (Exception ex )
                    {

                        throw ex ;
                    }
                }
                else {
                    try
                    {
                        row = GetRow();
                       
                        usuarioclon = (Usuarios)usuario.Clone();
                        usuario.Medico = medico;
                        usuario.Administrativo = admin;
                        usuario.TipoUsuario = (TipoUsuarios)cboTipoUsuario.SelectedItem;
                        usuario.Nombre = txtNombre.Text;
                        usuario.Contrasenia = txtContraseña.Text;
                        usuario.Bloqueo = chkBloqueo.Checked;

                        UsuariosBD.Editar(usuario);
                        SetearFila(usuario, row);
                        MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        usuario = null;
                        SetEditar(false);

                        LimpiarControles();
                    }
                    catch (Exception ex )
                    {
                        SetearFila(usuarioclon, row);
                        throw ex ;
                    }
                }

            }
        }
        bool Editar = false;
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (rbtMedico.Checked)
            {
                if (cboMedicos.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(cboMedicos, "Seleccione un medico");
                }


            } else if (rbtAdmin.Checked)

            {

                if (cboAdministrativo.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(cboAdministrativo, "Seleccione un administrativo");
                }

            }
            if (cboTipoUsuario.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTipoUsuario, "Seleccione un tipo de usuario");
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Ingrese Nombre de usuario");
            }
            if (string.IsNullOrEmpty(txtContraseña.Text))
            {
                valido = false;
                errorProvider1.SetError(txtContraseña, "Ingrese una Contraseña");
            }
            else if (txtContraseña.Text.Length<8)
            {
                valido = false;
                errorProvider1.SetError(txtContraseña, "la contraseña debe contener al menos 8 caracteres");
            }
            if (string.IsNullOrEmpty(txtVerContraseña.Text))
            {
                valido = false;
                errorProvider1.SetError(txtVerContraseña, "Repita la contrsañe anterior para verificar");
            } else if (txtVerContraseña.Text!=txtContraseña.Text) { valido = false; errorProvider1.SetError(txtVerContraseña, "La contraseña no coincide con la anterior"); }
            if (Editar==false)
            {
                if (chkBloqueo.Checked==true)
                {
                    valido = false;
                    errorProvider1.SetError(chkBloqueo, "No se puede registrar un usuario en estado Bloqueado");
                }
            }
            return valido;
        }

        private void rbtDirectiva_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDirectiva.Checked)
            {
                cboAdministrativo.Enabled = false;
                cboMedicos.Enabled = false;
                cboTipoUsuario.Enabled = true;
                medico = null;
                admin = null;
            }
            
            
        }

        private void cboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtDirectiva.Checked)
            {
                if (cboTipoUsuario.SelectedIndex > 0)
                {
                    txtNombre.Enabled = true;
                    txtContraseña.Enabled = true;
                    txtVerContraseña.Enabled = true;
                }
                else
                {
                    txtNombre.Enabled = false;
                    txtContraseña.Enabled =false;
                    txtVerContraseña.Enabled = false;
                }
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
            {
                txtContraseña.UseSystemPasswordChar = false;
                txtVerContraseña.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
                txtVerContraseña.UseSystemPasswordChar = true;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            bool bloqueo;
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("¿Desea bloquear/desbloquear este usuario?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr==DialogResult.Yes)
                {
                    DataGridViewRow r = dgvDatos.SelectedRows[0];
                    usuario = (Usuarios)r.Tag;
                    usuarioclon = (Usuarios)usuario.Clone();
                    if (usuario.Bloqueo == true)
                    {
                        bloqueo = false;
                    }
                    else { bloqueo = true; }
                    try
                    {
                        UsuariosBD.BloquearUsuario(usuario, bloqueo);SetearFila(usuario, r);
                        MessageBox.Show("Usuario Bloqueado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception ex)
                    {
                        SetearFila(usuarioclon, r);
                        throw ex;
                    } 
                }
                

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                lista = UsuariosBD.GetLista();
                MostrarDatosGrilla(lista);
                MessageBox.Show("Se actualizó la grilla.", "Lista Actualiada - Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                SetRow(r);
                usuario = (Usuarios)r.Tag;
                SetEditar(true);
                SetUsuario(usuario);
                if (usuario.Medico != null)
                {
                    rbtMedico.Checked = true;
                    cboMedicos.SelectedValue = usuario.Medico.IdMedico;
                }
                else if (usuario.Administrativo != null)
                {
                    rbtAdmin.Checked = true;
                    cboAdministrativo.SelectedValue = usuario.Administrativo.IdAdministrativo;
                }else
                { rbtDirectiva.Checked = true; }
                cboTipoUsuario.SelectedValue = usuario.TipoUsuario.IdTipoUsuario;

                txtNombre.Text = usuario.Nombre;
                txtContraseña.Text = usuario.Contrasenia;
                txtVerContraseña.Text = string.Empty;
                chkBloqueo.Checked = usuario.Bloqueo;


            }
        }
    }
}
