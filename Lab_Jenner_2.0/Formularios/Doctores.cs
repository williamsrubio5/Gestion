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
    public partial class Doctores : Form
    {
        Operaciones op = new Operaciones();
        public static string id;
        public string nombre, email,clinica;
        public int telefono;
        
        int i = -1;
        public Doctores()
        {
            InitializeComponent();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            Ingresar_Doctor inserDoc = new Ingresar_Doctor();
            inserDoc.Show();
            this.Hide();
        }

        public void cargardata()
        {
            dataGridDoc.DataSource = op.MostrarDoctor();
        }

        private void Doctores_Load(object sender, EventArgs e)
        {
            cargardata();
            
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if(i != -1)
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
            if (i != -1)
            {
                DialogResult Result = MessageBox.Show("Seguro Que Desea Eliminar Este Registro?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (Result == DialogResult.Yes)
                {
                    
                    op.EliminarDoctor(Convert.ToString(id));
                    cargardata();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar Una Fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnregresar_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Hide();
        }

        private void dataGridDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;

            if(i != -1)
            {
                
                id = dataGridDoc.Rows[i].Cells[0].Value.ToString();
                nombre = dataGridDoc.Rows[i].Cells[1].Value.ToString();
                telefono = Convert.ToInt32(dataGridDoc.Rows[i].Cells[2].Value);
                email = dataGridDoc.Rows[i].Cells[3].Value.ToString();
                clinica = dataGridDoc.Rows[i].Cells[4].Value.ToString();
            }
        }
    }
}
