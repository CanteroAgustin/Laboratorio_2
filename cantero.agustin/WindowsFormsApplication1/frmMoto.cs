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
    public partial class frmMoto : frmVehiculo
    {
        public frmMoto()
        {
            InitializeComponent();
        }

        private Moto m;

        public Moto moto
        {
            get { return m; }
        }
        
        private void frmMoto_Load(object sender, EventArgs e)
        {

        }
    }
}
