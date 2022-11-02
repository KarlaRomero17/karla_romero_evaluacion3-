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

namespace karla_romero_evaluacion3
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=WF-H3PHF12;database=administracion;integrated security=true");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO personal(nombre,apellido,telefono,direccion,correo) " +
                "values(@NOMBRE,@APELLIDO,@TELEFONO,@DIRECCION,@CORREO)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            //comando.Parameters.AddWithValue("@ID", textBox1.Text);
            comando.Parameters.AddWithValue("@NOMBRE", textBox2.Text);
            comando.Parameters.AddWithValue("@APELLIDO", textBox3.Text);
            comando.Parameters.AddWithValue("@TELEFONO", textBox4.Text);
            comando.Parameters.AddWithValue("@DIRECCION", textBox5.Text);
            comando.Parameters.AddWithValue("@CORREO", textBox6.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Datos ingresados correctamente");
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            textBox5.Text="";
            textBox6.Text="";
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                MessageBox.Show("Conexion exitosa");

            }
            catch
            {

                MessageBox.Show("Conexion fallida");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand comando = new SqlCommand("select * from personal", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string query = "DELETE FROM personal WHERE id= @ID";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", textBox1.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registros eliminados correctamente");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string query = "UPDATE personal SET nombre=@NOMBRE, apellido=@APELLIDO, telefono=@TELEFONO, " +
                "direccion=@DIRECCION, correo=@CORREO WHERE id=@ID";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@ID", textBox1.Text);
            comando.Parameters.AddWithValue("@NOMBRE", textBox2.Text);
            comando.Parameters.AddWithValue("@APELLIDO", textBox3.Text);
            comando.Parameters.AddWithValue("@TELEFONO", textBox4.Text);
            comando.Parameters.AddWithValue("@DIRECCION", textBox5.Text);
            comando.Parameters.AddWithValue("@CORREO", textBox6.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Registros actualizados correctamente");
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            textBox5.Text="";
            textBox6.Text="";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
