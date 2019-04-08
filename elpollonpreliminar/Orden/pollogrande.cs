using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden
{
    class pollogrande : Pollo
    {
        public pollogrande()
        {
            descripcion = "Pollo grande";
        }

        public override double precio()
        {
            return 120;
        }

        public override double preciocombo()
        {
            return 120;
        }
    }
}
