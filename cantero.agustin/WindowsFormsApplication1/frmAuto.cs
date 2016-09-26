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
   
    public partial class frmAuto : frmVehiculo
    {
        public frmAuto()
        {
            InitializeComponent();
	
        }
        
        private Auto auto;

        public Auto a
        {
            get { return auto; }
        }
        
        private void frmAuto_Load(object sender, EventArgs e)
        {
            
        }
    }
}
