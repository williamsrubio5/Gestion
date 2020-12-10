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
    public partial class Explorar_Tablas : Form
    {
        Operaciones op = new Operaciones();
        public static int metodo=0;
        int i = -1;
        public static string id;
        public static string nombre, clinica, email,usuario,pass,rol,rango,descrip;
        public static int telefono,sexo,ide;
        public static DateTime fechanac;
        public static decimal precio;
        public Explorar_Tablas()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            
            if (metodo == 0)
            {
                MessageBox.Show("Debe Seleccionar Una Tabla", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (metodo == 4)
            {
                MessageBox.Show("Solo Puede Visualizar Datos De Esta Tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Ingresar_Doctor inserDoc = new Ingresar_Doctor();
                inserDoc.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            metodo = 6;
            cargardata();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (metodo == 0)
            {
                MessageBox.Show("Debe Seleccionar Una Tabla", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (metodo == 4)
            {
                MessageBox.Show("Solo Puede Visualizar Datos De Esta Tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (i != -1)
            {
                DialogResult Result = MessageBox.Show("Seguro Que Desea Editar Este Registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    Editar_Doctor edit = new Editar_Doctor();

                    edit.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (metodo == 0)
            {
                MessageBox.Show("Debe Seleccionar Una Tabla", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (metodo == 4)
            {
                MessageBox.Show("Solo Puede Visualizar Datos De Esta Tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (i != -1)
            {
                DialogResult Result = MessageBox.Show("Seguro Que Desea Eliminar Este Registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    if(metodo == 1)
                    {
                        op.EliminarDoctor(id);
                    }
                    else if (metodo == 2)
                    {
                        op.EliminarPaciente(id);
                    }
                    else if (metodo == 3)
                    {
                        op.EliminarUsuario(usuario);
                    }
                    else if (metodo == 5)
                    {
                        op.EliminarExamen(ide);
                    }
                    else if (metodo == 6)
                    {
                        op.EliminarCai(id);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDoc_Click(object sender, EventArgs e)
        {   
            metodo = 1;
            cargardata();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            metodo = 2;
            cargardata();
        }

        public void cargardata()
        {
            if (metodo == 1)
            {
                dataGridView1.DataSource = op.MostrarDoctor();
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            else if (metodo == 2)
            {
                dataGridView1.DataSource = op.MostrarPaciente();
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            else if (metodo == 3)
            {
                dataGridView1.DataSource = op.MostrarUsuario();
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            else if (metodo == 4)
            {
                dataGridView1.DataSource = op.MostrarBitacora();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
            }
            else if(metodo == 5)
            {
                dataGridView1.DataSource = op.MostrarExamenes();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            else if (metodo == 6)
            {
                dataGridView1.DataSource = op.MostrarCai();
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
            }
        }

        private void Explorar_Tablas_Load(object sender, EventArgs e)
        {
            metodo = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            metodo = 3;
            cargardata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            metodo = 4;
            cargardata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            metodo = 5;
            cargardata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;

            if (metodo == 1)
            {
                if (i != -1)
                {

                    id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    telefono = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    email = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    clinica = dataGridView1.Rows[i].Cells[4].Value.ToString();

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;

                    label1.Text = id.ToString();
                    label2.Text = nombre.ToString();
                    label3.Text = telefono.ToString();
                    label4.Text = email.ToString();
                    label5.Text = clinica.ToString();

                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                }
            }
            else if (metodo == 2)
            {
                
                if (i != -1)
                {
                    id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    email = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    telefono = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    sexo = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    fechanac = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);
                    
                    label1.Text = id.ToString();
                    label2.Text = nombre.ToString();
                    label3.Text = telefono.ToString();
                    label4.Text = email.ToString();
                    if (sexo == 1)
                    {
                        label14.Text = "Masculino";
                    }
                    else
                    {
                        label14.Text = "Femenino";
                    }
                    
                    label13.Text = fechanac.ToString();

                    //titulos
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label6.Visible = false;
                    label5.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    //datos

                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label14.Visible = true;
                    label13.Visible = true;
                }
            }
            else if (metodo == 3)
            {
               
                if (i != -1)
                {
                    usuario = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    pass = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    rol = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    email = dataGridView1.Rows[i].Cells[4].Value.ToString();

                    label1.Text = usuario.ToString();
                    label2.Text = pass.ToString();
                    label3.Text = rol.ToString();
                    label4.Text = email.ToString();
                    //titulos
                    
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label7.Visible = true;
                    label6.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label10.Visible = false;
                    label9.Visible = false;
                    label5.Visible = false;
                    label14.Visible = false;
                    label13.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label8.Visible = false;
                    label18.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    //datos
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                }
            }
            else if (metodo == 4)
            {
                if (i != -1)
                {
                    ide =Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    usuario = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    descrip = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    fechanac = Convert.ToDateTime(dataGridView1.Rows[i].Cells[3].Value);

                    label1.Text = usuario.ToString();
                    label2.Text = descrip.ToString();
                    label3.Text = fechanac.ToString();

                    //titulos
                    label15.Visible = true;
                    label18.Visible = true;
                    label19.Visible = true;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label16.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    //datos
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                }
            }
            else if (metodo == 5)
            {
                if (i != -1)
                {
                    ide = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    precio = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);
                    rango = dataGridView1.Rows[i].Cells[4].Value.ToString();

                    label1.Text = ide.ToString();
                    label2.Text = nombre.ToString();
                    label3.Text = precio.ToString();
                    label4.Text = rango.ToString();
                    //titulos
                    label9.Visible = true;
                    label20.Visible = true;
                    label21.Visible = true;
                    label22.Visible = true;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label19.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    label23.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    //datos
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                }
            }
            else if (metodo == 6)
            {
                if (i != -1)
                {
                    id = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    nombre = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    clinica = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    fechanac =Convert.ToDateTime( dataGridView1.Rows[i].Cells[3].Value.ToString());

                    label1.Text = id.ToString();
                    label2.Text = nombre.ToString();
                    label3.Text = clinica.ToString();
                    label4.Text = fechanac.ToString();
                    label23.Visible = true;
                    label24.Visible = true;
                    label25.Visible = true;
                    label26.Visible = true;
                    //titulos
                    label9.Visible = false;
                    label20.Visible = false;
                    label21.Visible = false;
                    label22.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label19.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                    label13.Visible = false;
                    label14.Visible = false;
                    label15.Visible = false;
                    label16.Visible = false;
                    label17.Visible = false;
                    label18.Visible = false;
                    //datos
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                }
            }
            
        }
    }
}
