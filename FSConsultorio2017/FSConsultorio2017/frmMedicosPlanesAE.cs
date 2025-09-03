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
    public partial class frmMedicosPlanesAE : Form
    {
        public frmMedicosPlanesAE()
        {
            InitializeComponent();
        }

        private List<MedicoEspecialidad> lista; 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //EspecialidadesBD.CargarCombobox(ref cboEspecialidad);
            try
            {
                lista = MedicoEspecialidadBD.GetLista();
                MostrarDatosGrilla(lista);
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
          
            ObrasSocialesBD.CargarCombobox(ref cboObraSocial);
            if (medicoplan!=null)
            {
                dgvDatos.Rows[IndexDgv].Selected = true;
                cboObraSocial.SelectedValue = medicoplan.ObraSocial.IdObraSocial;
                cboPlan.SelectedValue = medicoplan.Plan.IdPlan;
            }

        }

        private void MostrarDatosGrilla(List<MedicoEspecialidad> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var i in lista)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, i);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }
        
        private void SetearFila(DataGridViewRow r, MedicoEspecialidad mp)
        {
            r.Cells[cmnNombreApe.Index].Value = mp.Medico.ToString();
            r.Cells[cmnEspecialidad.Index].Value = mp.Especialidad.Especialidad;
            r.Cells[cmnMat.Index].Value = mp.Matricula;
            r.Cells[cmnCosto.Index].Value = "$ " + mp.CostoConsulta.ToString();
            r.Tag = mp;
        }

        private MedicosPlanes medicoplan;
        private bool Editar = false;

        public MedicosPlanes GetMedicoPlan()
        {
            return medicoplan;
        }

        public void SetMedicoPlan(MedicosPlanes mp)
        {
            medicoplan = mp;
        }

        public void SetEditar(bool v)
        {
            Editar = v;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
           this.DialogResult=DialogResult.Cancel;
        }

        private void cboObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboObraSocial.SelectedIndex > 0)
            {
                ObraSociales obrasocial = (ObraSociales)cboObraSocial.SelectedItem;
                PlanesBD.CargarDatosCombo(ref cboPlan, obrasocial);
                cboPlan.Enabled = true;
            }
            else
            {
                cboPlan.DataSource = null;
                cboPlan.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (medicoplan==null)
                {
                    medicoplan= new MedicosPlanes();
                   
                }
               // medicoplan.Especialidad = (Especialidades) cboEspecialidad.SelectedItem;
               
                medicoplan.MedicoEspecialidad = me;
                medicoplan.ObraSocial = (ObraSociales) cboObraSocial.SelectedItem;
                medicoplan.Plan = (Planes) cboPlan.SelectedItem;

                if (!Editar)
                {
                    try
                    {
                        MedicosPlanesBD.Agregar(medicoplan);
                        MessageBox.Show("Medico-Plan agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.Yes)
                        {
                           // cboMedico.SelectedIndex = 0;
                            cboObraSocial.SelectedIndex = 0;
                           
                           // cboMedico.Focus();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            int index = dgvDatos.Rows.Count;
            if (index==null || index==0)
            {
                valido = false;
                MessageBox.Show("Elija un Medico con doble click sobre la fila", "No selecciono un medico",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider1.SetError(dgvDatos,"Elija un Medico");
            }
            if (cboObraSocial.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboObraSocial, "Seleccione una Obra social");
            }
            if (cboPlan.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboPlan, "Seleccione un Plan");
            }
            return valido;
        }

        private void frmMedicosPlanesAE_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboEspecialidad.SelectedIndex > 0)
            //{
            //    // ObraSociales obrasocial = (ObraSociales)cboObraSocial.SelectedItem;
            //    Especialidades es = (Especialidades)cboEspecialidad.SelectedItem;
            //   // PlanesBD.CargarDatosCombo(ref cboPlanes, obrasocial);
            //  //  MedicoEspecialidadBD.CargarCombobox(ref cboMedico,es);
            //    cboMedico.Enabled = true;
            //}
            //else
            //{
            //    cboMedico.DataSource = null;
            //    cboMedico.Enabled = true;
            //}


         //   Especialidades esp = (Especialidades) cboEspecialidad.SelectedItem;

        }

        private DataGridViewRow r;
        private MedicoEspecialidad me;
        private int IndexDgv;

        public void SetIndex(int p)
        {
            IndexDgv = p;
        }
        private void dgvDatos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)

            {
               r = dgvDatos.SelectedRows[0];
                me = (MedicoEspecialidad) r.Tag;
                txtNombre.Text = me.Medico.ToString();
                 SetIndex(r.Index);
               
               

            }
        }
    }
}
