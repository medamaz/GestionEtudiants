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
    public partial class GsFilier : Form
    {
        BindingSource bs = new BindingSource();
        Form parent;
        public GsFilier(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void GsFilier_Load(object sender, EventArgs e)
        {
            
            parent.Visible=false;
            bs.DataSource = Filier.afficherFilier();
            dataGridView1.DataSource = bs;
            comboBox1.DataSource = Enseignant.afficherEnseignnant();
            dataGridView1.Columns["idEns"].Visible = false;
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "idEns";
            textBox1.DataBindings.Add("text", bs, "nomFl", true);
            comboBox1.DataBindings.Add("selectedvalue",bs,"idEns",true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Filier.ajouterFilier(textBox1.Text,Convert.ToInt32(comboBox1.SelectedValue));
            bs.DataSource = Filier.afficherFilier();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Filier.supprimerFilier(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()));

            }
            bs.DataSource = Filier.afficherFilier();
            textBox1.Text = "";
            comboBox1.Text = "";
        }

        private void GsFilier_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Filier.modifierFilier(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()),textBox1.Text);

            }
            bs.DataSource = Filier.afficherFilier();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 2; i++)
            {
                comboBox1.SelectedIndex = Faker.RandomNumber.Next(0, comboBox1.Items.Count - 1);
                Filier.ajouterFilier(Faker.Company.Name(), Convert.ToInt32(comboBox1.SelectedValue));
            }
            bs.DataSource = Filier.afficherFilier();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FilierFind().ShowDialog();
        }
    }
}
