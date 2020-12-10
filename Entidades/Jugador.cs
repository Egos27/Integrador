using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        private string nombre;

        private int puntos;

        public int Puntos
        {
            get { return puntos; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public void SumarPuntos(int puntos)
        {
            this.puntos += puntos;
        }

    }
}
