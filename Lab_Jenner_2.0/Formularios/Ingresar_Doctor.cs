using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Clases;

namespace Formularios
{

    public partial class Ingresar_Doctor : Form
    {
        Operaciones op = new Operaciones();
        public Ingresar_Doctor()
        {
            InitializeComponent();
        }

        private void Ingresar_Doctor_Load(object sender, EventArgs e)
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
                }
                else if(Explorar_Tablas.metodo == 6)
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
                }
            
            
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Form1.accion = 2;
            op.IngresarBitacora(Convert.ToString(Form1.usu), int.Parse(Form1.accion.ToString()));

            if (Explorar_Tablas.metodo == 1)
            {
                if (txtidentidad.Text == "" || txtnombre.Text == "" || txttelefono.Text == "" || txtemail.Text == "" || txtclinica.Text == "")
                {
                    MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Error);
                }else { 
                    op.IngresarDoctor(txtidentidad.Text, txtnombre.Text, int.Parse(txttelefono.Text), txtemail.Text, txtclinica.Text);
                      }
                }
                else if (Explorar_Tablas.metodo == 2)
                {
                    int sex;
                    if (cbsexo.SelectedItem.ToString() == "Masculino")
                    {
                        sex = 1;
                    }
                    else
                    {
                        sex = 0;
                    }
                if (txtidentidad.Text == "" || txtemail.Text == "" || txttelefono.Text == "" || cbsexo.Text == "")
                {
                    MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Error);
                }
                else {
                    op.IngresarPaciente(txtidentidad.Text, txtnombre.Text, txtemail.Text, int.Parse(txttelefono.Text), sex, fechanac.Value.Date);
                }
                }
                else if (Explorar_Tablas.metodo == 3)
                {

                int rol;
                   if(comboBox2.SelectedItem.ToString() == "Administrador")
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

                if (txtusuario.Text == "" || txtnombre.Text == "" || txtemail.Text == "")
                {
                    MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Error);
                }
                else
                {
                    op.IngresarUsuario(txtusuario.Text, txtnombre.Text, rol, txtemail.Text);
                }
                
                }
                else if (Explorar_Tablas.metodo == 5)
                {
                if (txtusuario.Text == "" || txtnombre.Text == "" || txttelefono.Text == "")
                {
                    MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Error);
                }
                else
                {

                    op.IngresarExamen(txtusuario.Text, txtnombre.Text, decimal.Parse(txttelefono.Text));
                }
                }
                else if (Explorar_Tablas.metodo == 6)
                {
                if (txtusuario.Text == "" || txtnombre.Text == "" || txtrangof.Text == "")
                {
                    MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Error);
                }
                else
                {
                    op.IngresarCai(txtusuario.Text, txtnombre.Text, txtrangof.Text, fechanac.Value.Date);
                }
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

        private void button5_Click(object sender, EventArgs e)
        {
            Explorar_Tablas exp = new Explorar_Tablas();
            exp.Show();
            this.Hide();
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 8 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se aceptan numeros", "Informacion", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private Boolean validar_email(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (validar_email(txtemail.Text))
            {

            }
            else
            {
                if (txtemail.Text.Trim().Equals(""))
                {
                    errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(txtemail, "Introduzca el correo correctamente");
                    txtemail.Focus();

                    MessageBox.Show("Direccion de correo electronico no valido, el correo debe tener el formato: ejemplo@dominio.com," +
                        "Por favor use un direccion de correo electronico valida", "Validacion de Correo Electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }

        }

        private void txtidentidad_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbsexo_MouseEnter(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count <= 0)
            {
                MessageBox.Show("No puede dejar campos vacios", "Error", MessageBoxButtons.OK, /*Tipo de imagen que tendra el mensaje*/MessageBoxIcon.Error);
            }
        }
    }
}
