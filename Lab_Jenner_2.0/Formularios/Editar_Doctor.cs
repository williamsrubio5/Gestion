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
    public partial class Editar_Doctor : Form
    {
        Operaciones op = new Operaciones();
        public Editar_Doctor()
        {
            InitializeComponent();
        }

        private void Editar_Doctor_Load(object sender, EventArgs e)
        {
            if (Explorar_Tablas.metodo == 1)
            {
                //Deshabilitado
                label6.Visible = false;
                label7.Visible = false;
                cbsexo.Visible = false;
                fechanac.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                comboBox2.Visible = false;
                txtusuario.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label14.Visible = false;

                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                txtrangof.Visible = false;
                //Habilitado
                label13.Visible = true;
                label5.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                txtidentidad.Visible = true;
                txtnombre.Visible = true;
                txtemail.Visible = true;
                txttelefono.Visible = true;
                txtclinica.Visible = true;

                //data
                txtidentidad.Text = Explorar_Tablas.id.ToString();
                txtnombre.Text = Explorar_Tablas.nombre.ToString();
                txttelefono.Text = Explorar_Tablas.telefono.ToString();
                txtemail.Text = Explorar_Tablas.email.ToString();
                txtclinica.Text = Explorar_Tablas.clinica.ToString();
            }
            else if (Explorar_Tablas.metodo == 2)
            {
                //Habilitado
                label13.Visible = true;
                label5.Visible = false;
                label3.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                txtidentidad.Visible = true;
                txtnombre.Visible = true;
                txtemail.Visible = true;
                txttelefono.Visible = true;
                txtclinica.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
                cbsexo.Visible = true;
                fechanac.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                comboBox2.Visible = false;
                txtusuario.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label14.Visible = false;

                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                txtrangof.Visible = false;

                txtidentidad.Text = Explorar_Tablas.id.ToString();
                txtnombre.Text = Explorar_Tablas.nombre.ToString();
                txttelefono.Text = Explorar_Tablas.telefono.ToString();
                txtemail.Text = Explorar_Tablas.email.ToString();
                if (Explorar_Tablas.sexo == 1)
                {
                    cbsexo.SelectedItem = "Masculino";
                }
                else
                {
                    cbsexo.SelectedItem = "Femenino";
                }
                fechanac.Value = Explorar_Tablas.fechanac.Date;
            }
            else if (Explorar_Tablas.metodo == 3)
            {
                //Habilitado
                label13.Visible = false;
                label5.Visible = false;
                label3.Visible = false;
                label2.Visible = true;
                label4.Visible = false;
                txtidentidad.Visible = false;
                txtnombre.Visible = true;
                txtemail.Visible = true;
                txttelefono.Visible = false;
                txtclinica.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                cbsexo.Visible = false;
                fechanac.Visible = false;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                comboBox2.Visible = true;
                txtusuario.Visible = true;
                label11.Visible = false;
                label12.Visible = false;
                label14.Visible = false;

                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                txtrangof.Visible = false;

                txtusuario.Text = Explorar_Tablas.usuario.ToString();
                txtnombre.Text = Explorar_Tablas.pass.ToString();
                
                if (Explorar_Tablas.rol == "Administrador")
                {
                    comboBox2.SelectedItem = "Administrador";
                }
                else if (Explorar_Tablas.rol == "Cajero")
                {
                    comboBox2.SelectedItem = "Cajero";
                }
                else
                {
                    comboBox2.SelectedItem = "Doctor";
                }
                txtemail.Text = Explorar_Tablas.email.ToString();
            }
            else if (Explorar_Tablas.metodo == 5)
            {
                label13.Visible = false;
                label5.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                txtidentidad.Visible = false;
                txtnombre.Visible = true;
                txtemail.Visible = false;
                txttelefono.Visible = true;
                txtclinica.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                cbsexo.Visible = false;
                fechanac.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                comboBox2.Visible = false;
                txtusuario.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label14.Visible = true;

                label16.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                label19.Visible = false;
                txtrangof.Visible = false;

                txtusuario.Text = Explorar_Tablas.nombre.ToString();
                txtnombre.Text = Explorar_Tablas.rango.ToString();
                txttelefono.Text = Explorar_Tablas.precio.ToString();
            }
            else if (Explorar_Tablas.metodo == 6)
            {

                label16.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                label19.Visible = true;
                txtrangof.Visible = true;
                //--------------------
                label13.Visible = false;
                label5.Visible = false;
                label3.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                txtidentidad.Visible = false;
                txtnombre.Visible = true;
                txtemail.Visible = false;
                txttelefono.Visible = false;
                txtclinica.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                cbsexo.Visible = false;
                fechanac.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                comboBox2.Visible = false;
                txtusuario.Visible = true;
                label11.Visible = false;
                label12.Visible = false;
                label14.Visible = false;

                txtusuario.Text = Explorar_Tablas.id.ToString();
                txtnombre.Text = Explorar_Tablas.nombre.ToString();
                txtrangof.Text = Explorar_Tablas.clinica.ToString();
                fechanac.Value = Explorar_Tablas.fechanac.Date;
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Form1.accion = 3;
            op.IngresarBitacora(Convert.ToString(Form1.usu), int.Parse(Form1.accion.ToString()));

            if (Explorar_Tablas.metodo == 1)
            {
                op.EditarDoctor(txtidentidad.Text, txtnombre.Text, int.Parse(txttelefono.Text), txtemail.Text, txtclinica.Text);

            }
            else if (Explorar_Tablas.metodo == 2)
            {
                int sex;
                if (cbsexo.ToString() == "Masculino")
                {
                    sex = 1;
                }
                else
                {
                    sex = 0;
                }
                op.EditarPaciente(txtidentidad.Text, txtnombre.Text, txtemail.Text, int.Parse(txttelefono.Text), sex, fechanac.Value.Date);
            }
            else if (Explorar_Tablas.metodo == 3)
            {
                int rol;
                if (comboBox2.SelectedItem.ToString() == "Administrador")
                {
                    rol = 1;
                }
                else if (comboBox2.SelectedItem.ToString() == "Cajero")
                {
                    rol = 2;
                }
                else
                {
                    rol = 3;
                }

                op.EditarUsuario(txtusuario.Text, txtnombre.Text, rol, txtemail.Text);
            }
            else if (Explorar_Tablas.metodo == 5)
            {
                op.EditarExamen(txtusuario.Text, txtnombre.Text, decimal.Parse(txttelefono.Text),Convert.ToInt32( Explorar_Tablas.ide));
            }
            else if (Explorar_Tablas.metodo == 6)
            {
                op.EditarCai(txtusuario.Text, txtnombre.Text, txtrangof.Text, fechanac.Value.Date);
            }
            txtidentidad.Text = "";
            txtnombre.Text = "";
            txtemail.Text = "";
            txtclinica.Text = "";
            txttelefono.Text = "";
            cbsexo.Text = "";
            comboBox2.Text = "";
            txtusuario.Text = "";
            txtrangof.Text = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Explorar_Tablas ex = new Explorar_Tablas();
            ex.Show();
            this.Hide();
        }
    }
}
