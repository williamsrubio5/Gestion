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
    public partial class Resultados : Form
    {
        Operaciones op = new Operaciones();
        public static string  FacNum,Nombre,result;
        public int estado,code;
        public static DateTime fecha;
        int i;
        public Resultados()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (i != -1)
            {
                DialogResult Result = MessageBox.Show("Seguro Que Desea Ingresar Este Registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    op.EditarResult(textBox1.Text, code);
                    
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = "";
        }

        private void Resultados_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = op.MostrarFacturasResult();
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;

                if (i != -1)
                {

                    code =Convert.ToInt32( dataGridView1.Rows[i].Cells[0].Value);
                    FacNum = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    Nombre = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    estado = Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    fecha = Convert.ToDateTime( dataGridView1.Rows[i].Cells[4].Value);
                    result = dataGridView1.Rows[i].Cells[5].Value.ToString();

                    
                }
            }
    }
}
