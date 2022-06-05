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
    public partial class FilierFind : Form
    {
        public FilierFind()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = checkBox1.Checked;
          
        }

        private void FilierFind_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Filier.afficherFilier();
            comboBox1.DataSource = Enseignant.afficherEnseignnant();
            dataGridView1.Columns["idEns"].Visible = false;
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "idEns";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                dataGridView1.DataSource = Filier.afficherFilier(textBox1.Text, Convert.ToInt32(comboBox1.SelectedValue));
            else
                dataGridView1.DataSource = Filier.afficherFilier(textBox1.Text, -1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Filier.afficherFilier();

        }
    }
}
