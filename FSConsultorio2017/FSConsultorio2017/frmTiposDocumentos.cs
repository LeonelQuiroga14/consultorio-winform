using BL;
using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSConsultorio2017
{
    public partial class frmTiposDocumentos : Form
    {
        public frmTiposDocumentos()
        {
            InitializeComponent();
        }

        private static frmTiposDocumentos frm =null;
        public static frmTiposDocumentos Instancia()
        {
            if (frm == null)
            {
                frm = new frmTiposDocumentos();
                frm.FormClosed+= new FormClosedEventHandler(form_FormClosed);
            }
            return frm;
        }
        private static void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private List<TipoDocumento> lista;
        private void frmTiposDocumentos_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Dock=DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            try
            {
                lista = TiposDocBD.GetLista();
                MostrarDatosGrilla(lista);

            }
            catch (Exception ex )
            {
                
                throw ex;
            }
        }

        private void MostrarDatosGrilla(List<TipoDocumento> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var item in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, item);
                AgregarFlia(r);


            }
        }

        private void AgregarFlia(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoDocumento item)
        {
            r.Cells[cmnTipoDoc.Index].Value = item.TipoDoc;
            r.Tag = item;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmTiposDocAE frm= new frmTiposDocAE {Text = "Agregar tipos de documentos"};
            DialogResult dr = frm.ShowDialog();
            if (dr==DialogResult.OK)
            {
                try
                {

                    MostrarDatosAgregados();
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

        private void MostrarDatosAgregados()
        {
            List<TipoDocumento> lista = TiposDocBD.GetLista();
            MostrarDatosGrilla(lista);
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoDocumento tp = (TipoDocumento)r.Tag;
                DialogResult dr =
                    MessageBox.Show(string.Format("¿Desea eliminar {0} de la lista?",tp.TipoDoc),"Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        TiposDocBD.Borrar(tp);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count>0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                TipoDocumento tp = (TipoDocumento)r.Tag;
                TipoDocumento tpAux = (TipoDocumento) tp.Clone();
                frmTiposDocAE frm= new frmTiposDocAE {Text="Editar Tipo documento"};
                frm.SetEditar(true);
                frm.SetTipoDocumento(tp);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        tp = frm.GetTipoDocumento();
                        TiposDocBD.Editar(tp);
                        SetearFila(r,tp);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r,tpAux);

                    }
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            new Exportar().ExportarDgv(dgvDatos);
        }
    }
}
