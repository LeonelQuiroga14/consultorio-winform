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
    public partial class frmTipoUsuarios : Form
    {
        public frmTipoUsuarios()
        {
            InitializeComponent();
        }
        List<TipoUsuarios> lista;


       private static  frmTipoUsuarios frm = null;
        public  static frmTipoUsuarios GetInstancia()
        {
            if (frm==null)
            {
                frm = new frmTipoUsuarios();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static  void frm_FormClosed(object sender, FormClosedEventArgs e)
        { frm= null;
        }

        private void frmTipoUsuarios_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            try
            {
                lista = TipoUsuariosBD.GetLista();
                MostrarDatosGrilla(lista);
                VerificarCantidadRegistros();
               
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }
        bool Editar = false;
        private void SetEditar(bool v) { Editar = v; }
        private void MostrarDatosGrilla(List<TipoUsuarios> lista)
        {
            dgvdatos.Rows.Clear();
            foreach (var i in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvdatos);
                SetearFila(i, r);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvdatos.Rows.Add(r);
        }

        private void SetearFila(TipoUsuarios i, DataGridViewRow r)
        {
            r.Cells[cmnID.Index].Value = i.IdTipoUsuario.ToString();
            r.Cells[cmnTipo.Index].Value = i.TipoUsuario;
            r.Tag = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            DialogResult dr = MessageBox.Show("¿Desea salir del formulario?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
            else { return;textBox1.Focus(); }
        }
        TipoUsuarios tipouser,tipoclon;

        private TipoUsuarios GetTipoUsuario() {
            return tipouser;
        }

        private void VerificarCantidadRegistros() {
            int cantidad;
            lista = TipoUsuariosBD.GetLista();
            cantidad = lista.Count;
            if (cantidad == 3)
            {
                this.btnAceptar.Enabled = false;
            }
            else { this.btnAceptar.Enabled = true; }

        }
        private void SetTipoUsuario(TipoUsuarios t)
        {
            tipouser = t;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipouser == null)
                {
                    tipouser = new TipoUsuarios { TipoUsuario = textBox1.Text };
                }
                else {
                    tipouser = this.GetTipoUsuario();
                }
                
                if (Editar == false)
                {
                    try
                    {
                        TipoUsuariosBD.Agregar(tipouser);
                        MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        lista = TipoUsuariosBD.GetLista();
                        MostrarDatosGrilla(lista);
                        VerificarCantidadRegistros();
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else {
                    try
                    {
                        r = GetRow();
                        tipoclon = (TipoUsuarios)tipouser.Clone();
                        tipouser.TipoUsuario = textBox1.Text;
                      
                        TipoUsuariosBD.Editar(tipouser);
                        
                        SetearFila( tipouser,r);
                        MessageBox.Show("Registro Editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VerificarCantidadRegistros();
                        textBox1.Clear();
                        textBox1.Focus();
                        tipouser = null;
                        SetEditar(false);
                    }
                    catch (Exception ex )
                    {
                       SetearFila(tipoclon, r);
                        throw ex;
                    }

                }
            }
        }
        
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                valido = false;
                errorProvider1.SetError(textBox1, "Debe ingresar datos.");

            }
            return valido;
        }
        DataGridViewRow r;
        private void SetRow(DataGridViewRow rw) { r = rw; }
        private DataGridViewRow GetRow() {
            return r;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvdatos.SelectedRows.Count>0)
            {
                 r = dgvdatos.SelectedRows[0];
                SetRow(r);
                tipouser = (TipoUsuarios)r.Tag;
                TipoUsuarios tipoclon =(TipoUsuarios) tipouser.Clone();      
                this.SetEditar(true);
                this.SetTipoUsuario(tipouser);
                textBox1.Text = tipouser.TipoUsuario;

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dgvdatos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvdatos.SelectedRows[0];
                tipouser =(TipoUsuarios) r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea eliminar el tipo de usuario {tipouser.TipoUsuario}?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr==DialogResult.Yes)
                {
                    try
                    {
                        TipoUsuariosBD.Eliminar(tipouser);
                        dgvdatos.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VerificarCantidadRegistros();
                        
                    }
                    catch (Exception ex)
                    {

                        throw ex ;
                    } 
                }
            }
        }
    }
}
