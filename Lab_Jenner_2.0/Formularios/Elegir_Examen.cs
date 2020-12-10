using System;
using System.Collections;
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
    public partial class Elegir_Examen : Form
    {
        public static int casillas;
        public static String[] nombre = new String[99];
        public static Double[] precio = new Double[99];
        public static int[] cod = new int[99];
        public int xClick = 0, yClick = 0;
        Operaciones op = new Operaciones();
        public Elegir_Examen()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
          
        }
        public void cargardata()
        {

            Array.Clear(Elegir_Examen.cod, 0, 99);
            Array.Clear(Elegir_Examen.nombre, 0, 99);
            Array.Clear(Elegir_Examen.precio, 0, 99);
            ArrayList row = new ArrayList();

            dataGridView1.DataSource = op.MostrarExamenes();
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;


            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Seleccionar";
            chk.Width = 100;
            dataGridView1.Columns.Add(chk);

        }

        private void Elegir_Examen_Load(object sender, EventArgs e)
        {
            cargardata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.Clear(Elegir_Examen.cod, 0, 99);
            Array.Clear(Elegir_Examen.nombre, 0, 99);
            Array.Clear(Elegir_Examen.precio, 0, 99);
            casillas = dataGridView1.RowCount;
            for (int i = 0; i < casillas; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[5].Value))
                {
                    cod[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    precio[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    nombre[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
                }
            }
            this.Hide();
            this.Close();
        }
    }
}
