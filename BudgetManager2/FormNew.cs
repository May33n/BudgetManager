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

        public FormNew()
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
            lblTitle.Text = "Add new entry";
            isEditMode = false;
        }

        public FormNew(BudgetManager entryToEdit)
        {
            InitializeComponent();
            budgetManagerEntities = new BudgetManagerEntities();
            lblTitle.Text = "Edit entry";
            PopulateFields(entryToEdit);
            isEditMode = true;
        }

        private void PopulateFields(BudgetManager entryToEdit)
        {
            lblId.Text = entryToEdit.id.ToString();
            txtBoxName.Text = entryToEdit.Name;
            txtBoxAmount.Text = entryToEdit.Amount.ToString();
            txtBoxNotes.Text = entryToEdit.Notes;
            dt.Value = (DateTime)entryToEdit.Date;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                var id = int.Parse(lblId.Text);
                var entryToEdit = budgetManagerEntities.BudgetManagers.FirstOrDefault(q => q.id == id);
                entryToEdit.Name = txtBoxName.Text;
                entryToEdit.Amount = int.Parse(txtBoxAmount.Text);
                entryToEdit.Notes = txtBoxNotes.Text;
                entryToEdit.Date = dt.Value;
                budgetManagerEntities.SaveChanges();
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
                budgetManagerEntities.SaveChanges();
            }
            
            budgetManagerEntities.SaveChanges();

            MessageBox.Show("OK");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
