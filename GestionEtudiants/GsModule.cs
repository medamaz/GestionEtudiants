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
    public partial class GsModule : Form
    {
        Form parent;
        BindingSource bs = new BindingSource();

        public GsModule(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void GsModule_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "nomFl";
            comboBox1.ValueMember = "idFilier";
            comboBox1.DataSource = Filier.afficherFilier();

            comboBox2.DisplayMember = "nom";
            comboBox2.ValueMember = "idEns";
            comboBox2.DataSource = Enseignant.afficherEnseignnant();

            bs.DataSource = Module.afficherModule();
            dataGridView1.DataSource = bs;
            parent.Visible = false;

            dataGridView1.Columns["idEns"].Visible = false;
            dataGridView1.Columns["idFl"].Visible = false;
            dataGridView1.Columns["idMd"].Visible = false;

            dataGridView1.Columns["nomFl"].Name = "Nom Filier";
           
            textBox1.DataBindings.Add("text", bs, "nom", true);
            numericUpDown1.DataBindings.Add("value", bs, "nivaux", true);
            comboBox1.DataBindings.Add("selectedvalue", bs, "idFl", true);
            comboBox2.DataBindings.Add("selectedvalue", bs, "idEns", true);
        }

        private void GsModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                comboBox1.SelectedIndex = Faker.RandomNumber.Next(0, comboBox1.Items.Count - 1);
                comboBox2.SelectedIndex = Faker.RandomNumber.Next(0, comboBox2.Items.Count - 1);
                Module m = new Module(Faker.Name.FullName(), Faker.RandomNumber.Next(1, 3));
                Module.ajouterModule(m, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
            }
            bs.DataSource = Module.afficherModule();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Module.ajouterModule(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue));
            bs.DataSource = Module.afficherModule();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

               Module.supprimerModule(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()));

            }
            bs.DataSource = Module.afficherModule();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Module.modifierModule(textBox1.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()));

            }
            bs.DataSource = Module.afficherModule();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ModuleFind(this).ShowDialog();
        }
    }
}
