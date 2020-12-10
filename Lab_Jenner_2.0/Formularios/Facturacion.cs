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
    public partial class Facturacion : Form
    {
        Operaciones op = new Operaciones();
        Double acum = 0;
        Double descT;
        public static int contf = 0;
        public Facturacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Elegir_Examen elex = new Elegir_Examen();
            elex.Show();
            txtmonto.Text = "0";
            
        }

        public void cargarexam()
        {
            if (txtmonto.Text.Equals("0"))
            {
                String nombre;
                Double precio;
                acum = 0;
                contf = 0;
                textBox1.Clear();
                for (int i = 0; i < Elegir_Examen.casillas; i++)
                {
                    if (Elegir_Examen.nombre[i] != null)
                    {
                        nombre = Elegir_Examen.nombre[i];
                        precio = Elegir_Examen.precio[i];

                        textBox1.Text += nombre + " " + "L. " + precio;
                        textBox1.Text += Environment.NewLine;
                        contf++;

                    }
                }


                for (int x = 0; x < Elegir_Examen.casillas; x++)
                {
                    if (Elegir_Examen.precio[x].ToString() != "")
                    {
                        acum += Elegir_Examen.precio[x];
                    }
                }
                if (cbdescuento.SelectedIndex == 0)
                {
                    txtmonto.Text = (0.75 * acum).ToString();
                }
                else
                {
                    txtmonto.Text = (0.80 * acum).ToString();
                }

                Double isv = double.Parse(txtmonto.Text) * 0.15;
                Double total = double.Parse(txtmonto.Text) + isv;
                textBox2.Text = total.ToString();
            }


        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            cbcai.DataSource = op.cbCaiFac();
            cbmed.DataSource = op.cbMedFac();
            cbcai.DisplayMember = "CaiNum";
            cbcai.ValueMember = "CaiNum";
            cbmed.DisplayMember = "IdentidadMe";
            cbmed.ValueMember = "IdentidadMe";
        }

        private void Facturacion_Activated(object sender, EventArgs e)
        {
            cargarexam();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check;
            if (radioButton1.Checked == true)
            {
                check = 1;
            }
            else
            {
                check = 0;
            }
            op.IngresarFactura(txtref.Text,txtid.Text,check,float.Parse( txtmonto.Text),cbcai.Text,cbmed.Text,Elegir_Examen.cod,Elegir_Examen.precio);
            Menu men = new Menu();
            men.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (op.cargarpacfac(txtid.Text) == true)
            {
                txtnombre.Text = Operaciones.nombre.ToString();
                txtemail.Text = Operaciones.correo.ToString();
                txttelefono.Text = Operaciones.telefono.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(Operaciones.edad);
                if (Operaciones.sexo.ToString() == "1")
                {
                    cbgenero.Text = "Masculino";
                }
                else
                {
                    cbgenero.Text = "Femenino";
                }
                
                txtnombre.Enabled = false;
                txtemail.Enabled = false;
                txttelefono.Enabled = false;
                dateTimePicker1.Enabled = false;
                cbgenero.Enabled = false;
            }
            else
            {
                txtnombre.Text = "";
                txtemail.Text = "";
                txttelefono.Text = "";
                
                cbgenero.Text = "";
                txtnombre.Enabled = true;
                txtemail.Enabled = true;
                txttelefono.Enabled = true;
                dateTimePicker1.Enabled = true;
                cbgenero.Enabled = true;
            }
        }

        private void cbdescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtmonto.Text != "")
            {
                Double desc;
                if (cbdescuento.SelectedIndex == 1)
                {
                    desc = 0.20;
                }
                else
                {
                    desc = 0.25;
                }
                
                txtmonto.Text = (acum - (acum * descT)).ToString();
                Double isv = double.Parse(txtmonto.Text) * 0.15;
                Double total = double.Parse(txtmonto.Text) + isv;
                textBox2.Text = total.ToString();
            }
        }

        private void cbcai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Hide();
        }

        private void txtid_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtid_TextChanged_1(object sender, EventArgs e)
        {
            if (op.cargarpacfac(txtid.Text) == true)
            {
                txtnombre.Text = Operaciones.nombre.ToString();
                txtemail.Text = Operaciones.correo.ToString();
                txttelefono.Text = Operaciones.telefono.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(Operaciones.edad);
                if (Operaciones.sexo.ToString() == "1")
                {
                    cbgenero.Text = "Masculino";
                }
                else
                {
                    cbgenero.Text = "Femenino";
                }

                txtnombre.Enabled = false;
                txtemail.Enabled = false;
                txttelefono.Enabled = false;
                dateTimePicker1.Enabled = false;
                cbgenero.Enabled = false;
            }
            else
            {
                txtnombre.Text = "";
                txtemail.Text = "";
                txttelefono.Text = "";

                cbgenero.Text = "";
                txtnombre.Enabled = true;
                txtemail.Enabled = true;
                txttelefono.Enabled = true;
                dateTimePicker1.Enabled = true;
                cbgenero.Enabled = true;
            }
        }
    }
}
