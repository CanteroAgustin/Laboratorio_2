using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1_LAB_II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Text = "0";
            this.txtNumero2.Text = "0";
            this.lblResultado.Text = "";
            this.cmbOperacion.SelectedIndex = -1;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Calculadora cal = new Calculadora();
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            string operador = cal.validarOperador(this.cmbOperacion.Text);
            if (operador == "+")
            {
                this.cmbOperacion.SelectedIndex = 0;
            }
            this.lblResultado.Text = cal.operar(numero1, numero2, operador).ToString();
        }
    }
}
