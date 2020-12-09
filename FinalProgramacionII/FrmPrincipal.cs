using Entidades;
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
        private List<Pelota> pelotas;
        private Thread hilo; 
        public FrmPrincipal()
        {
            InitializeComponent();
            pelotas = new List<Pelota>();
            inicilizarBlancas();
            pelotas.Add(new PelotaMala());
            pelotas.Add(new PelotaBuena());
            Pelota.Ordernar(pelotas);
            hilo = new Thread(Mover);
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            hilo.Start();

        }

        public void inicilizarBlancas()
        {
            for (int i = 0; i < 25; i++)
            {
                pelotas.Add(new PelotaNeutra());
            }
        }

        private void FrmPrincipal_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < pelotas.Count; i++)
                {
                    Pelota item = pelotas[i]; 


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

            List<PelotaBuena> buenas = PelotaBuena.BuscarBuenas(pelotas);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    SetearVelocidad(buenas, true, -1);
                    break;
                case Keys.Up:
                    SetearVelocidad(buenas, false, -1);
                    break;
                case Keys.Right:
                    SetearVelocidad(buenas, true, 1);
                    break;
                case Keys.Down:
                    SetearVelocidad(buenas, false, 1);
                    break;
             }
        }

        private void SetearVelocidad(List<PelotaBuena> pelotasACambiar,bool ejeX, int valor)
        {
            for (int i = 0; i < pelotasACambiar.Count; i++)
            {
                if(ejeX)
                    pelotasACambiar[i].VelX = valor;
                else
                    pelotasACambiar[i].VelY = valor;
            }
        }

        private void Mover()
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
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.Refresh();
                });
            }
            else
            {
            this.Refresh();

            }
            
            Mover();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

            hilo.Abort();
        }

    }
}
