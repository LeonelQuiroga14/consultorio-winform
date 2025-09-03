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
    public partial class frmDias : Form
    {
        public frmDias()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       public List<Dias> lista; 
        private void tsbAgregar_Click(object sender, EventArgs e)
        {
            frmDiasAE frm = new frmDiasAE { Text = "Agregar Dias " };
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    lista = DiasBD.GetLista();
                    MostrarDatosGrilla(lista);
                    //TipoMovimientos tm = frm.GetTipoMovimientos();
                    //TiposMovimientosBD.Agregar(tm);
                    //DataGridViewRow r= new DataGridViewRow();
                    //r.CreateCells(dgvDatos);
                    //SetearFila(r,tm);
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
                Dias dia = (Dias)r.Tag;
               Dias diaAux = (Dias)dia.Clone();
                frmDiasAE frm = new frmDiasAE { Text = "Editar Dia" };
                frm.SetEditar(true);
                frm.SetDia(dia);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {

                    try
                    {
                        dia= frm.GetDia();
                        DiasBD.Editar(dia);
                        SetearFila(r, dia);
                        MessageBox.Show("Registro editado ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetearFila(r, diaAux);

                    }
                }
            }
        }

        private static frmDias frm = null;

        public static frmDias Instancia()
        {
            if (frm==null)
            {
                frm= new frmDias();
                frm.FormClosed+= new FormClosedEventHandler(frm_FormClosed);
            }
            return frm;
        }

        private static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
              Dias dia = (Dias)r.Tag;
                DialogResult dr =
                    MessageBox.Show(string.Format($"¿Desea eliminar {dia.Dia} de la lista?"), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        DiasBD.Borrar(dia);
                        dgvDatos.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado", "Informacion", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        VerificarCantidad();


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void frmDias_Load(object sender, EventArgs e)
        {
            this.Dock=DockStyle.Fill;
            VerificarCantidad();
            
            try
            {
                lista = DiasBD.GetLista();
                MostrarDatosGrilla(lista);
                 
                
            }
            catch (Exception)
            {

                throw;
            }
        
    }

        public static void VerificarCantidad()
        {
           List<Dias> lista = DiasBD.GetLista();
            if (lista.Count >= 7)
            {
                frm.tsbAgregar.Enabled = false;
                MessageBox.Show("La semana solo tiene 7 dias \nNo se admiten mas registros", "Atencion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                frm.tsbAgregar.Enabled = true;

            }
        }

        private void MostrarDatosGrilla(List<Dias> lista)
        {
            dgvDatos.Rows.Clear();
            foreach (var dia   in lista)
            {
                DataGridViewRow r= new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, dia);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);

        }

        private void SetearFila(DataGridViewRow r, Dias dia)
        {
            r.Cells[cmnDia.Index].Value = dia.Dia;
            r.Tag = dia;
        }
    }
}
