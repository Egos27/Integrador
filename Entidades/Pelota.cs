using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    public abstract class Pelota
    {
       
        protected int posX;
        protected int posY;
        protected int movX;
        protected int movy;
        protected static int MaximoX;
        protected static int MaximoY;
        protected static
            Random rnd;


        protected ConsoleColor color;
        protected int indice;

        static Pelota(){
            MaximoX = 700;
            MaximoY = 400;
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public int PosX
        {
            get { return this.posX; }
        }
        public int PosY
        {
            get { return this.posY; }
        }

        public int Indice
        {
            get { return indice; }
            set { indice = value; }
        }

        public static void Ordernar(List<Pelota
            > pelotas)
        {
            pelotas.Sort((x, y) => x.PosX - y.posX) ;
            for (int i = 0; i < pelotas.Count; i++)
            {
                pelotas[i].indice = i;
            }
        }


    }
}
