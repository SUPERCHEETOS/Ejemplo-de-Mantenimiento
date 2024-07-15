using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Service;

namespace Repaso
{
    public partial class FormularioMantenimiento : Form
    {
        sPaciente objneg = new sPaciente();
        Paciente oPaciente = null;
        public FormularioMantenimiento()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtDNI.Text = "";
            txtnombre.Text = "";
            txtfecha.Text = "";
            combosexo.Text = "";
            txtnumero.Text = "";
            txtdireccion.Text = "";
            txtdistrito.Text = "";

            dataGridView1.DataSource = objneg.n_ListarPacientes();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormularioMantenimiento_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.n_ListarPacientes();
        }
        private string Mantenimiento(string accion)
        {
            oPaciente = new Paciente();
            oPaciente.DNI = Convert.ToString(txtDNI.Text);
            oPaciente.Nombre_Completo = txtnombre.Text;
            oPaciente.Fecha_de_nacimiento = Convert.ToInt32(txtfecha.Text);
            oPaciente.Sexo = combosexo.Text;
            oPaciente.Numero_de_celular = txtnumero.Text;
            oPaciente.Direccion = txtdireccion.Text;
            oPaciente.Distrito = txtdistrito.Text;

            return objneg.dMantenimientoPaciente(oPaciente, accion);
        }

        private void boton_agregar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text != "" && txtnombre.Text != "" && txtfecha.Text != "" && combosexo.Text != "" && txtnumero.Text != "" && txtdireccion.Text != "" && txtdistrito.Text != "" )
            {
                string mensaje = Mantenimiento("1");
                MessageBox.Show(mensaje);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Oh que fue!!!!\n\nHay campos sin rellenar");
            }
        }

        private void boton_modificar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text != "" && txtnombre.Text != "" && txtfecha.Text != "" && combosexo.Text != "" && txtnumero.Text != "" && txtdireccion.Text != "" && txtdistrito.Text != "")
            {
                string mensaje = Mantenimiento("2");
                MessageBox.Show(mensaje);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Oh que fue!!!!\n\nHay campos sin rellenar");
            }
        }

        private void boton_eliminar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text != "" && txtnombre.Text != "" && txtfecha.Text != "" && combosexo.Text != "" && txtnumero.Text != "" && txtdireccion.Text != "" && txtdistrito.Text != "")
            {
                if (MessageBox.Show("En caso el cliente haya realizado una compra no será posible eliminarlo del registro.\n\n¿Desea Eliminar El Cliente?", "¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = Mantenimiento("3");
                    MessageBox.Show(mensaje);
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Oh que fue!!!!\n\nHay campos sin rellenar");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                txtDNI.Text = dataGridView1.Rows[index].Cells["DNI"].Value.ToString();
                txtnombre.Text = dataGridView1.Rows[index].Cells["Nombre_completo"].Value.ToString();
                txtfecha.Text = dataGridView1.Rows[index].Cells["Fecha_de_nacimiento"].Value.ToString();
                combosexo.Text = dataGridView1.Rows[index].Cells["Sexo"].Value.ToString();
                txtnumero.Text = dataGridView1.Rows[index].Cells["Numero_de_celular"].Value.ToString();
                txtdireccion.Text = dataGridView1.Rows[index].Cells["Direccion"].Value.ToString();
                txtdistrito.Text = dataGridView1.Rows[index].Cells["Distrito"].Value.ToString();
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
