using elpollonpreliminar.Orden;
using elpollonpreliminar.Orden.Complementos;
using elpollonpreliminar.Pollos.Complementos;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            
        }

        private void Ordenar_Load(object sender, EventArgs e)
        {
           
        }

        private void btnchico_Click(object sender, EventArgs e)
        {
            c = new pollochico();
           lblprecio.Text = "Precio: " + c.precio().ToString();
            metroLabel28.Text = c.Descripcion().ToString();
        }

        private void btnmed_Click(object sender, EventArgs e)
        {
            c = new pollomedia();
            lblprecio.Text = "Precio: " + c.precio().ToString();
            metroLabel28.Text = c.Descripcion().ToString();
        }

        private void btngran_Click(object sender, EventArgs e)
        {
            c = new pollogrande();
            lblprecio.Text = "Precio: " + c.precio().ToString();
            metroLabel28.Text = c.Descripcion().ToString();
        }

        private void chkTor_OnChange(object sender, EventArgs e)
        {

            complementos();
        }
        public void complementos()
        {
            switch (metroLabel28.Text)
            {
                case "Pollo chico":
                         c = new pollochico();
                    if (chkTor.Checked == true)
                    {
                        c = new Tortillas(c);                  
                    }
                    if (chksalsa.Checked == true)
                    {
                        c = new salnsa(c);                       
                    }

                   
                    lblprecio.Text = "Precio: " + c.precio().ToString();

                    break;
            }


           
        }

        private void chksalsa_OnChange(object sender, EventArgs e)
        {
            complementos();
        }
    }
}
