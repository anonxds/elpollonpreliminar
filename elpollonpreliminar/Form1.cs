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
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Forms;

namespace elpollonpreliminar
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        int cantidadventas = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            metroTabPage2.Parent = null;
            metroTabPage3.Parent = null;
            metroTabPage4.Parent = null;
            metroTabPage5.Parent = null;
            actualizar();
            pictureBox3.SendToBack();
            mtxtusu.Focus();
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

            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from clientes");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid1.DataSource = dt;
                connection.Close();
            }
            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from ventas");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                metroGrid2.DataSource = dt;
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(builder1.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from almacen");
                String sql = sb.ToString();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridalmacen.DataSource = dt;
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

        private void metroButton12_Click(object sender, EventArgs e)
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
            catch (Exception)
            {

                MessageBox.Show("No existe ID");
            }
            
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";
                if (txtusu.Text != "")
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
            }
            catch (Exception)
            {

                MessageBox.Show("No existe ese id");

            }
            
           
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";
                if (txtusu.Text != "" && txtcontra.Text != "" && cmrol.Text != "")
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

                MessageBox.Show("No existe ese id");
            }
            
            
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "pruebastec.database.windows.net";
                builder.UserID = "alexis";
                builder.Password = "Azure1234567";
                builder.InitialCatalog = "elpollon";
                /*  using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                  {
                      connection.Open();
                      StringBuilder sb = new StringBuilder();
                      sb.Append("select CantidaddeVentas from ventas");
                      String sql = sb.ToString();
                      SqlCommand cmd = new SqlCommand(sql, connection);
                      SqlDataAdapter da = new SqlDataAdapter(cmd);
                      DataSet dt = new DataSet();
                      da.Fill(dt, "ventas");
                      DataRow DR;
                      DR = dt.Tables["ventas"].Rows[0];
                      string memo = DR["cantidaddeventas"].ToString();
                      txtcantv.Text = memo;
                  }*/
                txtcantv.Text = System.DateTime.Today.Day.ToString();
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select * from ventas");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // metroGrid2.DataSource = dt;

                    chart1.DataSource = dt;
                    chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    chart1.Legends[0].Enabled = true;
                    chart1.Series[0].XValueMember = "TipodePollo";
                    chart1.Series[0].YValueMembers = "FechadeVenta";
                    chart1.DataBind();

                    connection.Close();
                }
                
                /*
                for (int i = 0; i < metroGrid2.RowCount-1; i++)
                {
                    chart1.Series.Add(metroGrid2.Rows[i].Cells[0].Value.ToString());//Creamos la nueva serie
                   // chart1.Series.Add(metroGrid2.Rows[i].Cells[1].Value.ToString());//Creamos la nueva serie

                    chart1.Series[metroGrid2.Rows[i].Cells[0].Value.ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                    chart1.Series[metroGrid2.Rows[i].Cells[0].Value.ToString()].Points.AddXY(metroGrid2.Rows[i].Cells[1].Value.ToString(), metroGrid2.Rows[i].Cells[2].Value.ToString(),metroGrid2.Rows[i].Cells[3].Value.ToString());

                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            
    }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pruebastec.database.windows.net";
            builder.UserID = "alexis";
            builder.Password = "Azure1234567";
            builder.InitialCatalog = "elpollon";
            txtcantv.Text = System.DateTime.Today.Day.ToString();

            {
                /*
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("select CantidaddeVentas from ventas");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "ventas");
                    DataRow DR;
                    DR = dt.Tables["ventas"].Rows[0];
                    string memo = DR["cantidaddeventas"].ToString();
                    txtcantv.Text = memo;
                    cantidadventas = Convert.ToInt32(memo);
                }
                */
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("insert into ventas values('" + cmbtipo.Text + "',"+txtcostep.Text+",'" + cmbextras.Text + "','"+ txtcantv.Text + "');");
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "ventas");

                }

               

                actualizar();
                //cantidadventas = cantidadventas + 1;
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pruebastec.database.windows.net";
            builder.UserID = "alexis";
            builder.Password = "Azure1234567";
            builder.InitialCatalog = "elpollon";

            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("delete ventas where id=" + txtidv.Text );
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "ventas");

                }
                actualizar();

            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "pruebastec.database.windows.net";
            builder.UserID = "alexis";
            builder.Password = "Azure1234567";
            builder.InitialCatalog = "elpollon";

            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("update ventas set TipoDePollo='" + cmbtipo.Text + "',Coste='"+txtcostep.Text+",Extras='"+cmbextras.Text+"' where id="+txtidv.Text);
                    String sql = sb.ToString();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet dt = new DataSet();
                    da.Fill(dt, "ventas");

                }
                actualizar();

            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {

                metroComboBox2.Focus();
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

        private void metroLabel26_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
