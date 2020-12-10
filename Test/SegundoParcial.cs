using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Threading;
using System.Collections.Generic;
using FinalProgramacionII;

namespace Test
{
    [TestClass]
    public class SegundoParcial
    {


        [TestMethod]
        public void Nombre()
        {
            if (Environment.CurrentDirectory.Contains("Apellido"))
                throw new Exception("Ponga su nombre en el proyexto");
        }

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


            //Hacer las modificaciones necesarias para serializar una pelota y que tambien pueda la lista



        }


        [TestMethod]
        public void GuardarRecord()
        {
            Jugador jugador1 = new Jugador();
            jugador1.Nombre = "PruebaLog";
            jugador1.SumarPuntos(10);
            Helper.GuardarEnLog(jugador1);
            List<Jugador> jugadores = Helper.BuscarEnlog();
            foreach (Jugador item in jugadores)
            {
                if (jugador1 == item)
                    Assert.IsTrue(true);

            }

            Assert.Fail();
        }

        [TestMethod]
        public void MetodoDeExtension()
        {
            //Descomentar la linea y crear el metodo para que ande
            //Assert.AreEqual(PelotaBuena.BuscarBuenas(), Juego.Pelotas.BuscarBuenas());
        }

        [TestMethod]
        [ExpectedException(typeof(ChoqueException))]
        public void Excepciones()
        {
            PelotaBuena buena = new PelotaBuena();
            PelotaMala mala = new PelotaMala();
            buena.Indice = 1;
            mala.Posicionar(buena.PosX, buena.PosY);
            mala.Indice = 0;
            List<Pelota> pelotas = new List<Pelota>();
            pelotas.Add(mala);
            pelotas.Add(buena);

            buena.HayChoque(pelotas);

            Assert.Fail();

        }

        [TestMethod]


        public void DelegadoEvento()
        {
            // Se debe crear el Delegado para poder crear
            // el evento SumarPuntos en Juego que reciva un entero 
            // con la cantidad de puntos a sumar; 
            Jugador jug = new Jugador();
            //Juego.SumarPuntos += jug.SumarPuntos;

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EjecutarEvento()
        {
            // Se debe crear el Delegado para poder crear
            // el evento SumarPuntos en Juego que reciva un entero 
            // con la cantidad de puntos a sumar; 
            Jugador jug = new Jugador();
            //Juego.SumarPuntos += jug.SumarPuntos;
            Juego.ForzarInvocacionEvento();

            Assert.AreNotEqual<int>(jug.Puntos, 0);
        }
    }
}
