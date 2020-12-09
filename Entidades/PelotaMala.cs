using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PelotaMala : Pelota, IMovimiento
    {
        int velX = 1;
        int velY = 1;

        public PelotaMala()
        {
            this.posX = rnd.Next(1, MaximoX);
            this.posY = rnd.Next(1, MaximoY);
        }

        public static PelotaMala HacerMala(Pelota pelota)
        {
            if (pelota is PelotaNeutra)
            {
                return new PelotaMala() { color = ConsoleColor.Red, indice = pelota.Indice, posX = pelota.PosX, posY = pelota.PosY, movX = 1, movy = 1 };
            }
            else if (pelota is PelotaMala)
            {
                return (PelotaMala)pelota;
            }
            return null;
        }
        public void Mover()
        {
            posX = posX + velX;
            posY = posY + velY;
            Verificar();
        }

        public void Verificar()
        {
            if (posX < 2 && velX < 0 || posX > MaximoX - 5 && velX > 0)
                velX = -1 * velX;

            if (posY < 2 && velY < 0 || posY > MaximoY - 5 && velY > 0)
                velY = -1 * velY;
        }

        public void HayChoque(List<Pelota> pelotas)
        {
            if (Indice > 0)
            {

                if (Math.Abs(pelotas[indice - 1].PosX - posX) < 15 && (Math.Abs(pelotas[indice - 1].PosY - PosY) < 15) && (pelotas[indice - 1]).GetType() != this.GetType())
                {
                    pelotas[indice - 1] = HacerMala(pelotas[indice - 1]);
                }
                if (pelotas[indice - 1].PosX - posX < 0)
                {
                    Pelota.Ordernar(pelotas);
                }

            }
        }

    }
}
