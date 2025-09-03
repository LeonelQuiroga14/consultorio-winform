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
    public partial class frmPacientes : Form
    {
        public frmPacientes()
        {
            InitializeComponent();
        }

        private static frmPacientes form = null;

        public static frmPacientes Instancia()
        {
            if (form==null)
            {
                form= new frmPacientes();
                form.FormClosed+= new FormClosedEventHandler(form_Closed);
            }
            return form;

        }

        private static void form_Closed(object sender, FormClosedEventArgs e)
        {
            form = null;
        }

        private List<Pacientes> lista;
        private void frmPacientes_Load(object sender, EventArgs e)
        {
            this.Dock=DockStyle.Fill;
            this.ControlBox = false;
            dgvDatos.AllowUserToAddRows = false;
            this.FormBorderStyle=FormBorderStyle.FixedToolWindow;
            try
            {
                lista = PacientesBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex  )
            {
                
                throw ex ;
            }
        }

        private void MostrarDatosGrilla(List<Pacientes> lista)
        {
           dgvDatos.Rows.Clear();
            foreach (var p in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, p);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pacientes p)
        {
            r.Cells[cmnNombreApe.Index].Value = p.ToString();
            r.Cells[cmnGenero.Index].Value = p.Genero.Genero;
            r.Cells[cmnGs.Index].Value = p.GrupoSanguineo;
            r.Cells[cmnDNI.Index].Value = p.NumeroDoc;
            r.Cells[cmnTelefonoMovil.Index].Value = p.TelefonoMovil;
            r.Cells[cmnTelefonofijo.Index].Value = p.TelefonoFijo;
            r.Cells[cmnObraSocial.Index].Value = p.ObraSocial.ObraSocial;
            r.Cells[cmnPlan.Index].Value = p.Plan.Plan;
            
            r.Tag = p;

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmPacientesAE frm= new frmPacientesAE {Text = "Agregar Pacientes"};
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {

                    lista = PacientesBD.GetLista();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Pacientes p = (Pacientes)r.Tag;
                Pacientes pAux = (Pacientes)p.Clone();
                frmPacientesAE frm = new frmPacientesAE { Text = "Editar Paciente" };

                frm.SetEditar(true);
                frm.SetPaciente(p);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        p = frm.GetPaciente();
                        PacientesBD.Editar(p);
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

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                Pacientes p = (Pacientes)r.Tag;
                Pacientes pAux = (Pacientes)p.Clone();

                DialogResult drr =
                    MessageBox.Show(string.Format("Los pacientes no pueden eliminarse por temas de Registro. \n En caso de un mal ingreso puede editarlo ¿Continuar con la edicion?"),
                        "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (drr == DialogResult.Yes)
                {

                    frmPacientesAE frm = new frmPacientesAE { Text = "Editar paciente" };
                    frm.SetEditar(true);
                    frm.SetPaciente(p);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {

                        try
                        {
                            p = frm.GetPaciente();
                          PacientesBD.Editar(p);
                            SetearFila(r, p);
                            MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            SetearFila(r, pAux);

                        }
                    }
                    drr = DialogResult.No;
                }
            }
        }
    }
}
