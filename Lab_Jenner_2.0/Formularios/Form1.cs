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
    public partial class Form1 : Form
    {
        Operaciones op = new Operaciones();
        Conexion cn = new Conexion();
        public static string usu;
        public static int accion=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (op.Login(txtnombre.Text, txtpassword.Text))
            {
                Menu men = new Menu();
                usu = txtnombre.Text;
                accion = 1;
                op.IngresarBitacora(Convert.ToString(usu), int.Parse(accion.ToString()));
                men.Show();
                this.Hide();
                
            }
        }
    }
}
