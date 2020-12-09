using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMovimiento
    {
        void Mover();
        void Verificar();
        void HayChoque(List<Pelota> p );
    }
}
