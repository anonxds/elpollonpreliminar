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
using MetroFramework.Forms;

namespace elpollonpreliminar
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroTabPage2.Parent = null;
            metroTabPage3.Parent = null;
            metroTabPage4.Parent = null;
            metroTabPage5.Parent = null;
            actualizar();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {

            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pruebastec.database.windows.net";
            builder.UserID = "alexis";
            builder.Password = "Azure1234567";
            builder.InitialCatalog = "elpollon";

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select usuario, contraseña,rol from usuarios where usuario = '" + mtxtusu.Text +
                    "'And contraseña = '" + mtxtcontra.Text + "' ");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                da.Fill(dt, "usuarios");

                DataRow DR;
                DR = dt.Tables["usuarios"].Rows[0];
                if ((mtxtusu.Text == DR["usuario"].ToString()) || (mtxtcontra.Text == DR["contraseña"].ToString()))
                {
                    btncsesion.Visible = true;

                    mlabelrol.Text = mlabelrol.Text + DR["rol"].ToString();
                    if (mlabelrol.Text == "Tu Rol Es: administrador")
                    {
                        metroTabPage1.Parent = null;
                        metroTabPage2.Parent = metroTabControl1;
                        metroTabPage3.Parent = metroTabControl1;
                        metroTabPage4.Parent = metroTabControl1;
                        metroTabPage5.Parent = metroTabControl1;

                        metroTabControl1.SelectedTab = metroTabPage4;

                    }

                    if (mlabelrol.Text == "Tu Rol Es: vendedor")
                    {
                        metroTabPage1.Parent = null;
                        metroTabPage2.Parent = null;
                        metroTabPage3.Parent = metroTabControl1;
                        metroTabPage4.Parent = metroTabControl1;
                        metroTabPage5.Parent = null;

                        metroTabControl1.SelectedTab = metroTabPage4;

                    }

                }


                connection.Close();
            }
            }
            catch (Exception)
            {

                MessageBox.Show("Credenciales Incorrectas");
            }
        }

        private void metroComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";
                if (metroComboBox8.Text == "Buscar")
                {

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("select usuario,contraseña,rol from usuarios where usuario=" + "'" + txtusu.Text + "'");
                        String sql = sb.ToString();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet dt = new DataSet();
                        da.Fill(dt, "usuarios");

                        DataRow DR;

                        DR = dt.Tables["usuarios"].Rows[0];
                        string usu = DR["usuario"].ToString();
                        string contra = DR["contraseña"].ToString();
                        string rol = DR["rol"].ToString();

                        txtusu.Text = usu;
                        txtcontra.Text = contra;
                        cmrol.SelectedItem = rol;
                        actualizar();
                    }
                }


                //Console.WriteLine(texto);
                if (metroComboBox8.Text == "Eliminar" && txtusu.Text != "")
                {

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("delete usuarios where usuario=" + "'" + txtusu.Text + "'");
                        String sql = sb.ToString();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet dt = new DataSet();
                        da.Fill(dt, "usuarios");

                    }
                    actualizar();

                    int texto = metroGrid4.RowCount;
                    Console.WriteLine(texto);
                    if (texto == 1)
                    {
                        advertencia.Text = "RECUERDA AGREGAR UN ADMINISTRADOR ANTES DE IRTE";
                    }
                }



                if (metroComboBox8.Text == "Añadir"&&txtusu.Text!="" && txtcontra.Text != ""&&cmrol.Text!="")
                {

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        StringBuilder sb = new StringBuilder();
                        sb.Append("insert into usuarios values('" + txtusu.Text + "','" + txtcontra.Text + "','" + cmrol.SelectedItem + "')");
                        String sql = sb.ToString();
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet dt = new DataSet();
                        da.Fill(dt, "usuarios");

                    }
                    actualizar();

                    int texto = metroGrid4.RowCount;
                    if (texto == 2)
                    {
                        advertencia.Text = "";
                    }
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese ID");
            }
        }

        public void actualizar()
        {
            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "pruebastec.database.windows.net";
            builder1.UserID = "alexis";
            builder1.Password = "Azure1234567";
            builder1.InitialCatalog = "elpollon";
            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from usuarios");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid4.DataSource = dt;
                connection.Close();
            }
        }

        private void btncsesion_Click(object sender, EventArgs e)
        {
            mlabelrol.Text = "Tu Rol Es: ";
            if (mlabelrol.Text == "Tu Rol Es: ")
            {
                metroTabPage1.Parent = metroTabControl1;
                metroTabPage2.Parent = null;
                metroTabPage3.Parent = null;
                metroTabPage4.Parent = null;
                metroTabPage5.Parent = null;

            }


            mtxtcontra.Text = "";
            mtxtusu.Text = "";
            btncsesion.Visible = false;
        }
    }
}
