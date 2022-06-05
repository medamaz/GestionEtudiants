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
    public partial class GsEnseignant : Form
    {
        Form parent;
        public GsEnseignant(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void GsEnseignant_Load(object sender, EventArgs e)
        {
            parent.Visible = false; 
            dataGridView1.DataSource = Enseignant.afficherEnseignnant();
            dataGridView1.Columns["idEns"].Visible = false;
        }

        private void GsEnseignant_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Enseignant.ajouterEnseignant(textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = Enseignant.afficherEnseignnant();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                Enseignant.supprimerEnseignant(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()));

            }
            dataGridView1.DataSource = Enseignant.afficherEnseignnant();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Enseignant es = new Enseignant(textBox1.Text, textBox2.Text);
                Enseignant.modifierEnseignant(Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value), es);
                es = null;
            }
            dataGridView1.DataSource = Enseignant.afficherEnseignnant();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            DataGridView dt = new DataGridView();
            dt.DataSource = Enseignant.afficherEnseignnant(textBox1.Text, textBox2.Text);
            dt.Dock= DockStyle.Fill;
            f.Controls.Add(dt);
            f.ShowDialog();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                Enseignant es = new Enseignant(Faker.Name.FullName(), Faker.Name.Suffix());
                Enseignant.ajouterEnseignant(es);
                es = null;
            }
            dataGridView1.DataSource = Enseignant.afficherEnseignnant();
        }
    }
}
