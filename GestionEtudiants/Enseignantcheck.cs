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
    public partial class Enseignantcheck : Form
    {
        Form parent;
        public Enseignantcheck(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Enseignantcheck_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "idEns";
            comboBox1.DataSource = Enseignant.afficherEnseignnant();
            parent.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new EnseignantForm(this,Convert.ToInt32(comboBox1.SelectedValue)).ShowDialog();
        }

        private void Enseignantcheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }
    }
}
