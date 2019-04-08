using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden
{
 public abstract   class Pollo
    {
        protected string descripcion = "Pollo generico";
        public virtual string Descripcion()
        {
            return descripcion;
        }
        public abstract double precio();
        public abstract double preciocombo();
   
    }
}
