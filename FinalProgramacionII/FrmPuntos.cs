using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProgramacionII
{
    public partial class FrmPuntos : Form
    {
        public FrmPuntos()
        {
            InitializeComponent();

        }

        private void FrmPuntos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Helper.BuscarEnlog();

        }
    }
}
