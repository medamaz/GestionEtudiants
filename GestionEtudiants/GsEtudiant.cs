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
    public partial class GsEtudiant : Form
    {
        BindingSource bs = new BindingSource();
        Form parent;
        public GsEtudiant(Form prant)
        {
            InitializeComponent();
            this.parent = prant;
        }
        void fakedata()
        {
            for(int i = 0; i < 40; i++)
            {
                comboBox1.SelectedIndex = Faker.RandomNumber.Next(0,comboBox1.Items.Count-1);
                Etudiant e = new Etudiant(Faker.Name.FullName(),Convert.ToDateTime(Faker.Identification.DateOfBirth().ToShortDateString()), Faker.RandomNumber.Next(1, 3));
                Etudiant.ajouterEtudiant(e, Convert.ToInt32(comboBox1.SelectedValue));

            }
        }
        private void GsEtudiant_Load(object sender, EventArgs e)
        {
            parent.Visible = false;
            bs.DataSource = Etudiant.afficherEtudiant();
            dataGridView1.DataSource=bs;
            comboBox1.DisplayMember = "nomFl";
            comboBox1.ValueMember = "idFilier";
            comboBox1.DataSource = Filier.afficherFilier();
            textBox1.DataBindings.Add("text", bs, "nom", true);
            numericUpDown1.DataBindings.Add("value", bs, "nivaux", true);
            dateTimePicker1.DataBindings.Add("value", bs, "dateN", true);
            comboBox1.DataBindings.Add("selectedvalue",bs,"idFl",true);
            dataGridView1.Columns["idEt"].Visible = false;
            dataGridView1.Columns["idFl"].Visible = false;
            dataGridView1.Columns["dateN"].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Etudiant.ajouterEtudiant(Convert.ToInt32(numericUpDown1.Value), textBox1.Text, Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()),Convert.ToInt32( comboBox1.SelectedValue));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Etudiant.supprimerEtudiant(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()));

            }
            bs.DataSource = Etudiant.afficherEtudiant();
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

               Etudiant.modifierEtudiant(Convert.ToInt32(numericUpDown1.Value),textBox1.Text,dateTimePicker1.Value, Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()));

            }
            bs.DataSource = Etudiant.afficherEtudiant();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fakedata();
            bs.DataSource = Etudiant.afficherEtudiant();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new EtudiantFind().ShowDialog();
        }

        private void GsEtudiant_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;

        }
    }
}
