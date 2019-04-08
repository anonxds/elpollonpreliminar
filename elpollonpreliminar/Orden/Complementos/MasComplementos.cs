using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elpollonpreliminar.Orden.Complementos
{
  public  class frigoles : DecoradorC
    {
        private Pollo _pollo;

        public frigoles(Pollo pollo)
        {
            _pollo = pollo;
        }
        public override string Descripcion()
        {
            return "frigoles";
        }

        public override double precio()
        {
            return 20;
        }

        public override double preciocombo()
        {
            return 20 + _pollo.preciocombo();
        }
    }
  public  class arroz : DecoradorC
    {
        private Pollo _pollo;

        public arroz(Pollo pollo)
        {
            _pollo = pollo;
        }
        public override string Descripcion()
        {
            return "Arroz ching chong";
        }

        public override double precio()
        {
            return 22;
        }

        public override double preciocombo()
        {
            return 22 + _pollo.preciocombo();
        }
    }
  public  class totopos : DecoradorC
    {
        private Pollo _pollo;

        public totopos(Pollo pollo)
        {
            _pollo = pollo;
        }
        public override string Descripcion()
        {
            return "Totopos dorados";
        }

        public override double precio()
        {
            return 15;
        }

        public override double preciocombo()
        {
            return 15 + -_pollo.preciocombo();
        }
    }
  public  class tortillasH : DecoradorC
    {
        private Pollo _pollo;

        public tortillasH(Pollo pollo)
        {
            _pollo = pollo;
        }
        public override string Descripcion()
        {
            return "Tortillas de harina";
        }

        public override double precio()
        {
            return 25;
        }

        public override double preciocombo()
        {
            return 25 + _pollo.preciocombo();
        }
    }
}
