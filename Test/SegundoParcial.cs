using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Threading;

namespace Test
{
    [TestClass]
    public class SegundoParcial
    {

        [TestMethod]
        public void MoverPelotas()
        {

            //Inicio el juego y verifico que se muevan las palotasBuenas y Malas 
            Juego.Hilo.Start();
            int posicion = PelotaBuena.BuscarBuenas()[0].PosX;
            Thread.Sleep(100);
            Juego.Hilo.Abort();
            Assert.AreNotEqual(posicion, PelotaBuena.BuscarBuenas()[0].PosX);
        }

        [TestMethod]
        public void SerializarPelotas()
        {
            

            string ruta = Helper.Serializar(Juego.Pelotas);

            Assert.AreEqual(Juego.Pelotas, Helper.deserializar(ruta));


            //Hacer las modificaciones necesarias para serializar una pelota y que esto siga funcionando

        }
    }
}
