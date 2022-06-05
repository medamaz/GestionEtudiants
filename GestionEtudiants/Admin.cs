using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEtudiants
{
    public partial class Admin : Form
    {
        Form form;
        public Admin(Form form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GsEnseignant(this).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new GsFilier(this).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new GsEtudiant(this).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new GsModule(this).ShowDialog();

        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Visible = true;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            form.Visible = false;
        }
    }
}
