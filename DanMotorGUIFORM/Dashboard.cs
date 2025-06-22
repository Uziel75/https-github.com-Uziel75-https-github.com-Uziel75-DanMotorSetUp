using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DanMotor.Business;
using DanMotor.Common;
using DanMotor.Data;

namespace DanMotorGUIFORM
{
    public partial class Dashboard : Form
    {
        private MotorService service;
        private string selectedBrand = "";

        public Dashboard()
        {
            InitializeComponent();
            IDataStore store = new DbMotoDataStore();
            service = new MotorService(store);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBoxParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxParts.SelectedItem != null)
            {
                textBoxPart.Text = listBoxParts.SelectedItem.ToString();
            }
        }

        private void btnEditParts_Click(object sender, EventArgs e)
        {
            string model = textBoxModel.Text.Trim();
            string concept = textBoxConcept.Text.Trim();
            string newPart = textBoxPart.Text.Trim();

            if (listBoxParts.SelectedItem == null)
            {
                MessageBox.Show("Please select the part to edit from the list.");
                return;
            }

            string oldPart = listBoxParts.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(selectedBrand) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(concept) || string.IsNullOrWhiteSpace(newPart))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            bool edited = service.EditPart(selectedBrand, model, concept, oldPart, newPart);
            MessageBox.Show(edited ? "Part updated successfully." : "Part not found.");
            LoadParts();
        }


        private void btnDeleteParts_Click(object sender, EventArgs e)
        {
            string model = textBoxModel.Text.Trim();
            string concept = textBoxConcept.Text.Trim();

            if (listBoxParts.SelectedItem == null)
            {
                MessageBox.Show("Please select the part to delete from the list.");
                return;
            }

            string part = listBoxParts.SelectedItem.ToString();

            bool deleted = service.DeletePart(selectedBrand, model, concept, part);
            MessageBox.Show(deleted ? "Part deleted successfully." : "Part not found.");
            LoadParts();
        }

        private void btnAddParts_Click(object sender, EventArgs e)
        {
            string model = textBoxModel.Text.Trim();
            string concept = textBoxConcept.Text.Trim();
            string part = textBoxPart.Text.Trim();

            if (string.IsNullOrWhiteSpace(selectedBrand) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(concept) || string.IsNullOrWhiteSpace(part))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            bool added = service.AddPart(selectedBrand, model, concept, part);
            MessageBox.Show(added ? "Part added successfully." : "Part already exists.");
            LoadParts();
        }


        private void radioButtonYamaha_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonYamaha.Checked)
            {
                selectedBrand = "Yamaha";
                LoadParts();
            }
        }

        private void radioButtonHonda_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHonda.Checked)
            {
                selectedBrand = "Honda";
                LoadParts();
            }
        }

        private void LoadParts()
        {
            if (string.IsNullOrEmpty(selectedBrand)) return;

            string model = textBoxModel.Text.Trim();
            string concept = textBoxConcept.Text.Trim();

            listBoxParts.Items.Clear();
            var parts = service.GetParts(selectedBrand, model, concept);
            foreach (var part in parts)
            {
                listBoxParts.Items.Add(part);
            }
        }

        private void textBoxModel_TextChanged(object sender, EventArgs e)
        {
            LoadParts();
        }

        private void textBoxConcept_TextChanged(object sender, EventArgs e)
        {
            LoadParts();
        }

        private void textBoxPart_TextChanged(object sender, EventArgs e)
        {
            LoadParts();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
