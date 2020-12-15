using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciamento_NewTalents
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void AbrirFormNoPanel(object Formhijo)
        {
            if (this.panelPrincipal.Controls.Count > 0)
                this.panelPrincipal.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(fh);
            this.panelPrincipal.Tag = fh;
            fh.Show();
        }

        private void newTalentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new CadastroTalents());
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel(new PesquisarTalents());
        }
    }
}
