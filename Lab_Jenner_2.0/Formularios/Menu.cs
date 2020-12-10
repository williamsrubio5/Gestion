using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Formularios
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Explorar_Tablas et = new Explorar_Tablas();
            et.Show();
            this.Hide();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void btnFac_Click(object sender, EventArgs e)
        {
            Facturacion fac = new Facturacion();
            fac.Show();
            this.Hide();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Desea Cerrar Sesion?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.Yes)
            {
                Form1 fm = new Form1();
                fm.Show();
                this.Hide();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (Operaciones.rol.ToString().Equals("2"))
            {
                btnFac.Location = new Point(220, 221);
                
                btnExa.Visible = false;
              
            } else if (Operaciones.rol.ToString().Equals("3"))
            {
                btnFac.Visible = false;
                
                btnExa.Visible = false;
              
                btnOrd.Location = new Point(220, 221);
            }else
            {
                btnFac.Visible = true;
                
                btnExa.Visible = true;
              
                btnOrd.Visible = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
               
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            Doctores doc = new Doctores();
            doc.Show();
            this.Hide();
        }

        private void btnPac_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOrd_Click(object sender, EventArgs e)
        {
            Resultados result = new Resultados();
            result.Show();
            this.Hide();
        }
    }
}
