using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            limpiar();
        }
        SqlConnection conexion = new SqlConnection("server=LAPTOP-6R0HNJDA ; database=Agenda ; integrated security = true");
    

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'agendaDataSet.Contactos' table. You can move, or remove it, as needed.
            this.contactosTableAdapter.Fill(this.agendaDataSet.Contactos);
            // TODO: This line of code loads data into the 'agendaDataSet.Contactos' table. You can move, or remove it, as needed.


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Contactos (Nombre, Apellido, telefono, direccion, correo) VALUES (@nombre, @apellido, @tel, @direccion, @correo)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@nombre", nombreTextBox.Text);
            comando.Parameters.AddWithValue("@apellido", apellidoTextBox.Text);
            comando.Parameters.AddWithValue("@tel", telefonoTextBox.Text);
            comando.Parameters.AddWithValue("@direccion", direccionTextBox.Text);
            comando.Parameters.AddWithValue("@correo", correoTextBox.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Insertado");
            limpiar();
            conexion.Close();

        }

        public void llenardrid()
        {
            iDTextBox.Text = contactosDataGridView.CurrentRow.Cells[0].Value.ToString();
            nombreTextBox.Text = contactosDataGridView.CurrentRow.Cells[1].Value.ToString();
            apellidoTextBox.Text = contactosDataGridView.CurrentRow.Cells[2].Value.ToString();
            telefonoTextBox.Text = contactosDataGridView.CurrentRow.Cells[3].Value.ToString();
            direccionTextBox.Text = contactosDataGridView.CurrentRow.Cells[4].Value.ToString();
            correoTextBox.Text = contactosDataGridView.CurrentRow.Cells[5].Value.ToString();

        }

        public void limpiar()
        {
            iDTextBox.Clear();
            nombreTextBox.Clear();
            telefonoTextBox.Clear();
            textBox1.Clear();
            apellidoTextBox.Clear();
            direccionTextBox.Clear();
            correoTextBox.Clear();
        }

        private void contactosDataGridView_CellContentClicl(object sender, DataGridViewCellEventArgs e)
        {
            iDTextBox.Text = contactosDataGridView.CurrentRow.Cells[0].Value.ToString();
            nombreTextBox.Text = contactosDataGridView.CurrentRow.Cells[1].Value.ToString();
            apellidoTextBox.Text = contactosDataGridView.CurrentRow.Cells[2].Value.ToString();
            telefonoTextBox.Text = contactosDataGridView.CurrentRow.Cells[3].Value.ToString();
            direccionTextBox.Text = contactosDataGridView.CurrentRow.Cells[4].Value.ToString();
            correoTextBox.Text = contactosDataGridView.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query2 = "UPDATE Contactos SET Nombre = @nombre, Apellido = @apellido, telefono = @tel, direccion = @direccion, correo = @correo  Where ID = '" + iDTextBox.Text + "'";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query2, conexion);
            comando.Parameters.AddWithValue("@nombre", nombreTextBox.Text);
            comando.Parameters.AddWithValue("@apellido", apellidoTextBox.Text);
            comando.Parameters.AddWithValue("@tel", telefonoTextBox.Text);
            comando.Parameters.AddWithValue("@direccion", direccionTextBox.Text);
            comando.Parameters.AddWithValue("@correo", correoTextBox.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Actualizado");
            limpiar();
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string query3 = "DELETE from Contactos Where ID = '" + iDTextBox.Text + "'";
           
            SqlCommand comando = new SqlCommand(query3, conexion);
            comando.ExecuteNonQuery();
      
            MessageBox.Show("Eliminado");

            conexion.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();
            if (radioButton1.Checked == true)
            {



                string consulta = "select  * from Contactos Where Nombre = '" + textBox1.Text + "'";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                contactosDataGridView.DataSource = dt;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector;
                lector = comando.ExecuteReader();


                limpiar();
            }
            else if (radioButton2.Checked == true)
            {


                string consulta = "select  * from Contactos Where telefono = '" + textBox1.Text + "'";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);
                contactosDataGridView.DataSource = dt;
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector;
                lector = comando.ExecuteReader();

                limpiar();

            }
            conexion.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "select  * from Contactos";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            contactosDataGridView.DataSource = dt;
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;
            lector = comando.ExecuteReader();
            conexion.Close();


        }

   
    }
}
