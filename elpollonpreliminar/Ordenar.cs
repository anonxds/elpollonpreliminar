using elpollonpreliminar.Orden;
using elpollonpreliminar.Orden.Combos;
using elpollonpreliminar.Orden.Complementos;
using elpollonpreliminar.Pollos.Complementos;
using MetroFramework.Forms;

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

namespace elpollonpreliminar
{
    public partial class Ordenar : MetroForm
    {
        Pollo c;
        public Ordenar()
        {
            InitializeComponent();
            fill();
            autocompletar();
        }
        List<string> _items = new List<string>();
        List<int> _precio = new List<int>();
        List<int> _cantidad = new List<int>();
        List<string> _descripcion = new List<string>();
        int[] combo = new int[] {1,2,3};
        SQL sql = new SQL();
        public void fill()
        {
            for (int i = 0; i < 3; i++)
            {
                cbcombo.Items.Add(combo[i]);
            }
        }
        private void Ordenar_Load(object sender, EventArgs e)
        {
           
        }
        public string query(string n2, string n3)
        {
            string query = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre = '{1}'",n2,n3);
            return query;
        }
        private void btnchico_Click(object sender, EventArgs e)
        {

            panel1.Enabled = true;
            _ticket.DataSource = null;
            c = new pollochico();            
            _items.Add(c.Descripcion() + "\t"+ txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();            
           sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void btnmed_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;           
            _ticket.DataSource = null;
            c = new pollomedia();

            _items.Add(c.Descripcion() + "\t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _ticket.DataSource = _items;
            _descripcion.Add(c.Descripcion());
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void btngran_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            _ticket.DataSource = null;
            c = new pollogrande();
            _items.Add(c.Descripcion() + "\t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;

            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }
        public void autocompletar()
        {
            txtnombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtnombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            string cons = "Server=tcp:pruebastec.database.windows.net,1433;Initial Catalog=elpollon;Persist Security Info=False;User ID=alexis;Password=Azure1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string query = "select * from clientes";
            SqlConnection con = new SqlConnection(cons); 
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string sName = reader.GetString(1);
                  //  string stelefono = reader.GetString("telefono");
                    coll.Add(sName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ahhhh" + ex);
            }
            txtnombre.AutoCompleteCustomSource = coll;
        }

        private void chkTor_OnChange(object sender, EventArgs e)
        {
           
           
        }          
        private void chksalsa_OnChange(object sender, EventArgs e)
        {
           
        }
        private void chkpolloC_OnChange(object sender, EventArgs e)
        {
           
        }
        private void chkpolloM_OnChange(object sender, EventArgs e)
        {
           
        }
        private void chkPolloG_OnChange(object sender, EventArgs e)
        {
           
        }
        private void chktortillasH_OnChange(object sender, EventArgs e)
        {
         
        }
        private void chktotopos_OnChange(object sender, EventArgs e)
        {
            
        }
        private void chkarroz_OnChange(object sender, EventArgs e)
        {
           
        }
        private void chkfrigoles_OnChange(object sender, EventArgs e)
        {
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            string polloc = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Pollo chico'";
            string pollom = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Pollo Mediano'";
            string pollog = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Pollo grande'";
            string tortillas = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Tortilla'";
            string tortillaH = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Tortillas de harina'";
            string arroz = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Arroz ching chong'";
            string frigoles = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'frigoles'";
            string totopos = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Totopos dorados'";
            string salsa = "update almacen2 set almacenado = almacenado - cantidad where nombre = 'Salsa'";
            sql.Exe(polloc);
            sql.Exe(pollom);
            sql.Exe(pollog);
            sql.Exe(tortillas);
            sql.Exe(tortillaH);
            sql.Exe(arroz);
            sql.Exe(frigoles);
            sql.Exe(totopos);
            sql.Exe(salsa);
            restar();
        }
        public void restar()
        {
            string polloc = "update almacen2 set cantidad = 0 where nombre = 'Pollo chico'";
            string pollom = "update almacen2 set cantidad = 0 where nombre = 'Pollo Mediano'";
            string pollog = "update almacen2 set cantidad = 0 where nombre = 'Pollo grande'";
            string tortillas = "update almacen2 set cantidad = 0  where nombre = 'Tortilla'";
            string tortillaH = "update almacen2 set cantidad = 0  where nombre = 'Tortillas de harina'";
            string arroz = "update almacen2 set cantidad = 0  where nombre = 'Arroz ching chong'";
            string frigoles = "update almacen2 set cantidad = 0  where nombre = 'frigoles'";
            string totopos = "update almacen2 set cantidad = 0  where nombre = 'Totopos dorados'";
            string salsa = "update almacen2 set cantidad = 0  where nombre = 'Salsa'";
            sql.Exe(polloc);
            sql.Exe(pollom);
            sql.Exe(pollog);
            sql.Exe(tortillas);
            sql.Exe(tortillaH);
            sql.Exe(arroz);
            sql.Exe(frigoles);
            sql.Exe(totopos);
            sql.Exe(salsa);
        }
        public string remove(string n2, string n3)
        {           
            string query = string.Format("update almacen2 set cantidad =   cantidad - '{0}' where nombre = '{1}'", n2, n3);
            return query;
        }
        private void btnquitar_Click(object sender, EventArgs e)
        {

           sql.Exe(remove(_cantidad[_ticket.SelectedIndex].ToString(),_descripcion[_ticket.SelectedIndex].ToString()));
            _cantidad.RemoveAt(_ticket.SelectedIndex);
            _descripcion.RemoveAt(_ticket.SelectedIndex);
            _precio.RemoveAt(_ticket.SelectedIndex);
            _items.RemoveAt(_ticket.SelectedIndex);
            _ticket.DataSource = null;
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            lblprecio.Text = _precio.Sum().ToString();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;
            c = new Tortillas(c);
            _items.Add(c.Descripcion() + "\t \t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void btnsalsa_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;
            c = new salnsa(c);
            _items.Add(c.Descripcion() + "\t \t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void btntortillasH_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;
            c = new tortillasH(c);
            _items.Add(c.Descripcion() + "\t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;
            c = new totopos(c);
            _items.Add(c.Descripcion() + "\t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void btnarroz_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;
            c = new arroz(c);
            _items.Add(c.Descripcion() + "\t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void btnfrigoles_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;
            c = new frigoles(c);
            _items.Add(c.Descripcion() + "\t \t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) * c.precio()).ToString());
            _precio.Add(int.Parse(txtcantidad.Text) * Convert.ToInt32(c.precio()));
            _cantidad.Add(int.Parse(txtcantidad.Text));
            _descripcion.Add(c.Descripcion());
            _ticket.DataSource = _items;
            lblprecio.Text = _precio.Sum().ToString();
            sql.Exe(query(txtcantidad.Text, c.Descripcion()));
        }

        private void cbcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            switch (cbcombo.SelectedIndex)
            {
                case 0:
                
                    comboUno x = new comboUno();
                    lblnomcombo.Text = x.nombre();
                   lbldescripcion.Text = "Descripcion: \n"+x.descripcion();
                    lblpreciobombo.Text = x.precio();

                    break;

                case 1:
               
                    comboDos z = new comboDos();
                    lblnomcombo.Text = z.nombre();
                    lbldescripcion.Text = "Descripcion: \n" + z.descripcion();
                    lblpreciobombo.Text = z.precio();
                    break;
                case 2:
                    comboTres w = new comboTres();
                    lblnomcombo.Text = w.nombre();
                    lbldescripcion.Text = "Descripcion: \n" + w.descripcion();
                    lblpreciobombo.Text =  w.precio();
                    break;

            }
        }

        private void btnagregarcombo_Click(object sender, EventArgs e)
        {
            _ticket.DataSource = null;        
            _items.Add(lblnomcombo.Text + "\t \t" + txtcantidad.Text + "  x\t " + (double.Parse(txtcantidad.Text) *  int.Parse(lblpreciobombo.Text)).ToString());
            _ticket.DataSource = _items;
            _precio.Add(int.Parse(txtcantidad.Text) * int.Parse(lblpreciobombo.Text));

          
            lblprecio.Text = _precio.Sum().ToString();
        }
    }
}
