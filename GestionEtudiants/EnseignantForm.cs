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
    public partial class EnseignantForm : Form
    {
        Form parent;
        int idEns;
        public EnseignantForm(Form parent, int idEns)
        {
            InitializeComponent();
            this.parent = parent;
            this.idEns = idEns;
        }

        private void EnseignantForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            

            dataGridView1.Columns["idEt"].Visible = false;
            dataGridView1.Columns["idMd"].Visible = false;

            parent.Visible = false;

            comboBox2.DisplayMember = "nom";
            comboBox2.ValueMember = "idMd";
            comboBox2.DataSource=Module.afficherModule(idEns);

            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "IdEt";
            comboBox1.DataSource = EtudientGs.afficherEtudiant(Convert.ToInt32(comboBox2.SelectedValue));

           
        }

        private void EnseignantForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));


        }

        private void button3_Click(object sender, EventArgs e)
        {
            EtudientGs.ajouterEtudiantGs(Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(numericUpDown1.Value), Convert.ToDouble(textBox1.Text));
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                EtudientGs.supprimerEtudiantGs(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue));
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));
            textBox1.Text = "";
            numericUpDown1.Value = 0;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                EtudientGs.modifierEtudiantGs(Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(numericUpDown1.Value), Convert.ToDouble(textBox1.Text));
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));
        }
        void fackData()
        {
            for(int i = 0; i < 150; i++)
            {
                comboBox1.SelectedIndex = Faker.RandomNumber.Next(0, comboBox1.Items.Count - 1);
                comboBox2.SelectedIndex = Faker.RandomNumber.Next(0, comboBox2.Items.Count - 1);
                EtudientGs.ajouterEtudiantGs(Convert.ToInt32(comboBox2.SelectedValue), Convert.ToInt32(comboBox1.SelectedValue), Faker.RandomNumber.Next(0,50), Faker.RandomNumber.Next(0,20));
                
            }
            if (radioButton1.Checked)
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsMd(Convert.ToInt32(comboBox2.SelectedValue));
            else
                dataGridView1.DataSource = EtudientGs.afficherEtudiantGsET(Convert.ToInt32(comboBox1.SelectedValue));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString() !="" && dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString() != "")
            {
                comboBox2.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                numericUpDown1.Value = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            fackData();
        }
    }
}
