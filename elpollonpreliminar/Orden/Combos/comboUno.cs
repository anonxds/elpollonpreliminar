using elpollonpreliminar.Orden.Complementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden.Combos
{
    class comboUno
    {
        Pollo c = new pollomedia();
        string spec;
        public string nombre()
        {
            return "Combo 1";
        }
         public string precio()
        {
            c = new arroz(c);
            c = new totopos(c);
            c = new salnsa(c);
            return c.preciocombo().ToString();
        }
        public string descripcion()
        {
            c = new arroz(c);
            spec += c.Descripcion();
            c = new totopos(c);
            spec += "\n"+c.Descripcion();
            c = new salnsa(c);
            spec += "\n"+c.Descripcion();
            return spec;

        }
    }
    class comboDos
    {
        Pollo c = new pollogrande();
        string spec;
        public string nombre()
        {
            return "Combo 2";
        }
        public string precio()
        {
            c = new tortillasH(c);
            c = new frigoles(c);
            c = new totopos(c);
            return c.preciocombo().ToString();
        }
        public string descripcion()
        {
            c = new tortillasH(c);
            spec += c.Descripcion();
            c = new frigoles(c);
            spec += "\n" + c.Descripcion();
            c = new totopos(c);
            spec += "\n" + c.Descripcion();
            return spec;

        }
    }
    class comboTres
    {
        public string nombre()
        {
            return "Combo 3";
        }
        Pollo c = new pollogrande();
        string spec;
        public string precio()
        {
           
            c = new tortillasH(c);
            c = new frigoles(c);
            c = new arroz(c);
            return c.preciocombo().ToString();
        }
        public string descripcion()
        {
            c = new tortillasH(c);
            spec += c.Descripcion();
            c = new frigoles(c);
            spec += "\n" + c.Descripcion();
            c = new arroz(c);
            spec += "\n" + c.Descripcion();
            return spec;

        }
    }
}
