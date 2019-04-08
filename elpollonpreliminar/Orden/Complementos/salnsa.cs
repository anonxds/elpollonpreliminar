using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden.Complementos
{
  public  class salnsa : DecoradorC
    {
        private Pollo _pollo;

        public salnsa(Pollo pollo)
        {
            _pollo = pollo;
        }

        public override string Descripcion()
        {
            return "Salsa";
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
