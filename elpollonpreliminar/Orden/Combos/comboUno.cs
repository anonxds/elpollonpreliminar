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
            spec += c.Descripcion();
            c = new arroz(c);
            spec += "\n"+c.Descripcion();
            c = new totopos(c);
            spec += "\n"+c.Descripcion();
            c = new salnsa(c);
            spec += "\n"+c.Descripcion();
            return spec;

        }
        SQL s = new SQL();
        public void almacen()
        {
         
            string polo = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  '{1}'", 1,c.Descripcion());
            string query = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Totopos dorados'", 1);
            string salsa = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Salsa'", 1);
            string arroz = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Arroz ching chong'", 1);
            s.Exe(polo);
            s.Exe(query);
            s.Exe(salsa);
            s.Exe(arroz);
        }
        public void restar()
        {
            
            string polo = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  '{1}'", 1, c.Descripcion());
            string query = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Totopos dorados'", 1);
            string salsa = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Salsa'", 1);
            string arroz = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Arroz ching chong'", 1);
            s.Exe(polo);
            s.Exe(query);
            s.Exe(salsa);
            s.Exe(arroz);

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
            spec += c.Descripcion();
            c = new tortillasH(c);
            spec += "\n"+c.Descripcion();
            c = new frigoles(c);
            spec += "\n" + c.Descripcion();
            c = new totopos(c);
            spec += "\n" + c.Descripcion();
            return spec;

        }
        public void almacen()
        {
            SQL s = new SQL();
            string polo = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  '{1}'", 1, c.Descripcion());
            string query = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Tortillas de harina'",1);
            string frigol = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'frigoles'", 1);
            string totopos = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Totopos dorados'", 1);
            s.Exe(polo);
            s.Exe(query);
            s.Exe(frigol);
            s.Exe(totopos);                          
        }
        public void restar()
        {
            SQL s = new SQL();
            string polo = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  '{1}'", 1, c.Descripcion());
            string query = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Tortillas de harina'", 1);
            string frigol = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'frigoles'", 1);
            string totopos = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Totopos dorados'", 1);
            s.Exe(polo);
            s.Exe(query);
            s.Exe(frigol);
            s.Exe(totopos);
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
            spec += c.Descripcion();
            c = new tortillasH(c);
            spec += "\n"+c.Descripcion();
            c = new frigoles(c);
            spec += "\n" + c.Descripcion();
            c = new arroz(c);
            spec += "\n" + c.Descripcion();
            return spec;

        }
        public void almacen()
        {
            SQL s = new SQL();
            string polo = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  '{1}'", 1, c.Descripcion());
            string query = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Tortillas de harina'", 1);
            string frigol = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'frigoles'", 1);
            string arroz = string.Format("update almacen2 set cantidad = '{0}' + cantidad where nombre =  'Arroz ching chong'", 1);
            s.Exe(polo);
            s.Exe(query);
            s.Exe(frigol);
            s.Exe(arroz);
        }
        public void restar()
        {
            SQL s = new SQL();
            string polo = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  '{1}'", 1, c.Descripcion());
            string query = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Tortillas de harina'", 1);
            string frigol = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'frigoles'", 1);
            string arroz = string.Format("update almacen2 set cantidad = '{0}' - cantidad where nombre =  'Arroz ching chong'", 1);
            s.Exe(polo);
            s.Exe(query);
            s.Exe(frigol);
            s.Exe(arroz);
        }
    }
}
