using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Juego
    {
        private static List<Pelota> pelotas;
        public static List<Pelota> Pelotas
        {
            get { return pelotas; }
            set { pelotas = value; }
        }

        public static Thread Hilo { get; set; }
        static Juego()
        {
            pelotas = new List<Pelota>();
            pelotas.Add(new PelotaMala());
            InicilizarNeutras();
            pelotas.Add(new PelotaBuena());
            Pelota.Ordernar(pelotas);
            //TEST
            //Hilo = new Thread(Mover);
        }

        public static void SetearVelocidad(List<PelotaBuena> pelotasACambiar, bool ejeX, int valor)
        {
            for (int i = 0; i < pelotasACambiar.Count; i++)
            {
                if (ejeX)
                    pelotasACambiar[i].VelX = valor;
                else
                    pelotasACambiar[i].VelY = valor;
            }
        }

        private static void InicilizarNeutras()
        {
            for (int i = 0; i < 25; i++)
            {
                pelotas.Add(new PelotaNeutra());
            }
        }
        private static void Mover()
        {
            for (int i = 0; i < pelotas.Count; i++)
            {
                Pelota item = pelotas[i];

                if (item is IMovimiento)
                {
                    ((IMovimiento)item).Mover();
                    ((IMovimiento)item).HayChoque(pelotas);
                }
            }


            Thread.Sleep(20);

            Mover();
        }
    }
}
