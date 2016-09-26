using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    using Clase09_Lavadero;
    
    public partial class frmLavadero : Form
    {

        List<Vehiculo> vehiculos;

        public frmLavadero()
        {
            InitializeComponent();
            vehiculos = new List<Vehiculo>();
            
        }
        
        private void frmLavadero_Load(object sender, EventArgs e)
        {
                        
        }

        private void btnAddAuto_Click(object sender, EventArgs e)
        {
            
            frmAuto auto = new frmAuto();
            auto.Show();
            if (auto.DialogResult == DialogResult.OK)
            {
                vehiculos.Add(auto.a);
            }
            
        }

        private void btnAddMoto_Click(object sender, EventArgs e)
        {
            frmMoto moto = new frmMoto();
            moto.Show();
            if (moto.DialogResult == DialogResult.OK)
            {
                vehiculos.Add(moto.moto);
            }
        }

        private void btnAddCamion_Click(object sender, EventArgs e)
        {
            frmCamion camion = new frmCamion();
            camion.Show();
            if (camion.DialogResult == DialogResult.OK)
            {
                vehiculos.Add(camion.camion);
            }
        }
    }
}
