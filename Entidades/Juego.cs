using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    //Crear un delegado
    

    public static class Juego
    {
        //Crear el evento del delegado
        
        #region NO_TOCAR
        private static List<Pelota> pelotas;
        public static List<Pelota> Pelotas
        {
            get { return pelotas; }
            set { pelotas = value; }
        }

        public static Thread Hilo { get; set; }
        #endregion

        static Juego()
        {
            pelotas = new List<Pelota>();
            pelotas.Add(new PelotaMala());
            InicilizarNeutras();
            pelotas.Add(new PelotaBuena());
            Pelota.Ordernar(pelotas);

            //inicializar hilo con el metodo Juego.Mover
            

        }
        #region NO_TOCAR
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
            int cantidadBuenas = PelotaBuena.BuscarBuenas().Count;
            for (int i = 0; i < pelotas.Count; i++)
            {
                Pelota item = pelotas[i];

                if (item is IMovimiento)
                {
                    try
                    {

                        ((IMovimiento)item).Mover();
                        ((IMovimiento)item).HayChoque(pelotas);
                    }
                    catch (Exception e)
                    {
                        return;
                    }
                }
            }
            int NuevaCantidadBuenas = PelotaBuena.BuscarBuenas().Count;
            #endregion

            if (cantidadBuenas < NuevaCantidadBuenas)
            {
                int puntos = NuevaCantidadBuenas - cantidadBuenas;
                puntos = puntos * 100;
                //invocar el evento sumar puntos 
                
            }

            #region NO_TOCAR
            Thread.Sleep(20);

            Mover();
        }
        #endregion

        public static void ForzarInvocacionEvento()
        {
            //invocar el evento sumar puntos 

        }
    }
}
