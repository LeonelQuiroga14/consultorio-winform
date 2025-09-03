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
    public partial class frmConsultorios : Form
    {
        public frmConsultorios()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Consultorios con = (Consultorios) r.Tag;
                Consultorios conAux = (Consultorios) con.Clone();
                frmConsultoriosAE frm = new frmConsultoriosAE {Text="Editar Consultorio"};
  
                frm.SetEditar(true);
                frm.SetConsultorio(con);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        con = frm.GetConsultorio();
                        ConsultoriosBD.Editar(con);
                        SetearFila(r, con);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, conAux);

                    }
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Consultorios con)
        {
            r.Cells[cmnConsultorio.Index].Value = con.Consultorio;
            r.Cells[cmnCosto.Index].Value = con.Costo.ToString();
            
                r.Cells[cmnEstado.Index].Value =  con.Estado?"Habilitado":"Inhabilitado";
           
            r.Tag = con;
        }

        private List<Consultorios> lista;

        private void frmConsultorios_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.tsAyuda.IsBalloon = true;
            dgvDatos.AllowUserToAddRows = false;
            this.tsAyuda.SetToolTip(dgvDatos,"Si el cuadro de estado esta chequeado significa\nque el consultorio esta Habilitado.");
            try
            {
                lista = ConsultoriosBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static frmConsultorios frm = null;

        public static frmConsultorios Instancia()
        {
            if (frm == null)
            {
                frm = new frmConsultorios();
                frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void MostrarDatosGrilla(List<Consultorios> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var con in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, con);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmConsultoriosAE frm = new frmConsultoriosAE {Text = "Agregar consultorio"};

            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = ConsultoriosBD.GetLista();
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

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count > 0)
            {       DataGridViewRow r = dgvDatos.SelectedRows[0];
                    Consultorios con = (Consultorios) r.Tag;
                    Consultorios conAux = (Consultorios) con.Clone();

                DialogResult drr =
                    MessageBox.Show(string.Format("Los consultorios no se pueden eliminar ¿Desea Deshablilitarlo/Habilitarlo?"),
                        "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (drr == DialogResult.Yes)
                {
                    
                    frmConsultoriosAE frm = new frmConsultoriosAE {Text="Editar consultorio"};                  
                    frm.SetEditar(true);
                    frm.SetConsultorio(con);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {

                        try
                        {
                            con = frm.GetConsultorio();
                            ConsultoriosBD.Editar(con);
                            SetearFila(r, con);
                            MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SetearFila(r, conAux);

                        }
                    }
                    drr = DialogResult.No;
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
