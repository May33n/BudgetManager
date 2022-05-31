using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetManager2
{
    public partial class FormNew : Form
    {
        private readonly BudgetManagerEntities budgetManagerEntities;
        private bool isEditMode;
        private Form1 _form1;

        public FormNew(Form1 form1 = null)
        {
            InitializeComponent();
            _form1 = form1;
            budgetManagerEntities = new BudgetManagerEntities();
            lblTitle.Text = "Add new entry";
            isEditMode = false;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        public FormNew(BudgetManager entryToEdit, Form1 form1 = null)
        {
            InitializeComponent();
            _form1 = form1;
            budgetManagerEntities = new BudgetManagerEntities();
            lblTitle.Text = "Edit entry";
            PopulateFields(entryToEdit);
            isEditMode = true;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        public void PopulateFields(BudgetManager entryToEdit)
        {
            lblId.Text = entryToEdit.id.ToString();
            txtBoxName.Text = entryToEdit.Name;
            txtBoxAmount.Text = entryToEdit.Amount.ToString();
            txtBoxNotes.Text = entryToEdit.Notes;
            dt.Value = (DateTime)entryToEdit.Date;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = true;

                if (string.IsNullOrWhiteSpace(txtBoxAmount.Text))
                {
                    isValid = false;
                    MessageBox.Show("Please enter Amount");
                }

                if (isValid)
                {
                    if (isEditMode)
                    {
                        var id = int.Parse(lblId.Text);
                        var entryToEdit = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);
                        entryToEdit.Name = txtBoxName.Text;
                        entryToEdit.Amount = int.Parse(txtBoxAmount.Text);
                        entryToEdit.Notes = txtBoxNotes.Text;
                        entryToEdit.Date = dt.Value;
                    }
                    else
                    {
                        var budgetManager = new BudgetManager();

                        string name = txtBoxName.Text;
                        string notes = txtBoxNotes.Text;
                        var date = dt.Value;
                        int amount = int.Parse(txtBoxAmount.Text);

                        budgetManager.Name = name;
                        budgetManager.Notes = notes;
                        budgetManager.Date = date;
                        budgetManager.Amount = amount;

                        budgetManagerEntities.BudgetManagers.Add(budgetManager);
                    }
                }
                budgetManagerEntities.SaveChanges();
                _form1.PopulateGrid();

                MessageBox.Show("OK");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"chyba { ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            Form1.ReleaseCapture();
            Form1.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
