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
    public partial class frmMedicos : Form
    {
        public frmMedicos()
        {
            InitializeComponent();
        }

        private static frmMedicos frm = null;

        public static frmMedicos GetInstancia()
        {
            if (frm==null)
            {
                frm = new frmMedicos();
                frm.FormClosed+=new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
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
                Medicos m = (Medicos) r.Tag;
                Medicos mAux = (Medicos) m.Clone();

                DialogResult drr =
                    MessageBox.Show(
                        string.Format(
                            "Los medicos no pueden eliminarse por temas de Registro. \n En caso de un mal ingreso puede editarlo ¿Continuar con la edicion?"),
                        "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (drr == DialogResult.Yes)
                {

                    frmMedicosAE frm = new frmMedicosAE { Text = "Editar Medico"};
                    frm.SetEditar(true);
                    frm.SetMedico(m);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {

                        try
                        {
                            m = frm.GetMedico();
                            MedicosBD.Editar(m);
                            SetearFila(r, m);
                            MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SetearFila(r, mAux);

                        }
                    }
                    drr = DialogResult.No;
                }
            }
        }

        private void SetearFila(DataGridViewRow r, Medicos p)
        {
            r.Cells[cmnNombreApe.Index].Value = p.Nombre + p.Apellido;
            r.Cells[cmnGenero.Index].Value = p.Genero.Genero;
            r.Cells[cmnGs.Index].Value = p.GrupoSanguineo;
            r.Cells[cmnDNI.Index].Value = p.NumeroDoc;
            r.Cells[cmnTelefonoMovil.Index].Value = p.TelefonoMovil;
            r.Cells[cmnTelefonofijo.Index].Value = p.TelefonoFijo;
            r.Cells[cmnObraSocial.Index].Value = p.ObraSocial.ObraSocial;
            r.Cells[cmnPlan.Index].Value = p.Plan.Plan;

            r.Tag = p;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Medicos p = (Medicos)r.Tag;
                Medicos pAux = (Medicos)p.Clone();
                frmMedicosAE frm = new frmMedicosAE { Text = "Editar Medico" };

                frm.SetEditar(true);
                frm.SetMedico(p);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        p = frm.GetMedico();
                        MedicosBD.Editar(p);
                        SetearFila(r, p);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, pAux);

                    }
                }
            }
        }

        private List<Medicos> lista;
        private void tsbAgregar_Click(object sender, EventArgs e)
        {

            frmMedicosAE frm = new frmMedicosAE { Text = "Agregar Medico" };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = MedicosBD.GetLista();
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

        private void MostrarDatosGrilla(List<Medicos> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var p in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, p);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void frmMedicos_Load(object sender, EventArgs e)
        {
           this.Dock=DockStyle.Fill;
            dgvDatos.AllowUserToAddRows = false;
            this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
            this.ControlBox = false;
            try
            {
                lista = MedicosBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex )
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            new Exportar().ExportarDgv(dgvDatos);
        }
    }
}
