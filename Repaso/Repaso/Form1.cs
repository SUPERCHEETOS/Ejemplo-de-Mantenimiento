using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Service;
using Capa_Entidades;

namespace Repaso
{
    public partial class Form1 : Form
    {
        sPaciente objneg = new sPaciente();
        Paciente oPaciente = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void botonSesion_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text != "" && txtcontrasena.Text != "")
            {
                int validar;
                int admin;

                oPaciente = new Paciente();
                oPaciente.DNI = Convert.ToString(txtusuario.Text);
                oPaciente.Numero_de_celular = Convert.ToString(txtcontrasena.Text);

                validar = objneg.nValidacionPaciente(oPaciente);

                if (validar == 1)
                {
                    admin = objneg.nValidacionPaciente(oPaciente);

                    if (admin == 1)
                    {
                        MessageBox.Show("Sesion iniciada del paciente correctamente");
                        FormularioMantenimiento f = new FormularioMantenimiento();
                        f.ShowDialog();
                    }
                }
                else if (validar != 1)
                {

                    MessageBox.Show("Oh que fue!!!!\n\nEl usuario o la contraseña son incorrectos");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}


