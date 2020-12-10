using Entidades;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProgramacionII
{
    public partial class FrmPrincipal : Form
    {
        #region NO_TOCAR_NADA
        private int reloj = 0;
        private Jugador jugador;
        public FrmPrincipal()
        {
            InitializeComponent();
            jugador = new Jugador();

        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            jugador.Nombre = Interaction.InputBox("Ingrese su nombre ", "Ingreso");
            timer1.Interval = 20;
        }


        private void FrmPrincipal_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Juego.Pelotas.Count; i++)
            {
                Pelota item = Juego.Pelotas[i];


                Pen pen = new Pen(Color.Green); ;
                if (item is PelotaNeutra)
                    pen = new Pen(Color.Blue);
                if (item is PelotaMala)
                    pen = new Pen(Color.Red);

                e.Graphics.DrawEllipse(pen, item.PosX, item.PosY, 15, 15);
            }
        }

        private void FrmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {

            List<PelotaBuena> buenas = PelotaBuena.BuscarBuenas();
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Juego.SetearVelocidad(buenas, true, -1);
                    break;
                case Keys.Up:
                    Juego.SetearVelocidad(buenas, false, -1);
                    break;
                case Keys.Right:
                    Juego.SetearVelocidad(buenas, true, 1);
                    break;
                case Keys.Down:
                    Juego.SetearVelocidad(buenas, false, 1);
                    break;
            }
        }



        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Juego.Hilo != null && Juego.Hilo.IsAlive)
            {
                Helper.Serializar(Juego.Pelotas);
                Juego.Hilo.Abort();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            reloj++;
            label1.Text = reloj.ToString();
            this.Refresh();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            btnComenzar.Visible = false;
            Juego.Hilo.Start();
            reloj = 0;
            timer1.Enabled = true;
        }
        #endregion



    }
}
