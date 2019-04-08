using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden
{
    class pollochico : Pollo
    {
        public pollochico()
        {
            descripcion = "Pollo chico";
        }

        public override double precio()
        {
            return 60;
        }

        public override double preciocombo()
        {
            return 120;
        }
    }
}
