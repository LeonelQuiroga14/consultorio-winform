using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Datos;

namespace FSConsultorio2017
{
    public partial class frmLocalidades : Form
    {
        public frmLocalidades()
        {
            InitializeComponent();
        }

        private List<Localidad> lista;

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmLocalidadesAE frm = new frmLocalidadesAE();
            {
                Text = "Agregar Localidades";
            }
            ;
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = LocalidadesBD.GetLista();
                    MostrarDatosGrilla(lista);

                    // MostrarDatosAgregados();
                    //TipoDocumento tp = frm.GetTipoDocumento();
                    //TiposDocBD.Agregar(tp);
                    //DataGridViewRow r= new DataGridViewRow();
                    //r.CreateCells(dgvDatos);
                    //SetearFila(r,tp);
                    //AgregarFlia(r);
                    //MessageBox.Show("Registro Agregado");


                }
                catch (Exception ex)
                {


                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatosGrilla(List<Localidad> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var localidad in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, localidad);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Localidad localidad)
        {
            r.Cells[cmnlocalidad.Index].Value = localidad.NombreLocalidad;
            r.Cells[cmnProvincia.Index].Value = localidad.provincia.Nombre;
            r.Tag = localidad;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Localidad localidad = (Localidad) r.Tag;
                Localidad localidadAux = (Localidad) localidad.Clone();
                frmLocalidadesAE frm = new frmLocalidadesAE {Text = "Editar Localdidad"};
                frm.SetEditar(true);
                frm.SetLocalidad(localidad);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        localidad = frm.GetLocalidad();
                        LocalidadesBD.Editar(localidad);
                        SetearFila(r, localidad);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, localidadAux);

                    }
                }
            }
        }

        private static frmLocalidades frm = null;

        public static frmLocalidades Instancia()
        {
            if (frm == null)
            {
                frm = new frmLocalidades();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            try
            {
                lista = LocalidadesBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Localidad loc = (Localidad) r.Tag;
                DialogResult dr = MessageBox.Show(string.Format($"¿Desea eliminar a {loc.NombreLocalidad}?"),
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        LocalidadesBD.Borrar(loc);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Localidad eliminada", "Mensaje", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}