using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden
{
    class pollomedia : Pollo
    {
        public pollomedia()
        {
            descripcion = "Pollo Mediano";
        }

        public override double precio()
        {
            return 90;
        }

        public override double preciocombo()
        {
            return 90;
        }
    }
}
