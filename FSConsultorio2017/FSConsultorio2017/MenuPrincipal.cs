using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSConsultorio2017
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(@"C:\Users\Leonel\Documents\Visual Studio 2015\Projects\FSConsultorio2017\Img\11.JPG");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        Usuarios usuario;
        public void SetUsuario(Usuarios u) { usuario = u; }
        public Usuarios GetUsuario() { return usuario; }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            this.ControlBox = false;
            this.WindowState=FormWindowState.Maximized;
            VerificarPermisos();
            usuario = GetUsuario();
            tsbLabel.Text = usuario.Nombre;
            stLabelRol.Text = usuario.TipoUsuario.TipoUsuario;

        }
        //**** Permisos ID*****
        //Administrador=1  Recepcion=2 Medico=3
        public void VerificarPermisos()
        {
            usuario = GetUsuario();
            if (usuario != null)
            {
                int id = usuario.TipoUsuario.IdTipoUsuario;
                switch (id)
                {
                    case 1:
                        AplicarPermisosAdministrador();
                        break;
                    case 2:
                        AplicarPermisosRecepcion();
                        break;
                    case 3:
                        AplicarPermisosMedico();
                        break;
                }
            }
            else { return; }
           
        }

        private void AplicarPermisosAdministrador()
        {
            this.registroListaToolStripMenuItem.Enabled = true;
            this.medicosPorPlanesToolStripMenuItem.Enabled = true;
            this.planesToolStripMenuItem.Enabled = true;
            this.especialidadesToolStripMenuItem.Enabled = true;
            this.registroListaToolStripMenuItem1.Enabled = true;
            this.administrativosToolStripMenuItem.Enabled = true;
            this.registrarToolStripMenuItem.Enabled = true;
            this.especialidadesToolStripMenuItem.Enabled = true;
            this.especialidadesToolStripMenuItem1.Enabled = true;
            this.planesToolStripMenuItem1.Enabled = true;
            this.registrarToolStripMenuItem1.Enabled = true;
            this.registroListaToolStripMenuItem.Enabled = true;
            this.registroToolStripMenuItem.Enabled = true;
            this.alquileresToolStripMenuItem.Enabled = true;
            this.listaAlquileresToolStripMenuItem.Enabled = true; 
            this.turnosToolStripMenuItem.Enabled = true;
            this.historiasClinicasToolStripMenuItem1.Enabled = true;
            this.registrarConsultaToolStripMenuItem.Enabled = true;
            this.consultarCtaCteToolStripMenuItem.Enabled = true;
            this.seguridadToolStripMenuItem.Enabled = true;
            this.otrosRegistrosToolStripMenuItem.Enabled = true;
        }

        private void AplicarPermisosMedico()
        {
            this.registroListaToolStripMenuItem.Enabled = false;
            this.medicosPorPlanesToolStripMenuItem.Enabled = false;
            this.planesToolStripMenuItem.Enabled = false;
            this.especialidadesToolStripMenuItem.Enabled = false;
            this.registroListaToolStripMenuItem1.Enabled =false;
            this.administrativosToolStripMenuItem.Enabled = false;
            this.registrarToolStripMenuItem.Enabled = false;
            this.especialidadesToolStripMenuItem.Enabled = false;
            this.especialidadesToolStripMenuItem1.Enabled = false;
            this.planesToolStripMenuItem1.Enabled = false;
            this.registrarToolStripMenuItem1.Enabled = false;  
            this.registroListaToolStripMenuItem.Enabled = false;
            this.registroToolStripMenuItem.Enabled = false;
            this.alquileresToolStripMenuItem.Enabled = false;
            this.listaAlquileresToolStripMenuItem.Enabled = false;
            this.turnosToolStripMenuItem.Enabled = false;
            this.historiasClinicasToolStripMenuItem1.Enabled = true;
            this.registrarConsultaToolStripMenuItem.Enabled = true;
            this.consultarCtaCteToolStripMenuItem.Enabled = true;
            this.seguridadToolStripMenuItem.Enabled = false;
            this.otrosRegistrosToolStripMenuItem.Enabled = false;
        }
        private void AplicarPermisosRecepcion()
        {
            this.registroListaToolStripMenuItem.Enabled = true;
            this.medicosPorPlanesToolStripMenuItem.Enabled = true;
            this.planesToolStripMenuItem.Enabled = true;
            this.especialidadesToolStripMenuItem.Enabled = true;
            this.registroListaToolStripMenuItem1.Enabled = true;
            this.administrativosToolStripMenuItem.Enabled = true;
            this.registrarToolStripMenuItem.Enabled = true;
            this.registrarToolStripMenuItem1.Enabled = true;
            this.registroListaToolStripMenuItem.Enabled = true;
            this.registroToolStripMenuItem.Enabled = true;
            this.alquileresToolStripMenuItem.Enabled = true;
            this.listaAlquileresToolStripMenuItem.Enabled = true;
            this.turnosToolStripMenuItem.Enabled = true;
            this.historiasClinicasToolStripMenuItem1.Enabled = true;
            this.registrarConsultaToolStripMenuItem.Enabled = false ;
            this.consultarCtaCteToolStripMenuItem.Enabled = false;
            this.seguridadToolStripMenuItem.Enabled = false;
            this.otrosRegistrosToolStripMenuItem.Enabled = true;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea salir de la Aplicacion?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { MessageBox.Show("Regresara al Menú principal", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            
        }

        private void registroListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedicos frm= frmMedicos.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedicosPlanes frm =  frmMedicosPlanes.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroListaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPacientes frm = frmPacientes.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void administrativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdministrativos frm= frmAdministrativos.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmObraSociales frm = frmObraSociales.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPlanes frm = frmPlanes.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroListaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEspecialidades frm= frmEspecialidades.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void consultoriosToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmConsultorios frm= frmConsultorios.Instancia();
        //    frm.MdiParent = this;
        //    frm.Show();
        //}

        private void diasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDias frm= frmDias.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGeneros frm= frmGeneros.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProvincias frm= frmProvincias.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalidades frm= new frmLocalidades();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nacionalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNacionalidades frm = frmNacionalidades.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDocumentos frm=frmTiposDocumentos.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoMovimientos frm= frmTipoMovimientos.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedicoEspecialidad frm = frmMedicoEspecialidad.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultorios frm = frmConsultorios.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void alquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlquilerConsultorio frm= frmAlquilerConsultorio.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listaAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaAlquileres frm = frmListaAlquileres.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTurnos frm = frmTurnos.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta frm = frmConsulta.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void historiasClinicasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmHistoriasClinicas frm = frmHistoriasClinicas.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void consultasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void registrarConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsulta frm = frmConsulta.Instancia();
            frm.MdiParent = this;
            frm.Show();
        }
        
        private void consultarCtaCteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario = GetUsuario();
            frmCtaCta frm = frmCtaCta.Instancia();
            frm.MdiParent = this;
            frm.SetUsuario(usuario);
            frm.Show();
        }

        private void tiposDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoUsuarios frm = frmTipoUsuarios.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void registroDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = frmUsuarios.GetInstancia();
            frm.Text="Usuarios";
            frm.MdiParent = this;
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario = null;
            Close();

            frmLogin frm = frmLogin.Instancia();
            frm.SetUsuario(usuario);
            frm.Show();
            

            
        }

        private void cambiarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario = null;
            
            while (usuario == null)
            {
                //this.Close();
                frmLogin frm = new frmLogin();
                frm.Text = "Cambio de Usuario";
                this.Refresh();
                frm.SetCambioUser(true);
               frm.ShowDialog();
                 usuario = frm.GetUsuario();
                    if (usuario != null)
                    {

                        tsbLabel.Text = usuario.Nombre;
                        stLabelRol.Text = usuario.TipoUsuario.TipoUsuario;
                        notifyIcon1.ShowBalloonTip(100, $"Bienvenido {usuario.Nombre}", "Se cambió el usuario", ToolTipIcon.Info);


                    }
                   
                    
                
               
                else
                {
                    Application.Exit();
                    break;
                }

            }
            VerificarPermisos();
        }
    }
    }

