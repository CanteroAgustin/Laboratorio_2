using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase09_Lavadero;

namespace WindowsFormsApplication1
{
    public partial class frmCamion : frmVehiculo
    {
        public frmCamion()
        {
            InitializeComponent();
        }

        private Camion c;

        public Camion camion
        {
            get { return c; }
        }
        
        private void frmCamion_Load(object sender, EventArgs e)
        {

        }
    }
}
