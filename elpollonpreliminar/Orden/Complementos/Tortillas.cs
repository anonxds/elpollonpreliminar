using elpollonpreliminar.Orden;
using elpollonpreliminar.Orden.Complementos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Pollos.Complementos
{
 public class Tortillas : DecoradorC
    {
        private Pollo _pollo;

        public Tortillas(Pollo pollo)
        {
            _pollo = pollo;
        }

        public override string Descripcion()
        {
            return "Tortilla";
        }

        public override double precio()
        {
            return 5;
        }

        public override double preciocombo()
        {
            return 5 + _pollo.preciocombo();
        }
    }
}
