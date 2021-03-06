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
    public partial class ModuleFind : Form
    {
        Form parent;
        public ModuleFind(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void ModuleFind_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "nom";
            comboBox1.ValueMember = "idEns";
            comboBox1.DataSource = Enseignant.afficherEnseignnant();

            comboBox2.DisplayMember = "nomFl";
            comboBox2.ValueMember = "idFilier";
            comboBox2.DataSource = Filier.afficherFilier();

            dataGridView1.DataSource = Module.afficherModule();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            panel5.Enabled = checkBox4.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Enabled = checkBox3.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int checkedBoxes = 0;
            bool et = false;
            // Iterate through all of the Controls in your Form
            foreach (Control c in panel1.Controls)
            {
                // If one of the Controls is a CheckBox and it is checked, then
                // increment your count
                if (c is CheckBox && (c as CheckBox).Checked)
                {
                    checkedBoxes++;
                }
            }
            string rq = "";
            if (checkedBoxes == 4)
            {
                rq = String.Format("select * from  Module where nom = '{0}' AND nivaux = {1} AND idEns = {2} AND idFl = {3}", textBox1.Text, Convert.ToUInt32(numericUpDown1.Value),comboBox1.SelectedValue, comboBox2.SelectedValue);
            }
            else if (checkedBoxes < 4 && checkedBoxes >= 2)
            {
                rq = "select * from  Module where";
                if (checkBox1.Checked && !et)
                {
                    rq = String.Format("{0} nivaux ={1}", rq, Convert.ToUInt32(numericUpDown1.Value));
                    et = true;
                }
                else if (checkBox1.Checked)
                    rq = String.Format("{0} And nivaux ={1}", rq, Convert.ToUInt32(numericUpDown1.Value));
                if (checkBox2.Checked && !et)
                {
                    rq = String.Format("{0} idEns ={1}", rq, comboBox1.SelectedValue);
                    et = true;
                }
                else if (checkBox2.Checked)
                    rq = String.Format("{0} And idEns ={1}", rq, comboBox1.SelectedValue);
                if (checkBox3.Checked && !et)
                {
                    rq = String.Format("{0} idFl ={1}", rq, comboBox2.SelectedValue);
                    et = true;
                }
                else if (checkBox3.Checked)
                    rq = String.Format("{0} And idFl ={1}", rq, comboBox2.SelectedValue);
                if (checkBox4.Checked && !et)
                {
                    rq = String.Format("{0} And nom ={1}", rq, textBox1.Text);
                    et = true;
                }
                else if (checkBox4.Checked)
                    rq = String.Format("{0} nom ={1}", rq, textBox1.Text);
            }
            else if (checkedBoxes == 1)
            {
                rq = "select * from  Module where";
                if (checkBox1.Checked)
                {
                    rq = String.Format("{0} nivaux = {1}", rq, Convert.ToUInt32(numericUpDown1.Value));
                }
                if (checkBox2.Checked)
                {
                    rq = String.Format("{0} idEns = {1}", rq, comboBox1.SelectedValue);

                }
                if (checkBox3.Checked)
                {
                    rq = String.Format("{0} idFl = {1}", rq, comboBox2.SelectedValue);

                }
                if (checkBox4.Checked)
                {
                    rq = String.Format("{0} 'nom' = {1}", rq, textBox1.Text);

                }
            }
            else
            {
                rq = "select * from  Module";
            }
            dataGridView1.DataSource = Module.afficherModule(rq);
        }
    }
}
